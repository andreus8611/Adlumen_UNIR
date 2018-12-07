'use strict';
adlumenApp.controller('projectsCtrl',
    [
        '$scope', 'projectAPI',
        function ($scope, projectAPI) {

            projectAPI($scope);

        }
    ]
);