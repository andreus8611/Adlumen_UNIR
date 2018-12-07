'use strict';
adlumenApp.controller('donanteCtrl',
    [
        '$scope', '$uibModalInstance', 'donante', 'idCliente', 'postDonante', 'idTypesAPI', 'FileUploadService', 'translationService', 'languageService',
        function ($scope, $uibModalInstance, donante, idCliente, postDonante, idTypesAPI, FileUploadService, translationService, languageService) {

            var localidusuario = 0;

            $scope.$watch('bdUser', function (newValue, oldValue) {
                localidusuario = newValue.idLocal;
            });

            $scope.donante = donante;
            $scope.idCliente = idCliente;
            $scope.postDonante = postDonante;

            $scope.editMode = false;

            $scope.alerts = [];
            $scope.showAlert = false;

            //Load Services
            idTypesAPI($scope);

            $scope.close = function () {
                $uibModalInstance.close();
            };

            //Edit functions
            $scope.Edit = function () {
                $scope.alerts = [];
                $scope.editMode = true;
            }

            $scope.CancelEdit = function () {
                $scope.editMode = false;

                if ($scope.donante.idDonante === 0) {
                    $scope.close();
                }
            }

            $scope.setEditNew = function () {
                if ($scope.donante.idDonante == 0) {
                    $scope.Edit();
                }
            }

            $scope.setEditNew();

            //Save
            $scope.SaveDonanteData = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.donante.idDonante == 0) $scope.donante.action = "addDonante";
                    else $scope.donante.action = "modifyDonante";
                    $scope.donante.userId = localidusuario;

                    if (!$scope.donante.idCliente) $scope.donante.idCliente = $scope.idCliente;

                    postDonante.post($scope.donante).then(function() {
                        if ($scope.donante.action == 'addDonante') {
                            $scope.addGlobalAlert('success', $scope.translation["MENSAJE_DONANTE_GUARDADO"]);
                            $scope.close();
                        }
                        else {
                            addAlert('success', $scope.translation["MENSAJE_DONANTE_GUARDADO"]);
                            $scope.showAlert = true;
                        }
                    }, function () {
                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);
                    });
                }
            }

            $scope.SaveDonante = function () {
                $scope.alerts = [];
                $scope.forms.sponsor.$setSubmitted(true);

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if (!$scope.SelectedFileForUpload) { //No files to upload
                        $scope.SaveDonanteData(); //Simple save
                    } else {
                        if ($scope.SelectedFileForUpload) {
                            $scope.CheckFileValid($scope.SelectedFileForUpload);
                            if ($scope.IsFileValid) {
                                var path = "/" + $scope.idCliente + "/orgs/";
                                FileUploadService.UploadFile($scope.SelectedFileForUpload, $scope.FileDescription, path).then(function (d) {
                                    $scope.donante.hojaVida = FileUploadService.getSavedFilePath();
                                    $scope.SaveDonanteData();
                                    ClearForm();
                                }, function (e) {
                                    addAlert('danger', e);
                                });
                            }
                        }
                    }
                }
            };

            $scope.validate = function () {
                var invalid = $scope.forms.sponsor.$invalid;

                if (!$scope.donante.nombre || !$scope.donante.idIdentificacionTipo || !$scope.donante.identificacion) {
                    invalid = true;
                    addAlert('danger', $scope.translation["DONANTE_ERROR_CAMPOS_VACIOS"]);
                }
                else if ($scope.forms.sponsor.$error.email) {
                    addAlert('danger', $scope.translation["ERROR_EMAIL"]);
                }
                else if (invalid) {
                    addAlert('danger', $scope.translation["ERROR_FORM"]);
                }

                return invalid;
            }

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            };

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