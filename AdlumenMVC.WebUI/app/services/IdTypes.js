'use strict';
adlumenApp.service("idTypesAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getIdTypes(scope) {
                Restangular.all("api/identificaciontipo").getList().then(
                    function addtoScope(identificacionTipos) {
                        scope.identificacionTipos = identificacionTipos;
                    }
                );
            }
        }
    ]
)