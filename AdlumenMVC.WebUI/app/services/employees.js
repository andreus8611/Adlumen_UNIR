'use strict';
adlumenApp.service("empleadosAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getEmpleados(scope) {
                Restangular.all("api/empleados").getList().then(
                    function addtoScope(empleados) {
                        scope.empleados = empleados;
                    }
                );
            }
        }
    ]
)