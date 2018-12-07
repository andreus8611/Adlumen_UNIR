'use strict';
adlumenApp.controller('profileController', ['$scope', '$uibModal', 'usersService', function ($scope, $uibModal, usersService) {

    $scope.users = [];

    $scope.user = null;
    $scope.currentUser = null;


    usersService.getUsers().then(function (results) {
        $scope.loading = true;
        $scope.users = results.data;
    }, function (error) {
        alert(error.data.message);
        $scope.loading = false;
    });

    //Delete user
    $scope.deleteuser = function () {
             $scope.loading = true;
        var Id = this.user.id;
        usersService.delete(Id).then(function (response) {
            $.each($scope.users, function (i) {
                if ($scope.users[i].id === Id) {
                    $scope.users.splice(i, 1);
                    return false;
                }
            });
        },
       function (err) {
           alert(err.error_description)
           $scope.message = err.error_description;
         $scope.loading = false;
       });
    };
    // Edit Customer
    $scope.edituser = function () {
        $scope.user = this.user;
        $scope.open('lg');
    };

    $scope.adduser = function () {
        $scope.add('lg');
    };

    // Edit Customer
    $scope.editroles = function () {
       $scope.user = this.user;
       $scope.openroles('sm');
    };

    // Open model to add edit customer
    $scope.add = function (size) {
        var modalInstance = $uibModal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'app/templates/account/adduser.html',
            controller: 'adduserModalCtrl',
            size: size
        });
        modalInstance.result.then(function (response) {
           $scope.users.push(response);
            $state.go('users');
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    // Open model to add edit customer
    $scope.openroles = function (size) {
        var modalInstance = $uibModal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'app/templates/account/editroles.html',
            controller: 'userRolesModalCtrl',
            size: size,
            resolve: {
                user: function () {
                    return $scope.user;
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

    // Open model to add edit customer
    $scope.open = function (size) {
        var modalInstance = $uibModal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'app/templates/account/edituser.html',
            controller: 'userModalCtrl',
            size: size,
            resolve: {
                user: function () {
                    return $scope.user;
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


}]);


adlumenApp.controller('adduserModalCtrl', ['$scope', '$uibModalInstance', 'authService', function ($scope, $uibModalInstance, authService) {

    $scope.headerTitle = 'Add User';
    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.registration = {
        userName: "",
        password: "",
        confirmPassword: "",
        firstName: "",
        lastName: "",
        email: ""
    };


    $scope.save = function () {
        authService.save($scope.registration).then(function (response) {
            $uibModalInstance.close(response.data);
        }, function (response) {
            var errors = [];
            for (var key in response.data.modelState) {
                for (var i = 0; i < response.data.modelState[key].length; i++) {
                    errors.push(response.data.modelState[key][i]);
                }
            }
            $scope.message = "Failed to register user due to:" + errors.join(' ');
        });
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
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


adlumenApp.controller('userModalCtrl', ['$scope', '$uibModalInstance', 'usersService', 'user', function ($scope, $uibModalInstance, usersService, user) {

    $scope.user = user;
  
    if (user.id != "")
        $scope.headerTitle = 'Edit User';
    else
        $scope.headerTitle = 'Add User';

    $scope.save = function () {
            usersService.save($scope.user).then(function (response) {
            $uibModalInstance.close(response.data);
        })
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

}]);