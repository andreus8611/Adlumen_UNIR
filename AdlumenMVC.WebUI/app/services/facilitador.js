'use strict';
adlumenApp.service('facilitadorAPI',
    [
        'Restangular',
        function (Restangular) {
            return function getFacilitadores(scope) {
                Restangular.all("api/facilitadores").getList().then(
                    function addtoScope(facilitadores) {
                        scope._facilitadores = facilitadores;
                    }
                );
            }
        }
    ]
)