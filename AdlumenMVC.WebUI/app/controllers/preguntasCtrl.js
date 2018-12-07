'use strict';
adlumenApp.controller('preguntasCtrl',
    [
        '$scope', 'preguntasAPI', 'encuestaAPI', 'translationService', 'languageService', '$stateParams',
        function ($scope, preguntasAPI, encuestaAPI, translationService, languageService, $stateParams) {

            $scope.idEncuesta = $stateParams.idEncuesta;

            //Translation
            //Run translation if selected language changes
            $scope.translate = function () {
                translationService.getTranslation($scope, $scope.selectedLanguage);
            };

            //Init
            $scope.selectedLanguage = languageService.get();
            $scope.translate();

            //Initialize Form
            encuestaAPI($scope);
            preguntasAPI($scope);

            $scope.preguntaNueva = { idPregunta: 0 };
            $scope.newPregunta = false;
            $scope.showAlert = false;
            $scope.nextOrder = 1;

            $scope.tipos = [
                { id: 1, name: 'PREGUNTA_TIPO_TEXTO' },
                { id: 2, name: 'PREGUNTA_TIPO_NUMERO' },
                { id: 3, name: 'PREGUNTA_TIPO_FECHA' },
                { id: 4, name: 'PREGUNTA_TIPO_OPCION_SIMPLE' },
                { id: 5, name: 'PREGUNTA_TIPO_MULTIPLE_OPCION' }
            ];

            //Form functions
            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            };

            $scope.showRespuestas = function (tipo) {
                if (tipo == 4 || tipo == 5) return true;
            };

            $scope.enableEditing = function () {
                if ($scope.encuesta !== undefined) {
                    if ($scope.encuesta.estado === 'A') //active
                        return true;
                    else
                        return false;
                }
            };

            $scope.setSelected = function () {
                $scope.preguntaNueva.idPregunta = this.pregunta.idPregunta;
                $scope.preguntaNueva.orden = this.pregunta.orden;
                $scope.preguntaNueva.pregunta = this.pregunta.pregunta;
                $scope.preguntaNueva.tipo = $scope.tipos[$scope.getTipoIndexById(this.pregunta.tipo)];
                var respuestasArr = $scope.getPosiblesRespuestasString(this.pregunta.m_PosiblesRespuestas);
                if (respuestasArr !== undefined && respuestasArr.length > 0) $scope.preguntaNueva.m_PosiblesRespuestas = respuestasArr;
                $scope.newPregunta = true;
            };
            
            $scope.getTipoIndexById = function (idTipo)
            {
                for (var i = 0; i < $scope.tipos.length; i++) {
                    if ($scope.tipos[i].id === idTipo)
                        return i;
                }
            }

            $scope.getPosiblesRespuestasString = function (respuestas) {
                var arrRespuestasTmp = [];
                for (var i = 0; i < respuestas.length; i++) {
                    arrRespuestasTmp.push(respuestas[i].respuesta);
                }
                var arrRespuestasText = arrRespuestasTmp.join('\n');
                var arrRespuestas = [arrRespuestasText];
                return arrRespuestas;
            }

            $scope.getTypeDescription = function (pregunta)
            {
                var tipo = $scope.tipos[$scope.getTipoIndexById(pregunta.tipo)];
                var tipoName;
                if (tipo !== undefined)
                    tipoName = tipo.name;
                if ($scope.translation !== undefined)
                    tipoName = $scope.translation[tipoName];
                return tipoName;
            }

            //Operations
            $scope.addPregunta = function () {
                $scope.alerts = [];
                
                var areErrors = false;

                if ($scope.preguntaNueva.orden === undefined || $scope.preguntaNueva.pregunta === undefined || $scope.preguntaNueva.tipo === undefined) {
                    areErrors = true;
                    addAlert('danger', $scope.translation["ERROR_CAMPOS_VACIOS"]);
                }

                if ($scope.preguntaNueva.tipo !== undefined && $scope.showRespuestas($scope.preguntaNueva.tipo.id) && $scope.preguntaNueva.m_PosiblesRespuestas === undefined) {
                    areErrors = true;
                    addAlert('danger', $scope.translation["AL_MENOS_UNA_RESPUESTA_REQUERIDA"]);
                }

                var nextOrder = $scope.preguntas.length + 1;
                if ($scope.preguntaNueva.orden > nextOrder){
                    areErrors = true;
                    addAlert('danger', $scope.translation["ORDEN_ERROR_MAXIMO"] + nextOrder + '. ' + $scope.translation["ORDEN_ERROR_MAXIMO_DETALLE"]);
                }

                if (!areErrors) {

                    $scope.preguntaNueva.action = "addmodify";
                    $scope.preguntaNueva.idEncuesta = $scope.idEncuesta;

                    $scope.todasLasPreguntas.post($scope.preguntaNueva).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_PREGUNTA_GUARDADA"]);

                        $scope.preguntaNueva = { idPregunta: 0 };
                        $scope.newPregunta = false;
                        preguntasAPI($scope);

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            };

            $scope.deletePregunta = function () {
                if (confirm($scope.translation["BORRAR_PREGUNTA_CONFIRMACION"])) {
                    // Save it!
                    $scope.preguntaNueva.idPregunta = this.pregunta.idPregunta;
                    $scope.alerts = [];

                    var areErrors = false;

                    //TO DO : Delete validations

                    if (!areErrors) {

                        $scope.preguntaNueva.action = "delete";
                        $scope.todasLasPreguntas.post($scope.preguntaNueva).then(function () {

                            addAlert('success', $scope.translation["MENSAJE_PREGUNTA_ELIMINADA"]);

                            $scope.preguntaNueva = { idPregunta: 0 };
                            $scope.newPregunta = false;
                            preguntasAPI($scope);

                        }, function () {

                            addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                        });

                    }
                } else {
                    // Do nothing!
                }
            };

            $scope.resetPregunta = function (preguntaNueva) {
                $scope.preguntaNueva = { idPregunta: 0 };
                $scope.newPregunta = false;
            };

        }
    ]
);