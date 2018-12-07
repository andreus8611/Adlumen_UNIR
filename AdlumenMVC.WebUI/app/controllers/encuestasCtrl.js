'use strict';
adlumenApp.controller('encuestasCtrl',
    [
        '$scope', 'encuestasAPI', 'idiomasAPI', 'translationService', 'languageService', '$window',
        function ($scope, encuestasAPI, idiomasAPI, translationService, languageService, $window) {

            encuestasAPI($scope);
            $scope.encuestaNueva = { idEncuesta: 0 };
            $scope.showAlert = false;
            $scope.newEncuesta = false;

            //Obtener la lista de idiomas
            idiomasAPI($scope);

            $scope.estados = [
                { id: 'A', name: 'ENCUESTA_ABIERTA' },
                { id: 'B', name: 'ENCUESTA_BLOQUEADA' },
                { id: 'E', name: 'ENCUESTA_ELIMINADA' },
                { id: 'T', name: 'ENCUESTA_TERMINADA' }
            ];

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            };

            $scope.closeAlert = function(index) {
                $scope.alerts.splice(index, 1);
            }

            $scope.editSelected = function () {
                $scope.encuestaNueva.idEncuesta = this.encuesta.idEncuesta;
                $scope.encuestaNueva.titulo = this.encuesta.titulo;
                $scope.encuestaNueva.descripcion = this.encuesta.descripcion;
                if ($scope.idiomas !== undefined) {
                    $scope.encuestaNueva.idioma = $scope.idiomas[$scope.getLanguageIndexById(this.encuesta.idIdioma)];
                }
                if (this.encuesta.estado === 'A') $scope.newEncuesta = true; //Sólo se pueden modificar las encuestas abiertas
            };

            $scope.editQuestions = function () {
                var encuestaId = this.encuesta.idEncuesta;
                $scope.encuestaSeleccionada = encuestaId;
                $window.location.href = '#!/inquiry_questions/' + encuestaId;
            };

            $scope.resolveQuestionnaire = function () {
                var encuestaId = this.encuesta.idEncuesta;
                $scope.encuestaSeleccionada = encuestaId;
                $window.location.href = '#!/questionnaire/' + encuestaId;
            };

            $scope.enableEditing = function () {
                if (this.encuesta !== undefined) {
                    if (this.encuesta.estado === 'A') //Sólo se pueden modificar las encuestas abiertas
                        return true;
                    else
                        return false;
                }
            };

            $scope.enableResolve = function () {
                if (this.encuesta !== undefined) {
                    if (this.encuesta.estado === 'B') //Sólo se pueden contestar las encuestas bloqueadas
                        return true;
                    else
                        return false;
                }
            };

            $scope.getLanguageIndexById = function (idIdioma) {
                if ($scope.idiomas !== undefined) {
                    for (var i = 0; i < $scope.idiomas.length; i++) {
                        if ($scope.idiomas[i].idIdioma === idIdioma)
                            return i;
                    }
                }
            }

            $scope.getLanguageDescription = function (encuesta) {
                var idiomaName;
                if ($scope.idiomas !== undefined)
                {
                    var idioma = $scope.idiomas[$scope.getLanguageIndexById(encuesta.idIdioma)];
                    if (idioma !== undefined)
                        idiomaName = idioma.nombre;
                }
                return idiomaName;
            }

            $scope.getEstadoIndexById = function (idEstado) {
                for (var i = 0; i < $scope.estados.length; i++) {
                    if ($scope.estados[i].id === idEstado)
                        return i;
                }
            }

            $scope.getEstadoDescription = function (encuesta) {
                var estadoName;
                var estado = $scope.estados[$scope.getEstadoIndexById(encuesta.estado)];
                if (estado !== undefined)
                    estadoName = estado.name;
                if ($scope.translation !== undefined)
                    estadoName = $scope.translation[estadoName];
                return estadoName;
            }

            $scope.addEncuesta = function () {
                $scope.alerts = [];

                var areErrors = false;

                if ($scope.encuestaNueva.titulo === undefined || $scope.encuestaNueva.descripcion === undefined || $scope.encuestaNueva.idioma === undefined) {
                    areErrors = true;
                    addAlert('danger', $scope.translation["ERROR_CAMPOS_VACIOS"]);
                }

                if (!areErrors) {

                    $scope.encuestaNueva.action = "addmodify";
                    $scope.encuestas.post($scope.encuestaNueva).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_ENCUESTA_GUARDADA"]);

                        $scope.encuestaNueva = { idEncuesta: 0 };
                        $scope.newEncuesta = false;
                        encuestasAPI($scope);

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            };

            $scope.deleteEncuesta = function () {
                if (confirm($scope.translation["BORRAR_ENCUESTA_CONFIRMACION"])) {
                    // Save it!
                    $scope.encuestaNueva.idEncuesta = this.encuesta.idEncuesta;

                    $scope.alerts = [];

                    var areErrors = false;

                    if (!areErrors) {

                        $scope.encuestaNueva.action = "delete";
                        $scope.encuestas.post($scope.encuestaNueva).then(
                            function() {
                                addAlert('success', $scope.translation["MENSAJE_ENCUESTA_ELIMINADA"]);

                                $scope.encuestaNueva = { idEncuesta: 0 };
                                $scope.newEncuesta = false;
                                encuestasAPI($scope);
                        },
                            function() {
                                addAlert('danger', $scope.translation["ERROR_DELETE_SURVEY"]);
                        });

                    }
                } else {
                    // Do nothing!
                }
            };

            $scope.lockEncuesta = function () {
                if (confirm($scope.translation["BLOQUEAR_ENCUESTA_CONFIRMACION"])) {
                    // Lock it!
                    $scope.encuestaNueva.idEncuesta = this.encuesta.idEncuesta;
                    $scope.alerts = [];

                    var areErrors = false;

                    if (!areErrors) {

                        $scope.encuestaNueva.action = "lock";
                        $scope.encuestas.post($scope.encuestaNueva).then(function () {

                            addAlert('success', $scope.translation["MENSAJE_ENCUESTA_BLOQUEADA"]);

                            $scope.encuestaNueva = { idEncuesta: 0 };
                            $scope.newEncuesta = false;
                            encuestasAPI($scope);

                        }, function () {

                            addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                        });

                    }
                } else {
                    // Do nothing!
                }
            };

            $scope.finishEncuesta = function () {
                if (confirm($scope.translation["FINISH_ENCUESTA_CONFIRMACION"])) {
                    // Lock it!
                    $scope.encuestaNueva.idEncuesta = this.encuesta.idEncuesta;
                    $scope.alerts = [];

                    var areErrors = false;

                    if (!areErrors) {

                        $scope.encuestaNueva.action = "finish";
                        $scope.encuestas.post($scope.encuestaNueva).then(function () {

                            addAlert('success', $scope.translation["MENSAJE_ENCUESTA_FINISHED"]);

                            $scope.encuestaNueva = { idEncuesta: 0 };
                            $scope.newEncuesta = false;
                            encuestasAPI($scope);

                        }, function () {

                            addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                        });

                    }
                } else {
                    // Do nothing!
                }
            };

            $scope.resetEncuesta = function (encuestaNueva) {
                $scope.encuestaNueva = { idEncuesta: 0 };
                $scope.newEncuesta = false;
                encuestasAPI($scope);
            };

            //Translation
            //Run translation if selected language changes
            $scope.translate = function () {
                translationService.getTranslation($scope, $scope.selectedLanguage);
            };

            //Init
            $scope.selectedLanguage = languageService.get();
            $scope.translate();

            $scope.search = function(item) {
                var text = $scope.searchText;
                if (!text ||
                    (item.titulo && item.titulo.toLowerCase().indexOf(text.toLowerCase()) != -1) ||
                    (item.descripcion && item.descripcion.toLowerCase().indexOf(text.toLowerCase()) != -1)) {
                    return true;
                }
                return false;
            }
        }
    ]
);