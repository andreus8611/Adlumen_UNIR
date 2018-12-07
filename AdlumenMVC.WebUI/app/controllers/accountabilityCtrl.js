'use strict';
adlumenApp.controller('accountabilityCtrl',
    [
        '$scope', '$uibModalInstance', 'indicador', 'muestra', 'idProyecto', 'postIndicador', 'periodAPI', 'verificadoresPorIndicadorAPI', 'FileUploadService', 'translationService', 'languageService',
        function ($scope, $uibModalInstance, indicador, muestra, idProyecto, postIndicador, periodAPI, verificadoresPorIndicadorAPI, FileUploadService, translationService, languageService) {

            var localidusuario = 0;

            $scope.$watch('bdUser', function (newValue, oldValue) {

                localidusuario = newValue.idLocal;

            }); 

            $scope.indicador = indicador;
            $scope.idProyecto = idProyecto;
            $scope.muestra = muestra;
            $scope.selectedVerificatorType = {};

            $scope.variableNueva = {};
            $scope.newVariable = false;

            $scope.verificadorNuevo = {};
            
            $scope.saved = false;
            $scope.alerts = [];
            $scope.showAlert = false;

            // File Upload Variables
            $scope.Message = "";
            $scope.SelectedFileForUpload = null;
            $scope.IsFileValid = false;

            //Load services
            periodAPI($scope);
            verificadoresPorIndicadorAPI($scope);
            
            $scope.getFechaProximoInforme = function () {
                if ($scope.muestra.reportIndicator && $scope.muestra.reportIndicator.date)
                    return $scope.muestra.reportIndicator.date;
                else
                    return $scope.indicador.fechaFin;
            }

            $scope.getMetaParcial = function () {
                if ($scope.muestra.reportIndicator && $scope.muestra.reportIndicator.goal)
                    return $scope.muestra.reportIndicator.goal;
                else
                    return $scope.indicador.meta;
            }

            $scope.getPeriodsByProject = function () {
                return _.result($scope.periodsList, $scope.idProyecto);
            }

            $scope.getNotDeletedVerificators = function () {
                return _.filter($scope.muestra.verificators, function (_verificator) {
                    return _verificator.deleted == false;
                });
            }

            $scope.changeTipoVerificador = function (selectedVerificatorType) {
                $scope.selectedVerificatorType = selectedVerificatorType;
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

            //File Select event 
            $scope.selectFileforUpload = function (file) {
                $scope.SelectedFileForUpload = file[0];
            }

            //Save File
            $scope.SaveFile = function () {
                $scope.Message = "";
                if ($scope.selectedVerificatorType && $scope.selectedVerificatorType.idVerificador) {
                    $scope.CheckFileValid($scope.SelectedFileForUpload);
                    if ($scope.IsFileValid) {
                        FileUploadService.UploadFile($scope.SelectedFileForUpload, $scope.FileDescription).then(function (d) {
                            $scope.addNewVerificador();
                            ClearForm();
                        }, function (e) {
                            $scope.Message = e;
                        });
                    }
                }
                else {
                    $scope.Message = $scope.translation["SELECCIONAR_VERIFICADOR_PRIMERO"]
                }
            };

            //Clear form 
            function ClearForm() {
                //as 2 way binding not support for File input Type so we have to clear in this way
                //you can select based on your requirement
                angular.forEach(angular.element("input[type='file']"), function (inputElem) {
                    angular.element(inputElem).val(null);
                });
                $scope.SelectedFileForUpload = null;
            }

            $scope.addNewVerificador = function () {
                var savedFilePath = FileUploadService.getSavedFilePath();
                if ($scope.selectedVerificatorType && $scope.selectedVerificatorType.idVerificador) {
                    if (savedFilePath && savedFilePath !== '') {
                        $scope.verificadorNuevo.idVerificator = $scope.selectedVerificatorType.idVerificador;
                        $scope.verificadorNuevo.description = $scope.selectedVerificatorType.description;
                        $scope.verificadorNuevo.idMuestra = $scope.muestra.id;
                        $scope.verificadorNuevo.url = FileUploadService.getSavedFilePath();
                        $scope.verificadorNuevo.isNew = true;
                        $scope.verificadorNuevo.deleted = false;
                        $scope.verificadorNuevo.fileName = "";
                        var startindex = $scope.verificadorNuevo.url.lastIndexOf("/");
                        if (startindex != -1) $scope.verificadorNuevo.fileName = $scope.verificadorNuevo.url.substring(startindex + 1);
                        $scope.muestra.verificators.push(angular.copy($scope.verificadorNuevo));
                    }
                }
            }

            $scope.deleteSelectedVerificator = function () {
                this.verificator.deleted = true;
            }

            $scope.ok = function () {
                if (!$scope.saved) {
                    if (confirm($scope.translation["CERRAR_VENTANA_CONFIRMACION"]))
                        $uibModalInstance.close();
                } else {
                    $uibModalInstance.close();
                }
            };

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            };

            $scope.modifyMuestra = function () {
                $scope.alerts = [];

                var areErrors = false;

                if (!areErrors) {
                    if ($scope.muestra.id == 0) $scope.muestra.action = "add";
                    else $scope.muestra.action = "modify";
                    $scope.muestra.userId = localidusuario;

                    postIndicador.post($scope.muestra).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_MUESTRA_GUARDADA"]);
                        $scope.saved = true;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            };

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