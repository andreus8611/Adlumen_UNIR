'use strict';
adlumenApp.controller('proyectoIndicadorCtrl',
    [
        '$scope', '$uibModal', '$uibModalInstance', 'indicador', 'idObjetivo', 'postProyecto', 'indicatorsTypesAPI', 'empleadosAPI', 'translationService', 'languageService',
        function ($scope, $uibModal, $uibModalInstance, indicador, idObjetivo, postProyecto, indicatorsTypesAPI, empleadosAPI, translationService, languageService) {

            var localidusuario = 0;

            $scope.$watch('bdUser', function (newValue, oldValue) {
                localidusuario = newValue.idLocal;
            });

            if (indicador != null) {
                indicador.fechaInicio = indicador.fechaInicio ? new Date(indicador.fechaInicio) : indicador.fechaInicio;
                indicador.fechaFin = indicador.fechaFin ? new Date(indicador.fechaFin) : indicador.fechaFin;
            }
            $scope.indicador = indicador;

            $scope.idObjetivo = idObjetivo;

            $scope.editMode = false;

            $scope.alerts = [];
            $scope.showAlert = false;

            //Load services
            indicatorsTypesAPI($scope);
            empleadosAPI($scope);

            $scope.close = function () {
                $uibModalInstance.dismiss('cancel');
            };

            //Date
            $scope.datePicker = { opened: false }

            $scope.open = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();

                $scope.datePicker.opened = true;
            };

            $scope.datePicker1 = { opened: false }

            $scope.open1 = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();

                $scope.datePicker1.opened = true;
            };

            //Edit functions
            $scope.Edit = function () {
                $scope.alerts = [];
                $scope.editMode = true;

                if (_.isUndefined($scope.indicador.pry_IndicadoresVerificadores)) {
                    $scope.indicador.pry_IndicadoresVerificadores = [];
                }

                if (_.isEmpty($scope.indicador.pry_IndicadoresVerificadores)) {
                    $scope.indicador.pry_IndicadoresVerificadores.push({ descripcion: "" });
                }
            }

            $scope.CancelEdit = function () {
                $scope.editMode = false;
            }

            $scope.setEditNew = function () {
                if ($scope.indicador.idIndicador == 0) {
                    $scope.indicador.fechaInicio = new Date();
                    $scope.indicador.fechaFin = new Date();
                    $scope.Edit();
                }
            }

            $scope.setEditNew();

            //added by Ernesto Duarte
            $scope.newRow = function () {
                $scope.indicador.pry_IndicadoresVerificadores.push({ descripcion: "" });
            };

            $scope.deleteRow = function (verificator) {
               
                var verificators = _.without($scope.indicador.pry_IndicadoresVerificadores, verificator);

                $scope.indicador.pry_IndicadoresVerificadores = verificators;
                
            };

            //Save
            $scope.SaveIndicador = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.indicador.idIndicador == 0) {
                        $scope.indicador.action = "addIndicador";
                        
                    }
                    else $scope.indicador.action = "modifyIndicador";
                    $scope.indicador.userId = localidusuario;

                    if (!$scope.indicador.idObjetivo) $scope.indicador.idObjetivo = $scope.idObjetivo;
                    
                    postProyecto.post($scope.indicador).then(function () {

                        $scope.showAlert($scope.translation["MENSAJE_INDICADOR_GUARDADO"]);

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });
                }
            }

            $scope.validate = function () {
                var areErrors = false;

                if (!$scope.indicador.descripcion || !$scope.indicador.definicion || !$scope.indicador.objetivo ||
                    !$scope.indicador.cualidades || !$scope.indicador.cobertura || !$scope.indicador.fechaInicio ||
                    !$scope.indicador.fechaFin || ($scope.indicador.base == null) || ($scope.indicador.meta == null) ||
                    !$scope.indicador.unidadMedida /*|| !$scope.indicador.unidadOperativa*/) {
                    areErrors = true;
                    addAlert('danger', $scope.translation["INDICADOR_ERROR_CAMPOS_VACIOS"]);
                }

                if (!$scope.indicador.base < 0 || !$scope.indicador.meta < 0) {
                    areErrors = true;
                    addAlert('danger', $scope.translation["INDICADOR_ERROR_META_BASE_INVALID"]);
                }

                return areErrors;
            }

            $scope.showUnidadOperacionalFormula = function () {
                $scope.animationsEnabled = true;

                var modalInstance = $uibModal.open({
                    animation: $scope.animationsEnabled,
                    templateUrl: 'modalFormulaContent.html',
                    controller: 'formulaCtrl',
                    size: 'lg',
                    resolve: {
                        unidadOperativa: function () {
                            return $scope.indicador.unidadOperativa;
                        },
                        unidadOperativaId: function () {
                            return $scope.indicador.unidadOperativaId;
                        }
                    }
                });

                modalInstance.result.then(function (returnObject) {
                    if (returnObject) {
                        $scope.indicador.unidadOperativa = returnObject.formulaNombre;
                        $scope.indicador.unidadOperativaId = returnObject.formulaIds;
                    }
                }, function () {

                });
            }

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            };

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