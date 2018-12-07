'use strict';
adlumenApp.service("evaluacionProyectoPeriodoAPI",
    [
        'Restangular',
        function (Restangular) {
            var restFul = Restangular.all("api/evaluacionperiodoproyecto");

            return function getEvaluacionesProyectoPeriodo(scope) {
                Restangular.one("api/evaluacionperiodoproyecto/" + scope.evaluacionparams.idProyecto).get().then(
                    function addtoScope(evaluacionproyectoperiodoobject) {

                        scope.evaluacionproyectoperiodoobject = evaluacionproyectoperiodoobject
                        scope.evaluacionesproyectoperiodo = evaluacionproyectoperiodoobject.evaluacionesProyectoPeriodo;
                        scope.postRestangular = restFul;
                        scope.setFilteredProjects();

                    }
                );
            }
        }
    ]
)