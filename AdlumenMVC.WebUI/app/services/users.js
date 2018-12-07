'use strict';
adlumenApp.service("usuariosAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getUsuarios(scope) {
                Restangular.all("api/usuarios").getList().then(
                    function addtoScope(usuarios) {
                        scope.usuarios = usuarios;
                    }
                );
            }
        }
    ]
)