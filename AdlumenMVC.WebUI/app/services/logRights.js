'use strict';
adlumenApp.service("permisosBitacoraAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getPermisos(scope) {
                Restangular.all("api/permisosbitacora").getList().then(
                    function addtoScope(permisos) {

                        scope.permisos = _.filter(permisos, function (_permisos) {
                            return _permisos.idVisita == scope.idVisita;
                        });

                        scope.todosLosPermisos = permisos;
                    }
                );
            }
        }
    ]
)