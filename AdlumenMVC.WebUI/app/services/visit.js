'use strict';
adlumenApp.service("visitaAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getVisita(scope) {
                Restangular.one("api/visitas/" + scope.idVisita).get().then(
                    function addtoScope(visita) {

                        scope.visita = visita;

                    }
                );
            }
        }
    ]
)