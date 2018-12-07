//servicio para consumir api de periodos
'use strict';
adlumenApp.service("tcAPI",
    [
        'Restangular',
        function (Restangular) {

            var restFul = Restangular.all("api/tipcambios");

            this.postRestangular = restFul;

            this.getRestangular = restFul.getList();

        }
    ]
)