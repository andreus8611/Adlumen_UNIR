'use strict';
adlumenApp.service("listasTareasAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getListasTareas(scope) {
                Restangular.all("api/listastareas").getList().then(
                    function addtoScope(listastareas) {
                        scope.listastareas = listastareas;
                    }
                );
            }
        }
    ]
)