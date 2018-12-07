'use strict';
adlumenApp.controller('usersCtrl',
    ['$scope', '$uibModal', 'usersService', 'uiGmapGoogleMapApi',
    function($scope, $uibModal, usersService, uiGmapGoogleMapApi) {

    $scope.users = [];
    $scope.user = {};

    //google maps initialization

    $scope.location = '';
    $scope.map = {};
    $scope.marker = {};

    //initalize user
    var userInitialState;

    $scope.doSearch = function () {
        if ($scope.location === '') {
            alert('Directive did not update the location property in parent controller.');
        } else {
            if ($scope.location !== '') {
                var locationName = $scope.location.name;
                var locationAddress = $scope.location.formatted_address;
                var lat = parseFloat($scope.location.geometry.location.lat());
                var lng = parseFloat($scope.location.geometry.location.lng());

                $scope.map = {
                    "center": {
                        "latitude": lat,
                        "longitude": lng
                    },
                    "zoom": 10
                };
                $scope.marker = {
                    id: 1,
                    coords: {
                        latitude: lat,
                        longitude: lng
                    }
                };

                $scope.user.latitude = lat;
                $scope.user.longitude = lng;
            }
        }
    };

    $scope.$watch('bdUser', function (newValue, oldValue) {

        userInitialState = newValue;

        $scope.user = userInitialState;

        uiGmapGoogleMapApi.then(function (maps) {
            $scope.marker = {
                id: 1,
                coords: {
                    latitude: newValue.latitude,
                    longitude: newValue.longitude
                },
                options: { draggable: false },
                events: {
                    dragend: function (marker, eventName, args) {

                        $scope.marker.options = {
                            draggable: true,
                            labelContent: "lat: " + $scope.marker.coords.latitude + ' ' + 'lon: ' + $scope.marker.coords.longitude,
                            labelAnchor: "100 0",
                            labelClass: "marker-labels"
                        };
                    }
                }
            };

            $scope.map = {
                center: {
                    latitude: newValue.latitude,
                    longitude: newValue.longitude
                },
                zoom: 10,
                bounds: {},
                control: {}
            };

        });

    });
    
    $scope.currentUser = null;

    //initialize alerts

    $scope.alerts = [];

    var addAlert = function (varType, varMsg) {
        $scope.alerts.push({ type: varType, msg: varMsg });
        $scope.showAlert = true;
    };

    //cancel user edit

    $scope.cancelEdit = function () {
        $scope.editMode = false;
        $scope.user = userInitialState;
    }

    //edit user from profile

    $scope.editProfile = function () {
        usersService.save($scope.user).then(function (response) {
            //$scope.bdUser = response.data;
            $scope.editMode = false;
            addAlert("success", $scope.translation.USUARIO_GUARDADO);
        });
    }

    $scope.validate = function() {
        $scope.forms.profile.$setSubmitted(true);
        var invalid = $scope.forms.profile.$valid;
        return invalid;
    }

    $scope.closeAlert = function(index) {
        $scope.alerts.splice(index, 1);
    }

    usersService.getUsers().then(function (results) {
        $scope.loading = true;
        $scope.users = results.data;
    }, function (error) {
        alert(error.data.message);
        $scope.loading = false;
        }
    );


    $scope.confirmDeleteUser = function(user) {
        $scope.confirmDelete({ msg: $scope.translation['CONFIRM_DELETE'] }, $scope.deleteuser, user);
    }

    //Delete user
    $scope.deleteuser = function(user) {
        $scope.loading = true;
        var Id = user.id;

        usersService.delete(Id).then(
            function(response) {
                $.each($scope.users, function (i) {
                    if ($scope.users[i].id === Id) {
                        $scope.users.splice(i, 1);
                        return false;
                    }
                });
                addAlert('success', $scope.translation['MSG_DELETED_ITEM']);
            },
            function (err) {
                alert(err.error_description)
                $scope.message = err.error_description;
                $scope.loading = false;
            }
        );
    };


    //Open modal to change password
    
    $scope.changePassword = function () {
        var modalInstance = $uibModal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'change_password.html',
            controller: 'changepasswordModalCtrl',
            size: 'md',
            resolve: {
                user: function () {
                    return $scope.user;
                },

                translation: function () {
                    return $scope.translation;
                }
            }
        });

        modalInstance.result.then(function (response) {
            userInitialState = response;
            $scope.user = response;
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    // Open modal to add a user
    $scope.add = function () {
        var modalInstance = $uibModal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'app/templates/account/user.html',
            controller: 'userModalCtrl',
            size: 'md',
            resolve: {
                user: function () {
                    return null;
                },
                translation: function () {
                    return $scope.translation;
                }
            }
        });
        modalInstance.result.then(function (response) {
           $scope.users.push(response);
            $state.go('users');
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    // Open modal to edit roles
    $scope.rolesopen = function (user) {
        var modalInstance = $uibModal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'app/templates/account/users_roles.html',
            controller: 'userRolesModalCtrl',
            size: 'md',
            resolve: {
                user: function () {
                    return user;
                }
            }
        });

        modalInstance.result.then(function (response) {
            $scope.currentUser = response;
            $state.go('users');
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    // Open model to edit user
    $scope.edit = function (_user) {
        var modalInstance = $uibModal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'app/templates/account/user.html',
            controller: 'userModalCtrl',
            size: 'md',
            resolve: {
                user: function () {
                    return _user;
                },

                translation: function () {
                    return $scope.translation;
                }
            }
        });

        modalInstance.result.then(function (response) {
            usersService.getUsers().then(function (results) {
                $scope.loading = true;
                $scope.users = results.data;
            }, function (error) {
                addAlert('danger', error.data.message);
                $scope.loading = false;
            });
            $state.go('users');
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

}]);

adlumenApp.controller('userRolesModalCtrl', ['$scope', '$uibModalInstance', 'usersService', 'user', function ($scope, $uibModalInstance, usersService, user) {

    $scope.user = user;
    $scope.roles = [];

    // selected fruits
    $scope.selection = [];

    $scope.selection = user.roles;

    usersService.getAllRoles().then(function (results) {
           $scope.roles = results.data;
    }, function (error) {
        alert(error.data.message);
    });

    // toggle selection for a given fruit by name
    $scope.toggleSelection = function toggleSelection(roleName) {
        var idx = $scope.selection.indexOf(roleName);

        // is currently selected
        if (idx > -1) {
            $scope.selection.splice(idx, 1);
        }

            // is newly selected
        else {
            $scope.selection.push(roleName);
        }
    };

    $scope.headerTitle = 'Select Role Assignments';
  

    $scope.save = function () {

        $scope.user.roles = $scope.selection;

        usersService.assignRoles($scope.user).then(function (response) {
            $uibModalInstance.close(response.data);
        })
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

}]);

adlumenApp.controller('changepasswordModalCtrl', ['$scope', '$uibModalInstance', 'usersService', 'user','translation', function ($scope, $uibModalInstance, usersService, user, translation) {

    //initialize $scope properties
    
    $scope.translation = translation;

    //initialize alerts

    var addAlert = function (varType, varMsg) {
        $scope.alerts.push({ type: varType, msg: varMsg });
        $scope.showAlert = true;
    };

    //save changes on user

    $scope.save = function () {

        //validate if the new password and confirmation password is the same

        $scope.alerts = [];

        if ($scope.passwordModel.newPassword === $scope.passwordModel.confirmPassword) {
            usersService.changePassword($scope.passwordModel).then(function (response) {
                $uibModalInstance.close(response.data);

            }, function(response) {
                addAlert('danger', 'La contraseña debe tener mínimo una mayúscula y un caracter que no sea letra o dígito.');
                //for (var key in response.data.modelState) {
                //    for (var i = 0; i < response.data.modelState[key].length; i++) {
                //        addAlert('danger', response.data.modelState[key][i]);
                //    }
                //}
            });
        }

        else {
            addAlert('danger', translation.CONTRASENIAS_NO_COINCIDEN);
        }

    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.closeAlert = function(index) {
        $scope.alerts.splice(index, 1);
    }

}]);

adlumenApp.controller('userModalCtrl', [
    '$scope', '$uibModalInstance', 'usersService', 'authService', 'user', 'translation', 'uiGmapGoogleMapApi', 'uiGmapIsReady',
    function($scope, $uibModalInstance, usersService, authService, user, translation, uiGmapGoogleMapApi, uiGmapIsReady) {

    //initialize $scope properties
    
    $scope.translation = translation;

    var service;

    //validate if it has user

    if (!_.isNull(user)) {
        $scope.headerTitle = translation.EDITAR + ' ' + translation.USUARIO;
        $scope.user = user;
        $scope.editMode = true;
        service = usersService;
    }
    else {
        $scope.headerTitle = translation.NUEVO + ' ' + translation.USUARIO;
        user = { latitude: 0, longitude: 0 };
        service = authService;
    }
    
    //initialize google maps

    uiGmapIsReady.promise().then(function(maps) {
        google.maps.event.trigger(maps[0].map, 'resize');
    });

    $scope.location = '';
    $scope.marker = {};
    $scope.map = {};

    $scope.doSearch = function () {
        if ($scope.location === '') {
            alert('Directive did not update the location property in parent controller.');
        } else {
            if ($scope.location !== '') {
                var locationName = $scope.location.name;
                var locationAddress = $scope.location.formatted_address;
                var lat = parseFloat($scope.location.geometry.location.lat());
                var lng = parseFloat($scope.location.geometry.location.lng());

                $scope.map = {
                    "center": {
                        "latitude": lat,
                        "longitude": lng
                    },
                    "zoom": 10,
                    control: {}
                };
                $scope.marker = {
                    id: 1,
                    coords: {
                        latitude: lat,
                        longitude: lng
                    }
                };

                $scope.user.latitude = lat;
                $scope.user.longitude = lng;
            }
        }
    };
    
    uiGmapGoogleMapApi.then(function(maps) {
        var lat = user.latitude === 0 ? '25.7616798' : user.latitude;
        var lng = user.longitude === 0 ? '-80.1917902' : user.longitude;

        $scope.marker = {
            id: 1,
            coords: {
                latitude: lat,
                longitude: lng
            },
            options: { draggable: false },
            events: {
                dragend: function (marker, eventName, args) {

                    $scope.marker.options = {
                        draggable: true,
                        labelContent: "lat: " + $scope.marker.coords.latitude + ' ' + 'lon: ' + $scope.marker.coords.longitude,
                        labelAnchor: "100 0",
                        labelClass: "marker-labels"
                    };
                }
            }
        };

        $scope.map = {
            center: {
                latitude: lat,
                longitude: lng
            },
            zoom: 10,
            bounds: {},
            control: {}
        };

    });

    var map;
    $scope.$on('mapInitialized', function (evt, evtMap) {
        map = evtMap;
        $scope.placeMarker = function (e) {
            var marker = new google.maps.Marker({ position: e.latLng, map: map });
            map.panTo(e.latLng);
        }
    });

    //initialize alerts

    $scope.alerts = [];

    var addAlert = function (varType, varMsg) {
        $scope.alerts.push({ type: varType, msg: varMsg });
        $scope.showAlert = true;
    };

    //save changes on user

    $scope.save = function () {
        $scope.user.client = $scope.bdClient.id;
        service.save($scope.user).then(
            function(response) {
                $uibModalInstance.close(response.data);
            },
            function(response) {
                addAlert('danger', 'Ocurrió un error. Verifique que la contraseña y el correo sean válidos.');
                //for (var key in response.data.modelState) {
                //    for (var i = 0; i < response.data.modelState[key].length; i++) {
                //        addAlert('danger', response.data.modelState[key][i]);
                //    }
                //}
            }
        );
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    }

    $scope.closeAlert = function(index) {
        $scope.alerts.splice(index, 1);
    }

}]);