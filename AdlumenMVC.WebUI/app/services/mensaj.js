'use strict';
adlumenApp.service("mensajeAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getMensajes(scope) {
                Restangular.all("api/mensajes").getList().then(
                    function addtoScope(mensajes) {
                        scope.mensajes = mensajes;

                    });
            }
  
        }
    ]
)