'use strict';
adlumenApp.controller('facilitadoresController',
    [
        '$rootScope', '$scope', 'facilitadorAPI', '$window', 'commonModel',
        function ($rootScope,$scope, facilitadorAPI, $window, commonModel) {

            facilitadorAPI($scope);

            $scope.newFacilitador = false;

            $scope.showAlert = false;

            $scope.addNewObject = function () {
                $scope.Common.setObject('operation', 'new');
                $window.location.href = '#!/facilitators/add';
            }

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            }

            $scope.inputFacilitador = {
                txtNombre: "",
                txtEmail: "",
                txtTelefono: "",
                txtDireccion: ""
            }

            $scope.resetTexts = function () {
                $scope.inputFacilitador.txtNombre = "";
                $scope.inputFacilitador.txtEmail = "";
                $scope.inputFacilitador.txtTelefono = "";
                $scope.inputFacilitador.txtDireccion = "",

                $scope.newFacilitador = false;
            };

            $scope.validateEmail = function(email) {
                var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                return re.test(email);
            }

            $scope.addFacilitador = function () {
                
                $scope.alerts = [];

                var existErrors = false;

                if ($scope.inputFacilitador.txtNombre === "" || $scope.inputFacilitador.txtEmail === "" || $scope.inputFacilitador.txtTelefono === "" || $scope.txtDireccion === "") {
                    existErrors = true;
                    addAlert('danger', 'Por favor llene todos los campos');
                }

                if ( existErrors == false && !$scope.validateEmail($scope.inputFacilitador.txtEmail)) {
                    existErrors = true;
                    addAlert('danger', 'Ingrese un email válido');
                } else {
                    existErrors = false;
                }

                if (!existErrors) {
                    $scope._facilitadores.post($scope.inputFacilitador).then(function () {
                        addAlert('success', 'Facilitador agregado exitosamente');
                        facilitadorAPI($scope);
                        $scope.resetTexts();
                    }, function () {
                        addAlert('danger', 'Ha ocurrido un error, el registro no ha podido completarse');
                    });
                }
            }

            $scope.editFacilitador = function (idFacilitador) {
                $scope.Common.setObject('edit_facilitador', idFacilitador);
                $scope.Common.setObject('operation', 'edit');
                //$rootScope.$broadcast('edit_beneficiario', { idBeneficiario: _idBeneficiario });
                $window.location.href = '/#!/facilitators/update';
            }

            $scope.deleteFacilitador = function (idFacilitador) {
                
                var _facilitador = _.find($scope._facilitadores, function (facilitador) {
                    return facilitador.idFacilitador === idFacilitador;
                })


                $scope.eliminarFacilitador = {
                    txtIdFacilitador: _facilitador.idFacilitador,
                    txtNombre: _facilitador.nombre,
                    txtEmail: _facilitador.email,
                    txtTelefono: _facilitador.telefono,
                    txtDireccion: _facilitador.direccion
                }

                $scope._facilitadores.remove($scope.eliminarFacilitador).then(function () {
                    facilitadorAPI($scope);
                });
                
            }

        }
    ]
);