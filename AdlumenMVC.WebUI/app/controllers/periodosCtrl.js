'use strict';
adlumenApp.controller('periodosCtrl',
    [
        '$scope', 'periodAPI', 'projectAPI',
        function ($scope, periodAPI, projectAPI) {
            
            periodAPI($scope);

            projectAPI($scope);

            $scope.showAlert = false;

            $scope.prueba = $scope.periodsList;

            $scope.showPeriods = function(idProject) {
                $scope.periodsByProject = _.result($scope.periodsList, idProject);
            }

            var addAlert = function (varType, varMsg) {
                $scope.alert = { type: varType, msg: varMsg }
                $scope.showAlert = true;
            };

            $scope.changeState = function (varidProyecto, varidPeriodo) {

                var periodToChange = _.where($scope.periods, { idProyecto: varidProyecto, idPeriodo: varidPeriodo });

                if (periodToChange[0].activo != true) {

                    periodToChange[0].post().then(
                        function () {
                            addAlert('success', 'El período se activo con éxito!!');
                            console.log("Object saved OK");
                        }, function () {
                            addAlert('danger', 'Ha ocurrido un error consulte con el administrador del sistema!!');
                            console.log("There was an error saving");
                        });

                } else {
                    addAlert('danger', 'El período ya se encuentra activo');

                }

            }

        }
    ]
);