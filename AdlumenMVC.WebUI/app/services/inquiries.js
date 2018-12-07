'use strict';
adlumenApp.service("encuestasAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getEncuestas(scope) {
                Restangular.all("api/encuestas").getList().then(
                    function addtoScope(encuestas) {

                        scope.encuestas = encuestas;

                    }
                );
            }
        }
    ]
)