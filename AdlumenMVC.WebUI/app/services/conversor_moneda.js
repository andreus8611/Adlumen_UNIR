'use strict';
adlumenApp.service("conversorMonedaAPI",
    [
        'Restangular',
        function (Restangular) {

            this.getTipoCambio = function (scope) {
                var restOne = Restangular.one("api/conversormonedas/" + scope.conversorparams.idMoneda);
                return restOne.get();
            }

        }
    ]
)