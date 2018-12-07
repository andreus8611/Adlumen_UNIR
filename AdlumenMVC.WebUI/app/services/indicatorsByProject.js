'use strict';
adlumenApp.service("indicadoresPorProyectoAPI",
    [
        'Restangular',
        function (Restangular) {
            var restFul = Restangular.all("api/indicadoresproyecto");

            return function getIndicadoresProyecto(scope) {
                Restangular.one("api/indicadoresproyecto/" + scope.indicadoresparams.idProyecto).get().then(
                    function addtoScope(indicadoresobject) {

                        scope.indicadoresobject = indicadoresobject
                        scope.objectives = indicadoresobject.objectives;
                        scope.postRestangular = restFul;
                        
                    }
                );
            }
        }
    ]
)