'use strict';
adlumenApp.service("encuestaAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getEncuesta(scope) {
                Restangular.one("api/encuestas/" + scope.idEncuesta).get().then(
                    function addtoScope(encuesta) {

                        scope.encuesta = encuesta;

                    }
                );
            }
        }
    ]
)