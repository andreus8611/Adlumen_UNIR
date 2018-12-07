'use strict';
adlumenApp.service("cuestionarioAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getCuestionario(scope) {
                Restangular.one("api/cuestionario/" + scope.idEncuesta).get().then(
                    function addtoScope(cuestionario) {

                        scope.cuestionario = cuestionario;

                    }
                );
                Restangular.all("api/cuestionario").getList().then(
                    function addtoScope(cuestionarios) {

                        scope.cuestionarios = cuestionarios;

                    }
                );
            }
        }
    ]
)