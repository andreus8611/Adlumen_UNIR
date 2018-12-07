'use strict';
adlumenApp.service("capacitacionAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getCapacitaciones(scope) {
                Restangular.all("api/capacitaciones").getList().then(
                    function addtoScope(capacitaciones) {
                        scope.capacitaciones = capacitaciones;
                    }
                );
            }
        }
    ]
)