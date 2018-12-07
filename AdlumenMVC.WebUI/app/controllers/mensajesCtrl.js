'use strict';
adlumenApp.controller('mensajesCtrl',
    [
        '$scope', 'mensajeAPI','usuarioAPI','translationService','languageService', '$sce', 'Restangular', '$http', '$q', '$location', '$window',
        function ($scope, mensajeAPI, usuarioAPI, translationService, languageService, $sce, Restangular, $http, $q, $location, $window) {

            mensajeAPI($scope);

            usuarioAPI($scope);

            $scope.message = {};

            $scope.views = { showInbox: true, showSent: false, showDraft: false, showCompose: false, showDeleted: false };

            $scope.tinymceOptions = {
                menubar: false,
                statusbar: false,
                plugins: 'lists',
                language: 'es',
                toolbar1: 'insertfile | styleselect | bold italic underline | bullist numlist outdent indent',
                style_formats: [
                    { title: 'Encabezado 1', block: 'h1' },
                    { title: 'Encabezado 2', block: 'h2' },
                    { title: 'Encabezado 3', block: 'h3' },
                    { title: 'Encabezado 4', block: 'h4' },
                    { title: 'Encabezado 5', block: 'h5' },
                    { title: 'Encabezado 6', block: 'h6' }
                ]
            }

            $scope.setMessageView = function (id, lastView, message) {
                _.each($scope.views, function (value, key) {
                    $scope.views[key] = false;
                });
                $scope.attachmentName = null;
                $scope.attachmentKey = null;
                switch (id) {
                    case 1:
                        $scope.views.showInbox = true;
                        break;
                    case 2:
                        $scope.views.showSent = true;
                        break;
                    case 3:
                        $scope.views.showDraft = true;
                        break;
                    case 4:
                        $scope.views.showCompose = true;
                        break;
                    case 5:
                        $scope.views.showDeleted = true;
                        break;
                    case 6:
                        $scope.views.showReadMessage = true;
                        if (!_.isUndefined(lastView) && !_.isUndefined(message)) {
                            $scope.lastView = lastView;
                            $scope.selectedMessage = message;
                            $scope.checkForAttachment(message);
                        }
                        break;
                }
            };

            $scope.checkForAttachment = function (message) {
                $http.get('api/mensajes/GetAttachmentUrl?idMessage=' + message.idMensaje).then(function (response) {
                    $scope.attachmentName = response.data.name;
                    $scope.attachmentKey = response.data.key;
                });
            }

            $scope.validateAttachment = function (element) {
                if (element.files[0].size > (32 * 1024 * 1024)) {
                    alert("Tamaño máximo: 32 MB");
                    element.value = "";
                }
                else {
                    var fileName = element.files[0].name;
                    $('#custom-file-label').html(fileName);
                }
            }

            $scope.$watchCollection('[bdUser, mensajes]', function (newValue, oldValue) {

                if (!_.isUndefined(newValue[1]) && !_.isUndefined(newValue[0])) {
                    $scope.user = newValue[0];
                    $scope.messages = newValue[1];
                    $scope.inbox = _.filter($scope.messages, function (message) {
                        return message.idEstado != 3 && message.idUsuarioDestinatario === $scope.user.idLocal;
                    });

                    $scope.newMessages = (_.where($scope.inbox, { idEstado: 1 })).length;

                    $scope.deleted = _.filter($scope.messages, function (message) {
                        return message.idEstado === 3 && (message.idUsuarioDestinatario === $scope.user.idLocal || message.idUsuarioRemitente === $scope.user.idLocal);
                    });

                    $scope.draft = _.filter($scope.messages, function (message) {
                        return message.idEstado === 4;
                    });

                    $scope.sent = _.filter($scope.messages, function (message) {
                        return message.idUsuarioRemitente === $scope.user.idLocal && message.idEstado != 3;
                    });

                }

            });

            $scope.dateAgo = function (dateEval) {

                var value;

                var datediff = (new Date()).getTime() - dateEval.getTime();

                var days = datediff / (1000 * 60 * 60 * 24);

                var years = datediff / (1000 * 365 * 60 * 60 * 24);

                var hours = datediff / (1000 * 60 * 60);

                var minutes = datediff / (1000 * 60);

                var months = datediff / (1000 * 60 * 60 * 24 * 30);


                if (days.toFixed() >= 1 || days.toFixed() <= 30) {
                    value = days.toFixed() + ' ' + $scope.translation.DIAS;
                } else if (month.toFixed() >= 1 || days.toFixed() <= 12) {
                    value = days.toFixed() + ' ' + $scope.translation.MESES;
                } else if (years.toFixed() >= 1 || days.toFixed() <= 12) {
                    value = days.toFixed() + ' ' + $scope.translation.MESES;
                } else if (month.toFixed() >= 1 || days.toFixed() <= 12) {
                    value = days.toFixed() + ' ' + $scope.translation.MESES;
                } else if (month.toFixed() >= 1 || days.toFixed() <= 12) {
                    value = days.toFixed() + ' ' + $scope.translation.MESES;
                }

                return value;
            };

            $scope.showAlert = false;


             var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            }

            $scope.inputMensaje = {
                txtCorreo: "",
                txtAsunto: "",
                txtMensaje: "",
                txtPrioridad: "",
            }

            $scope.resetTexts = function () {
                $scope.inputMensaje.txtAsunto = "";
                $scope.inputMensaje.txtMensaje = "";
                
                $scope.newMensaje = false;
            };

            $scope.addMensaje = function () {
                $scope.message.idUsuarioRemitente = $scope.user.idLocal;
                $scope.message.prioridad = false;
                $scope.message.idEstado = 1;
                $scope.alerts = [];
                var data = new FormData();
                data.append('idUsuarioRemitente', $scope.user.idLocal);
                data.append('prioridad', false);
                data.append('idEstado', 1);
                data.append('idUsuarioDestinatario', $scope.message.idUsuarioDestinatario);
                data.append('asunto', $scope.message.asunto);
                data.append('mensaje', $scope.message.mensaje);
                
                if ($('#attachment')[0].files.length > 0) {
                    $scope.message.attachment = $('#attachment')[0].files[0];
                    data.append('attachment', $('#attachment')[0].files[0])
                }
                var defer = $q.defer();
                $http.post("/api/Mensajes/AddMensaje", data,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                }).then(
                    function (d) {
                        addAlert('success', $scope.translation.MENSAJE_BITACORA_GUARDADA);
                        mensajeAPI($scope);
                        $scope.setMessageView(1);
                    },
                    function () {
                        addAlert('danger', 'Error');
                    }
                );
                //Restangular.one('api/mensajes')
                //    .withHttpConfig({ transformRequest: angular.identity })
                //    .customPOST(data, '', undefined, { 'Content-Type': undefined })

                //$scope.mensajes.post($scope.message).then(function () {
                //    addAlert('success', $scope.translation.MENSAJE_BITACORA_GUARDADA);
                //    mensajeAPI($scope);
                //    setMessageView(1);
                //}, function (error) {
                //    addAlert('danger', error.data.exceptionMessage);
                //});
            }

            //Sirve para ver los mensajes Recibicos, Enviados
            $scope.selectMensajesRecibidos = function (mensaje) {
                $scope.newMensaje = mensaje;
                $scope.selected = true;
                $scope.Recibidos = false;
                $scope.leer = true;

            }
            $scope.selectMensajesEnviados = function (mensaje) {
                $scope.newMensaje = mensaje;
                $scope.selected = true;
                $scope.Enviados = false;
                $scope.leer = true;

            }
            $scope.selectMensajesElimados = function (mensaje) {
                $scope.newMensaje = mensaje;
                $scope.selected = true;
                $scope.Eliminados = false;
                $scope.leer = true;

            }
           
            
        //Sirve par cambiar color de los que no se ha leido
            $scope.set_color = function (mensaje) {
                if (mensaje.prioridad == true ) {
                    return {
                                             
                        'background-color': "#09A225",
                        color: 'white'
                    }
                if (mensaje.idEstado == 1) {
                    return {
                        'background-color': "#076F91",
                        color: 'black'
                    }

                }
               
               }
                
                
            }
///esta
            $scope.edit = function (mensaje, numero) {
                var noMensaje = mensaje.idMensaje;
                var numero2 = numero;
                $scope.newMensaje.put({ idMensaje: noMensaje, estado: numero2 }).then(function () {

                    mensajeAPI($scope);
                  
                }, function () {
                }

                );
            }

            $scope.displayHtml = function () {
                return $sce.trustAsHtml($scope.selectedMessage.mensaje);
            };
        }
    ]
);