'use strict';
adlumenApp.service("partidasGastosAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getPartidasGastos(scope) {
                Restangular.all("api/partidasgastos").getList().then(
                    function addtoScope(partidasgastos) {
                        scope.partidasgastos = partidasgastos;
                    }
                );
            }
        }
    ]
)