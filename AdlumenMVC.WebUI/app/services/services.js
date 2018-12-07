//eventually all services have to be on this file

'use strict';

//service to get the table pry_nivelaceptacion

adlumenApp.service('nivelaceptacionAPI',
    [
        '$http',

        function ($http) {

            var _getAll = function () {
                return $http.get('api/nivelaceptacion').then(function(results) {
                    
                    return results;
                })

            };

            this.getAll = _getAll;

        }

    ]);

//service to get modules information from the security database

adlumenApp.service('modulosAPI',
['$http',
function ($http) {

    var _getAll = function () {
        return $http.get('api/modulos').then(function (results) {
            return results;
        });
    };

    var _getbyId = function (id) {
        return $http.get('api/modulos/' + id).then(function (results) {
            return results;
        });
    };

    this.getAll = _getAll;

    this.getById = _getbyId;

}]);

//service to get the actions information of the security database

adlumenApp.service('accionesAPI',
['$http',
function ($http) {

    var _getAll = function () {
        return $http.get('api/acciones').then(function (results) {
            return results;
        });
    };

    var _getbyId = function (id) {
        return $http.get('api/acciones/' + id).then(function (results) {
            return results;
        });
    };

    this.getAll = _getAll;

    this.getById = _getbyId;

}]);

//service to get the information of the actions by role (the actions that a role have permision for module)

adlumenApp.service('accionesrolAPI',
['$http',
function ($http) {

    var _getAll = function () {
        return $http.get('api/accionesrol').then(function (results) {
            return results;
        });
    };

    var _getbyRoleId = function (id) {
        return $http.get('api/accionesrol/' + id).then(function (results) {
            return results;
        });
    };

    var _post = function (accionesRol) {
        return $http.post('api/accionesrol/', accionesRol).then(function (results) {
            return results;
        });
    };

    this.getAll = _getAll;

    this.getByRoleId = _getbyRoleId;

    this.post = _post;

}]);