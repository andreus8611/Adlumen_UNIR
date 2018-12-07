'use strict';
adlumenApp.service("evaluacionActivitiesAPI",
    [
        'Restangular',
        function (Restangular) {
            var restFul = Restangular.all("api/evaluacionactividades");

            return function getEvaluacionesActividades(scope) {
                Restangular.one("api/evaluacionactividades/" + scope.evaluacionparams.idPeriodo).get().then(
                    function addtoScope(evaluacionactividadesobject) {

                        scope.evaluacionindicadoresobject = evaluacionactividadesobject
                        scope.evaluacionesactividades = evaluacionactividadesobject.evaluacionesActividades;
                        scope.postRestangularActividades = restFul;
                        scope.setFilteredActivities();

                    }
                );
            }
        }
    ]
)