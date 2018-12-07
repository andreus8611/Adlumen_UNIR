'use strict';
adlumenApp.service("indicadoresAPI",
    [
        'Restangular',
        function (Restangular) {

            this.getIndicadoresProyecto = function (scope) {
                var restOne = Restangular.one("api/indicadores/" + scope.objetivosparams.idObjetivo);
                return restOne.get();
            }

            this.getIndicadoresRestFul = function () {
                var restFul = Restangular.all("api/indicadores");
                return restFul;
            }
        }
    ]
)