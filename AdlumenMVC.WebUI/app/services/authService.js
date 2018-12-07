'use strict';
adlumenApp.factory('authService', ['$rootScope', 'usersService', '$http', '$q', 'localStorageService', 'ngAuthSettings', '$location', 'clienteAPI', function ($rootScope, usersService, $http, $q, localStorageService, ngAuthSettings, $location, clienteAPI) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        userName: "",
        useRefreshTokens: false
    };

    var _externalAuthData = {
        provider: "",
        userName: "",
        externalAccessToken: ""
    };

    var _save = function (registration) {
      //  _logOut();
        return $http.post(serviceBase + 'api/accounts/create', registration).then(function (response) {
            return response;
        });
    };

    var _login = function (loginData) {

        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

        if (loginData.useRefreshTokens) {
            data = data + "&client_id=" + ngAuthSettings.clientId;
        }

        var deferred = $q.defer();
  
        $http.post(serviceBase + 'oauth/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).then(
            function(res) {

                var response = res.data;

                if (loginData.useRefreshTokens) {
                    localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, refreshToken: response.refresh_token, useRefreshTokens: true });
                }
                else {
                    localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, refreshToken: "", useRefreshTokens: false });
                }

                _authentication.isAuth = true;
                _authentication.userName = loginData.userName;
                _authentication.useRefreshTokens = loginData.useRefreshTokens;

                deferred.resolve(response);

                usersService.getUserByName(_authentication.userName).then(function (results) {

                    $rootScope.bdUser = results.data;

                    clienteAPI.getCliente(results.data.client).then(function (serviceClient) {
                        $rootScope.bdClient = serviceClient;
                    });

                });

            },
            function(err, status) {
                _logOut();
                deferred.reject(err);
            }
        );
        return deferred.promise;
    };

    var _logOut = function () {

        localStorageService.remove('authorizationData');

        _authentication.isAuth = false;
        _authentication.userName = "";
        _authentication.useRefreshTokens = false;

        $location.path('/login');

    };

    var _fillAuthData = function () {
     
        var authData = localStorageService.get('authorizationData');

        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
            _authentication.useRefreshTokens = authData.useRefreshTokens;

            usersService.getUserByName(authData.userName).then(function (results) {

                $rootScope.bdUser = results.data;

                clienteAPI.getCliente(results.data.client).then(function (serviceClient) {
                    $rootScope.bdClient = serviceClient;
                });

            });

            $rootScope.$on('$stateChangeStart', function (event, toState, toParams) {
                if (toState.name === 'base.clients') {
                    if (_.indexOf($rootScope.bdUser, "Admin") === -1) {
                        $location.path('/client')
                    }
                }
            });

        }
        else {
            if ($location.$$path == '/resetPassword' && $location.$$search['key'] && $location.$$search['code']) {

            }
            else {
                $location.path('/login');
            }
        }

    };

    var _refreshToken = function () {
        var deferred = $q.defer();

        var authData = localStorageService.get('authorizationData');

        if (authData) {

            if (authData.useRefreshTokens) {

                var data = "grant_type=refresh_token&refresh_token=" + authData.refreshToken + "&client_id=" + ngAuthSettings.clientId;

                localStorageService.remove('authorizationData');

                $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).then(
                    function(res) {
                        var response = res.data;
                        localStorageService.set('authorizationData', { token: response.access_token, userName: response.userName, refreshToken: response.refresh_token, useRefreshTokens: true });
                        deferred.resolve(response);
                    },
                    function(err, status) {
                        _logOut();
                        deferred.reject(err);
                    }
                );
            }
        }

        return deferred.promise;
    };

    var _obtainAccessToken = function (externalData) {

        var deferred = $q.defer();

        $http.get(serviceBase + 'api/account/ObtainLocalAccessToken', { params: { provider: externalData.provider, externalAccessToken: externalData.externalAccessToken } }).then(
            function(res) {
                var response = res.data;
                localStorageService.set('authorizationData', { token: response.access_token, userName: response.userName, refreshToken: "", useRefreshTokens: false });

                _authentication.isAuth = true;
                _authentication.userName = response.userName;
                _authentication.useRefreshTokens = false;

                deferred.resolve(response);
            },
            function(err, status) {
                _logOut();
                deferred.reject(err);
            }
        );
        return deferred.promise;
    };

    var _registerExternal = function (registerExternalData) {

        var deferred = $q.defer();

        $http.post(serviceBase + 'api/account/registerexternal', registerExternalData).then(
            function(res) {
                var response = res.data;
                localStorageService.set('authorizationData', { token: response.access_token, userName: response.userName, refreshToken: "", useRefreshTokens: false });

                _authentication.isAuth = true;
                _authentication.userName = response.userName;
                _authentication.useRefreshTokens = false;

                deferred.resolve(response);
            },
            function(err, status) {
                _logOut();
                deferred.reject(err);
            }
        );

        return deferred.promise;
    };


    //var _getAllRolles = function () {
    //    //alert('test');
    //    return $http.get(serviceBase + 'api/roles').then(function (response) {
    //        return response;
    //    });

    //};

    var _sendRecovery = function(email) {

        var deferred = $q.defer();

        $http.post(serviceBase + 'api/accounts/ForgotPassword?email=' + email).then(
            function(res) {
                var response = res.data;

                deferred.resolve(response);
            },
            function(err, status) {
                deferred.reject(err);
            }
        );
        return deferred.promise;
    }

    var _resetPassword = function(userId, code, pass) {

        var deferred = $q.defer();

        $http.post(serviceBase + 'api/accounts/ResetPassword',
            { userId: userId, code: code, pass: pass }).then(
            function(res) {
                var response = res.data;
                deferred.resolve(response);
            },
            function(err, status) {
                deferred.reject(err);
            }
        );
        return deferred.promise;
    }

    authServiceFactory.save = _save;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;
    authServiceFactory.refreshToken = _refreshToken;

    authServiceFactory.obtainAccessToken = _obtainAccessToken;
    authServiceFactory.externalAuthData = _externalAuthData;
    authServiceFactory.registerExternal = _registerExternal;
    //authServiceFactory.getAllRoles = _getAllRolles;

    authServiceFactory.sendRecovery = _sendRecovery;
    authServiceFactory.resetPassword = _resetPassword;

    return authServiceFactory;
}]);