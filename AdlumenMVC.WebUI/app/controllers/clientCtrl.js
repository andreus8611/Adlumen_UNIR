'use strict';
adlumenApp.controller('clientCtrl',
    [
        '$scope', 'clienteAPI', '$uibModal', '$log',
        function ($scope, clienteAPI, $uibModal, $log) {
            
            //get all clients

            var _setClients = function () {
                clienteAPI.getRestAll().getList().then(
                function (clients) {
                    $scope.clients = clients;
                });
            };

            _setClients();

            //open modal to show client's detail

            $scope.showDetail = function (client) {
                var modalInstance = $uibModal.open({
                    animation: false,
                    backdrop: 'static',
                    templateUrl: 'app/templates/client/client_modal.html',
                    controller: 'clientmodalCtrl',
                    size: 'lg',
                    resolve: {
                        client: function () {
                            return (_.isUndefined(client) ? null : client);
                        },

                        translation: function () {
                            return $scope.translation;
                        }
                    }
                });

                modalInstance.result.then(function (response) {
                    _setClients();
                },
                function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };

            //delete client

            $scope.confirmDeleteClient = function(client) {
                $scope.confirmDelete({ msg: $scope.translation['CONFIRM_DELETE'] }, $scope.deleteClient, client);
            }

            $scope.deleteClient = function(client) {
                $scope.client.remove().then(function() {
                    addAlert('success', $scope.translation['MSG_DELETED_ITEM']);
                    _setClients();
                },
                function(error) {
                    addAlert('danger', error.data.exceptionMessage);
                });
            };

            $scope.search = function(item) {
                var text = $scope.searchText;
                if (!text ||
                    (item.name && item.name.toLowerCase().indexOf(text.toLowerCase()) != -1)) {
                    return true;
                }
                return false;
            }
        }
    ]
);

adlumenApp.controller('clientsingleCtrl',
    [
        '$scope', 'clienteAPI', 'FileUploadService',
        function ($scope, clienteAPI, FileUploadService) {

            //initialize variables

            var clientInitialState = {};

            $scope.alerts = [];

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            }

            $scope.$watch('bdClient', function (newValue, oldValue) {
                if (newValue != null) {
                    newValue.orderDate = newValue.orderDate ? new Date(newValue.orderDate) : null;
                    newValue.expirationDate = newValue.expirationDate ? new Date(newValue.expirationDate) : null;
                }
                clientInitialState = newValue;
                $scope.client = clientInitialState;
            });

            //FileUpload

            var CheckFileValidImage = function (file) {
                var isValid = false;
                if (file != null) {
                    if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') && file.size <= (512 * 1024)) {
                        isValid = true;
                    }
                    else {
                        addAlert('danger', $scope.translation.ARCHIVO_IMAGEN_INVALIDO);
                        $scope.$apply();
                    }
                }
                else {
                    addAlert('danger', $scope.translation.SELECCIONE_ARCHIVO_PRIMERO);
                }
               return isValid;
            }

            $scope.SelectedPhotoForUpload = function (files) {
                var file = files[0];
                if (CheckFileValidImage(file) === true) {
                    var path = "/" + $scope.bdClient.id + "/";
                    FileUploadService.UploadFile(file, file.description , path).then(function (d) {
                        $scope.client.logo = FileUploadService.getSavedFilePath();
                    }, function (e) {
                        addAlert('danger', e);
                    });
                }
            }

            //datepicker configuration

            $scope.statusorderDate = { opened: false };

            $scope.openorderDate = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();
                $scope.statusorderDate.opened = true;
            };

            $scope.statusexpirationDate = { opened: false };

            $scope.openexpirationDate = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();
                $scope.statusexpirationDate.opened = true;
            };

            $scope.maxDate = new Date(2020, 5, 22);

            $scope.edit = function () {
                $scope.editMode = true;
            }

            $scope.cancel = function () {
                $scope.client = clientInitialState;
                $scope.editMode = false;
            }
            
            $scope.save = function () {
                if ($scope.editMode === true) {
                    $scope.client.put().then(
                        function (response) {
                            addAlert('success', $scope.translation.MENSAJE_BITACORA_GUARDADA);
                            $scope.editMode = false;
                        }, function (response) {
                            addAlert('danger', response.data.exceptionMessage);
                        });
                }
                
            }

            $scope.validate = function() {
                var diff = $scope.client.expirationDate - $scope.client.orderDate;
                if (Math.round(diff / (1000 * 60 * 60 * 24)) < 365) {
                    addAlert('danger', 'La fecha de expiración debe ser por lo menos un año mayor a la fecha de adquisición.');
                    return;
                }

                $scope.forms.client.$setSubmitted(true);
                var invalid = $scope.forms.client.$valid;
                return invalid;
            }

            $scope.closeAlert = function(index) {
                $scope.alerts.splice(index, 1);
            }
        }
    ]
);
adlumenApp.controller('clientmodalCtrl',
    [
        '$scope', 'clienteAPI', '$uibModalInstance', 'client', 'translation','$filter',
        function ($scope, clienteAPI, $uibModalInstance, client, translation, $filter) {

            //initialize variables

            $scope.translation = translation;

            $scope.alerts = [];

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            }

            if (_.isNull(client)) {
                $scope.client = {};
                $scope.client.orderDate = new Date();//.toLocaleDateString();
                $scope.client.orderDate.setHours(0, 0, 0, 0);
                $scope.client.expirationDate = new Date($scope.client.orderDate);
                $scope.client.expirationDate.setFullYear($scope.client.orderDate.getFullYear() + 1);
                $scope.editMode = false;
                $scope.headerTitle = translation.NUEVO + ' ' + translation.CLIENTE;
            }
            else {
                client.orderDate = client.orderDate ? new Date(client.orderDate) : null;
                client.expirationDate = client.expirationDate ? new Date(client.expirationDate) : null;
                $scope.client = client;
                $scope.editMode = true;
                $scope.headerTitle = translation.EDITAR + ' ' + translation.CLIENTE;
            }

            //datepicker configuration

            $scope.statusorderDate = { opened: false };

            $scope.openorderDate = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();
                $scope.statusorderDate.opened = true;
            };

            $scope.statusexpirationDate = { opened: false };

            $scope.openexpirationDate = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();
                $scope.statusexpirationDate.opened = true;
            };

            $scope.maxDate = new Date(2020, 5, 22);



            $scope.save = function () {
                if ($scope.editMode === true) {
                    $scope.client.put().then(
                        function (response) {
                            $uibModalInstance.close(response);
                        }, function (response) {
                            addAlert('danger', response.data.exceptionMessage);
                        });
                }
                else {
                    clienteAPI.save($scope.client).then(
                        function (response) {
                        $uibModalInstance.close(response);
                    }, function (response) {
                        addAlert('danger', response.data.exceptionMessage);
                    });
                }
            };

            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
            }

            $scope.validate = function() {
                var diff = $scope.client.expirationDate - $scope.client.orderDate;
                if (Math.round(diff / (1000 * 60 * 60 * 24)) < 365) {
                    addAlert('danger', 'La fecha de expiración debe ser por lo menos un año mayor a la fecha de adquisición.');
                    return;
                }

                $scope.forms.client.$setSubmitted(true);
                var invalid = $scope.forms.client.$valid;
                return invalid;
            }

            $scope.closeAlert = function(index) {
                $scope.alerts.splice(index, 1);
            }

            //FileUpload
            var CheckFileValidImage = function(file) {
                var isValid = false;
                if (file != null) {
                    if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') && file.size <= (512 * 1024)) {
                        isValid = true;
                    }
                    else {
                        addAlert('danger', $scope.translation.ARCHIVO_IMAGEN_INVALIDO);
                        $scope.$apply();
                    }
                }
                else {
                    addAlert('danger', $scope.translation.SELECCIONE_ARCHIVO_PRIMERO);
                }
                return isValid;
            }

            $scope.SelectedPhotoForUpload = function(files) {
                var file = files[0];
                if (CheckFileValidImage(file) === true) {
                    var path = "/" + $scope.bdClient.id + "/";
                    FileUploadService.UploadFile(file, file.description, path).then(function(d) {
                        $scope.client.logo = FileUploadService.getSavedFilePath();
                    }, function(e) {
                        addAlert('danger', e);
                    });
                }
            }
        }
    ]
);