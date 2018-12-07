'use strict';
adlumenApp.factory('usersService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var usersServiceFactory = {};

    var _getUsers = function () {

        return $http.get(serviceBase + 'api/accounts/users').then(function (results) {
            return results;
        });
    };

    var _getUser = function (id) {
      
        return $http.get(serviceBase + 'api/accounts/user/' + id).then(function (results) {
            return results;
        });
    };

    var _getUserByName = function (username) {
        return $http.get(serviceBase + 'api/accounts/' + username).then(function (results) {
            return results
        });
    };

    var _changePassword = function (passwords) {
        return $http.post(serviceBase + 'api/accounts/ChangePassword/', passwords).then(function (results) {
            return results;
        });
    };

    var _save = function (user) {
            return $http.put(serviceBase + 'api/accounts/user/' + user.id, user).then(function (response) {
            return response;
        });

    };

    var _delete = function (id) {
       
        return $http.delete(serviceBase + 'api/accounts/user/' + id).then(function (response) {
            return response;
        });

    };


    var _getAllRolles = function () {
       
        return $http.get(serviceBase + 'api/roles/roles').then(function (response) {
            return response;
        });

    };

    var _assignRoles = function (user) {
      
        return $http.put(serviceBase + 'api/accounts/user/' + user.id + '/roles', user.roles).then(function (response) {
            return response;
        });

    };


    usersServiceFactory.getUsers = _getUsers;

    usersServiceFactory.getUser = _getUser;

    usersServiceFactory.getUserByName = _getUserByName;

    usersServiceFactory.save = _save;

    usersServiceFactory.delete = _delete;

    usersServiceFactory.getAllRoles = _getAllRolles;

    usersServiceFactory.assignRoles = _assignRoles;

    usersServiceFactory.changePassword = _changePassword;


    return usersServiceFactory;

}]);