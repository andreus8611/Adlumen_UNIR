'use strict';
adlumenApp.service("rolesAPI",
    [
        '$http', 'ngAuthSettings',
        function ($http, ngAuthSettings) {
           
            var serviceBase = ngAuthSettings.apiServiceBaseUri;

            var _getRoles = function () {
                return $http.get(serviceBase + 'api/roles/roles').then(
                    function (results) {
                        return results;
                    });
            };

            var _save = function(role) {
                return $http.post(serviceBase + 'api/roles/create', role).then(function(results) {
                    return results;
                });
            };

            var _delete = function(role) {
                return $http.post(serviceBase + 'api/roles/deleterole/' + role.id).then(function(results) {
                    return results;
                });
            };

            this.save = _save;
            this.getAll = _getRoles;
            this.delete = _delete;
        }
    ]);