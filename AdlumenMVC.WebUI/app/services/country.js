'use strict';
adlumenApp.service("paisesAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getPaises(scope) {
                Restangular.all("api/paises").getList().then(
                    function addtoScope(paises) {
                        scope.paises = paises;
                    }
                );
            }
        }
    ]
)