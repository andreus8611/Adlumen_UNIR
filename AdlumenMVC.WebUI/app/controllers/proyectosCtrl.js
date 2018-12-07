'use strict';
adlumenApp.controller('proyectosCtrl',
    [
        '$scope', '$uibModal', '$stateParams', 'proyectoAPI', 'monedaAPI', 'objetivosClaseAPI', 'usuariosAPI', 'empresasAPI', 'empleadosAPI', 'FileUploadService', 'uiGmapGoogleMapApi', 'translationService', 'languageService', '$window', '$log', 'nivelaceptacionAPI', 'localStorageService', 'globalAlerts',
        function($scope, $uibModal, $stateParams, proyectoAPI, monedaAPI, objetivosClaseAPI, usuariosAPI, empresasAPI, empleadosAPI, FileUploadService, uiGmapGoogleMapApi, translationService, languageService, $window, $log, nivelaceptacionAPI, localStorageService, globalAlerts) {

            //get all projects
            var localidusuario = 0;
            $scope.proyectosparams = { idCliente: 0, idProyecto: 0 };
            $scope.proyectosparams.idProyecto = $stateParams.idProyecto;
            
            $scope.$watchGroup(['bdUser', 'bdClient'], function (newValue, oldValue) {
                if (!_.isUndefined(newValue[0])) {
                    localidusuario = newValue[0].idLocal;

                }

                if (!_.isUndefined(newValue[1])) {
                    $scope.proyectosparams.idCliente = newValue[1].id;
                    proyectoAPI.getProjectsByClient(newValue[1].id).getList().then(function(results) {
                        var projects = filterProjects(results, $stateParams.status);
                        $scope.projects = projects;
                    });
                    if (!_.isUndefined($scope.proyecto)) {
                        $scope.proyecto.proyecto.idCliente = newValue[1].id;
                    }
                }
            });

            var filterProjects = function(projects, status) {
                if (!status)
                    return projects;

                return _.filter(projects, function(project) {
                    return project.idEstado == status;
                });
            }

            //Added by Cristina

            $scope.setFlatObjetivos = function () {
                $scope.proyecto.flatObjetivos = [];
                if ($scope.proyecto && $scope.proyecto.objetivos) {
                    for (var i = 0; i < $scope.proyecto.objetivos.length; i++) {
                        $scope.getFlatObjects($scope.proyecto.objetivos[i]);
                    }
                }
            };

            $scope.getFlatObjects = function (objetivo) {
                $scope.proyecto.flatObjetivos.push(objetivo);
                for (var j = 0; j < objetivo.children.length; j++) {
                    $scope.getFlatObjects(objetivo.children[j]);
                }
            };

            $scope.alerts = [];
            $scope.alertsObjetivos = [];
            $scope.showAlert = false;
            $scope.showAlertObjetivos = false;
            $scope.saved = false;
            $scope.newProject = $scope.proyectosparams.idProyecto === 0 ? true : false;
            $scope.newObjetivo = false;

            $scope.tabs = [];
            $scope.tabSelected = 0;
            $scope.objetivoClaseIdSelected = 0;
            $scope.editMode = $scope.proyectosparams.idProyecto === 0 ? true : false;

            //added by Ernesto Duarte

            nivelaceptacionAPI.getAll().then(function (response) {
                $scope.nivelesAceptacion = response.data;
            });


            $scope.editModeSupuesto = false;

            $scope.selectedObjetivo = null;
            $scope.selectedIndicator = null;
            $scope.selectedSupuesto = null;
            $scope.selectedInforme = null;

            $scope.flatResultados = [];

            $scope.datePicker = { opened : false }

            $scope.open = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();

                $scope.datePicker.opened = true;
            };

            $scope.datePicker1 = { opened : false }

            $scope.open1 = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();

                $scope.datePicker1.opened = true;
            };

            $scope.loadTabs = function () {
                var tmpIndex = 1;
                $scope.tabs = [];

                $scope.tabs.push({ index: tmpIndex++, name: 'GENERAL', disabled: false, translate: true, template: 'app/templates/proyectos/generalView.html' });
                $scope.tabs.push({ index: tmpIndex++, name: 'GEOREFERENCIA', disabled: false, translate: true, template: 'app/templates/proyectos/GeoreferenciaView.html' });
                $scope.tabs.push({ index: tmpIndex++, name: 'PLANTEAMIENTO', disabled: false, translate: true, template: 'app/templates/proyectos/problemaView.html' });
                $scope.tabs.push({ index: tmpIndex++, name: 'OBJETIVOS', disabled: false, translate: true, template: ''});
                $scope.tabs.push({ index: tmpIndex++, name: 'MATRIZ', disabled: false, translate: true, template: ''});
                $scope.tabs.push({ index: tmpIndex++, name: 'CALENDARIO_ACTIVIDADES', disabled: false, translate: true, template: ''});
                $scope.tabs.push({ index: tmpIndex++, name: 'CALENDARIO_INDICADORES', disabled: false, translate: true, template: ''});
                $scope.tabs.push({ index: tmpIndex++, name: 'CALENDARIO_INFORMES', disabled: false, translate: true, template: ''});
                $scope.tabs.push({ index: tmpIndex++, name: 'PONDERACION_COMPONENTES', disabled: false, translate: true, template: ''});
                $scope.tabs.push({ index: tmpIndex++, name: 'PONDERACION_INDICADORES', disabled: false, translate: true, template: ''});
                $scope.tabs.push({ index: tmpIndex++, name: 'PLANES_CONTINGENCIA', disabled: false, translate: true, template: ''});
                $scope.tabs.push({ index: tmpIndex++, name: 'PLANES_PRESUPUESTO', disabled: false, translate: true, template: ''});
            }

            //Load services
            usuariosAPI($scope);
            empresasAPI($scope);
            monedaAPI($scope);
            empleadosAPI($scope);

            $scope.loadData = function () {
                objetivosClaseAPI.getObjetivosClases().then(
                    function addtoScope(objetivosclases) {
                        $scope.objetivosclases = objetivosclases;
                        $scope.lastObjetivoClase = _.max($scope.objetivosclases, function (clase) { return clase.idObjetivoClase; });
                        if ($scope.tabs.length === 0) $scope.loadTabs();
                    }
                );

                proyectoAPI.getParents().then(
                    function addtoScope(proyectos) {
                        $scope.parents = _.filter(proyectos, function (_proyecto) {
                            return _proyecto.idProyecto != $scope.proyectosparams.idProyecto;
                        });;
                    }
                );
            };

            $scope.loadData();

            //Edit functions
            $scope.Edit = function () {
                $scope.alerts = [];
                $scope.alertsObjetivos = [];
                
                $scope.editMode = true;
                for (var i = 0; i < $scope.tabs.length ; i++) {
                    if (i == $scope.tabSelected) {
                        $scope.tabs[i].disabled = false;
                    } else {
                        $scope.tabs[i].disabled = true;
                    }
                }
            }

            $scope.CancelEdit = function () {
                $scope.editMode = false;
                $scope.FinishEdit();
                if (!$scope.newProject) $scope.showProyectoDetails(false);
                if ($scope.newProject) $scope.close();
                if ($scope.newObjetivo) $scope.selectedObjetivo = null;
            }

            $scope.FinishEdit = function () {
                $scope.selectedObjetivo = null;
                $scope.selectedIndicator = null;
                $scope.selectedSupuesto = null;
                $scope.selectedInforme = null;
                
                for (var i = 0; i < $scope.tabs.length ; i++) {
                    $scope.tabs[i].disabled = false;
                }
            }

            //Create nuevo proyecto
            $scope.crearNuevoProyecto = function () {
                $scope.newProject = true; 
                $scope.tabSelected = 0;
                $scope.proyecto = {};
                $scope.proyecto.idProyecto = 0;
                $scope.proyecto.proyecto = { idCliente: $scope.proyectosparams.idCliente, idTipo: 2, idProyecto: 0, logo: null };
                //$scope.loadTabs();
                $scope.Edit();
                $scope.$state.go('base.project', { idProyecto: 0 });
                $scope.editMode = true;
            }

            //Edit selected proyecto

            $scope.gotoProject = function (idProject) {
                var project = _.findWhere($scope.projects, { idProyecto: idProject });

                $scope.proyecto = project;
                //localStorageService.set('project', project);

                $scope.$state.go('base.project', { idProyecto: project.idProyecto });

            }

            $scope.showProyectoDetails = function (setObjetivo) {
                if ($scope.proyectosparams && $scope.proyectosparams.idProyecto) {
                    proyectoAPI.getProyecto($scope).then(
                        function addtoScope(proyecto) {
                            proyecto.proyecto.fechaFin = new Date(proyecto.proyecto.fechaFin);
                            proyecto.proyecto.fechaInicio = new Date(proyecto.proyecto.fechaInicio);
                            $scope.proyecto = proyecto;
                            $scope.setFlatObjetivos();
                            $scope.showLocationInMap();
                            if (setObjetivo) {
                                $scope.setSelectedObjetivo();
                            }

                            $scope.flatResultados = _.filter($scope.proyecto.flatObjetivos, function (_objetivos) {
                                return _objetivos.idObjetivoClase >= 3;
                            });

                            $scope.getUsersbyCompany();
                        }
                    );
                }
            }

            $scope.viewProjectDetails = function () {
                if (!_.isUndefined($scope.proyectosparams) && !_.isUndefined($scope.proyectosparams.idProyecto)) {
                    if ($scope.proyectosparams.idProyecto == 0) {
                        $scope.crearNuevoProyecto();
                    } else {
                        $scope.showProyectoDetails(false);
                    }
                }
            }

            $scope.viewProjectDetails();

            uiGmapGoogleMapApi.then(function (maps) {
                $scope.map = {
                    center: {
                        latitude: 52.47491894326404,
                        longitude: -1.8684210293371217
                    },
                    zoom: 18,
                    bounds: {}
                };

                $scope.marker = {
                    id: 0,
                    coords: {
                        latitude: 52.47491894326404,
                        longitude: -1.8684210293371217
                    },
                    options: { draggable: false },
                    events: {
                        dragend: function (marker, eventName, args) {

                            $scope.marker.options = {
                                draggable: true,
                                labelContent: "lat: " + $scope.marker.coords.latitude + ' ' + 'lon: ' + $scope.marker.coords.longitude,
                                labelAnchor: "100 0",
                                labelClass: "marker-labels"
                            };
                        }
                    }
                };

            });

            $scope.googlePlaces = { value: '' };

            $scope.doSearch = function () {
                $scope.location = $scope.googlePlaces.value;
                if ($scope.location === '') {
                    alert('Directive did not update the location property in parent controller.');
                } else {
                    if ($scope.location !== '') {
                        var locationName = $scope.location.name;
                        var locationAddress = $scope.location.formatted_address;
                        var lat = parseFloat($scope.location.geometry.location.lat());
                        var lng = parseFloat($scope.location.geometry.location.lng());

                        $scope.map = {
                            "center": {
                                "latitude": lat,
                                "longitude": lng
                            },
                            "zoom": 18
                        };
                        $scope.marker = {
                            id: 0,
                            coords: {
                                latitude: lat,
                                longitude: lng
                            }
                        };
                        $scope.proyecto.proyecto.latitude = lat;
                        $scope.proyecto.proyecto.longitude = lng;
                    }
                }
            };

            $scope.showLocationInMap = function () {
                if ($scope.proyecto.proyecto.latitude && $scope.proyecto.proyecto.longitude) {
                    $scope.map = {
                        "center": {
                            "latitude": $scope.proyecto.proyecto.latitude,
                            "longitude": $scope.proyecto.proyecto.longitude
                        },
                        "zoom": 16
                    };
                    $scope.marker = {
                        id: 0,
                        coords: {
                            latitude: $scope.proyecto.proyecto.latitude,
                            longitude: $scope.proyecto.proyecto.longitude
                        }
                    };
                }
            }

            var map;
            $scope.$on('mapInitialized', function (evt, evtMap) {
                map = evtMap;
                $scope.placeMarker = function (e) {
                    var marker = new google.maps.Marker({ position: e.latLng, map: map });
                    map.panTo(e.latLng);
                }
            });

            //Objetivos
            $scope.proyectoTieneObjetivoGeneral = function () {
                return $scope.proyectoTieneObjetivoLevel(1);
            }

            $scope.proyectoTieneProposito = function () {
                return $scope.proyectoTieneObjetivoLevel(2);
            }

            $scope.proyectoTieneObjetivoLevel = function (level) {
                if ($scope.proyecto.flatObjetivos && $scope.proyecto.flatObjetivos.length > 0) {
                    var objetivoGeneral = _.where($scope.proyecto.flatObjetivos, { idObjetivoClase: level });
                    if (objetivoGeneral && objetivoGeneral.length > 0) return true;
                    else return false;
                }
                else
                {
                    return false;
                }
            }

            $scope.crearObjetivoGeneral = function () {
                $scope.selectedObjetivo = { idPadre: 0, idObjetivo: 0, idObjetivoClase: 1, idProyecto: $scope.proyecto.idProyecto }
                $scope.newObjetivo = true;
                $scope.Edit();
            }

            $scope.crearProposito = function () {
                var objetivoGeneral = _.where($scope.proyecto.objetivos, { idObjetivoClase: 1 });
                var idPadre = objetivoGeneral[0].idObjetivo;
                $scope.selectedObjetivo = { idPadre: idPadre, idObjetivo: 0, idObjetivoClase: 2, idProyecto: $scope.proyecto.idProyecto }
                $scope.newObjetivo = true;
                $scope.Edit();
            }

            $scope.newSubObjetivo = function () {
                $scope.selectedObjetivo = { idPadre: this.node.idObjetivo, idObjetivo: 0, idObjetivoClase: (this.node.idObjetivoClase + 1), idProyecto: $scope.proyecto.idProyecto }
                $scope.newObjetivo = true;
                $scope.Edit();
            }

            $scope.showObjetivoDetails = function(objective) {
                objective = objective || this.node;
                $scope.selectedObjetivo = objective;
                $scope.newObjetivo = false;
            }

            $scope.SaveObjetivo = function () {
                $scope.alertsObjetivos = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.selectedObjetivo.idObjetivo == 0) $scope.selectedObjetivo.action = "addObjetivo";
                    else $scope.selectedObjetivo.action = "modifyObjetivo";
                    $scope.selectedObjetivo.userId = localidusuario;

                    var postProyecto = proyectoAPI.getRestAll();
                    
                    postProyecto.post($scope.selectedObjetivo).then(
                        function (response) {
                            $scope.selectedObjetivo.idObjetivo = response;
                            $scope.tmpObjetivo = $scope.selectedObjetivo;
                            addAlert('success', $scope.translation["MENSAJE_PROYECTO_GUARDADO"]);
                            $scope.saved = true;
                            $scope.FinishEdit();
                            $scope.showProyectoDetails(true);
                            $scope.editMode = false;
                            $scope.newObjetivo = false;
                        },
                        function() {
                            addAlert('danger', $scope.translation["ERROR_GUARDADO"]);
                        }
                    );

                }
            }

            $scope.removeObjetivo = function () {
                $scope.alertsObjetivos = [];

                $scope.selectedObjetivo = this.node;

                var areErrors = $scope.validate();

                if (!areErrors) {
                    $scope.selectedObjetivo.action = "deleteObjetivo";
                    $scope.selectedObjetivo.userId = localidusuario;

                    var postProyecto = proyectoAPI.getRestAll();

                    postProyecto.post($scope.selectedObjetivo).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_OBJETIVO_ELIMINADO"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.showProyectoDetails(true);
                        $scope.editMode = false;
                        $scope.newObjetivo = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            }

            $scope.setSelectedObjetivo = function () {
                var tmpObjetivo = $scope.tmpObjetivo;

                if (tmpObjetivo && tmpObjetivo.idObjetivo) {
                    for (var i = 0; i < $scope.proyecto.flatObjetivos.length; i++) {
                        if ($scope.proyecto.flatObjetivos[i].idObjetivo == tmpObjetivo.idObjetivo) {
                            $scope.selectedObjetivo = angular.copy($scope.proyecto.flatObjetivos[i]);
                            break;
                        }
                    }
                }
                $scope.tmpObjetivo = null;
            }

            $scope.getverificadorestooltip = function () {
                var tmpindicador = this.indicador;
                var tooltip = "";
                for (var i = 0; i < tmpindicador.pry_IndicadoresVerificadores.length; i++) {
                    if (!tooltip || tooltip == "") {
                        tooltip += "- " + tmpindicador.pry_IndicadoresVerificadores[i].descripcion;
                    }
                    else
                    {
                        tooltip += "\n" + "- " + tmpindicador.pry_IndicadoresVerificadores[i].descripcion;
                    }
                }
                return tooltip;
            }

            $scope.getCalendarioTemplate = function (objetivo) {
                if ($scope.selectedObjetivo && objetivo.idObjetivo === $scope.selectedObjetivo.idObjetivo) return 'editCalendarioActividades';
                else return 'displayCalendarioActividades';
            };

            $scope.editCalendarioActividades = function () {
                $scope.selectedObjetivo = angular.copy(this.objetivo);
                $scope.Edit();
            };

            //$scope.getObjetivosByClase = function()
            //{
            //    $scope.selectedObjetivos = [];
            //    if ($scope.objetivoClaseIdSelected) {
            //        $scope.selectedObjetivos = _.filter($scope.proyecto.objetivos, function (_objetivos) {
            //            return _objetivos.idObjetivoClase == $scope.objetivoClaseIdSelected;
            //        });
            //    }
            //}

            //Indicadores
            $scope.showIndicadorDetails = function () {
                $scope.selectedIndicator = angular.copy(this.indicador);
                $scope.viewIndicatorDetail();
            }

            $scope.crearNuevoIndicador = function () {
                $scope.selectedIndicator = {
                    idIndicador: 0,
                    idObjetivo: $scope.selectedObjetivo.idObjetivo
                };
                $scope.viewIndicatorDetail();
            }

            $scope.viewIndicatorDetail = function () {
                $scope.animationsEnabled = true;

                var modalInstance = $uibModal.open({
                    animation: $scope.animationsEnabled,
                    templateUrl: 'modalIndicadorContent.html',
                    controller: 'proyectoIndicadorCtrl',
                    size: 'md',
                    resolve: {
                        indicador: function () {
                            return $scope.selectedIndicator;
                        },
                        idObjetivo: function () {
                            return $scope.selectedObjetivo.idObjetivo;
                        },
                        postProyecto: function () {
                            return proyectoAPI.getRestAll();
                        }
                    }
                });

                modalInstance.result.then(function () {
                    $scope.showProyectoDetails(true /*set selected objetivo*/);

                }, function () {
                    
                });
            }

            $scope.deleteIndicador = function () {
                $scope.confirmDelete($scope.translation["BORRAR_INDICADOR_CONFIRMACION"], 'indicador', this.indicador);
            }

            $scope.deleteIndicadorData = function (item) {

                $scope.selectedIndicator = angular.copy(item);

                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    $scope.selectedIndicator.action = "deleteIndicador";
                    $scope.selectedIndicator.userId = localidusuario;

                    var postProyecto = proyectoAPI.getRestAll();
                    postProyecto.post($scope.selectedIndicator).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_INDICADOR_ELIMINADO"]);
                        $scope.showProyectoDetails(true /*set selected objetivo*/);

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });
                }
            }

            $scope.SaveIndicador = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    $scope.selectedIndicator.action = "modifyIndicador";
                    $scope.selectedIndicator.userId = localidusuario;

                    var postProyecto = proyectoAPI.getRestAll();
                    postProyecto.post($scope.selectedIndicator).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_INDICADOR_GUARDADO"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.showProyectoDetails(true);
                        $scope.editMode = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });
                }
            }

            $scope.getCalendarioIndicadoresTemplate = function (indicador) {
                if ($scope.selectedIndicator && indicador.idIndicador === $scope.selectedIndicator.idIndicador) return 'editCalendarioIndicadores';
                else return 'displayCalendarioIndicadores';
            };

            $scope.editCalendarioIndicadores = function() {
                this.indicador.fechaFin = new Date(this.indicador.fechaFin || Date.now());
                this.indicador.fechaInicio = new Date(this.indicador.fechaInicio || Date.now());
                $scope.selectedIndicator = angular.copy(this.indicador);
                $scope.Edit();
            };

            //Supuestos
            $scope.getSupuestoTemplate = function (supuesto) {
                if ($scope.selectedSupuesto && supuesto.idSupuesto === $scope.selectedSupuesto.idSupuesto) return 'editSupuesto';
                else return 'displaySupuesto';
            };

            $scope.getNewSupuestoTemplate = function () {
                if ($scope.selectedSupuesto && $scope.selectedSupuesto.idSupuesto === 0) return 'editSupuesto';
                else return null;
            };

            $scope.editSupuesto = function () {
                $scope.selectedSupuesto = angular.copy(this.supuesto);
                openModalAssumption();
            };

            $scope.crearNuevoSupuesto = function () {
                $scope.selectedSupuesto = { idSupuesto: 0, idObjetivo: $scope.selectedObjetivo.idObjetivo, impacto: 1 }
                openModalAssumption();
            }

            //added by ernesto

            var openModalAssumption = function () {
                var modalInstance = $uibModal.open({
                    animation: false,
                    backdrop: 'static',
                    templateUrl: 'assumption_modal.html',
                    controller: 'assumptionModalCtrl',
                    size: 'md',
                    resolve: {
                        translation: function () { return $scope.translation; },
                        supuesto: function () { return $scope.selectedSupuesto; }
                    }
                });

                modalInstance.result.then(function (response) {
                    $scope.selectedSupuesto = response;
                    $scope.SaveSupuesto();
                },
                function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };

            $scope.SaveSupuestoData = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.selectedSupuesto.idSupuesto == 0) $scope.selectedSupuesto.action = "addSupuesto";
                    else $scope.selectedSupuesto.action = "modifySupuesto";
                    $scope.selectedSupuesto.userId = localidusuario;

                    var postProyecto = proyectoAPI.getRestAll();
                    postProyecto.post($scope.selectedSupuesto).then(function () {
                        $scope.tmpObjetivo = $scope.selectedObjetivo;
                        addAlert('success', $scope.translation["MENSAJE_PROYECTO_GUARDADO"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.showProyectoDetails(true);
                        $scope.editMode = false;
                        $scope.editModeSupuesto = false;
                        //$scope.showObjetivoDetails(tmpObjetivo);
                    }, function () {
                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);
                    });

                }
            };

            $scope.SaveSupuesto = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if (!$scope.SelectedFileForUpload && !$scope.SelectedPhotoForUpload) { //No files to upload
                        $scope.SaveSupuestoData(); //Simple save
                    } else {
                        if ($scope.SelectedFileForUpload) {
                            $scope.CheckFileValid($scope.SelectedFileForUpload);
                            if ($scope.IsFileValid) {
                                var path = "/" + $scope.proyectosparams.idCliente + "/proj/" + $scope.proyectosparams.idProyecto + "/ass";
                                FileUploadService.UploadFile($scope.SelectedFileForUpload, $scope.FileDescription, path).then(function (d) {
                                    $scope.selectedSupuesto.planContingencia = FileUploadService.getSavedFilePath();
                                    $scope.SaveSupuestoData();
                                    ClearForm();
                                }, function (e) {
                                    addAlert('danger', e);
                                });
                            }
                        }
                    }
                }
            };

            $scope.deleteSupuesto = function () {
                $scope.confirmDelete($scope.translation["BORRAR_SUPUESTO_CONFIRMACION"], 'supuesto', this.supuesto);
            }

            $scope.deleteSupuestoData = function (item) {
                $scope.alerts = [];

                $scope.selectedSupuesto = angular.copy(item);

                var areErrors = $scope.validate();

                if (!areErrors) {
                    $scope.selectedSupuesto.action = "deleteSupuesto";
                    $scope.selectedSupuesto.userId = localidusuario;

                    var postProyecto = proyectoAPI.getRestAll();
                    postProyecto.post($scope.selectedSupuesto).then(function() {
                        $scope.tmpObjetivo = $scope.selectedObjetivo;
                        addAlert('success', $scope.translation["MENSAJE_PROYECTO_GUARDADO"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.showProyectoDetails(true);
                        $scope.editMode = false;
                        $scope.editModeSupuesto = false;
                        //$scope.showObjetivoDetails(tmpObjetivo);
                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            }

            //Plan Contingencia
            $scope.getPlanContingenciaTemplate = function (supuesto) {
                if ($scope.selectedSupuesto && supuesto.idSupuesto === $scope.selectedSupuesto.idSupuesto) return 'editPlanContingencia';
                else return 'displayPlanContingencia';
            };

            $scope.editPlanesContingencia = function () {
                $scope.selectedSupuesto = angular.copy(this.supuesto);
                $scope.Edit();
            };

            //Informes
            $scope.getInformeTemplate = function (informe) {
                if ($scope.selectedInforme && informe.idInforme === $scope.selectedInforme.idInforme) return 'editCalendarioInformes';
                else return 'displayCalendarioInformes';
            };

            $scope.getNewInformeTemplate = function () {
                if ($scope.selectedInforme && $scope.selectedInforme.idInforme === 0) return 'editCalendarioInformes';
                else return null;
            };

            $scope.editInforme = function () {
                $scope.selectedInforme = angular.copy(this.informe);
                $scope.Edit();
            };

            $scope.crearNuevoInforme = function () {
                $scope.selectedInforme = {
                    idInforme: 0, idProyecto: $scope.proyecto.idProyecto, presupuestoMeta: 0, avanceMeta: 0
                }
                $scope.Edit();
            }

            $scope.SaveInforme = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.selectedInforme.idInforme == 0) $scope.selectedInforme.action = "addInforme";
                    else $scope.selectedInforme.action = "modifyInforme";
                    $scope.selectedInforme.userId = localidusuario;

                    var postProyecto = proyectoAPI.getRestAll();
                    postProyecto.post($scope.selectedInforme).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_PROYECTO_GUARDADO"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.showProyectoDetails(true);
                        $scope.editMode = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            };

            $scope.deleteInforme = function () {
                $scope.confirmDelete($scope.translation["BORRAR_INFORME_CONFIRMACION"], 'informe', this.informe);
            }

            $scope.deleteInformeData = function (item) {
                $scope.alerts = [];

                $scope.selectedInforme = angular.copy(item);

                var areErrors = $scope.validate();

                if (!areErrors) {
                    $scope.selectedInforme.action = "deleteInforme";
                    $scope.selectedInforme.userId = localidusuario;

                    var postProyecto = proyectoAPI.getRestAll();
                    postProyecto.post($scope.selectedInforme).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_PROYECTO_GUARDADO"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.showProyectoDetails(true);
                        $scope.editMode = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);
                    });
                }
            };

            //Ponderado
            $scope.getFlatObjetivos = function (level) {
                var resultados = _.where($scope.proyecto.flatObjetivos, {idObjetivoClase: level})
                return resultados;
            }

            $scope.getPonderadoTemplate = function (objetivo) {
                if ($scope.selectedObjetivo && objetivo.idObjetivo === $scope.selectedObjetivo.idObjetivo) return 'editPonderadoActividades';
                else return 'displayPonderadoActividades';
            };

            $scope.editPonderadoActividades = function () {
                $scope.selectedObjetivo = angular.copy(this.objetivo);
                $scope.Edit();
            };

            $scope.getPonderadoIndicadoresTemplate = function (indicador) {
                if ($scope.selectedIndicator && indicador.idIndicador === $scope.selectedIndicator.idIndicador) return 'editPonderadoIndicador';
                else return 'displayPonderadoIndicador';
            };

            $scope.editPonderadoIndicadores = function () {
                $scope.selectedIndicator = angular.copy(this.indicador);
                $scope.Edit();
            };

            //Presupuesto
            $scope.showAsistentePresupuesto = function () {
                $scope.animationsEnabled = true;

                var modalInstance = $uibModal.open({
                    animation: $scope.animationsEnabled,
                    templateUrl: 'modalPresupuestoContent.html',
                    controller: 'presupuestoCtrl',
                    size: 'lg',
                    resolve: {
                        idProyecto: function () {
                            return $scope.proyecto.idProyecto;
                        }
                    }
                });

                modalInstance.result.then(function () {
                    $scope.showProyectoDetails(false /*set selected objetivo*/);

                }, function () {

                });
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
                    //if ($scope.tabs[i].idSelected){                    
                    //    $scope.objetivoClaseIdSelected = $scope.tabs[i].idSelected;
                    //    $scope.getObjetivosByClase();
                    //}
                }
            };

            //General
            $scope.setPresupuesto = function () {
                var amount = 0;

                if (!_.isUndefined($scope.proyecto.proyecto.montofinanciamiento) && !_.isUndefined($scope.proyecto.proyecto.montocontrapartida)) {
                    amount += parseFloat($scope.proyecto.proyecto.montofinanciamiento) + parseFloat($scope.proyecto.proyecto.montocontrapartida);
                }

                $scope.proyecto.proyecto.presupuesto = amount;
            };

            $scope.SaveGeneralData = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.proyecto.idProyecto == 0) {
                        $scope.proyecto.action = "addGeneral";
                        $scope.proyecto.proyecto.nivelesAceptacion = $scope.nivelesAceptacion;
                    }
                    else { $scope.proyecto.action = "modifyGeneral"; }
                    $scope.proyecto.userId = localidusuario;

                    var postProyecto = proyectoAPI.getRestAll();

                    postProyecto.post($scope.proyecto).then(function (elementId) {

                        addAlert('success', $scope.translation["MENSAJE_PROYECTO_GUARDADO"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.editMode = false;

                        if ($scope.proyecto.idProyecto === 0) {
                            $scope.proyecto.idProyecto = elementId;
                            $scope.proyectosparams.idProyecto = elementId;
                        }

                        $scope.showProyectoDetails(false);

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            }

            $scope.SaveGeneral = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.SelectedFileForUpload) {
                        $scope.CheckFileValidImage($scope.SelectedFileForUpload);
                        if ($scope.IsFileValid) {
                            var path = "/" + $scope.proyecto.proyecto.customerId + "/proj/" + $scope.proyecto.proyecto.idProyecto;
                            FileUploadService.UploadFile($scope.SelectedFileForUpload, $scope.FileDescription, path).then(function (d) {
                                $scope.proyecto.proyecto.logo = FileUploadService.getSavedFilePath();
                                $scope.SaveGeneralData();
                                ClearForm();
                            }, function (e) {
                                addAlert('danger', e);
                            });
                        }
                    }
                    else {
                        $scope.SaveGeneralData();
                    }
                }
            };

            $scope.validate = function () {
                var areErrors = false;

                if ($scope.tabSelected === 0) { //General
                    if (!$scope.proyecto.proyecto.codigo || !$scope.proyecto.proyecto.nombre ||
                        !$scope.proyecto.proyecto.area || !$scope.proyecto.proyecto.region ||
                        !$scope.proyecto.proyecto.beneficiarios || !$scope.proyecto.proyecto.fechaInicio ||
                        !$scope.proyecto.proyecto.fechaFin || !$scope.proyecto.proyecto.idEmpresa ||
                        !$scope.proyecto.proyecto.idUsuarioResponsable || !$scope.proyecto.proyecto.idUsuarioDigitador ||
                        !$scope.proyecto.proyecto.idUsuarioEvaluador) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["PROYECTO_ERROR_CAMPOS_VACIOS"]);
                    }

                    var lastValue = 100;
                    if ($scope.proyecto.nivelesAceptacion){
                        for (var i = 0; i < $scope.proyecto.nivelesAceptacion.length; i++) {
                            var nivel = $scope.proyecto.nivelesAceptacion[i].idNivelAceptacion;
                            if ($scope.proyecto.nivelesAceptacion[i].valor < 0 || $scope.proyecto.nivelesAceptacion[i].valor > 100) {
                                areErrors = true;
                                addAlert('danger', $scope.translation["PROYECTO_ERROR_NIVELES_ACEPTACION"]);
                            } else if ($scope.proyecto.nivelesAceptacion[i].valor > lastValue) {
                                areErrors = true;
                                addAlert('danger', $scope.translation["PROYECTO_NIVELES_ACEPTACION_INCONSISTENTES"]);
                            }
                            lastValue = $scope.proyecto.nivelesAceptacion[i].valor;
                        }
                    }
                }
                if ($scope.tabSelected === 2) { //Problem Statement
                    if (!$scope.proyecto.proyecto.problema ||
                        !$scope.proyecto.proyecto.descripcionProblema ||
                        !$scope.proyecto.proyecto.justificacion) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["PROYECTO_ERROR_CAMPOS_PROBLEMA_VACIOS"]);
                    }
                }
                if ($scope.tabSelected === 3) { //Objetivos
                    if ($scope.selectedObjetivo && !$scope.selectedObjetivo.descripcion) {
                        areErrors = true;
                        addAlertObjetivos('danger', $scope.translation["OBJETIVO_ERROR_DESCRIPCION_VACIA"]);
                    }

                    if ($scope.selectedSupuesto && !$scope.selectedSupuesto.descripcion) {
                        areErrors = true;
                        addAlertObjetivos('danger', $scope.translation["SUPUESTO_ERROR_DESCRIPCION_VACIA"]);
                    }
                }
                if ($scope.tabSelected === 5) { //Calendario Objetivos
                    if (!$scope.selectedObjetivo || !$scope.selectedObjetivo.objetivo.idResponsable ||
                        !$scope.selectedObjetivo.objetivo.fechaInicio || !$scope.selectedObjetivo.objetivo.fechaFin) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_CAMPOS_VACIOS"]);
                    }
                    else if ($scope.selectedObjetivo.objetivo.fechaInicio > $scope.selectedObjetivo.objetivo.fechaFin) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_FECHAINICIO_FECHAFIN_INVALIDAS"]);
                    }
                }
                if ($scope.tabSelected === 6) { //Calendario Indicadores
                    if (!$scope.selectedIndicator || !$scope.selectedIndicator.idResponsableIndicador ||
                        !$scope.selectedIndicator.fechaInicio || !$scope.selectedIndicator.fechaFin) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_CAMPOS_VACIOS"]);
                    }
                    else if ($scope.selectedIndicator.fechaInicio > $scope.selectedIndicator.fechaFin) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_FECHAINICIO_FECHAFIN_INVALIDAS"]);
                    }
                }
                if ($scope.tabSelected === 7) { //Calendario informes
                    if (!$scope.selectedInforme ||
                        !$scope.selectedInforme.descripcion || !$scope.selectedInforme.fechaProgramada) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_CAMPOS_VACIOS"]);
                    }
                    else if ($scope.selectedInforme.presupuestoMeta < 0 || $scope.selectedInforme.avanceMeta < 0) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_INFORME_METAS_INVALIDAS"]);
                    }
                }
                if ($scope.tabSelected === 8) { //Ponderado Objetivos
                    if (!$scope.selectedObjetivo ||
                        !$scope.selectedObjetivo.objetivo.ponderado < 0) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_PONDERADO_INVALIDO"]);
                    }
                }
                if ($scope.tabSelected === 9) { //Ponderado Indicador
                    if (!$scope.selectedIndicator ||
                        !$scope.selectedIndicator.ponderado < 0) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_PONDERADO_INVALIDO"]);
                    }
                }
                return areErrors;
            }

            $scope.validateActivation = function() {
                //var areErrors = false;

                //General
                if (!$scope.proyecto.proyecto.codigo || !$scope.proyecto.proyecto.nombre ||
                    !$scope.proyecto.proyecto.area || !$scope.proyecto.proyecto.region ||
                    !$scope.proyecto.proyecto.beneficiarios || !$scope.proyecto.proyecto.fechaInicio ||
                    !$scope.proyecto.proyecto.fechaFin || !$scope.proyecto.proyecto.idEmpresa ||
                    !$scope.proyecto.proyecto.idUsuarioResponsable || !$scope.proyecto.proyecto.idUsuarioDigitador ||
                    !$scope.proyecto.proyecto.idUsuarioEvaluador) {
                    addAlert('danger', $scope.translation["PROYECTO_ERROR_CAMPOS_VACIOS"]);
                    return false;
                }

                var lastValue = 100;
                if ($scope.proyecto.nivelesAceptacion) {
                    for (var i = 0; i < $scope.proyecto.nivelesAceptacion.length; i++) {
                        var nivel = $scope.proyecto.nivelesAceptacion[i].idNivelAceptacion;
                        if ($scope.proyecto.nivelesAceptacion[i].valor < 0 || $scope.proyecto.nivelesAceptacion[i].valor > 100) {
                            addAlert('danger', $scope.translation["PROYECTO_ERROR_NIVELES_ACEPTACION"]);
                            return false;
                        } else if ($scope.proyecto.nivelesAceptacion[i].valor > lastValue) {
                            addAlert('danger', $scope.translation["PROYECTO_NIVELES_ACEPTACION_INCONSISTENTES"]);
                            return false;
                        }
                        lastValue = $scope.proyecto.nivelesAceptacion[i].valor;
                    }
                }
                
                //Problem Statement
                if (!$scope.proyecto.proyecto.problema ||
                    !$scope.proyecto.proyecto.descripcionProblema ||
                    !$scope.proyecto.proyecto.justificacion) {
                    addAlert('danger', $scope.translation["PROYECTO_ERROR_CAMPOS_PROBLEMA_VACIOS"]);
                    return false;
                }
                
                //Objetivos
                if (!$scope.proyecto.proyecto.pry_Objetivos || $scope.proyecto.proyecto.pry_Objetivos.length == 0) {
                    addAlertObjetivos('danger', $scope.translation["OBJETIVO_ERROR_DESCRIPCION_VACIA"]);
                    return false;
                }

                return true;
            }

            //Check file
            $scope.CheckFileValid = function (file) {
                var isValid = false;
                if ($scope.SelectedFileForUpload != null) {
                    isValid = true;
                }
                else {
                    $scope.Message = $scope.translation["SELECCIONE_ARCHIVO_PRIMERO"];
                }
                $scope.IsFileValid = isValid;
            };

            $scope.CheckFileValidImage = function (file) {
                var isValid = false;
                if ($scope.SelectedFileForUpload != null) {
                    if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') && file.size <= (512 * 1024)) {
                        $scope.Message = "";
                        isValid = true;
                    }
                    else {
                        $scope.Message = $scope.translation["ARCHIVO_IMAGEN_INVALIDO"];
                    }
                }
                else {
                    $scope.Message = $scope.translation["SELECCIONE_ARCHIVO_PRIMERO"];
                }
                $scope.IsFileValid = isValid;
            };

            //File Select event 
            $scope.selectFileforUpload = function (file) {
                $scope.SelectedFileForUpload = file[0];
            }

            //Foto Select event 
            $scope.selectPhotoforUpload = function (file) {
                $scope.SelectedPhotoForUpload = file[0];
            }

            //Clear form 
            function ClearForm() {
                //as 2 way binding not support for File input Type so we have to clear in this way
                //you can select based on your requirement
                angular.forEach(angular.element("input[type='file']"), function (inputElem) {
                    angular.element(inputElem).val(null);
                });
                $scope.SelectedFileForUpload = null;
            }

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
                    if (sender == 'indicador') { $scope.deleteIndicadorData(item); }
                    if (sender == 'supuesto') { $scope.deleteSupuestoData(item); }
                    if (sender == 'informe') { $scope.deleteInformeData(item); }

                }, function () {
                    //No
                });
            };

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            };

            var addAlertObjetivos = function (varType, varMsg) {
                $scope.alertsObjetivos.push({ type: varType, msg: varMsg });
                $scope.showAlertObjetivos = true;
            };

            //Close
            $scope.close = function () {
                $window.location.href = '#!/projects';
            }

            //Translation
            //Run translation if selected language changes
            $scope.translate = function () {
                translationService.getTranslation($scope, $scope.selectedLanguage);
            };

            //Init
            $scope.selectedLanguage = languageService.get();
            $scope.translate();

            $scope.activate = function() {
                $scope.alerts = [];
                var hasErrors = $scope.validate();
                if (hasErrors) {
                    addAlert('danger', 'No se activo el proyecto. Asegurese de haber capturado por lo menos un dato en cada sección.');
                    return;
                }
                proyectoAPI.activate($scope.proyecto.idProyecto).post().then(function(result) {
                    if (result === 1) {
                        $scope.$state.go('base.projects');
                        $scope.addGlobalAlert('success', 'El proyecto ha sido activado.');
                    }
                    else {
                        addAlert('danger', 'No se activo el proyecto. Asegurese de haber capturado por lo menos un dato en cada sección.');
                    }
                });
            }

            $scope.cerrarProyecto = function(id) {
                $scope.$parent.confirmDelete(
                    { msg: '¿Quiere cerrar el proyecto permanentemente?' },
                    $scope.closeProject,
                    id
                );
            }

            $scope.closeProject = function(id) {
                proyectoAPI.close(id).post().then(
                    function(result) {
                        if (result === 1) {
                            $scope.$state.reload();
                            $scope.addGlobalAlert('success', 'El proyecto ha sido cerrado.');
                        }
                        else {
                            $scope.addGlobalAlert('danger', 'Ocurrió un error. No se cerró el proyecto.');
                        }
                    },
                    function(error) {
                        $scope.addGlobalAler('danger', error.data.exceptionMessage);
                    }
                );
            }

            $scope.closeAlert = function(index) {
                $scope.alerts.splice(index, 1);
            }

            $scope.EliminarProyecto = function() {
                $scope.$parent.confirmDelete({ msg: $scope.translation["CONFIRM_DELETE"] }, $scope.delete);
            }

            $scope.delete = function() {
                $scope.proyecto.remove().then(
                    function(result) {
                        $scope.$state.go('base.projects');
                        $scope.addGlobalAlert('success', 'El proyecto ha sido eliminado.');
                    },
                    function(error) {
                        addAlert('danger', error.data.exceptionMessage);
                    }
                );
            }

            $scope.getUsersbyCompany = function() {
                proyectoAPI.getUsersByCompany($scope.proyecto.proyecto.idEmpresa).getList().then(function (results) {
                    $scope.usuarios2 = results;
                });
            }
        }
    ]
);

adlumenApp.controller('assumptionModalCtrl', ['$scope', '$uibModalInstance', 'supuesto', 'translation',
    function ($scope, $uibModalInstance, supuesto, translation) {

    //initialize $scope properties

    $scope.translation = translation;
    $scope.supuesto = supuesto;
    //initialize alerts

    
    $scope.save = function () {
        $uibModalInstance.close($scope.supuesto);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

}]);