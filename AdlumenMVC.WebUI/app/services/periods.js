'use strict';
//servicio para consumir api de periodos
adlumenApp.service("periodAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getPeriods(scope) {
                Restangular.all("api/periodos").getList().then(
                    function addtoScope(periodos) {

                        scope.periods = periodos;

                        scope.periodsList = _.groupBy(periodos, function(periodo){
                            return periodo.idProyecto;
                           
                            
                        });

                    }
                );
            }
        }
    ]
)