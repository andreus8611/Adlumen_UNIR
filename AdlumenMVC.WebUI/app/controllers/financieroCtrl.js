'use strict';
adlumenApp.controller('financieroCtrl', [
'$scope', '$uibModal', 'financieroAPI', 'projectAPI', 'periodAPI', 'translationService', 'languageService',
function ($scope, $uibModal, financieroAPI, projectAPI, periodAPI, translationService, languageService) {

    var localidusuario = 0;

    $scope.$watch('bdUser', function (newValue, oldValue) {

        localidusuario = newValue.idLocal;

    });

    $scope.selectedTotal = {};
    $scope.selectedMovimiento = {};
    $scope.financieroparams = { idProyecto: 0 };
    $scope.labels = [];
    $scope.data = [];
    $scope.excludedtype = 5; //Tipo de presupuesto a excluir en el pie
    $scope.periodosProyecto = [];
    $scope.movimientoEjecutado = [];
    $scope.options = {
        legend: {
            display: true,
            position: 'bottom'
        }
    };

    $scope.alerts = [];

    //Load services
    projectAPI($scope);
    periodAPI($scope);

    $scope.showMovimientosProyecto = function (setSelected) {
        if ($scope.financieroparams && $scope.financieroparams.idProyecto) {
            financieroAPI.getTotalesProyecto($scope).then(
                function addtoScope(financialsobject) {
                    $scope.financialsobject = financialsobject
                    $scope.totales = financialsobject.totales;
                    $scope.pierecords = _.filter($scope.totales, function (_totales) {
                        return _totales.idTipo != $scope.excludedtype;
                    });

                    $scope.presupuestosTipos = financialsobject.presupuestosTipos;
                    $scope.productosByProyecto = financialsobject.productosByProyecto;
                    $scope.donorsByProyecto = financialsobject.donorsByProyecto;
                    $scope.movimientoEjecutado = financialsobject.movimientoEjecutado;

                    $scope.buildGraph();
                    if (setSelected) $scope.setSelectedTotal();
                    else $scope.selectedTotal = {};
                }
            );

            if ($scope.periods) {
                $scope.periodosProyecto = _.filter($scope.periods, function (_periods) {
                    return _periods.idProyecto == $scope.financieroparams.idProyecto;
                });
            }
        }

        $scope.postMovimiento = financieroAPI.getTotalesRestFul();
    }

    $scope.buildGraph = function () {
        $scope.labels = [];
        $scope.data = [];
        if ($scope.pierecords) {
            for (var i = 0; i < $scope.pierecords.length; i++) {
                $scope.labels.push($scope.pierecords[i].descripcion);
                $scope.data.push($scope.pierecords[i].presupuesto);
            }
        }
    }

    $scope.changeSelectedTotal = function () {
        $scope.selectedTotal = angular.copy(this.total);
    }

    //Modal
    $scope.crearNuevoMovimiento = function () {
        //Inicialización del objeto
        $scope.selectedMovimiento = { idMovimiento: 0, montosDonacion: [] };
        $scope.showDetallesMovimiento();
    }

    $scope.editSelectedMovimiento = function () {
        $scope.selectedMovimiento = angular.copy(this.movimiento);
        $scope.showDetallesMovimiento();
    }

    $scope.deleteSelectedMovimiento = function () {
        $scope.selectedMovimiento = angular.copy(this.movimiento);
        $scope.confirmDelete($scope.translation["BORRAR_MOVIMIENTO_CONFIRMACION"], $scope.selectedMovimiento);
    }

    $scope.deleteMovimiento = function (movimiento) {
        $scope.alerts = [];

        var areErrors = false;

        if (!areErrors) {
            movimiento.action = "deleteMovimiento";
            movimiento.userId = localidusuario;
                    
            $scope.postMovimiento.post(movimiento).then(function () {

                addAlert('success', $scope.translation["MENSAJE_MOVIMIENTO_ELIMINADO"]);
                $scope.showMovimientosProyecto(true /* set selected */);

            }, function () {

                addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

            });
        }
    }

    //Confirmation
    $scope.confirmDelete = function (mensaje, item) {
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
            $scope.deleteMovimiento(item);

        }, function () {
            //No
        });
    };

    $scope.showDetallesMovimiento = function () {

        $scope.animationsEnabled = true;

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'modalMovimientoContent.html',
            controller: 'movimientoCtrl',
            size: 'md',
            resolve: {
                movimiento: function () {
                    return $scope.selectedMovimiento;
                },
                presupuestosTipos: function () {
                    return $scope.presupuestosTipos;
                },
                productosByProyecto: function () {
                    return $scope.productosByProyecto;
                },
                donorsByProyecto: function () {
                    return $scope.donorsByProyecto;
                },
                periodosProyecto: function () {
                    return $scope.periodosProyecto;
                },
                movimientoEjecutado: function () {
                    return $scope.movimientoEjecutado;
                },
                idProyecto: function () {
                    return $scope.financieroparams.idProyecto;
                },
                postMovimiento: function () {
                    return $scope.postMovimiento;
                }
            }
        });

        modalInstance.result.then(function () {
            $scope.showMovimientosProyecto(true /* set selected */);
        }, function () {

        });
    }

    $scope.setSelectedTotal = function () {
        var tmpTotal = $scope.selectedTotal;

        if (tmpTotal && tmpTotal.idTipo) {
            for (var i = 0; i < $scope.totales.length; i++) {
                if ($scope.totales[i].idTipo == tmpTotal.idTipo) {
                    $scope.selectedTotal = angular.copy($scope.totales[i]);
                    break;
                }
            }
        }
    }

    var addAlert = function (varType, varMsg) {
        $scope.alerts.push({ type: varType, msg: varMsg });
        $scope.showAlert = true;
    };

    $scope.getMovTemplate = function () {
        return 'app/Files/Templates/template_import_mov_' + $scope.selectedLanguage + '.csv';
    };

    //abrir el modal para cargar el archivo de excel
    $scope.importFile = function () {

        var modalInstance = $uibModal.open({
            templateUrl: '/app/templates/financiero/importarMovimientos.html',
            controller: 'modalImportMovimientoCtrl',
            resolve: {
                presupuestosTipos: function () {
                    return $scope.presupuestosTipos;
                },
                productosByProyecto: function () {
                    return $scope.productosByProyecto;
                },
                donorsByProyecto: function () {
                    return $scope.donorsByProyecto;
                },
                periodosProyecto: function () {
                    return $scope.periodosProyecto;
                },
                movimientoEjecutado: function () {
                    return $scope.movimientoEjecutado;
                }
            }
        });

        modalInstance.result.then(function (content) {

            $scope.SaveMovimiento(content.archivo);

        }, function () {
            addAlert('danger', $scope.translation["ERROR_INESPERADO_IMPORTANDO_MOVIMIENTO"]);
        });
    };

    //Alert
    $scope.showPopUpAlert = function (mensaje) {
        $scope.mensajeAlert = mensaje;

        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: 'modalAlert.html',
            controller: 'modalAlertCtrl',
            size: 'sm',
            resolve: {
                mensaje: function () {
                    return $scope.mensajeAlert;
                }
            }
        });

        modalInstance.result.then(function (response) {
            //Ok
            $uibModalInstance.close();

        }, function () {

        });
    };

    $scope.SaveMovimiento = function (movimientos) {
        $scope.alerts = [];
        var recordsSaved = 0;
        $scope.movimientosAImportar = [];
        for (var i = 0; i < movimientos.length; i++) {
            $scope.movimiento = {};
            $scope.movimiento.idProyecto = $scope.financieroparams.idProyecto;
            $scope.movimiento.idPeriodo = movimientos[i].idPeriodo;
            $scope.movimiento.idTipoPresupuesto = movimientos[i].idTipoMovimiento;
            $scope.movimiento.idActividad = movimientos[i].idActividad;
            $scope.movimiento.beneficiario = movimientos[i].beneficiario;
            $scope.movimiento.contraPartida = movimientos[i].contrapartida;
            $scope.movimiento.aportePrograma = movimientos[i].contribucion;
            $scope.movimiento.moneda = movimientos[i].idMoneda;
            $scope.movimiento.aporteMonedaLocal = movimientos[i].contribucionMonedaLocal;
            $scope.movimiento.medioPago = movimientos[i].mediopago;
            $scope.movimiento.fecha = movimientos[i].fecha;
            $scope.movimiento.idPartidaGasto = movimientos[i].idPartidaGasto;
            $scope.movimiento.monto = parseFloat($scope.movimiento.aportePrograma) + parseFloat($scope.movimiento.contraPartida);
            $scope.movimiento.observaciones = movimientos[i].descripcion;

            $scope.getPresupuesto();
            $scope.movimiento.idPresupuesto = $scope.idPresupuesto;

            $scope.movimientosAImportar.push($scope.movimiento);
        }

        $scope.movimientosObj = { action: "import", movimientos: $scope.movimientosAImportar, userId: localidusuario }

        $scope.postMovimiento.post($scope.movimientosObj).then(
            function() {
                $scope.showMovimientosProyecto(true /* set selected */);
                $scope.showPopUpAlert($scope.translation["MENSAJE_MOVIMIENTOS_IMPORTADOS"]);
            },
            function() {
                addAlert('danger', $scope.translation["ERROR_GUARDADO"]);
            }
        );
    }

    $scope.getPresupuesto = function () {
        var tmpValorProgramado = 0;
        var tmpValorActual = 0;
        if ($scope.movimiento.idTipoPresupuesto) {
            var movimientoEjecutadoTipo = _.filter($scope.movimientoEjecutado, function (_movimientoEjecutado) {
                return _movimientoEjecutado.idTipo == $scope.movimiento.idTipoPresupuesto;
            });
            if ($scope.movimiento.idTipoPresupuesto == 1) {
                if ($scope.movimiento.idActividad) {
                    for (var i = 0; i < movimientoEjecutadoTipo.length; i++) {
                        if (movimientoEjecutadoTipo[i].idObjetivo == $scope.movimiento.idActividad) {
                            tmpValorProgramado += movimientoEjecutadoTipo[i].monto;
                            tmpValorActual += movimientoEjecutadoTipo[i].ejecutado;
                            $scope.idPresupuesto = movimientoEjecutadoTipo[i].idPresupuesto;
                        }
                    }
                }
            } else if ($scope.movimiento.idTipoPresupuesto == 5) { //Donaciones
                for (var i = 0; i < movimientoEjecutadoTipo.length; i++) {
                    if (movimientoEjecutadoTipo[i].idDonante == $scope.movimiento.idProveedor) {
                        tmpValorProgramado += movimientoEjecutadoTipo[i].monto;
                        tmpValorActual += movimientoEjecutadoTipo[i].ejecutado;
                        $scope.idPresupuesto = movimientoEjecutadoTipo[i].idPresupuesto;
                    }
                }
            } else {
                for (var i = 0; i < movimientoEjecutadoTipo.length; i++) {
                    tmpValorProgramado += movimientoEjecutadoTipo[i].monto;
                    tmpValorActual += movimientoEjecutadoTipo[i].ejecutado;
                    $scope.idPresupuesto = movimientoEjecutadoTipo[i].idPresupuesto;
                }
            }
        }
        //$scope.valorProgramado = tmpValorProgramado;
        //$scope.valorActual = tmpValorActual;
    }

    //Translation
    //Run translation if selected language changes
    $scope.translate = function () {
        translationService.getTranslation($scope, $scope.selectedLanguage);
    };

    //Init
    $scope.selectedLanguage = languageService.get();
    $scope.translate();

    $scope.search = function(item) {
        var text = $scope.searchText;
        if (!text ||
            (item.beneficiario && item.beneficiario.toLowerCase().indexOf(text.toLowerCase()) != -1) ||
            (item.observaciones && item.observaciones.toLowerCase().indexOf(text.toLowerCase()) != -1)) {
            return true;
        }
        return false;
    }
}]);