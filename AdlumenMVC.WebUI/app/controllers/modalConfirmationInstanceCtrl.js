'use strict';
adlumenApp.controller('modalConfirmationInstanceCtrl',
    [
        '$scope', '$uibModalInstance', 'mensaje', 'translationService', 'languageService',
        function ($scope, $uibModalInstance, mensaje, translationService, languageService) {
            $scope.mensajeConfirmacion = mensaje;

            $scope.ok = function () {
                $uibModalInstance.close(true);
            };

            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
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