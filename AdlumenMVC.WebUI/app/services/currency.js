'use strict';
adlumenApp.service("monedaAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getMonedas(scope) {
                Restangular.all("api/monedas").getList().then(
                    function addtoScope(monedas) {

                        scope.monedas = monedas;

                    }
                );
            }
        }
    ]
)