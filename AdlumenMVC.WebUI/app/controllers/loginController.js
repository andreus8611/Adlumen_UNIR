'use strict';
adlumenApp.controller('loginCtrl', ['$scope', '$location', 'authService', 'ngAuthSettings', function ($scope, $location, authService, ngAuthSettings) {

    $scope.loginData = {
        userName: "",
        password: "",
        useRefreshTokens: false
    };

    $scope.message = "";

    $scope.login = function () {
       
        authService.login($scope.loginData).then(function (response) {

            $location.path('/');

        },
         function (err) {
             alert(err.error_description)
             $scope.message = err.error_description;
         });
    };

    $scope.authExternalProvider = function (provider) {

        var redirectUri = location.protocol + '//' + location.host + '/authcomplete.html';

        var externalProviderUrl = ngAuthSettings.apiServiceBaseUri + "api/Account/ExternalLogin?provider=" + provider
                                                                    + "&response_type=token&client_id=" + ngAuthSettings.clientId
                                                                    + "&redirect_uri=" + redirectUri;
        window.$windowScope = $scope;

        var oauthWindow = window.open(externalProviderUrl, "Authenticate Account", "location=0,status=0,width=600,height=750");
    };

    $scope.authCompletedCB = function (fragment) {

        $scope.$apply(function () {

            if (fragment.haslocalaccount == 'False') {

                authService.logOut();

                authService.externalAuthData = {
                    provider: fragment.provider,
                    userName: fragment.external_user_name,
                    externalAccessToken: fragment.external_access_token
                };

                $location.path('/associate');

            }
            else {
                //Obtain access token and redirect to orders
                var externalData = { provider: fragment.provider, externalAccessToken: fragment.external_access_token };
                authService.obtainAccessToken(externalData).then(function (response) {

                    $location.path('/orders');

                },
             function (err) {
                 $scope.message = err.error_description;
             });
            }

        });
    }

    $scope.sendRecovery = function() {
        if (!$scope.recoveryEmail) {
            return;
        }
        $scope.recoveryEmailSent = $scope.errorEmail = false;

        authService.sendRecovery($scope.recoveryEmail).then(
            function(response) {
                $scope.recoveryEmailSent = true;
            },
            function(error) {
                $scope.errorEmail = true;
            }
        );
    }

    $scope.resetPassword = function() {
        var regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*(_|[\W])).*$/g;
        if (!$scope.pass1 || !$scope.pass2 ||
            $scope.pass1.length < 6 ||
            $scope.pass1 != $scope.pass2 ||
            !(regex.test($scope.pass1))) {
            $scope.errorPass = true;
            return;
        }

        $scope.resetSuccess = $scope.errorPass = $scope.errorLink = false;
        var query = $location.search();

        authService.resetPassword(query.key, query.code, $scope.pass1).then(
            function(response) {
                $scope.resetSuccess = true;
            },
            function(error) {
                $scope.errorLink = true;
            }
        );
    }
}]);
