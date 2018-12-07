'use strict';
adlumenApp.service("variablesAPI",
    [
        'Restangular',
        function (Restangular) {
            this.getVariables = function () {
                return Restangular.all("api/variables").getList();
            }

            this.getRestAll = function () {
                return Restangular.all("api/variables");
            }
        }
    ]
)