'use strict';
adlumenApp.controller('bitacoraCtrl',
    [
        '$scope', '$uibModal', 'bitacoraAPI', 'visitaAPI', 'importBitacoraAPI', 'translationService', 'languageService', '$stateParams',
        function ($scope, $uibModal, bitacoraAPI, visitaAPI, importBitacoraAPI, translationService, languageService, $stateParams) {

            var localidtarea = parseInt($stateParams.idTarea);

            var localidusuario = 0;

            $scope.idVisita = ($stateParams.idVisita);

            //Translation
            //Run translation if selected language changes
            $scope.translate = function () {
                translationService.getTranslation($scope, $scope.selectedLanguage);
            };

            //Init
            $scope.selectedLanguage = languageService.get();
            $scope.translate();

            //Initialize Form
            bitacoraAPI($scope);

            $scope.logNuevo = { idBitacora: 0, fecha: Date.now(), idUsuario: null };

            $scope.$watch('bdUser', function (newValue, oldValue) {

                localidusuario = newValue.idLocal;
                $scope.logNuevo.idUsuario = localidusuario;

            });

            $scope.newLog = false;
            $scope.showAlert = false;
            
            //Form functions
            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            };

            $scope.getUserName = function (log) {
                var userName;
                if (log.sys_Usuarios) {
                    userName = log.sys_Usuarios.nombre;
                }
                return userName;
            }

            $scope.getFormatedDate = function (dateToFormat) {
                var date = new Date(dateToFormat);
                var day = date.getDay();        // yields day
                var month = date.getMonth();    // yields month
                var year = date.getFullYear();  // yields year
                var hour = date.getHours();     // yields hours 
                var minute = date.getMinutes(); // yields minutes
                var second = date.getSeconds(); // yields seconds

                var time = year + "/" + month + "/" + day + " " + hour + ':' + minute + ':' + second;
                return time;
            }

            $scope.enableEditing = function () {
                if ($scope.visita !== undefined) {
                    if ($scope.visita.estado === 'A') { //active
                        if ($scope.visita.tar_Tareas.idResponsable == localidusuario ||
                            $scope.visita.tar_Tareas.idUsuarioCreacion == localidusuario) {
                            return true;
                        }
                        else {
                            var permisos = $scope.visita.tar_Permisos_Bitacora;
                            var allowed = false;
                            var i = 0;

                            for (i = 0; i < permisos.length; i++) {
                                if (permisos[i].idUsuario === localidusuario && permisos[i].permiso && permisos[i].permiso.indexOf("WB") !== -1) {
                                    allowed = true;
                                }
                            }

                            return allowed;
                        }
                    }
                    else {
                        return false;
                    }
                }
            };

            //Operations
            $scope.addBitacora = function () {
                $scope.alerts = [];

                var areErrors = false;

                if ($scope.logNuevo.comentario === undefined) {
                    areErrors = true;
                    addAlert('danger', $scope.translation["ERROR_CAMPOS_VACIOS"]);
                }

                if (!areErrors) {

                    $scope.logNuevo.action = "addmodify";
                    $scope.logNuevo.idVisita = $scope.idVisita;
                    $scope.logNuevo.formatedDateTime = $scope.getFormatedDate($scope.logNuevo.fecha);

                    $scope.todasLasBitacoras.post($scope.logNuevo).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_BITACORA_GUARDADA"]);

                        $scope.logNuevo = { idBitacora: 0, fecha: Date.now() };
                        $scope.newLog = false;
                        bitacoraAPI($scope);

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            };

            $scope.resetBitacora = function (logNuevo) {
                $scope.logNuevo = { idBitacora: 0, fecha: Date.now() };
                $scope.newLog = false;
            };

            //post a la base de datos con el archivo de excel.
            function saveLogRecords(archivo) {

                $scope.alerts = [];
                var areErrors = false;

                var logsArray = [];

                var i = 0;
                for (i = 0; i < archivo.length; i++) {
                    var logImport = {};
                    logImport.idVisita = $scope.idVisita;
                    logImport.formatedDateTime = archivo[i].date;
                    logImport.comentario = archivo[i].comment;

                    logsArray.push(logImport);
                }

                if (!areErrors) {

                    importBitacoraAPI.postRestangular.post({ logsArray: logsArray }).then(
                    function () {

                        $scope.logNuevo = { idBitacora: 0, fecha: Date.now() };
                        $scope.newLog = false;
                        bitacoraAPI($scope);

                    },
                    function () {
                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);
                    });
                }
            };

            //abrir el modal para cargar el archivo de excel
            $scope.openModal = function () {

                var modalInstance = $uibModal.open({
                    templateUrl: '/app/templates/visitas/importarBitacora.html',
                    controller: 'modalImportLogCtrl'

                });

                modalInstance.result.then(function (content) {

                    saveLogRecords(content.archivo);

                }, function () {
                    addAlert('danger', $scope.translation["ERROR_INESPERADO_IMPORTANDO_LOG"]);
                });
            };
        }
    ]
);