'use strict';
adlumenApp.controller('modalImportLogCtrl',
    [
        '$scope', '$uibModalInstance', 'bitacoraAPI', 'translationService', 'languageService',
        function ($scope, $uibModalInstance, bitacoraAPI, translationService, languageService) {

            //Translation
            //Run translation if selected language changes
            $scope.translate = function () {
                translationService.getTranslation($scope, $scope.selectedLanguage);
            };

            //Init
            $scope.selectedLanguage = languageService.get();
            $scope.translate();

            bitacoraAPI($scope);

            $scope.showAlert = false;

            var addAlert = function (varType, varMsg) {
                $scope.alert = { type: varType, msg: varMsg };
                $scope.showAlert = true;
            };

            $scope.content = [];
            $scope.contieneEncabezados = true;

            $scope.getContent = function ($fileContent) {

                $scope.alerts = [];
                var areErrors = false;
                var numberOfRecords = 0;

                var allTextLines = $fileContent.split(/\r\n|\n/);

                for (var i = 0; i < allTextLines.length; i++) {
                    if (allTextLines[i] && allTextLines[i] !== '') { //Skip empty rows
                        var rowNumber = i + 1;
                        var n = allTextLines[i].indexOf(",");
                        var data = [];
                        var logObj = {};

                        data.push(allTextLines[i].substring(0, n));
                        data.push(allTextLines[i].substring(n + 1)); //Split removed because comment can contain commas ","
                        //allTextLines[i].split(',');

                        if ($scope.contieneEncabezados && i > 0) {
                            if (data.length < 2) {
                                addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNAS_INSUFICIENTES"]);
                                areErrors = true;
                            } else if (data.length > 2) {
                                addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + $scope.translation["ERROR_ARCHIVO_EXCESO_COLUMNAS"]);
                                areErrors = true;
                            } else {
                                if (!data[0] || data[0] === '') {
                                    addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNA_FECHA_VACIA"]);
                                    areErrors = true;
                                } else {
                                    var resdatetime = data[0].split(" ");
                                    if (!resdatetime) {
                                        addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNA_FECHA_INVALIDA"]);
                                        areErrors = true;
                                    } else {
                                        var strresdate = resdatetime[0];
                                        var valid = isValidImportedDate(strresdate);
                                        if (!valid) {
                                            addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNA_FECHA_INVALIDA"]);
                                            areErrors = true;
                                        }

                                        var strrestime = resdatetime[1];
                                        if (strrestime && strrestime !== '') {
                                            var valid = isValidImportedTime(strrestime);
                                            if (!valid) {
                                                addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNA_HORA_INVALIDA"]);
                                                areErrors = true;
                                            }
                                        } else {
                                            strrestime = '00:00';
                                        }
                                    }
                                }
                                if (!data[1] || data[1] === '') {
                                    addAlert('danger', $scope.translation["ROW"] + rowNumber + ": " + $scope.translation["ERROR_ARCHIVO_COLUMNA_COMENTARIO_VACIO"]);
                                    areErrors = true;
                                }
                            }

                            if (!areErrors) {
                                logObj.date = strresdate + " " + strrestime + ":00";
                                logObj.comment = data[1];
                                $scope.content.push(logObj);
                                numberOfRecords++;
                            }
                        }
                    }
                }

                if (!areErrors) {
                    addAlert('success', $scope.translation["IMPORT_LOG_ARCHIVO_VALIDO"] + numberOfRecords);
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

        }

    ]
);