'use strict';
adlumenApp.service("listAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getListas(scope) {
                Restangular.all("api/listas").getList().then(
                    function addtoScope(listas) {
                        scope.listas = listas;

                    }
                );
            }
        }
    ]
)