'use strict';
adlumenApp.service("empresaAPI",
    [
        'Restangular',
        function (Restangular) {

            this.getEmpresa = function (scope) {
                var restOne = Restangular.one("api/empresas/" + scope.empresasparams.idEmpresa);
                return restOne.get();
            }

            this.getRestAll = function () {
                var restAll = Restangular.all("api/empresas");
                return restAll;
            }
        }
    ]
)