'use strict';
adlumenApp.service("preguntasAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getPreguntas(scope) {
                Restangular.all("api/preguntas").getList().then(
                    function addtoScope(preguntas) {

                        scope.preguntas = _.filter(preguntas, function (_pregunta) {
                            return _pregunta.idEncuesta == scope.idEncuesta;
                        });

                        scope.todasLasPreguntas = preguntas;
                    }
                );
            }
        }
    ]
)