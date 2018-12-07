'use strict';
adlumenApp.controller('CapacitacionesCtrl',
    [
        '$rootScope','$scope', 'capacitacionAPI', 'facilitadorAPI', '$window',
        function ($rootScope, $scope, capacitacionAPI, facilitadorAPI, $window) {

            capacitacionAPI($scope);

            facilitadorAPI($scope);

            $scope.newFacilitador = false;

            $scope.showAlert = false;

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            }

            $scope.Capacitacion = {
                cmbIdFacilitador: "",
                txtNombreCapacitacion: "",
                txtDescripcionCapacitacion: "",
                txtFechaInicio: "",
                txtFechaFinal: ""
            }

            $scope.open = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();

                $scope.opened = true;
            }

            $scope.open2 = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();

                $scope.opened2= true;
            }


            $scope.addCapacitacion = function () {

                $scope.alerts = [];

                var existErrors = false;

                if ($scope.Capacitacion.txtNombreCapacitacion === "" || $scope.Capacitacion.txtDescripcionCapacitacion === "" || $scope.Capacitacion.txtFechaInicio === "" || $scope.txtFechaFinal === "") {
                    existErrors = true;
                    addAlert('danger', 'Por favor llene todos los campos');
                }

                if (!existErrors) {
                    $scope.capacitaciones.post($scope.Capacitacion).then(function () {

                        addAlert('success', 'Facilitador agregado exitosamente');

                        setTimeout(function () { $window.location.href = '/#!/capacitaciones' }, 1500);

                    }, function () {
                        addAlert('danger', 'Ha ocurrido un error, el registro no ha podido completarse');
                    });
                }

            }

            $scope.deleteCapacitacion = function (_idCapacitacion) {
                var _confirm = confirm("¿Desea eliminar esta Capacitacion?");
                if (_confirm == true) {

                    $scope._editCapacitacion = _.find($scope.capacitaciones, function (_capacitacion) {
                        return _capacitacion.IdCapacitacion == _idCapacitacion;
                    });

                    $scope.Capacitacion = {
                        cmbIdFacilitador: "",
                        txtNombreCapacitacion: "",
                        txtDescripcionCapacitacion: "",
                        txtFechaInicio: "",
                        txtFechaFinal: "",
                        Status: 0
                    }

                    $scope.Beneficiario = {
                        idBeneficiario: _idBeneficiario,
                        cmbIdObjetivo: $scope._editBeneficiario.idObjetivo,
                        txtNombre: $scope._editBeneficiario.nombre,
                        txtEmail: $scope._editBeneficiario.email,
                        txtTelefono: $scope._editBeneficiario.telefono,
                        txtDireccion: $scope._editBeneficiario.direccion,
                        txtExtensionTerritorial: $scope._editBeneficiario.extensionTerritorial,
                        status: 0
                    }

                    $scope.capacitaciones.customPUT($scope.Capacitacion).then(function () {
                        //addAlert('success', 'Beneficiario eliminado exitosamente');
                        alert('Capacitacion eliminada exitosamente');

                        setTimeout(function () { $window.location.href = '/#!/capacitacion'; }, 1500);
                    }, function () {
                        addAlert('danger', 'Ha ocurrido un error, el registro no ha podido eliminarse correctamente');
                    });

                }
            }

            $scope.beneficiariosCapacitacion = function (idCapacitacion) {
                $window.location.href = '/#!/capacitacion/' + idCapacitacion + '/beneficiarios'
            }

        }
    ]
);