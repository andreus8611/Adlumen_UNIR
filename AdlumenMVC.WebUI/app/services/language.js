'use strict';
adlumenApp.service("idiomasAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getIdiomas(scope) {
                Restangular.all("api/idiomas").getList().then(
                    function addtoScope(idiomas) {
                        scope.idiomas = idiomas;
                    }
                );
            }
        }
    ]
)