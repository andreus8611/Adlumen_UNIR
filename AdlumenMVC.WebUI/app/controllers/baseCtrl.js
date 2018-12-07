'use strict';
adlumenApp.controller('baseCtrl',
    [
        '$scope', '$uibModal', 'authService', 'languageService', 'translationService', 'tareaAPI', 'mensajeAPI', 'empresasAPI', 'cuestionarioAPI', '$window',
        function ($scope, $uibModal, authService, languageService, translationService, tareaAPI, mensajeAPI, empresasAPI, cuestionarioAPI, $window) {
            
            $scope.changeLanguage = function (lang) {
                languageService.set(lang);
                $scope.selectedLanguage = lang;
                translate();
                $window.location.href = '#!/dashboardCtrl'
               
            };

            $scope.logOut = function () {
                authService.logOut();
            };

            var translate = function () {
                translationService.getTranslation($scope, $scope.selectedLanguage);
              
            };

            //Init

            $scope.authentication = authService.authentication;

            $scope.loadAdminJs = function() {
                loadScript('/Scripts/AdminLTE/app.js');
            }

            //Tasks

            tareaAPI($scope);
            mensajeAPI($scope);
            empresasAPI($scope);
            cuestionarioAPI($scope);
            $scope.$watchCollection('[tasks, mensajes, bdUser]', function (newValue, oldValue) {

                if (newValue != oldValue) {
                    if (!_.isUndefined(newValue[0]) && !_.isUndefined(newValue[2])) {
                        if (_.indexOf(newValue[2].roles, "Admin") === -1 && _.indexOf(newValue[2].roles, "manager") === -1) {
                            $scope.tareas = _.where(newValue[0], { idResponsable: newValue[2].idLocal, idUsuarioCompletado: null });
                        }
                        else {
                            $scope.tareas = _.where(newValue[0], { idUsuarioCompletado: null });
                        }
                    }

                    if (!_.isUndefined(newValue[1]) && !_.isUndefined(newValue[2])) {
                        $scope.messages = _.where(newValue[1], { idUsuarioDestinatario: newValue[2].idLocal, idEstado: 1 });
                    }
                }
            });


            $scope.forms = {};
            $scope.base = {};
            $scope.base.phoneRegex = /^\+?[0-9 \-]{6,15}$/;

            // Global Alerts
            $scope.globalAlerts = [];

            $scope.addGlobalAlert = function(type, msg, timeout) {
                if (timeout !== null && !timeout) //si es null, la dejamos persistente, si es otra cosa falsey:
                    timeout = 5000; //asignamos valor default

                var alert = { 'type': type, 'msg': msg, 'timeout': timeout };
                $scope.globalAlerts.push(alert);
            }

            $scope.closeGlobalAlert = function(index) {
                $scope.globalAlerts.splice(index, 1);
            }
            // //Global Alerts

            $scope.confirmDelete = function(options, action, param) {

                $scope.mensajeConfirmacion = options.msg;

                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: 'modalConfirmation.html',
                    controller: 'modalConfirmationInstanceCtrl',
                    size: 'sm',
                    resolve: {
                        mensaje: function() {
                            return $scope.mensajeConfirmacion;
                        }
                    }
                });

                modalInstance.result.then(function(response) {
                    action(param);
                },
                    function() {
                });
            }

            //$scope.closeAlert = function(index) {
            //    $scope.alerts.splice(index, 1);
            //}
        }
    ]
);

