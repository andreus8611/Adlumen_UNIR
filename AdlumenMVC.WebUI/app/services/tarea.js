'use strict';
adlumenApp.service("tareaAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getTarea(scope) {
                Restangular.all("api/tareas").getList().then(
                    function addtoScope(tareas) {
                        scope.tasks = tareas;
                    }
                );
            }
        }
    ]
)