'use strict';
adlumenApp.service("indicatorsTypesAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getIndicatorsTypes(scope) {
                Restangular.all("api/indicadorestipos").getList().then(
                    function addtoScope(indicadorestipos) {
                        scope.indicadorestipos = indicadorestipos;
                    }
                );
            }
        }
    ]
)