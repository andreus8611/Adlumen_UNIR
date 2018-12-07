'use strict';
adlumenApp.service("objetivosClaseAPI",
    [
        'Restangular',
        function (Restangular) {

            this.getObjetivosClases = function () {
                return Restangular.all("api/objetivosclases").getList();
            }

        }
    ]
)