'use strict';
adlumenApp.service("donanteAPI",
    [
        'Restangular',
        function (Restangular) {
            this.getRestAll = function () {
                var restAll = Restangular.all("api/donantes");
                return restAll;
            }
        }
    ]
)