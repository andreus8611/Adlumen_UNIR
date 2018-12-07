'use strict';
adlumenApp.service('languageService',
    [
        '$locale', '$http', '$cookies', '$window',
        function ($locale, $http, $cookies, $window) {
            var supportedLanguages = ['en', 'fr', 'es']; //Add the supported languages by MySign in this array

            var lang = 'en'; //by default, set the lang cookie in english but we might change it

            this.init = function init() {
                //If the cookie lang is not set, try to fetch the language of the navigator, otherwise, we use english.
                if (_.isUndefined($cookies.get('lang'))) {
                    var language = $window.navigator.language || $window.navigator.userLanguage;
                    language = language.substr(0, 2); // get the lang to the ISO639-1 format 
                    console.info('cookie lang not set, language found', language);
                    if (supportedLanguages.indexOf(language) !== -1)
                        $cookies.put('lang', language);
                    else
                        $cookies.put('lang', lang);

                    this.set($cookies.get('lang'), 'init');
                }
            };

            this.get = function get() {
                return $cookies.get('lang');
            };

            this.set = function set(language, context) {

                console.info('Set language', language);

                $locale.id = language;
                $cookies.put('lang', language);

            };
        }
    ]
)