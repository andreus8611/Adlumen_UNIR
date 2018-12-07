'use strict';
adlumenApp.controller('modalAlertCtrl',
    [
        '$scope', '$uibModalInstance', 'mensaje', 'translationService', 'languageService',
        function ($scope, $uibModalInstance, mensaje, translationService, languageService) {
            $scope.mensajeAlert = mensaje;

            $scope.ok = function () {
                $uibModalInstance.close(true);
            };
            
            //Translation
            //Run translation if selected language changes
            $scope.translate = function () {
                translationService.getTranslation($scope, $scope.selectedLanguage);
            };

            //Init
            $scope.selectedLanguage = languageService.get();
            $scope.translate();
        }
    ]
);