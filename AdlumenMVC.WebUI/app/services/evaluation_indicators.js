'use strict';
adlumenApp.service("evaluacionIndicadoresAPI",
    [
        'Restangular',
        function (Restangular) {
            var restFul = Restangular.all("api/evaluacionindicadores");

            return function getEvaluacionesIndicadores(scope) {
                Restangular.one("api/evaluacionindicadores/" + scope.evaluacionparams.idPeriodo).get().then(
                    function addtoScope(evaluacionindicadoresobject) {

                        scope.evaluacionindicadoresobject = evaluacionindicadoresobject
                        scope.evaluacionesindicadores = evaluacionindicadoresobject.evaluacionesIndicadores;
                        scope.postRestangular = restFul;
                        scope.setFiltered();

                    }
                );
            }
        }
    ]
)