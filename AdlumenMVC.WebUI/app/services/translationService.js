'use strict';
adlumenApp.service('translationService',
    [
        'Restangular',
        function (Restangular) {
            this.getTranslation = function (scope, language) {
                Restangular.one("api/translations", language).get().then(
                    function addtoScope(translations) {
                        scope.translation = translations;

                    });
                
            };
        }
    ]
);
