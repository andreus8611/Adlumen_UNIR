'use strict';
adlumenApp.controller('historicoIndicadorCtrl',
    [
        '$scope', '$uibModalInstance', '$uibModal', '$timeout', 'indicatorAPI', 'idIndicador', 'idProyecto', 'translationService', 'languageService',
        function ($scope, $uibModalInstance, $uibModal, $timeout, indicatorAPI, idIndicador, idProyecto, translationService, languageService) {

            var localidusuario = 0;

            $scope.$watch('bdUser', function (newValue, oldValue) {

                localidusuario = newValue.idLocal;

            });

            //$scope.indicador = indicador;
            //$scope.muestras = indicador.datosMuestra;
            $scope.indicadorparams = { idIndicador: idIndicador };
            $scope.idProyecto = idProyecto;
            $scope.newMuestra = false;
            $scope.alerts = [];
            $scope.showAlert = false;
            
            $scope.close = function () {
                $uibModalInstance.close();
            };

            //Load services
            indicatorAPI($scope);

            //Modal
            $scope.addNew = function () {
                $scope.animationsEnabled = true;
                $scope.selectedMuestra = $scope.indicador.nuevaMuestra;

                var modalInstance = $uibModal.open({
                    animation: $scope.animationsEnabled,
                    templateUrl: 'accountabilityContent.html',
                    controller: 'accountabilityCtrl',
                    size: 'lg',
                    resolve: {
                        indicador: function () {
                            return $scope.indicador;
                        },
                        muestra: function () {
                            return $scope.selectedMuestra;
                        },
                        idProyecto: function () {
                            return $scope.idProyecto;
                        },
                        postIndicador: function () {
                            return $scope.postIndicador;
                        }
                    }
                });

                modalInstance.result.then(function () {
                    indicatorAPI($scope);
                }, function () {
                    
                });
            }

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            };

            $scope.editSelected = function () {

                $scope.animationsEnabled = true;
                $scope.selectedMuestra = angular.copy(this.muestra);

                var modalInstance = $uibModal.open({
                    animation: $scope.animationsEnabled,
                    templateUrl: 'accountabilityContent.html',
                    controller: 'accountabilityCtrl',
                    size: 'lg',
                    resolve: {
                        indicador: function () {
                            return $scope.indicador;
                        },
                        muestra: function () {
                            return $scope.selectedMuestra;
                        },
                        idProyecto: function () {
                            return $scope.idProyecto;
                        },
                        postIndicador: function () {
                            return $scope.postIndicador;
                        }
                    }
                });

                modalInstance.result.then(function () {
                    indicatorAPI($scope);
                }, function () {
                    
                });

            }

            $scope.deleteSelected = function () {

                $scope.selectedMuestra = angular.copy(this.muestra);
                
                $timeout(function () {
                    if (confirm($scope.translation["BORRAR_MUESTRA_CONFIRMACION"])) {
                        $scope.alerts = [];

                        var areErrors = false;

                        if (!areErrors) {

                            $scope.selectedMuestra.action = "delete";
                            $scope.selectedMuestra.userId = localidusuario;

                            $scope.postIndicador.post($scope.selectedMuestra).then(function () {

                                addAlert('success', $scope.translation["MENSAJE_MUESTRA_ELIMINADA"]);
                                indicatorAPI($scope);

                            }, function () {

                                addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                            });

                        }
                    }
                }, 0);
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