'use strict';
adlumenApp.service("beneficiariosCapacitacionAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getBeneficiariosCapacitacion(scope) {
                Restangular.all("api/beneficiariosCapacitacion").getList().then(
                    function addtoScope(beneficiariosCapacitacion) {
                        scope.beneficiariosCapacitacion = beneficiariosCapacitacion;
                    }
                );
            }
        }
    ]
)