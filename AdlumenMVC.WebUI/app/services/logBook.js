'use strict';
adlumenApp.service("bitacoraAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getBitacora(scope) {
                Restangular.all("api/bitacora").getList().then(
                    function addtoScope(bitacora) {

                        scope.logs = _.filter(bitacora, function (_bitacora) {
                            return _bitacora.idVisita == scope.idVisita;
                        });

                        scope.todasLasBitacoras = bitacora;
                    }
                );
            }
        }
    ]
)