'use strict';
adlumenApp.service("proyectoPresupuestoAPI",
    [
        'Restangular',
        function (Restangular) {

            this.getProyectoPresupuesto = function (scope) {
                return Restangular.one("api/presupuestoproyecto/" + scope.idProyecto).get();
            }

            this.getRestAll = function () {
                var restAll = Restangular.all("api/presupuestoproyecto");
                return restAll;
            }
        }
    ]
)