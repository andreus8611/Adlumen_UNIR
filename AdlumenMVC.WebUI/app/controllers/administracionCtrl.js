'use strict';
adlumenApp.controller('administracionCtrl',
    [
        '$scope', '$stateParams', '$uibModal', 'clienteAPI', 'donanteAPI', 'translationService', 'languageService', '$window',
        function ($scope, $stateParams, $uibModal, clienteAPI, donanteAPI, translationService, languageService, $window) {

            $scope.donante = null;
            $scope.selectedDonante = null;

            $scope.alerts = [];
            $scope.showAlert = false;

            $scope.empresas = [];
            $scope.projects = [];

            var x_idClient;

            //added by Ernesto Duarte
            $scope.$watch('bdClient', function (NewValue, OldValue) {
                x_idClient = NewValue.id;
                $scope.loadData(NewValue.id);
            });

            //Load services modified by Ernesto Duarte
            $scope.loadData = function (id) {
                clienteAPI.getProjectsByClient(id).get().then(
                    function addtoScope(cliente) {
                        $scope.cliente = cliente;
                    }
                );
            };

            //Empresas
            $scope.showEmpresaDetails = function () {
                $scope.idEmpresa = this.empresa.idEmpresa;
                $window.location.href = '#!/company/' + $scope.idEmpresa;
            }

            $scope.crearNuevaEmpresa = function () {
                $scope.idEmpresa = 0;
                $window.location.href = '#!/company/' + $scope.idEmpresa;
            }

            //Proyectos
            $scope.showProyectoDetails = function () {
                $scope.idProyecto = this.proyecto.idProyecto;
                $scope.$state.go('base.project', { idProyecto: $scope.idProyecto });
                //$window.location.href = '#!/project/' + $scope.cliente.id + '/' + $scope.idProyecto;
            }

            $scope.crearNuevoProyecto = function () {
                $scope.idProyecto = 0;
                $scope.$state.go('base.project', { idProyecto: $scope.idProyecto });
            }

            //Patrocinadores
            $scope.showDonanteDetails = function () {
                $scope.selectedDonante = angular.copy(this.donante);
                $scope.viewDonanteDetails();
            }

            $scope.viewDonanteDetails = function () {
                $scope.animationsEnabled = true;

                var modalInstance = $uibModal.open({
                    animation: $scope.animationsEnabled,
                    templateUrl: 'modalDonanteContent.html',
                    controller: 'donanteCtrl',
                    scope: $scope.$parent,
                    size: 'md',
                    resolve: {
                        donante: function () {
                            return $scope.selectedDonante;
                        },
                        idCliente: function () {
                            return $scope.cliente.id;
                        },
                        postDonante: function () {
                            return donanteAPI.getRestAll();
                        }
                    }
                });

                modalInstance.result.then(function () {
                    $scope.loadData(x_idClient);

                }, function () {

                });
            }

            $scope.crearNuevoDonante = function () {
                $scope.selectedDonante = { idDonante: 0 };
                $scope.viewDonanteDetails();
            }

            $scope.confirmDeleteDonante = function() {
                $scope.donante = angular.copy(this.donante);
                $scope.confirmDelete({ msg: $scope.translation["CONFIRM_DELETE"] }, $scope.deleteDonante);
            }

            $scope.deleteDonante = function() {
                $scope.selectedDonante = $scope.donante;
                $scope.selectedDonante.eliminado = true;
                $scope.selectedDonante.action = "modifyDonante";

                donanteAPI.getRestAll().post($scope.selectedDonante).then(function () {
                    addAlert('success', $scope.translation["MENSAJE_DONANTE_ELIMINADO"]);
                    $scope.loadData(x_idClient);
                },
                  function() {
                    addAlert('danger', $scope.translation["ERROR_GUARDADO"]);
                });
            }

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
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