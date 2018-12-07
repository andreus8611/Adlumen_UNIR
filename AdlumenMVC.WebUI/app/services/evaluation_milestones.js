'use strict';
adlumenApp.service("evaluacionHitosAPI",
    [
        'Restangular',
        function (Restangular) {
            var restFul = Restangular.all("api/evaluacionhitos");

            return function getEvaluacionesHitos(scope) {
                Restangular.one("api/evaluacionhitos/" + scope.evaluacionparams.idPeriodo).get().then(
                    function addtoScope(evaluacionhitosobject) {

                        scope.evaluacionhitosobject = evaluacionhitosobject
                        scope.evaluacioneshitos = evaluacionhitosobject.evaluacionesHitos;
                        scope.postRestangular = restFul;
                        scope.setFiltered();
                    }
                );
            }
        }
    ]
)