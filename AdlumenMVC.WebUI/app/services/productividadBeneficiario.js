'use strict';
adlumenApp.service("productividadBeneficiarioAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getProductividadBeneficiario(scope) {
                Restangular.all("api/beneficiarioProductividades").getList().then(
                    function addtoScope(productividadbeneficiario) {
                        scope.productividadbeneficiario = productividadbeneficiario;
                    }
                );
            }
        }
    ]
)