'use strict';
adlumenApp.controller('beneficiariosCapacitacionCtrl',
    [
        '$rootScope', '$scope', 'beneficiarioAPI', 'capacitacionAPI', 'beneficiariosCapacitacionAPI', '$window', '$stateParams',
        function ($rootScope, $scope, beneficiarioAPI, capacitacionAPI, beneficiariosCapacitacionAPI, $window, $stateParams) {

            $scope.idCapacitacion = $stateParams.idCapacitacion;

            beneficiarioAPI($scope);

            capacitacionAPI($scope)

            beneficiariosCapacitacionAPI($scope);

            setTimeout(function () {

                $scope.beneficiarioCapacitacion = _.find($scope.beneficiariosCapacitacion, function (_beneficiarioCapacitacion) {
                    return _beneficiarioCapacitacion.idCapacitacion == $scope.idCapacitacion;
                });

                $scope.Capacitacion = _.find($scope.capacitaciones, function (_capacitacion) {
                    return _capacitacion.idCapacitacion == $scope.idCapacitacion;
                });

            }, 1500);

            $scope.showAlert = false;

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            }

            $scope.newBeneficiarioCapacitacion = {
                cmbIdCapacitacion: $scope.idCapacitacion,
                cmbIdBeneficiario: ""
            }

            $scope.addBeneficiarioCapacitacion = function () {

                $scope.alerts = [];

                var existErrors = false;

                if ($scope.newBeneficiarioCapacitacion.cmbIdBeneficiario === "") {
                    existErrors = true;
                    addAlert('danger', 'Por favor seleccione un beneficiario para esta capacitaci&oacute;n');
                    return false;
                }

                if (!existErrors) {
                    $scope.beneficiariosCapacitacion.post($scope.newBeneficiarioCapacitacion).then(function () {
                        addAlert('success', 'Beneficiario Agregado Exitosamente ...');

                        setTimeout(function () { $window.location.href = '/#!/capacitacion/' + $scope.idCapacitacion + '/beneficiarios/' + $scope.idBeneficiario; }, 1500);
                    }, function () {
                        addAlert('danger', 'Ha ocurrido un error, el registro no ha podido completarse');
                    });
                }

            }

            $scope.regresarCapacitacion = function () {
                $window.location.href = '/#!/capacitacion/'+$scope.idCapacitacion+'/beneficiarios';
            }

            $scope.regresarListado = function () {
                $window.location.href = '/#!/capacitaciones';
            }
        }
    ]
);