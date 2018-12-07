'use strict';
adlumenApp.controller('monedaCtrl',
    [
        '$scope', 'monedaAPI', 'projectAPI', 'listAPI', 'usuarioAPI', '$uibModal',
        function($scope, monedaAPI, projectAPI, listAPI, usuarioAPI, $uibModal) {

            //projectAPI($scope);
            monedaAPI($scope);
            //listAPI($scope);
            
            $scope.$watchCollection('[monedas, bdUser]', function (newValue, oldValue) {
                if (newValue != oldValue) {
                    $scope.monedas = newValue[0];
                }
            });

            //initialize alerts

            $scope.alerts = [];

            var addAlert = function(varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            }

            //modal to create and update moneda
            $scope.openModalMoneda = function(moneda) {

                var modalInstance = $uibModal.open({
                    animation: false,
                    backdrop: 'static',
                    templateUrl: 'newMoneda.html',
                    controller: 'monedaModalCtrl',
                    size: 'md',
                    resolve: {
                        moneda: function () {
                            return (_.isUndefined(moneda) ? null : moneda);
                        },
                        translation: function () {
                            return $scope.translation;
                        },
                        _monedas: function () {
                            return $scope.monedas;
                        }
                    }
                });

                modalInstance.result.then(function (response) {
                    monedaAPI($scope);
                })
            };

            $scope.confirmDeleteMoneda = function(moneda) {
                $scope.confirmDelete({ msg: $scope.translation["CONFIRM_DELETE"] }, $scope.deleteMoneda, moneda);
            }

            $scope.deleteMoneda = function (moneda) {
                moneda.remove({ id: moneda.idMoneda }, { 'Content-Type': 'application/json' }).then(function () {
                    monedaAPI($scope);
                },
                function (error) {
                    addAlert('danger', error.message);
                });
            };
        }
    ]
);

adlumenApp.controller('monedaModalCtrl',
    [
        '$scope', '_monedas', '$uibModalInstance', 'usuarioAPI', 'translation', 'moneda',
        function($scope, _monedas, $uibModalInstance, usuarioAPI, translation, moneda) {

            //initialize variables
            $scope.translation = translation;

            if (_.isNull(moneda)) {
                $scope.editMode = false;
                $scope.moneda = {};
                $scope.headerTitle = translation.NEW_CURRENCY;
            }
            else {
                $scope.editMode = true;
                $scope.moneda = moneda;
                $scope.headerTitle = translation.EDIT_CURRENCY;
            }
            
            //initialize alerts

            $scope.alerts = [];

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            }

            $scope.closeAlert = function(index) {
                $scope.alerts.splice(index, 1);
            }

            //Save moneda
            $scope.save = function (idUsuario) {

                if ($scope.editMode === false) {
                    _monedas.post($scope.moneda).then(function (result) {
                        $uibModalInstance.close(result);
                    }, function (error) {
                        addAlert('danger', error.data.exceptionMessage);
                    });
                }
                else {
                    $scope.moneda.put().then(function (result) {
                        $uibModalInstance.close(result);
                    }, function (error) {
                        addAlert('danger', error.data.exceptionMessage);
                    });
                }
            };

            $scope.close = function () {
                $uibModalInstance.dismiss('cancel');
            };
        }
    ]
);