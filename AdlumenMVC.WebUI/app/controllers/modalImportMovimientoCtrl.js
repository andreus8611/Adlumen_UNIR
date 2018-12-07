'use strict';
adlumenApp.controller('modalImportMovimientoCtrl',
    [
        '$scope', '$uibModalInstance', 'presupuestosTipos', 'productosByProyecto', 'donorsByProyecto', 'periodosProyecto', 'movimientoEjecutado', 'monedaAPI', 'partidasGastosAPI', 'translationService', 'languageService',
        function ($scope, $uibModalInstance, presupuestosTipos, productosByProyecto, donorsByProyecto, periodosProyecto, movimientoEjecutado, monedaAPI, partidasGastosAPI, translationService, languageService) {

            $scope.presupuestotipos = presupuestosTipos;
            $scope.productos = productosByProyecto;
            $scope.donantes = donorsByProyecto;
            $scope.periodosProyecto = periodosProyecto;
            $scope.movimientoEjecutado = movimientoEjecutado;

            $scope.showAlert = false;

            var addAlert = function (varType, varMsg) {
                $scope.alert = { type: varType, msg: varMsg };
                $scope.showAlert = true;
            };

            //Load services
            monedaAPI($scope);
            partidasGastosAPI($scope);


            $scope.content = [];
            $scope.contieneEncabezados = true;

            $scope.getContent = function ($fileContent) {

                $scope.alerts = [];
                var areErrors = false;
                var numberOfRecords = 0;

                var headers = [];

                var allTextLines = $fileContent.split(/\r\n|\n/);

                for (var i = 0; i < allTextLines.length; i++) {
                    if (allTextLines[i] && allTextLines[i] !== '') { //Skip empty rows
                        var rowNumber = i + 1;
                        var data = [];
                        var movimientoObj = {};
                        var columns = allTextLines[i].split(',');

                        if ($scope.contieneEncabezados && i === 0) {
                            //Get the headers
                            for (var j = 0; j < columns.length; j++) {
                                if (columns[j]) headers.push(columns[j]);
                            }
                        }

                        if ($scope.contieneEncabezados && i > 0) {
                            //Get the data
                            for (var j = 0; j < headers.length; j++) {
                                data.push(columns[j]);
                            }
                            
                            if (data.length < 14) {
                                addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNAS_INSUFICIENTES"]);
                                areErrors = true;
                            } else if (data.length > 14) {
                                addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + $scope.translation["ERROR_ARCHIVO_EXCESO_COLUMNAS"]);
                                areErrors = true;
                            } else {
                                if (!data[0] || data[0] === '') { //Periodo
                                    addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + headers[0] + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNA_VACIA"]);
                                    areErrors = true;
                                }
                                if (!data[1] || data[1] === '') { //Tipo de movimiento
                                    addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + headers[1] + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNA_VACIA"]);
                                    areErrors = true;
                                }
                                if (!data[3] || data[3] === '') { //Fecha
                                    addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + headers[3] + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNA_VACIA"]);
                                    areErrors = true;
                                }
                                if (!data[4] || data[4] === '') { //Partida Gasto
                                    addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + headers[4] + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNA_VACIA"]);
                                    areErrors = true;
                                }
                                if (!data[7] || data[7] === '') { //Descripción
                                    addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + headers[7] + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNA_VACIA"]);
                                    areErrors = true;
                                }
                                if (!data[12] || data[12] === '') { //Aporte
                                    addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + headers[12] + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNA_VACIA"]);
                                    areErrors = true;
                                }

                                if (!areErrors) { //Periodo
                                    var idPeriodo = $scope.getPeriodo(data[0]);
                                    if (!idPeriodo) {
                                        addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + $scope.translation["ERROR_ARCHIVO_PERIODO_INVALIDO"] + data[0] + ". " + $scope.translation["ERROR_ARCHIVO_VERIFICAR_ORTOGRAFIA"]);
                                        areErrors = true;
                                    } else {
                                        movimientoObj.idPeriodo = idPeriodo;
                                    }
                                }
                                if (!areErrors) { //Tipo Movimiento
                                    var idTipoMovimiento = $scope.getTipoMovimiento(data[1]);
                                    if (!idTipoMovimiento) {
                                        addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + $scope.translation["ERROR_ARCHIVO_TIPO_MOVIMIENTO_INVALIDO"] + data[1] + ". " + $scope.translation["ERROR_ARCHIVO_VERIFICAR_ORTOGRAFIA"]);
                                        areErrors = true;
                                    } else {
                                        movimientoObj.idTipoMovimiento = idTipoMovimiento;
                                        if (movimientoObj.idTipoMovimiento === 1) {
                                            if (!data[2] || data[2] === '') { //Actividad
                                                addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + headers[2] + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNA_VACIA"]);
                                                areErrors = true;
                                            }

                                            if (!data[6] || data[6] === '') { //Beneficiario
                                                addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + headers[6] + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNA_VACIA"]);
                                                areErrors = true;
                                            } else {
                                                movimientoObj.beneficiario = data[6];
                                            }

                                            if (!areErrors) {
                                                var idActividad = $scope.getActividad(data[2]);
                                                if (!idActividad) {
                                                    addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + $scope.translation["ERROR_ARCHIVO_ACTIVIDAD_INVALIDA"] + data[2] + ". " + $scope.translation["ERROR_ARCHIVO_VERIFICAR_ORTOGRAFIA"]);
                                                    areErrors = true;
                                                }
                                                else {
                                                    movimientoObj.idActividad = idActividad;
                                                }
                                            }
                                        } else if (movimientoObj.idTipoMovimiento === 2) {
                                            if (!data[6] || data[6] === '') { //Beneficiario
                                                addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + headers[6] + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNA_VACIA"]);
                                                areErrors = true;
                                            } else {
                                                movimientoObj.beneficiario = data[6];
                                            }
                                        }
                                    }
                                }

                                if (!areErrors) //Fecha
                                {
                                    var valid = isValidImportedDate(data[3]);
                                    if (!valid) {
                                        addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNA_FECHA_MOVIMIENTO_INVALIDA"]);
                                        areErrors = true;
                                    } else {
                                        movimientoObj.fecha = data[3];
                                    }
                                }

                                if (!areErrors) //Partida Gasto
                                {
                                    var idPartidaGasto = $scope.getPartidaGasto(data[4]);
                                    if (!idPartidaGasto) {
                                        addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + $scope.translation["ERROR_ARCHIVO_PARTIDA_GASTO_INVALIDO"] + data[4] + ". " + $scope.translation["ERROR_ARCHIVO_VERIFICAR_ORTOGRAFIA"]);
                                        areErrors = true;
                                    } else {
                                        movimientoObj.idPartidaGasto = idPartidaGasto;
                                    }
                                }

                                if (!areErrors) //Contribucion moneda local
                                {
                                    if (data[9] && data[9] !== '') {
                                        if (!isValidImportedAmount(data[9])) {
                                            addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + headers[9] + ": " + $scope.translation["ERROR_ARCHIVO_NUMERO_INVALIDO"]);
                                            areErrors = true;
                                        } else {
                                            movimientoObj.contribucionMonedaLocal = parseFloat(data[9]);

                                            if (!data[10] || data[10] === '') {
                                                addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + headers[10] + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNA_VACIA"]);
                                                areErrors = true;
                                            }
                                            else //Moneda
                                            {
                                                var idMoneda = $scope.getMoneda(data[10]);
                                                if (!idMoneda) {
                                                    addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + $scope.translation["ERROR_ARCHIVO_MONEDA_INVALIDA"] + data[10] + ". " + $scope.translation["ERROR_ARCHIVO_VERIFICAR_ORTOGRAFIA"]);
                                                    areErrors = true;
                                                } else {
                                                    movimientoObj.idMoneda = idMoneda;
                                                }
                                            }
                                            if (!data[11] || data[11] === '') {
                                                addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + headers[11] + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNA_VACIA"]);
                                                areErrors = true;
                                            } else {
                                                if (!isValidImportedAmount(data[11])) {
                                                    addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + headers[11] + ": " + $scope.translation["ERROR_ARCHIVO_NUMERO_INVALIDO"]);
                                                    areErrors = true;
                                                } else {
                                                    movimientoObj.tipoDeCambio = parseFloat(data[11]);
                                                }
                                            }
                                        }
                                    }
                                }

                                if (!areErrors) { //Contribucion
                                    if (movimientoObj.contribucionMonedaLocal && movimientoObj.tipoDeCambio) {
                                        movimientoObj.contribucion = movimientoObj.contribucionMonedaLocal * movimientoObj.tipoDeCambio;
                                    } else {
                                        if (!isValidImportedAmount(data[12])) {
                                            addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + headers[12] + ": " + $scope.translation["ERROR_ARCHIVO_NUMERO_INVALIDO"]);
                                            areErrors = true;
                                        } else {
                                            movimientoObj.contribucion = parseFloat(data[12]);
                                        }
                                    }
                                }

                                if (!areErrors) { //Contrapartida
                                    if (!data[13] || data[13] === '') { //Contrapartida
                                        movimientoObj.contrapartida = 0;
                                    } else {
                                        if (!isValidImportedAmount(data[13])) {
                                            addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + headers[13] + ": " + $scope.translation["ERROR_ARCHIVO_NUMERO_INVALIDO"]);
                                            areErrors = true;
                                        } else {
                                            movimientoObj.contrapartida = parseFloat(data[13]);
                                        }
                                    }
                                }

                                if (!areErrors) { //Medio de Pago
                                    if (data[5] && data[5] !== '') { 
                                        movimientoObj.mediopago = data[5];
                                    }
                                }
                            }

                            if (!areErrors) {
                                movimientoObj.descripcion = data[7];
                                movimientoObj.contribucionMonedaLocal = Math.round(movimientoObj.contribucionMonedaLocal * 100) / 100;
                                movimientoObj.contribucion = Math.round(movimientoObj.contribucion * 100) / 100;
                                movimientoObj.contrapartida = Math.round(movimientoObj.contrapartida * 100) / 100;
                                $scope.content.push(movimientoObj);
                                numberOfRecords++;
                            }
                        }
                    }
                }

                if (!areErrors) {
                    addAlert('success', $scope.translation["IMPORT_MOVIMIENTO_ARCHIVO_VALIDO"] + numberOfRecords);
                }
                if (areErrors) {
                    //Limpiar el objeto para que el botón aceptar no suba los datos.
                    $scope.content = [];
                }

            };

            $scope.ok = function () {

                if ($.isEmptyObject($scope.content)) {

                    addAlert('danger', $scope.translation["IMPORT_LOG_ERROR"])

                } else {

                    $uibModalInstance.close({ archivo: $scope.content });
                }
            };

            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
            };

            //Validaciones
            $scope.getPeriodo = function (dataAVerificar)
            {
                //1. remove blank spaces
                //2. Cambiar a mayúculas para no tenerlo en cuenta
                var dataConverted = (dataAVerificar.replace(/\s+/g, '')).toUpperCase();
                for (var i = 0; i < $scope.periodosProyecto.length; i++) {
                    var itemName = ($scope.periodosProyecto[i].nombre.replace(/\s+/g, '')).toUpperCase();
                    if (itemName === dataConverted) return $scope.periodosProyecto[i].idPeriodo;
                }
                return null;
            }

            $scope.getTipoMovimiento = function (dataAVerificar)
            {
                //1. remove blank spaces
                //2. Cambiar a mayúculas para no tenerlo en cuenta
                var dataConverted = (dataAVerificar.replace(/\s+/g, '')).toUpperCase();
                for (var i = 0; i < $scope.presupuestotipos.length; i++) {
                    var itemName = ($scope.presupuestotipos[i].descripcion.replace(/\s+/g, '')).toUpperCase();
                    if (itemName === dataConverted) return $scope.presupuestotipos[i].idTipo;
                }
                return null;
            }

            $scope.getActividad = function (dataAVerificar)
            {
                //1. remove blank spaces
                //2. Cambiar a mayúculas para no tenerlo en cuenta
                var dataConverted = (dataAVerificar.replace(/\s+/g, '')).toUpperCase();
                for (var i = 0; i < $scope.productos.length; i++) {
                    for (var j = 0; j < $scope.productos[i].actividades.length; j++) {
                        var itemName = ($scope.productos[i].actividades[j].codigo.replace(/\s+/g, '')).toUpperCase();
                        if (itemName === dataConverted) return $scope.productos[i].actividades[j].idObjetivo;
                    }
                }
                return null;
            }

            $scope.getPartidaGasto = function (dataAVerificar) {
                //1. remove blank spaces
                //2. Cambiar a mayúculas para no tenerlo en cuenta
                var dataConverted = (dataAVerificar.replace(/\s+/g, '')).toUpperCase();
                for (var i = 0; i < $scope.partidasgastos.length; i++) {
                    var itemName = ($scope.partidasgastos[i].nombre.replace(/\s+/g, '')).toUpperCase();
                    if (itemName === dataConverted) return $scope.partidasgastos[i].idPartidaGasto;
                }
                return null;
            }

            $scope.getMoneda = function (dataAVerificar) {
                //1. remove blank spaces
                //2. Cambiar a mayúculas para no tenerlo en cuenta
                var dataConverted = (dataAVerificar.replace(/\s+/g, '')).toUpperCase();
                for (var i = 0; i < $scope.monedas.length; i++) {
                    var itemName = ($scope.monedas[i].nombre.replace(/\s+/g, '')).toUpperCase();
                    if (itemName === dataConverted) return $scope.monedas[i].idMoneda;
                }
                return null;
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