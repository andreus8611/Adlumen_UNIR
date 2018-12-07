'use strict';
adlumenApp.controller('permisosBitacoraCtrl',
    [
        '$scope', 'permisosBitacoraAPI', 'translationService', 'languageService', '$stateParams',
        function ($scope, permisosBitacoraAPI, translationService, languageService, $stateParams) {

            $scope.idVisita = $stateParams.idVisita;

            //Translation
            //Run translation if selected language changes
            $scope.translate = function () {
                translationService.getTranslation($scope, $scope.selectedLanguage);
            };

            //Init
            $scope.selectedLanguage = languageService.get();
            $scope.translate();

            //Initialize Form
            permisosBitacoraAPI($scope);

            $scope.showAlert = false;

            //Form functions
            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            };

            $scope.submitPermisos = function () {

                $scope.alerts = [];

                var areErrors = false;

                if (!areErrors) {

                    $scope.todosLosPermisos.post($scope.permisos).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_PERMISOS_BITACORA_GUARDADA"]);

                        permisosBitacoraAPI($scope);

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }

            };

        }
    ]
);