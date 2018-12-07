'use strict';
adlumenApp.service("visitasAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getVisitas(scope) {
                Restangular.all("api/visitas").getList().then(
                    function addtoScope(visitas) {

                        scope.todasLasVisitas = visitas;

                    }
                );
            }
        }
    ]
)