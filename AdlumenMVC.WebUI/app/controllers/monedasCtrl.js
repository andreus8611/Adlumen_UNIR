'use strict';
adlumenApp.controller('monedasCtrl',
    [
        '$scope', 'monedaAPI',
        function ($scope, monedaAPI) {

            monedaAPI($scope);
            
            $scope.newMensaje = false;

            $scope.showAlert = false;
           
            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            };

            $scope.inputMonedas = {
                inputNombre: "",
                inputRepresentacion: "",
                
            };

            $scope.resetTexts = function () {
                
                $scope.inputMonedas.inputNombre = "";
                $scope.inputMonedas.inputRepresentacion = "";

                $scope.newMoneda = false;
            };

            $scope.addMoneda = function () {
                
                $scope.alerts = [];
                
                var areErrors = false;

                if ($scope.inputMonedas.inputNombre === "" || $scope.inputMonedas.inputRepresentacion === "") {
                    areErrors = true;
                    addAlert('danger', 'Ninguno de los campos puede estar vacío');
                }

                if (!areErrors) {

                    $scope.monedas.post($scope.inputMonedas).then(function () {

                        addAlert('success', 'Se ha ingresado la moneda correctamente!!');

                        monedaAPI($scope);

                        $scope.resetTexts();

                    }, function () {

                        addAlert('danger', 'Ocurrió un error, el registro no pudo ser completado');

                    });

                }

            }

        }
    ]
);