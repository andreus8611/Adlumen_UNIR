'use strict';
adlumenApp.controller('formBeneficiarioCtrl',
    [
        '$rootScope', '$scope', 'beneficiarioAPI', 'objetivoAPI', '$window', 'commonModel',
        function ($rootScope, $scope, beneficiarioAPI, objetivoAPI, $window, commonModel) {

            beneficiarioAPI($scope);

            objetivoAPI($scope);

            $scope.Common = commonModel;            

            $scope.showAlert = false;

            $scope._idBeneficiario = $scope.Common.getObject('edit_beneficiario');
            $scope._operation = $scope.Common.getNewObject('operation');


            $scope._newObject = $scope._operation == 'new' ? true : false;

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            }

            $scope.validateEmail = function (email) {
                var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                return re.test(email);
            }

            setTimeout(function () {

                $scope._editBeneficiario = _.find($scope.beneficiarios, function (_beneficiario) {
                    return _beneficiario.idBeneficiario == $scope._idBeneficiario;
                });

                if ($scope._operation == 'edit') {
                    $scope.Beneficiario = {
                        idBeneficiario: $scope._editBeneficiario.idBeneficiario,
                        cmbIdObjetivo: $scope._editBeneficiario.idObjetivo,
                        txtNombre: $scope._editBeneficiario.nombre,
                        txtEmail: $scope._editBeneficiario.email,
                        txtTelefono: $scope._editBeneficiario.telefono,
                        txtDireccion: $scope._editBeneficiario.direccion,
                        txtExtensionTerritorial: $scope._editBeneficiario.extensionTerritorial,
                        status: $scope._editBeneficiario.status
                    }
                } else {
                    $scope.Beneficiario = {
                        cmbIdObjetivo: "",
                        txtNombre: "",
                        txtEmail: "",
                        txtTelefono: "",
                        txtDireccion: "",
                        txtExtensionTerritorial: ""
                    }
                }
            }, 2500);

            $scope.addBeneficiario = function () {

                $scope.alerts = [];

                var existErrors = false;

                if ($scope.Beneficiario.txtNombre === "" || $scope.Beneficiario.txtEmail === "" || $scope.Beneficiario.txtTelefono === "" || $scope.Beneficiario.txtDireccion === "" || $scope.Beneficiario.txtExtensionTerritorial === "") {
                    existErrors = true;
                    addAlert('danger', 'Por favor llene todos los campos');
                    return false;
                }

                if (existErrors == false && !$scope.validateEmail($scope.Beneficiario.txtEmail)) {
                    existErrors = true;
                    addAlert('danger', 'Ingrese un email válido');
                    return false;
                } else {
                    existErrors = false;
                }

                if (!existErrors) {
                    $scope.beneficiarios.post($scope.Beneficiario).then(function () {
                        addAlert('success', 'Facilitador agregado exitosamente');

                        setTimeout(function () { $window.location.href = '/#!/beneficiarios'; }, 1500);

                    }, function () {
                        addAlert('danger', 'Ha ocurrido un error, el registro no ha podido completarse');
                    });
                }
            }

            /*actualizar*/
            $scope.updateBeneficiario = function () {

                $scope.alerts = [];

                var existErrors = false;

                if ($scope.Beneficiario.txtNombre === "" || $scope.Beneficiario.txtEmail === "" || $scope.Beneficiario.txtTelefono === "" || $scope.Beneficiario.txtDireccion === "" || $scope.Beneficiario.txtExtensionTerritorial === "") {
                    existErrors = true;
                    addAlert('danger', 'Por favor llene todos los campos');
                    return false;
                }

                if (existErrors == false && !$scope.validateEmail($scope.Beneficiario.txtEmail)) {
                    existErrors = true;
                    addAlert('danger', 'Ingrese un email válido');
                    return false;
                } else {
                    existErrors = false;
                }

                if (!existErrors) {
                    $scope.beneficiarios.customPUT($scope.Beneficiario).then(function () {
                        addAlert('success', 'Beneficiario actualizado exitosamente');

                        setTimeout(function () { $window.location.href = '/#!/beneficiarios'; }, 1500);

                    }, function () {
                        addAlert('danger', 'Ha ocurrido un error, el registro no ha podido completarse');
                    });
                }
            }

        }
    ]
);