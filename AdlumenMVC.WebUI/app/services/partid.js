'use strict';
adlumenApp.service("partidaAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getPartidas(scope) {
                Restangular.all("api/partidas").getList().then(
                    function addtoScope(partidas) {
                        scope.partidas = partidas;

                    }
                );  
            }
        }
    ]
)