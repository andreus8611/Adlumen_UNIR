'use strict';
adlumenApp.service("donantesAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getDonantes(scope) {
                Restangular.all("api/donantes").getList().then(
                    function addtoScope(donantes) {
                        scope.donantes = donantes;
                    }
                );
            }
        }
    ]
)