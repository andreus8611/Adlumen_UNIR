'use strict';
adlumenApp.controller('presupuestoCtrl',
    [
        '$scope', '$uibModal', '$uibModalInstance', 'idProyecto', 'donantesAPI', 'usuariosAPI', 'partidasGastosAPI', 'proyectoPresupuestoAPI', 'translationService', 'languageService',
        function ($scope, $uibModal, $uibModalInstance, idProyecto, donantesAPI, usuariosAPI, partidasGastosAPI, proyectoPresupuestoAPI, translationService, languageService) {

            var localidusuario = 0;

            $scope.$watch('bdUser', function (newValue, oldValue) {

                localidusuario = newValue.idLocal;

            });

            $scope.idProyecto = idProyecto;
            $scope.alerts = [];
            $scope.showAlert = true;

            $scope.tabs = [];
            $scope.tabSelected = 0;

            $scope.editMode = false;
            $scope.selectedProyectoDonante = null;
            $scope.selectedDistribucion = null;
            $scope.selectedPresupuesto = null;
            $scope.selectedRecurso = null;
            $scope.selectedDonacion = null;
            $scope.selectedCalendarioDonacion = null;
            $scope.selectedDonante = {idDonante: 0};
            $scope.flatDonacionesDonante = [];

            $scope.popup2 = {opened: false};

            $scope.open2 = function () {
                $scope.popup2.opened = true;
            };

            //Load services
            donantesAPI($scope);
            usuariosAPI($scope);
            partidasGastosAPI($scope);

            //Tabs
            $scope.loadTabs = function () {
                var tmpIndex = 1;
                $scope.tabs = [];

                $scope.tabs.push({ index: tmpIndex++, name: 'REGISTRO_DONANTES', disabled: false, translate: true });
                $scope.tabs.push({ index: tmpIndex++, name: 'PRESUPUESTO_PROYECTO', disabled: false, translate: true });
                $scope.tabs.push({ index: tmpIndex++, name: 'PRESUPUESTO_OBJETIVOS', disabled: false, translate: true });
                $scope.tabs.push({ index: tmpIndex++, name: 'RECURSOS_ACTIVIDADES', disabled: false, translate: true });
                $scope.tabs.push({ index: tmpIndex++, name: 'DISTRIBUCION_DONANTES', disabled: false, translate: true });
                $scope.tabs.push({ index: tmpIndex++, name: 'CALENDARIO_DESEMBOLSOS', disabled: false, translate: true });
            }

            $scope.loadData = function () {
                $scope.loadTabs();

                proyectoPresupuestoAPI.getProyectoPresupuesto($scope).then(
                    function addtoScope(presupuestoData) {
                        $scope.presupuestoData = presupuestoData;

                        var orderedBudgets = _.filter($scope.presupuestoData.flatPresupuesto, function (budget) { return budget.objetivo.idPadre === 0 });

                        var cascadeObjectives = _.where($scope.presupuestoData.flatObjetivos, { idPadre: 0 });

                        $scope.childs = initObjectives($scope.presupuestoData.flatPresupuesto, orderedBudgets);

                        _.each($scope.presupuestoData.flatObjetivos, function (element, index) {
                            $scope.presupuestoData.flatObjetivos[index].pendientePresupuesto = $scope.presupuestoData.flatObjetivos[index].totalPresupuesto - $scope.presupuestoData.flatObjetivos[index].totalDistribuidoRecursos;
                        });

                        $scope.cascadeObjectives = initObjectives($scope.presupuestoData.flatObjetivos, cascadeObjectives);

                        if ($scope.selectedDonante.idDonante !== 0) {
                            $scope.getDonacionesPorDonante();
                        }
                    }
                );
            };

            $scope.loadData();
            
            //validate if the objectives has childs

            $scope.hasChilds = function (child) {
                var value = false;

                if ((_.has(child, "childs"))) {
                    value = true;
                }

                return value;
            }

            //validate the sums of objectives childs and it has to be the same amount of the parent objective, Ernesto Duarte

            $scope.validateSum = function (child) {
                

                var value = false;

                var sum = parseFloat("0");

                if ($scope.hasChilds(child)) {

                    _.each(child.childs, function (_child) {

                        if (_child.presupuesto === null) {
                            sum += parseFloat("0");
                        } else {
                            sum += parseFloat(_child.presupuesto.monto);
                        }
                        
                    });

                    if (child.presupuesto !== null && parseFloat(child.presupuesto.monto) !== sum) {

                        value = true;
                    }

                }

                return value;
            }

            //do it by Ernesto Duarte, order the objectives by codigo

            var initObjectives = function (budgets, array) {

                _.each(budgets, function (objective, index) {

                    //we get the childs of the objective

                    var childs = _.sortBy(_.filter(budgets, function (budget) { return budget.objetivo.idPadre === objective.idObjetivo }),
                        function (_budget) {
                            return parseInt(_budget.codigo.replace(".",""))
                        });

                    //if childs is not empty (this mean that the objective has childs) 
                    //then we call the function where we will asign the childs objectives to his parents objectives
                    
                    if (!_.isEmpty(childs)) {
                        setChildNodes(array, objective, childs);
                    }

                });

                return array;

            };

            var setChildNodes = function (array, objective, childs) {

                var value = false;

                //check if the array object is an array

                if (_.isArray(array)) {

                    //find the object of the array who will have the childs objectives

                    var filteredObjective = _.find(array, function(item) { return item.idObjetivo === objective.idObjetivo });

                    //check if the filteredObjective is undefined, means that the objective is not in this node level

                    if (_.isUndefined(filteredObjective)) {
                        //search the objective parent of the childs in the next node level

                        _.each(array, function (item) {
                            //check if the object already have childs
                            if ($scope.hasChilds(item)) {
                                //if it does then call setChildNodes to search in the next level
                                if (setChildNodes(item.childs, objective, childs)) {
                                    return;
                                }
                            }
                        });
                    }
                        //if the objective is in this level then asign to the parent objective his childs and set the value to true to returned it
                    else {
                        //we identify the index of the parent objective and add his childs
                        array[_.indexOf(array, filteredObjective)].childs = childs;
                        //set the value to return to true
                        value = true;
                    }


                }

                return value;

            };

            $scope.close = function () {
                $uibModalInstance.close();
            };

            //Edit functions
            $scope.Edit = function () {
                $scope.alerts = [];

                $scope.editMode = true;
                for (var i = 0; i < $scope.tabs.length ; i++) {
                    if (i == $scope.tabSelected) {
                        $scope.tabs[i].disabled = false;
                    } else {
                        $scope.tabs[i].disabled = true;
                    }
                }
            }

            $scope.CancelEdit = function() {
                $scope.originalIdDonante = null;
                $scope.editMode = false;
                $scope.FinishEdit();
                $scope.loadData();
            }

            $scope.FinishEdit = function() {
                $scope.originalIdDonante = null;
                $scope.selectedProyectoDonante = null;
                $scope.selectedDistribucion = null;
                $scope.selectedPresupuesto = null;
                $scope.selectedRecurso = null;
                $scope.selectedDonacion = null;
                $scope.selectedCalendarioDonacion = null;
                
                for (var i = 0; i < $scope.tabs.length ; i++) {
                    $scope.tabs[i].disabled = false;
                }
            }

            //Proyecto Donante
            $scope.getProyectoDonanteTemplate = function (proyectoDonante) {
                if ($scope.selectedProyectoDonante &&
                    proyectoDonante.idProyecto === $scope.selectedProyectoDonante.idProyecto &&
                    proyectoDonante.$id === $scope.selectedProyectoDonante.$id) return 'editProyectoDonanteTemplate';
                else return 'displayProyectoDonanteTemplate';
            };

            $scope.getNewProyectoDonanteTemplate = function () {
                if ($scope.selectedProyectoDonante && $scope.selectedProyectoDonante.newProyectoDonante) return 'editProyectoDonanteTemplate';
                else return null;
            };

            $scope.editProyectoDonante = function() {
                $scope.originalIdDonante = this.proyectoDonante.idDonante
                $scope.selectedProyectoDonante = angular.copy(this.proyectoDonante);
                $scope.editMode = true;
                $scope.Edit();
            };

            $scope.crearNuevoProyectoDonante = function () {
                $scope.selectedProyectoDonante = { idProyecto: $scope.idProyecto, newProyectoDonante: true }
                $scope.editMode = true;
                $scope.Edit();
            }

            $scope.filterSponsor = function(item) {
                if ($scope.selectedProyectoDonante && $scope.selectedProyectoDonante.idDonante == item.idDonante) {
                    return true;
                }
                var found = _.findWhere($scope.presupuestoData.proyectoDonantes, { idDonante: item.idDonante });
                return found == null;
            }

            $scope.SaveProyectoDonante = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.selectedProyectoDonante.newProyectoDonante) $scope.selectedProyectoDonante.action = "addProyectoDonante";
                    else $scope.selectedProyectoDonante.action = "modifyProyectoDonante";
                    $scope.selectedProyectoDonante.userId = localidusuario;

                    $scope.selectedProyectoDonante.originalIdDonante = $scope.originalIdDonante;
                    var postProyecto = proyectoPresupuestoAPI.getRestAll();
                    postProyecto.post($scope.selectedProyectoDonante).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_PROYECTO_GUARDADO"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.loadData(true);
                        $scope.editMode = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            };

            $scope.deleteProyectoDonante = function () {
                $scope.confirmDelete($scope.translation["BORRAR_REGISTRO_DONANTE_CONFIRMACION"], 'proyectoDonante', this.proyectoDonante);
            }

            $scope.deleteProyectoDonanteData = function (item) {
                $scope.alerts = [];

                $scope.selectedProyectoDonante = angular.copy(item);

                var areErrors = $scope.validate();

                if (!areErrors) {
                    $scope.selectedProyectoDonante.action = "deleteProyectoDonante";
                    $scope.selectedProyectoDonante.userId = localidusuario;

                    var postProyecto = proyectoPresupuestoAPI.getRestAll();
                    postProyecto.post($scope.selectedProyectoDonante).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_PROYECTO_GUARDADO"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.loadData(true);
                        $scope.editMode = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            }

            //Distribucion
            $scope.getDistribucionTemplate = function (distribucion) {
                if ($scope.selectedDistribucion && distribucion.idTipo === $scope.selectedDistribucion.idTipo) return 'editDistribucionTemplate';
                else return 'displayDistribucionTemplate';
            };

            $scope.editDistribucion = function () {
                $scope.selectedDistribucion = angular.copy(this.distribucion);
                $scope.editMode = true;
                $scope.Edit();
            };

            $scope.SaveDistribucion = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    $scope.selectedDistribucion.action = "modifyDistribucion";
                    $scope.selectedDistribucion.userId = localidusuario;

                    var postProyecto = proyectoPresupuestoAPI.getRestAll();
                    postProyecto.post($scope.selectedDistribucion).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_PROYECTO_GUARDADO"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.loadData(true);
                        $scope.editMode = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            };

            //Presupuesto
            $scope.editPresupuesto = function (presupuesto) {                
                $scope.selectedPresupuesto = presupuesto;
                $scope.Edit();
            }

            $scope.getPresupuestoTemplate = function (presupuesto) {
                if ($scope.selectedPresupuesto && presupuesto.idObjetivo === $scope.selectedPresupuesto.idObjetivo) return 'editPresupuesto';
                else return 'displayPresupuesto';
            }

            $scope.SavePresupuesto = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if (_.isUndefined($scope.selectedPresupuesto.presupuesto.idPresupuesto)) $scope.selectedPresupuesto.action = "addPresupuesto";
                    else $scope.selectedPresupuesto.action = "modifyPresupuesto";
                    $scope.selectedPresupuesto.idTipoPresupuesto = 1;
                    $scope.selectedPresupuesto.userId = localidusuario;

                    var postProyecto = proyectoPresupuestoAPI.getRestAll();
                    postProyecto.post($scope.selectedPresupuesto).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_PROYECTO_GUARDADO"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.loadData(true);
                        $scope.editMode = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            };

            //Recursos
            $scope.getRecursosTemplate = function (recurso) {
                if ($scope.selectedRecurso && recurso.idRecurso === $scope.selectedRecurso.idRecurso) return 'editRecursosTemplate';
                else return 'displayRecursosTemplate';
            }

            $scope.getNewRecursoTemplate = function (objetivo) {
                if ($scope.selectedRecurso && $scope.selectedRecurso.idRecurso === 0 &&
                    $scope.selectedRecurso.idObjetivo === objetivo.idObjetivo) return 'editRecursosTemplate';
                else return null;
            };

            $scope.editRecurso = function () {
                $scope.selectedRecurso = angular.copy(this.recurso);
                $scope.selectedObjetivo = this.objetivo;
                $scope.Edit();
            }

            $scope.crearNuevoRecurso = function (objetivo) {
                $scope.selectedRecurso = { idObjetivo: objetivo.idObjetivo, idRecurso: 0, tipo: "Fisico", contrapartida: 0 }
                $scope.selectedObjetivo = objetivo;
                $scope.editMode = true;
                $scope.Edit();
            }

            $scope.setAportePrograma = function () {
                var valor = 0;
                if ($scope.selectedRecurso) {
                    if ($scope.selectedRecurso.cantidad && $scope.selectedRecurso.valorUnitario) {
                        valor = parseFloat($scope.selectedRecurso.cantidad) * parseFloat($scope.selectedRecurso.valorUnitario);
                    }
                    if ($scope.selectedRecurso.contrapartida) {
                        valor = valor - parseFloat($scope.selectedRecurso.contrapartida);
                    }
                }
                $scope.selectedRecurso.aporteprograma = valor;
            }

            $scope.SaveRecurso = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.selectedRecurso.idRecurso === 0) $scope.selectedRecurso.action = "addRecurso";
                    else $scope.selectedRecurso.action = "modifyRecurso";
                    $scope.selectedRecurso.userId = localidusuario;

                    var postProyecto = proyectoPresupuestoAPI.getRestAll();
                    postProyecto.post($scope.selectedRecurso).then(
                        function() {
                            addAlert('success', $scope.translation["MENSAJE_PROYECTO_GUARDADO"], true);
                            $scope.saved = true;
                            $scope.FinishEdit();
                            $scope.loadData(true);
                            $scope.editMode = false;
                        },
                        function() {
                            addAlert('danger', $scope.translation["ERROR_GUARDADO"]);
                        }
                    );

                }
            };

            $scope.deleteRecurso = function () {
                $scope.confirmDelete($scope.translation["BORRAR_RECURSO_CONFIRMACION"], 'recurso', this.recurso);
            }

            $scope.deleteRecursoData = function (item) {
                $scope.alerts = [];

                $scope.selectedRecurso = angular.copy(item);

                var areErrors = $scope.validate();

                if (!areErrors) {
                    $scope.selectedRecurso.action = "deleteRecurso";
                    $scope.selectedRecurso.userId = localidusuario;

                    var postProyecto = proyectoPresupuestoAPI.getRestAll();
                    postProyecto.post($scope.selectedRecurso).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_PROYECTO_GUARDADO"], fixed);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.loadData(true);
                        $scope.editMode = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            }

            $scope.getObjectiveTotalDonated = function (idObjetivo) {

                var totalDonadoxObjetivo = parseFloat(0);

                _.each(_.groupBy($scope.presupuestoData.flatDonaciones, function (donacion) { return donacion.idObjetivo })[idObjetivo],
                    function (donacion) {
                        totalDonadoxObjetivo += donacion.totalDonaciones;
                    });

                return totalDonadoxObjetivo;

            }

            //Distribución Donaciones
            $scope.getDonacionesPorDonante = function () {

                var proyectoDonante = _.findWhere($scope.presupuestoData.proyectoDonantes, { idDonante: $scope.selectedDonante.idDonante });

                if (!_.isUndefined(proyectoDonante)) {
                    $scope.totalDonadoDistribucion = proyectoDonante.monto;
                }
                else {
                    $scope.totalDonadoDistribucion = 0;
                    $scope.totalDonacionesDistribucion = 0;
                    return;
                }

                $scope.totalDonacionesDistribucion = parseFloat(0);
                var donaciones = [];
                var maxObjetivoClase = _.max($scope.presupuestoData.flatDonaciones, function (_maxObjetivoClase) { return _maxObjetivoClase.objetivoProyecto.idObjetivoClase; });
                if ($scope.selectedDonante.idDonante !== 0) {
                    donaciones = _.filter($scope.presupuestoData.flatDonaciones, function (_donacion) {
                        return _donacion.idDonante === $scope.selectedDonante.idDonante && _donacion.objetivoProyecto.idObjetivoClase === maxObjetivoClase.objetivoProyecto.idObjetivoClase;
                    });
                }

                _.each(donaciones, function (donacion, index) {
                    donaciones[index].pendiente = donacion.totalPresupuesto - donacion.totalDonaciones;
                    $scope.totalDonacionesDistribucion += donacion.totalDonaciones;
                });

                return donaciones;
            }

            $scope.editPresupuestoDonacion = function () {
                $scope.selectedDonacion = angular.copy(this.donacionPresupuesto);
                $scope.Edit();
            }

            $scope.crearNuevoPresupuestoDonacion = function () {
                $scope.selectedDonacion = { idPresupuesto: 0, idTipoPresupuesto: 6, idObjetivo: this.donacion.idObjetivo, idProyecto: $scope.idProyecto, idDonante: $scope.selectedDonante.idDonante };
                $scope.Edit();
            }

            $scope.getPresupuestoDonacionesTemplate = function (donacionPresupuesto) {
                if ($scope.selectedDonacion && donacionPresupuesto.idPresupuesto === $scope.selectedDonacion.idPresupuesto) return 'editDonacionTemplate';
                else return 'displayDonacionTemplate';
            }

            $scope.getNewPresupuestoDonacionesTemplate = function (donacion) {
                if ($scope.selectedDonacion && $scope.selectedDonacion.idPresupuesto === 0 &&
                    $scope.selectedDonacion.idObjetivo === donacion.idObjetivo) return 'editDonacionTemplate';
                else return null;
            }

            $scope.SavePresupuestoDonacion = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if (!$scope.selectedDonacion.idPresupuesto) $scope.selectedDonacion.action = "addPresupuesto";
                    else $scope.selectedDonacion.action = "modifyPresupuesto";
                    $scope.selectedDonacion.userId = localidusuario;

                    var postProyecto = proyectoPresupuestoAPI.getRestAll();
                    
                    var _selectedDonacion = { monto: $scope.selectedDonacion.monto, idProyecto: $scope.selectedDonacion.idProyecto };
                    $scope.selectedDonacion.presupuesto = { monto: _selectedDonacion.monto };
                    $scope.selectedDonacion.objetivoProyecto = { idProyecto: _selectedDonacion.idProyecto };

                    postProyecto.post($scope.selectedDonacion).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_PROYECTO_GUARDADO"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.loadData(true);
                        $scope.editMode = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            };

            $scope.deletePresupuestoDonacion = function () {
                $scope.alerts = [];

                $scope.selectedDonacion = angular.copy(this.donacionPresupuesto);

                var areErrors = $scope.validate();

                if (!areErrors) {
                    $scope.selectedDonacion.action = "deletePresupuesto";
                    $scope.selectedDonacion.userId = localidusuario;

                    var postProyecto = proyectoPresupuestoAPI.getRestAll();
                    postProyecto.post($scope.selectedDonacion).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_PROYECTO_GUARDADO"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.loadData(true);
                        $scope.editMode = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            };

            //Calendario Donaciones

            $scope.open = true;

            $scope.getCalendarioDonaciones = function (donante) {
                var calendarioPorDonante = _.where($scope.presupuestoData.calendarioDonaciones, { idDonante: donante.idDonante });
                return calendarioPorDonante;
            }

            $scope.getPresupuestoDonante = function (donante) {
                var presupuestoDonante = _.where($scope.presupuestoData.proyectoDonantes, { idDonante: donante.idDonante });
                var totalPresupuesto = 0;
                for (var i = 0; i < presupuestoDonante.length; i++) {
                    totalPresupuesto += presupuestoDonante[i].monto;
                }
                return totalPresupuesto;
            }

            $scope.getProgramadoDonante = function (donante) {
                var programadoDonante = $scope.getCalendarioDonaciones(donante);
                var totalProgramado = 0;
                for (var i = 0; i < programadoDonante.length; i++) {
                    totalProgramado += programadoDonante[i].monto;
                }
                return totalProgramado;
            }

            $scope.getPendienteDonante = function (donante) {

                var diferencia = $scope.getPresupuestoDonante(donante) - $scope.getProgramadoDonante(donante);

                return diferencia >= 0 ? diferencia : 0;
            }

            $scope.getCalendarioDonacionesTemplate = function (calendarioDonaciones) {
                if ($scope.selectedCalendarioDonacion && calendarioDonaciones.idDonacion === $scope.selectedCalendarioDonacion.idDonacion) return 'editCalendarioDonacionesTemplate';
                else return 'displayCalendarioDonacionesTemplate';
            }

            $scope.getNewCalendarioDonacionesTemplate = function (donante) {
                if ($scope.selectedCalendarioDonacion && $scope.selectedCalendarioDonacion.idDonacion === 0 &&
                    $scope.selectedCalendarioDonacion.idDonante === donante.idDonante) return 'editCalendarioDonacionesTemplate';
                else return null;
            }

            $scope.editCalendarioDonaciones = function () {
                $scope.selectedCalendarioDonacion = angular.copy(this.calendarioDonaciones);
                $scope.Edit();
            }

            $scope.crearNuevoCalendarioDonacion = function () {
                $scope.selectedCalendarioDonacion = { idDonante: this.donante.idDonante, idProyecto: $scope.idProyecto, idDonacion: 0 }
                $scope.editMode = true;
                $scope.Edit();
            }

            $scope.SaveCalendarioDonacion = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.selectedCalendarioDonacion.idDonacion === 0) $scope.selectedCalendarioDonacion.action = "addCalendarioDonacion";
                    else $scope.selectedCalendarioDonacion.action = "modifyCalendarioDonacion";
                    $scope.selectedCalendarioDonacion.userId = localidusuario;

                    var postProyecto = proyectoPresupuestoAPI.getRestAll();
                    postProyecto.post($scope.selectedCalendarioDonacion).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_PROYECTO_GUARDADO"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.loadData(true);
                        $scope.editMode = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            }

            $scope.deleteCalendarioDonaciones = function () {
                $scope.confirmDelete($scope.translation["BORRAR_CALENDARIO_DONACION_CONFIRMACION"], 'calendarioDonacion', this.calendarioDonaciones);
            }

            $scope.deleteCalendarioDonacionesData = function (item) {
                $scope.alerts = [];

                $scope.selectedCalendarioDonacion = angular.copy(item);

                var areErrors = $scope.validate();

                if (!areErrors) {
                    $scope.selectedCalendarioDonacion.action = "deleteCalendarioDonacion";
                    $scope.selectedCalendarioDonacion.userId = localidusuario;

                    var postProyecto = proyectoPresupuestoAPI.getRestAll();
                    postProyecto.post($scope.selectedCalendarioDonacion).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_PROYECTO_GUARDADO"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.loadData(true);
                        $scope.editMode = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            }

            //Validate
            $scope.validate = function () {
                var areErrors = false;

                if ($scope.tabSelected === 0) { //Presupuesto donante
                    if (!$scope.selectedProyectoDonante.idDonante || !$scope.selectedProyectoDonante.idUsuarioResponsable ||
                        (!$scope.selectedProyectoDonante.monto && $scope.selectedProyectoDonante.monto != 0)) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_CAMPOS_VACIOS"]);
                    } else if ($scope.selectedProyectoDonante.monto < 0) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_MONTO_REQUERIDO"]);
                    }
                }
                if ($scope.tabSelected === 1) { //Distribucion
                    if (!$scope.selectedDistribucion.monto && $scope.selectedDistribucion.monto != 0) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_CAMPOS_VACIOS"]);
                    } else if ($scope.selectedDistribucion.monto < 0) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_MONTO_REQUERIDO"]);
                    }
                }
                if ($scope.tabSelected === 2) { //Distribucion
                    if (!$scope.selectedPresupuesto.presupuesto.monto && $scope.selectedDistribucion.presupuesto.monto != 0) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_CAMPOS_VACIOS"]);
                    } else if ($scope.selectedPresupuesto.presupuesto.monto < 0) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_MONTO_REQUERIDO"]);
                    }
                }
                if ($scope.tabSelected === 3) { //Recursos
                    if (!$scope.selectedRecurso.descripcion || !$scope.selectedRecurso.idpartidagasto ||
                        !$scope.selectedRecurso.cantidad || !$scope.selectedRecurso.valorUnitario ||
                        (!$scope.selectedRecurso.contrapartida && $scope.selectedRecurso.contrapartida != 0)) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_CAMPOS_VACIOS"]);
                    } else if ($scope.selectedRecurso.cantidad < 0 || $scope.selectedRecurso.valorUnitario < 0 || $scope.selectedRecurso.contrapartida < 0) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_MONTO_REQUERIDO"]);
                    } else
                    {
                        if ($scope.selectedObjetivo){
                            var totalOtrosRecursos = 0;
                            for (var i = 0; i < $scope.selectedObjetivo.recursos.length; i++) {
                                if ($scope.selectedObjetivo.recursos[i].idRecurso != $scope.selectedRecurso.idRecurso) {
                                    totalOtrosRecursos += $scope.selectedObjetivo.recursos[i].aporteprograma;
                                }
                            }
                            if ((totalOtrosRecursos + $scope.selectedRecurso.aporteprograma) > $scope.selectedObjetivo.totalPresupuesto) {
                                areErrors = true;
                                addAlert('danger', $scope.translation["ERROR_RECURSOS_SOBREPASA_PRESUPUESTO"]);
                            }
                        }
                    }
                }
                if ($scope.tabSelected === 4) { //Presupuesto Donación
                    if (!$scope.selectedDonacion.monto && $scope.selectedDonacion.monto != 0) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_CAMPOS_VACIOS"]);
                    } else if ($scope.selectedDonacion.monto < 0) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_MONTO_REQUERIDO"]);
                    }
                }
                if ($scope.tabSelected === 5) { //Calendario donaciones
                    if (!$scope.selectedCalendarioDonacion.monto || !$scope.selectedCalendarioDonacion.fechaProgramada) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_CAMPOS_VACIOS"]);
                    }
                }

                return areErrors;
            }

            //Tabs functions
            $scope.getTabHeader = function (i) {
                var header = "";
                if ($scope.tabs && $scope.translation && $scope.tabs[i]) {
                    if ($scope.tabs[i].translate) {
                        header = $scope.tabs[i].index + " - " + $scope.translation[$scope.tabs[i].name];
                    } else {
                        header = $scope.tabs[i].index + " - " + $scope.tabs[i].name;
                    }
                }
                return header;
            }

            $scope.setTab = function (i) {
                if (!$scope.editMode) {
                    $scope.tabSelected = i;
                }
            };

            //Confirmation
            $scope.confirmDelete = function (mensaje, sender, item) {
                $scope.mensajeConfirmacion = mensaje;
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: 'modalConfirmation.html',
                    controller: 'modalConfirmationInstanceCtrl',
                    size: 'sm',
                    resolve: {
                        mensaje: function () {
                            return $scope.mensajeConfirmacion;
                        }
                    }
                });

                modalInstance.result.then(function (response) {
                    //Yes
                    if (sender == 'proyectoDonante') { $scope.deleteProyectoDonanteData(item); }
                    if (sender == 'recurso') { $scope.deleteRecursoData(item); }
                    if (sender == 'calendarioDonacion') { $scope.deleteCalendarioDonacionesData(item); }
                }, function () {
                    //No
                });
            };

            var addAlert = function(varType, varMsg, fixed) {
                if (fixed) {
                    $('.budget-alerts').closest('.modal-dialog').css('transform', 'none');
                }
                $scope.alerts.push({ type: varType, msg: varMsg, fixed: fixed });
                $scope.showAlert = true;
            };

            //Translation
            //Run translation if selected language changes
            $scope.translate = function () {
                translationService.getTranslation($scope, $scope.selectedLanguage);
            };

            //Init
            $scope.selectedLanguage = languageService.get();
            $scope.translate();

            $scope.closeAlert = function(index) {
                $scope.alerts.splice(index, 1);
            }
        }
    ]
);