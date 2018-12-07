'use strict';
adlumenApp.service("tenantsAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getTenant(scope) {
                Restangular.all("api/tenants").getList().then(
                    function addtoScope(tenants) {
                        scope._tenants = tenants;
                    }
                );
            }
        }
    ]
)