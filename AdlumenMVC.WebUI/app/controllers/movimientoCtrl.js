'use strict';
adlumenApp.controller('movimientoCtrl',
    [
        '$scope', '$uibModalInstance', '$uibModal', 'monedaAPI', 'partidasGastosAPI', 'conversorMonedaAPI', 'movimiento', 'presupuestosTipos', 'productosByProyecto', 'donorsByProyecto', 'periodosProyecto', 'movimientoEjecutado', 'idProyecto', 'postMovimiento', 'FileUploadService', 'translationService', 'languageService',
        function ($scope, $uibModalInstance, $uibModal, monedaAPI, partidasGastosAPI, conversorMonedaAPI, movimiento, presupuestosTipos, productosByProyecto, donorsByProyecto, periodosProyecto, movimientoEjecutado, idProyecto, postMovimiento, FileUploadService, translationService, languageService) {

            var localidusuario = 0;
            
            $scope.$watch('bdUser', function (newValue, oldValue) {

                localidusuario = newValue.idLocal;

            });

            $scope.movimiento = movimiento;
            $scope.presupuestotipos = presupuestosTipos;
            $scope.productos = productosByProyecto;
            $scope.donantes = donorsByProyecto;
            $scope.periodosProyecto = periodosProyecto;
            $scope.movimientoEjecutado = movimientoEjecutado;
            $scope.idProyecto = idProyecto;
            $scope.alerts = [];
            $scope.showAlert = false;
            $scope.tipomovimiento = 0; //Not defined
            $scope.selectedProducto = { actividades: [] };
            $scope.valorProgramado = 0;
            $scope.valorActual = 0;
            $scope.idPresupuesto = $scope.movimiento.idPresupuesto;
            $scope.montosDonantes = [];
            $scope.aporteMonedaLocalMensaje = null;

            $scope.close = function () {
                $uibModalInstance.close();
            };

            $scope.opened = false;

            $scope.open = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();

                $scope.opened = true;
            };

            $scope.toggleMax = function () {
                $scope.maxDate = ($scope.maxDate) ? null : new Date();
            };
            $scope.toggleMax();

            $scope.disabled = function (date, mode) {
                return (mode === 'day' && (date > new Date()));
            };

            $scope.getPresupuesto = function () {
                var tmpValorProgramado = 0;
                var tmpValorActual = 0;
                if ($scope.movimiento.idTipoPresupuesto) {
                    var movimientoEjecutadoTipo = _.filter($scope.movimientoEjecutado, function (_movimientoEjecutado) {
                        return _movimientoEjecutado.idTipo == $scope.movimiento.idTipoPresupuesto;
                    });
                    if ($scope.movimiento.idTipoPresupuesto == 1) {
                        if ($scope.movimiento.idResultado && movimiento.idActividad) {
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
                $scope.valorProgramado = tmpValorProgramado;
                $scope.valorActual = tmpValorActual;
            }

            $scope.getMontosDonantes = function () {
                $scope.montosDonantes = [];
                if ($scope.movimiento.idTipoPresupuesto == 1) {
                    for (var i = 0 ; i < $scope.donantes.length; i++) {
                        var montoTotal = 0;
                        for (var j = 0; j < $scope.movimiento.montosDonacion.length; j++) {
                            montoTotal = $scope.movimiento.montosDonacion[j].monto;
                        }
                        $scope.montosDonantes.push({
                            idMovimiento: $scope.movimiento.idMovimiento,
                            idDonante: $scope.donantes[i].idDonante,
                            nombre: $scope.donantes[i].nombre,
                            monto: montoTotal
                        });
                    }
                }
            }

            $scope.setTipoMovimiento = function (section) {
                if ($scope.movimiento.idTipoPresupuesto == 1) {
                    $scope.tipomovimiento = 1; //Costos de proyecto
                } else if ($scope.movimiento.idTipoPresupuesto == 5) {
                    $scope.tipomovimiento = 2; //Donaciones
                } else {
                    $scope.tipomovimiento = 3; //Otros
                }

                $scope.getPresupuesto();
                $scope.getMontosDonantes();
            }

            $scope.setTipoMovimiento();

            $scope.setSelectedProducto = function () {
                $scope.selectedProducto = { actividades: [] };
                if ($scope.movimiento && $scope.movimiento.idResultado) {
                    for (var i = 0; i < $scope.productos.length; i++) {
                        if ($scope.productos[i].idObjetivo == $scope.movimiento.idResultado) {
                            $scope.selectedProducto = $scope.productos[i];
                        }
                    }
                }
            }

            $scope.setSelectedProducto();

            $scope.setSelectedActividad = function () {
                $scope.getPresupuesto();
            }

            $scope.setSelectedDonante = function () {
                $scope.getPresupuesto();
            }

            $scope.setAmount = function () {
                var amount = 0.00;
                if ($scope.movimiento.contraPartida) amount += parseFloat($scope.movimiento.contraPartida);
                if ($scope.movimiento.aportePrograma) amount += parseFloat($scope.movimiento.aportePrograma);
                console.log(amount);
                $scope.movimiento.monto = amount;
            }

            $scope.setMontoDonacion = function () {
                var amount = 0.00;
                if ($scope.montosDonantes) {
                    for (var i = 0; i < $scope.montosDonantes.length; i++) {
                        amount += parseFloat($scope.montosDonantes[i].monto);
                    }
                }
                $scope.movimiento.aportePrograma = amount;
                $scope.setAmount();
            }

            $scope.setAporteMonedaLocal = function () {
                $scope.aporteMonedaLocalMensaje = null;
                if ($scope.movimiento.moneda) {
                    $scope.conversorparams = { idMoneda: $scope.movimiento.moneda, valor: $scope.movimiento.monto };
                    conversorMonedaAPI.getTipoCambio($scope).then(
                        function addtoScope(tipocambio) {
                            var tipocambio = tipocambio
                            var valorAConvertir = $scope.conversorparams.valor;

                            var valorCompra = 0;
                            var message = null;
                            if (!tipocambio || tipocambio === "null") {
                                message = $scope.translation["TIPO_CAMBIO_NO_ENCONTRADO"];
                            }
                            else if (tipocambio && valorAConvertir) {
                                valorCompra = valorAConvertir * tipocambio.valCompra;
                            }

                            $scope.movimiento.aporteMonedaLocal = valorCompra;
                            $scope.aporteMonedaLocalMensaje = message;

                        });
                }
                else
                {
                    $scope.movimiento.aporteMonedaLocal = 0;
                }
            }

            //Load services
            monedaAPI($scope);
            partidasGastosAPI($scope);

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            };

            //File Select event 
            $scope.selectFileforUpload = function (file) {
                $scope.SelectedFileForUpload = file[0];
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

            $scope.validate = function () {
                var areErrors = false;

                if (!$scope.movimiento.idTipoPresupuesto) {
                    areErrors = true;
                    addAlert('danger', $scope.translation["MOVIMIENTO_ERROR_TIPO_REQUERIDO"]);
                }
                else
                {
                    if ($scope.tipomovimiento == 1){ //Costos de proyecto
                        if (!$scope.movimiento.idResultado || !$scope.movimiento.idActividad || !$scope.movimiento.beneficiario) {
                            areErrors = true;
                            addAlert('danger', $scope.translation["MOVIMIENTO_ERROR_PRODUCTO_REQUERIDO"]);
                        }
                    }
                    else if ($scope.tipomovimiento == 2) { //Donaciones
                        if (!$scope.movimiento.idProveedor) {
                            areErrors = true;
                            addAlert('danger', $scope.translation["MOVIMIENTO_ERROR_DONANTE_REQUERIDO"]);
                        }
                    }
                    else { //Otros
                        if (!$scope.movimiento.beneficiario) {
                            areErrors = true;
                            addAlert('danger', $scope.translation["MOVIMIENTO_ERROR_BENEFICIARIO_REQUERIDO"]);
                        }
                    }

                    //Validaciones aplicables a todos los tipos
                    if (!$scope.movimiento.monto || $scope.movimiento.monto <= 0) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["MOVIMIENTO_ERROR_MONTO_REQUERIDO"]);
                    }
                    if (!$scope.movimiento.fecha) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["MOVIMIENTO_ERROR_FECHA_REQUERIDA"]);
                    }
                    if (!$scope.movimiento.idPeriodo) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["MOVIMIENTO_ERROR_PERIODO_REQUERIDO"]);
                    }
                    if (!$scope.movimiento.idPartidaGasto) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["MOVIMIENTO_ERROR_PARTIDA_GASTO_REQUERIDA"]);
                    }
                    if (!$scope.movimiento.observaciones || $scope.movimiento.observaciones.length < 5) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["MOVIMIENTO_ERROR_OBSERVACIONES_REQUERIDA"]);
                    }
                    if ($scope.movimiento.aporteMonedaLocal) {
                        if (!$scope.movimiento.moneda) {
                            areErrors = true;
                            addAlert('danger', $scope.translation["MOVIMIENTO_ERROR_MONEDA_REQUERIDO"]);
                        }
                    }
                    if (!$scope.idPresupuesto || $scope.idPresupuesto == 0) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["MOVIMIENTO_ERROR_PRESUPUESTO_NO_ENCONTRADO"]);
                    }
                }

                return areErrors;
            }

            $scope.SaveMovimientoData = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.movimiento.idMovimiento == 0) $scope.movimiento.action = "addMovimiento";
                    else $scope.movimiento.action = "modifyMovimiento";
                    $scope.movimiento.userId = localidusuario;
                    $scope.movimiento.idPresupuesto = $scope.idPresupuesto;

                    if (!$scope.movimiento.idProyecto) $scope.movimiento.idProyecto = $scope.idProyecto;
                    $scope.movimiento.montosDonantes = $scope.montosDonantes;

                    postMovimiento.post($scope.movimiento).then(function () {

                        //addAlert('success', $scope.translation["MENSAJE_MOVIMIENTO_GUARDADO"]);
                        $scope.showAlert($scope.translation["MENSAJE_MOVIMIENTO_GUARDADO"]);

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });
                }
            }

            //Alert
            $scope.showAlert = function (mensaje) {
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

            $scope.SaveMovimiento = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.SelectedFileForUpload) {
                        $scope.CheckFileValid($scope.SelectedFileForUpload);
                        if ($scope.IsFileValid) {
                            var path = "/" + $scope.idProyecto + "/" + 'mov';
                            FileUploadService.UploadFile($scope.SelectedFileForUpload, $scope.FileDescription, path).then(function (d) {
                                $scope.movimiento.urlSoporte = FileUploadService.getSavedFilePath();
                                $scope.SaveMovimientoData();
                                ClearForm();
                            }, function (e) {
                                addAlert('danger', e);
                            });
                        }
                    }
                    else {
                        $scope.SaveMovimientoData();
                    }
                }
            }

            //Translation
            //Run translation if selected language changes
            $scope.translate = function () {
                translationService.getTranslation($scope, $scope.selectedLanguage);
            };

            //Init
            $scope.selectedLanguage = languageService.get();
            $scope.translate();

        }
    ]
);