'use strict';
adlumenApp.service("importBitacoraAPI",
    [
        'Restangular',
        function (Restangular) {
            var restFul = Restangular.all("api/importarbitacora");
            this.postRestangular = restFul;
        }
    ]
)