'use strict';
adlumenApp.service("indicatorAPI",
    [
        'Restangular',
        function (Restangular) {
            var restFul = Restangular.all("api/indicador");

            return function getIndicador(scope) {
                Restangular.one("api/indicador/" + scope.indicadorparams.idIndicador).get().then(
                    function addtoScope(indicador) {

                        scope.indicador = indicador;
                        scope.muestras = indicador.datosMuestra;
                        scope.postIndicador = restFul;

                    }
                );
            }
        }
    ]
)