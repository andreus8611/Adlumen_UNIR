'use strict';
adlumenApp.controller('evaluacionCtrl',
    [
        '$scope', 'translationService', 'languageService',
        function ($scope, translationService, languageService) {
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