'use strict';
adlumenApp.controller('tenantsCtrl',
    [
        '$scope', 'tenantsAPI', 'projectAPI', 'listAPI', 'usuarioAPI', '$uibModal',
        function ($scope, tenantsAPI, projectAPI, listAPI, usuarioAPI, $uibModal) {

            //projectAPI($scope);
            tenantsAPI($scope);
            //listAPI($scope);
            
            $scope.$watchCollection('[_tenants, bdUser]', function (newValue, oldValue) {
                if (newValue != oldValue) {

                    //if (_.indexOf(newValue[1].roles, "Admin") === -1 && _.indexOf(newValue[1].roles, "manager") === -1) {
                    //    $scope.tenants = _.where(newValue[0], {idResponsable: newValue[1].idLocal});
                    //}
                    //else {
                        $scope.tenants = newValue[0];
                    //}
                                        
                }
            });

            //modal to create and update lists
            //$scope.openModaList = function (list) {

            //    var modalInstance = $uibModal.open({
            //        animation: false,
            //        backdrop: 'static',
            //        templateUrl: 'newList.html',
            //        controller: 'listModalCtrl',
            //        size: 'md',
            //        resolve: {
            //            list: function () {
            //                return (_.isUndefined(list) ? null : list);
            //            },
            //            translation: function () {
            //                return $scope.translation;
            //            },
            //            project: function () {
            //                return $scope.misProyectos;
            //            }
            //        }
            //    });

            //    modalInstance.result.then(function (response) {
            //        listAPI($scope);
            //    })
            //}

            //modal to create and update tenant

            $scope.openModalTenant = function(tenant) {

                var modalInstance = $uibModal.open({
                    animation: false,
                    backdrop: 'static',
                    templateUrl: 'newTenant.html',
                    controller: 'tenantModalCtrl',
                    size: 'md',
                    resolve: {
                        tenant: function () {
                            return (_.isUndefined(tenant) ? null : tenant);
                        },
                        translation: function () {
                            return $scope.translation;
                        },
                        _tenants: function () {
                            return $scope.tenants;
                        }
                    }
                });

                modalInstance.result.then(function (response) {
                    tenantsAPI($scope);
                })
            };


            $scope.confirmDeleteTenant = function(tenant) {
                $scope.confirmDelete({ msg: $scope.translation["CONFIRM_DELETE"] }, $scope.deleteTenant, tenant);
            }

            $scope.deleteTenant = function (tenant) {
                tenant.remove(null, { 'Content-Type': 'application/json' }).then(function () {
                    tenantsAPI($scope);
                },
                function (error) {
                    addAlert('danger', error.data.exceptionMessage);
                });
            };
        }
    ]
);

//adlumenApp.controller('listModalCtrl',
//    [
//        '$scope', 'listAPI', '$uibModalInstance','list', 'translation','project',
//        function ($scope, listAPI, $uibModalInstance, list, translation, project) {

//            //initialize variables

//            listAPI($scope);

//            $scope.translation = translation;

//            if(_.isNull(list)) {
//                $scope.editMode = false;
//                $scope.list = {};
//                $scope.headerTitle = translation.NUEVA_LISTA;
//            }
//            else {
//                $scope.editMode = true;
//                $scope.list = list;
//                $scope.headerTitle = translation.MODIFICAR_LISTA;
//            }

//            //initialize alerts

//            $scope.alerts = [];

//            var addAlert = function (varType, varMsg) {
//                $scope.alerts.push({ type: varType, msg: varMsg });
//                $scope.showAlert = true;
//            }

//            //save list
            
//            $scope.save = function (idUsuario) {

//                $scope.list.idUsuario = idUsuario;
//                $scope.list.idProyecto = project.idProyecto;

//                if ($scope.editMode === false) {
//                    $scope.listas.post($scope.list).then(function (result) {

//                        $uibModalInstance.close(result);

//                    }, function (error) {
//                        addAlert('danger', error.data.exceptionMessage);
//                    });
//                }
//                else {
//                    $scope.list.put().then(function (result) {
//                        $uibModalInstance.close(result);
//                    }, function (error) {
//                        addAlert('danger', error.data.exceptionMessage);
//                    });
//                }

//            };

//            $scope.close = function () {
//                $uibModalInstance.dismiss('cancel');
//            };

//        }



//    ]
//);

adlumenApp.controller('tenantModalCtrl',
    [
        '$scope', '_tenants', '$uibModalInstance', 'usuarioAPI', 'translation', 'tenant',
        function($scope, _tenants, $uibModalInstance, usuarioAPI, translation, tenant) {

            //initialize variables

            //usuarioAPI($scope);
            
            $scope.translation = translation;

            //$scope.minDate = minDate;

            if (_.isNull(tenant)) {
                $scope.editMode = false;
                $scope.tenant = {};
                $scope.headerTitle = translation.NEW_TENANT;
            }
            else {
                $scope.editMode = true;
                $scope.tenant = tenant;
                //$scope.tenant.done = tenant.idUsuarioCompletado != null;
                $scope.headerTitle = translation.EDIT_TENANT;

                //$scope.$watch('usuarios', function (newValue, oldValue) {
                //    if (newValue != oldValue) {
                //        $scope.responsable = _.findWhere(newValue, { idUsuario: tenant.idResponsable });
                //    }
                //});

            }
            
            //initialize alerts

            $scope.alerts = [];

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            }

            //datepicker configuration

            //$scope.statusfechaInicio = { opened: false };

            //$scope.openfechaInicio = function ($event) {
            //    $event.preventDefault();
            //    $event.stopPropagation();
            //    $scope.statusfechaInicio.opened = true;
            //};

            //$scope.statusfechaFin = { opened: false };

            //$scope.openfechaFin = function ($event) {
            //    $event.preventDefault();
            //    $event.stopPropagation();
            //    $scope.statusfechaFin.opened = true;
            //};

            //$scope.maxDate = new Date(2020, 5, 22);

            //Save tenant

            $scope.save = function (idUsuario) {

                //$scope.tenant.idUsuario = idUsuario;
                //$scope.tenant.idLista = list.id;
                //$scope.tenant.idResponsable = $scope.responsable.idUsuario;

                //if ($scope.tenant.done === true) 
                //    $scope.tenant.idUsuarioCompletado = idUsuario;
                //else
                //    $scope.tenant.idUsuarioCompletado = null;

                if ($scope.editMode === false) {
                    _tenants.post($scope.tenant).then(function (result) {

                        $uibModalInstance.close(result);

                    }, function (error) {
                        addAlert('danger', error.data.exceptionMessage);
                    });
                }
                else {
                    $scope.tenant.put().then(function (result) {
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