'use strict';
adlumenApp.controller('BeneficiariosCtrl',
    [
        '$rootScope', '$scope', 'beneficiarioAPI', 'objetivoAPI', '$window', 'commonModel',
        function($rootScope, $scope, beneficiarioAPI, objetivoAPI, $window, commonModel) {

            beneficiarioAPI($scope);

            objetivoAPI($scope);

            $scope.Common = commonModel;

            $scope.filtro_beneficiario = false;

            $scope.filtrarBeneficiarios = function() {
                $scope.beneficiariosByObjetivo = _.filter($scope.beneficiarios, function(_beneficiario) {
                    return _beneficiario.idObjetivo == $scope.Beneficiario.cmbIdObjetivo;
                });

                if (Object.keys($scope.beneficiariosByObjetivo).length > 0) {
                    $scope.filtro_beneficiario = true;
                } else {
                    $scope.filtro_beneficiario = false;
                }
            }

            $scope.addNewObject = function() {
                $scope.Common.setObject('operation', 'new');
                $window.location.href = '#!/beneficiarios/add';
            }

            $scope.editbeneficiario = function(_idBeneficiario) {
                $scope.Common.setObject('edit_beneficiario', _idBeneficiario);
                $scope.Common.setObject('operation', 'edit');
                //$rootScope.$broadcast('edit_beneficiario', { idBeneficiario: _idBeneficiario });
                $window.location.href = '/#!/beneficiarios/update';
            }

            $scope.productivitybeneficiario = function(idBeneficiario) {
                //console.log(idBeneficiario);
                $window.location.href = '/#!/productividades/' + idBeneficiario;
            }

            $scope.deletebeneficiario = function(_idBeneficiario) {
                var _confirm = confirm("¿Desea eliminar este beneficiario?");
                if (_confirm == true) {

                    $scope._editBeneficiario = _.find($scope.beneficiarios, function(_beneficiario) {
                        return _beneficiario.idBeneficiario == _idBeneficiario;
                    });

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

                    $scope.beneficiarios.customPUT($scope.Beneficiario).then(function() {
                        //addAlert('success', 'Beneficiario eliminado exitosamente');
                        alert('Beneficiario eliminado exitosamente');

                        setTimeout(function() { $window.location.href = '/#!/beneficiarios'; }, 1500);
                    }, function() {
                        addAlert('danger', 'Ha ocurrido un error, el registro no ha podido eliminarse correctamente');
                    });

                }
            }
        }
    ]

);