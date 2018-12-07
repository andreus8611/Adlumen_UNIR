'use strict';
adlumenApp.service("projectAPI",
    [
        'Restangular',
        function (Restangular) {
            return function (scope) {
                Restangular.all("api/projects").getList().then(
                    function getProjects(projects) {
                        scope.projects = projects;
                    }
                );
            }
        }
    ]
)