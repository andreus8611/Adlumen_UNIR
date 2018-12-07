'use strict';
adlumenApp.service("usuarioAPI",
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