adlumenApp.controller('roleCtrl', ['$scope', '$uibModal', 'rolesAPI', function ($scope, $uibModal, rolesAPI) {

    //Get all roles

    var getAll = function () {
        rolesAPI.getAll().then(function (results) {
            $scope.roles = results.data;
        });
    };
    
    getAll();

    //initialize alerts

    $scope.alerts = [];

    var addAlert = function (varType, varMsg) {
        $scope.alerts.push({ type: varType, msg: varMsg });
        $scope.showAlert = true;
    };

    //Open Role Modal

    $scope.open = function (role) {
        var modalInstance = $uibModal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'role.html',
            controller: 'rolemodalCtrl',
            size: 'sm',
            resolve: {
                role: function () {
                    return ((_.isUndefined(role) ? null : role));
                },
                translation: function () {
                    return $scope.translation;
                }
            }

        });

        modalInstance.result.then(function (response) {
            getAll();
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.openPermissions = function (role) {
        var modalInstance = $uibModal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: '/app/templates/roles/modulesbyRole.html',
            controller: 'assignPermissionCtrl',
            size: 'lg',
            resolve: {
                role: function () {
                    return role;
                },
                translation: function () {
                    return $scope.translation;
                }
            }
        });
    }

    $scope.confirmDeleteRole = function(role) {
        $scope.confirmDelete({ msg: $scope.translation['CONFIRM_DELETE'] }, $scope.deleteRole, role);
    }

    $scope.deleteRole = function(role) {
        rolesAPI.delete(role).then(
            function() {
                addAlert('success', $scope.translation['MSG_DELETED_ITEM']);
                getAll();
            },
            function(error) {
                addAlert('danger', error.data.exceptionMessage);
            }
        );
    }

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.closeAlert = function(index) {
        $scope.alerts.splice(index, 1);
    }

}]);

adlumenApp.controller('rolemodalCtrl', ['$scope', '$uibModalInstance', 'translation', 'role', 'rolesAPI', function ($scope, $uibModalInstance, translation, role, rolesAPI) {

    var editMode;

    $scope.role = {};

    $scope.translation = translation;

    if (_.isNull(role)) {
        editMode = false
        $scope.headerTitle = translation.NUEVO + ' ' + translation.ROL;
    }
    else {
        editMode = true;
        $scope.role = role;
        $scope.headerTitle = translation.EDITAR + ' ' + translation.ROL;
    }

    //initialize alerts

    $scope.alerts = [];

    var addAlert = function (varType, varMsg) {
        $scope.alerts.push({ type: varType, msg: varMsg });
        $scope.showAlert = true;
    };

    //create a new role
    $scope.save = function () {

        if (editMode === true) {
            rolesAPI.edit($scope.role).then(function (results) {
                $uibModalInstance.close();

            }, function (error) {
                addAlert('danger', error.data.message);
            });
        }
        else {
            rolesAPI.save($scope.role).then(function (results) {
                $uibModalInstance.close();
            },
            function(error) {
                addAlert('danger', error.data.message);
            });
        }

    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

}]);

adlumenApp.controller('assignPermissionCtrl', ['$scope', '$uibModalInstance', 'modulosAPI', '$log', 'role', 'accionesAPI', 'accionesrolAPI','translation', function ($scope, $uibModalInstance, modulosAPI, $log, role, accionesAPI, accionesrolAPI, translation) {
    
    //initialize information
    var modulos = [];
    $scope.acciones = [];
    var accionesRol = [];
    $scope.permissions = [];
    //get modules

    modulosAPI.getAll().then(function (response) {

        modulos = response.data;

        _.each(modulos, function (modulo) {
            $scope.permissions.push(modulo);
        });

        //get actions

        accionesAPI.getAll().then(function (response) {

            $scope.acciones = response.data;

            if (!_.isEmpty($scope.permissions)) {

                _.each($scope.permissions, function (element, index) {

                    $scope.permissions[index].actions = _.map(
                        _.where($scope.acciones, {moduloId: element.moduloId}), function (action) {
                        return { idAccion: action.accionesId, descripcion: action.descripcion, permission: false };
                    });

                    
                    $scope.permissions[index].actions.push({ idAccion: 0, descripcion: translation.SIN_PERMISO, permission: true });
                    
                });

            }

            //acciones by rol

            accionesrolAPI.getAll().then(function (response) {
                accionesRol = response.data;
                if (!_.isEmpty(accionesRol)) {
                    _.each($scope.permissions, function (modulo) {
                        _.each(modulo.actions, function (action, index) {
                            var hasPermission = !_.isUndefined(
                                    _.findWhere(accionesRol, { accionesId: action.idAccion, roleId: role.id })
                                );

                            if (hasPermission == true) {
                                modulo.actions[
                                    _.indexOf(modulo.actions,
                                        _.findWhere(modulo.actions, { idAccion: 0 })
                                    )
                                ].permission = false;

                                action.permission = hasPermission;

                            }

                        });
                    });
                }

            }, function (error) {
                $log.info(error.data.message);
            });

        }, function (error) {
            $log.info(error.data.message);
        });

    }, function (error) {
        $log.info(error.data.message)
    });

    $scope.setCheck = function (module, action) {
        if (action.idAccion !== 0 && action.permission === true) {
            module.actions[_.indexOf(module.actions,
                                        _.findWhere(module.actions, { idAccion: 0 })
                                    )
            ].permission = false;
        } else if(action.idAccion === 0 && action.permission === true) {
            _.each(module.actions, function (_action) {
                if (_action.idAccion != 0) {
                    _action.permission = false;
                }
            });
        }
    }

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
    
    $scope.save = function () {
        accionesrolAPI.post({ role: role.id, permissions: $scope.permissions }).then(
            function(response) {
                $uibModalInstance.close();
            },
            function(error) {
                $log.info(error.data.message);
            }
        );
    };

    //initializing alerts

    $scope.alerts = [];

    var addAlert = function (varType, varMsg) {
        $scope.alerts.push({ type: varType, msg: varMsg });
        $scope.showAlert = true;
    };


}]);