'use strict';
adlumenApp.service("financieroAPI",
    [
        'Restangular',
        function (Restangular) {
            this.getTotalesProyecto = function (scope) {
                return Restangular.one("api/financiero/" + scope.financieroparams.idProyecto).get();
            }

            this.getTotalesRestFul = function () {
                return Restangular.all("api/financiero");
            }
        }
    ]
)