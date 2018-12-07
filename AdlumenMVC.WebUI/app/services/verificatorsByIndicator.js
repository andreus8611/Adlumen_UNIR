'use strict';
adlumenApp.service("verificadoresPorIndicadorAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getVerificadoresIndicador(scope) {
                Restangular.one("api/indicadoresverificadores/" + scope.indicador.id ).get().then(
                    function addtoScope(verificador) {
                        scope.verificador = verificador
                        scope.verificadores = verificador.verificadores;
                    }
                );
            }
        }
    ]
)