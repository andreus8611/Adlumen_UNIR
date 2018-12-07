'use strict';
adlumenApp.service("proyectoAPI",
    [
        'Restangular',
        function (Restangular) {

            var baseApi = "api/projects/"

            this.getProyecto = function (scope) {
                return Restangular.one(baseApi + scope.proyectosparams.idProyecto).get();
            }

            this.getParents = function () {
                var todosLosProyectos;
                return todosLosProyectos = Restangular.all(baseApi).getList();
            }

            this.getRestAll = function () {
                var restAll = Restangular.all(baseApi);
                return restAll;
            }

            this.getProjectsByClient = function (id) {
                return Restangular.one(baseApi + "projectsbyclient", id);
            }

            this.activate = function(id) {
                return Restangular.one(baseApi + "activate", id);
            }

            this.close = function(id) {
                return Restangular.one(baseApi + "close", id);
            }

            this.getUsersByCompany = function(id) {
                return Restangular.one(baseApi + "getUsersByCompany", id);
            }
        }
    ]
)