'use strict';
adlumenApp.service("empresasAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getEmpresas (scope) {
                Restangular.all("api/empresas").getList().then(
                    function addtoScope(empresas) {
                        scope.empresas = empresas;
                    }
                );
            }
        }
    ]
)