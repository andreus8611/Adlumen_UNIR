'use strict';
adlumenApp.service("objetivoAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getObjetivos(scope) {
                Restangular.all("api/objetivos").getList().then(
                    function addtoScope(objetivos) {

                        scope.objetivos = objetivos;

                    }
                );
            }
        }
    ]
)