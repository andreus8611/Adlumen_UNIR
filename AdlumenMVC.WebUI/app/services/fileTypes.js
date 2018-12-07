'use strict';
adlumenApp.service("tiposArchivosAPI",
    [
        'Restangular',
        function (Restangular) {
            return function getTiposArchivos(scope) {
                Restangular.all("api/archivostipos").getList().then(
                    function addtoScope(archivostipos) {
                        scope.archivostipos = archivostipos;
                    }
                );
            }
        }
    ]
)