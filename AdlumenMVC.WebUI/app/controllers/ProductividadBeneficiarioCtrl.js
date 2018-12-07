'use strict';
adlumenApp.controller('ProductividadBeneficiarioCtrl',
    [
        '$rootScope', '$scope', 'beneficiarioAPI', 'productividadBeneficiarioAPI', '$window', '$stateParams',
        function ($rootScope, $scope, beneficiarioAPI, productividadBeneficiarioAPI, $window, $stateParams) {

            $scope.idBeneficiario = $stateParams.idBeneficiario;

            beneficiarioAPI($scope);

            productividadBeneficiarioAPI($scope);

            setTimeout(function () {

                $scope.productividadesBeneficiario = _.find($scope.productividades, function (_productividad) {
                    return _productividad.idBeneficiario == $scope.idBeneficiario;
                });

                $scope.Beneficiario = _.find($scope.beneficiarios, function (_beneficiario) {
                    return _beneficiario.idBeneficiario == $scope.idBeneficiario;
                });

                //console.log($scope.productividadesBeneficiario); return false;

            }, 1500);

            $scope.showAlert = false;

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            }

            $scope.Productividad = {
                cmbIdBeneficiario: $scope.idBeneficiario,
                txtAreaSembrada: "",
                txtCultivoSembrado: "",
                txtCantidadSembrada: "",
                txtProduccionCultivo: ""
            }

            $scope.addProductividad = function () {

                $scope.alerts = [];

                var existErrors = false;

                if ($scope.Productividad.txtAreaSembrada === "" || $scope.Productividad.txtCultivoSembrado === "" || $scope.Productividad.txtCantidadSembrada === "" || $scope.Productividad.txtProduccionCultivo === "") {
                    existErrors = true;
                    addAlert('danger', 'Por favor llene todos los campos');
                    return false;
                }

                if (!existErrors) {
                    $scope.productividadbeneficiario.post($scope.Productividad).then(function () {
                        addAlert('success', 'Productividad agregada exitosamente');

                        setTimeout(function () { $window.location.href = '/#!/beneficiario/productividad/' + $scope.idBeneficiario; }, 1500);

                    }, function () {
                        addAlert('danger', 'Ha ocurrido un error, el registro no ha podido completarse');
                    });
                }

            }

            $scope.productivitybeneficiario = function (idBeneficiario) {
                $window.location.href = '/#!/beneficiario/productividad/' + idBeneficiario;
            }
        }
    ]
);