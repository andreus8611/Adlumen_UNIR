'use strict';
adlumenApp.service("beneficiarioAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getBeneficiarios(scope) {
                Restangular.all("api/beneficiarios").getList().then(
                    function addtoScope(beneficiarios) {
                        scope.beneficiarios = beneficiarios;
                    }
                );
            }
        }
    ]
)