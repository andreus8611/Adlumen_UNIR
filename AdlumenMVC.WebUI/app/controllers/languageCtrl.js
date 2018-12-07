'use strict';
adlumenApp.controller('languageCtrl',
    [
        '$scope', 'languageService',
        function ($scope, languageService) {

            $scope.selected;
            languageService.init();
            $scope.changeLanguage = function changeLanguage(lang) {
                languageService.set(lang);
                $scope.selected = lang;
            };

            $scope.updateLanguage = function () {
                $scope.changeLanguage($scope.selected);
            }

        }
    ]
);