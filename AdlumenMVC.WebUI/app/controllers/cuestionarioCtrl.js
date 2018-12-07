'use strict';
adlumenApp.controller('cuestionarioCtrl',
    [
        '$scope', 'cuestionarioAPI', '$stateParams', 'translationService', 'languageService',
        function ($scope, cuestionarioAPI, $stateParams, translationService, languageService) {

            $scope.idEncuesta = $stateParams.idEncuesta;

            cuestionarioAPI($scope);

            $scope.showAlert = false;

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            };

            $scope.submitQuestionary = function () {

                $scope.alerts = [];

                var areErrors = false;
                var errorCamposVacios = false;
                var index = 0;
                for (index = 0; index < $scope.cuestionario.preguntasAMostrar.length ; ++index){
                    var pregunta = $scope.cuestionario.preguntasAMostrar[index];
                    if (pregunta.tipoPregunta === "templateText"){

                        if (!pregunta.textoRespuesta || pregunta.textoRespuesta === '') {
                            areErrors = true;
                            errorCamposVacios = true;
                        }
                    }
                    if (pregunta.tipoPregunta === "templateNumber") {

                        if (!pregunta.numeroRespuesta || pregunta.numeroRespuesta === '') {
                            areErrors = true;
                            errorCamposVacios = true;
                        }
                    }
                    if (pregunta.tipoPregunta === "templateDate") {

                        if (!pregunta.fechaRespuesta || pregunta.fechaRespuesta === '') {
                            areErrors = true;
                            errorCamposVacios = true;
                        }
                    }
                    if (pregunta.tipoPregunta === "multiOption") {
                        var selected = false;
                        var j = 0;
                        for (j = 0; j < pregunta.respuestasAMostrar.length; ++j) {
                            if (pregunta.respuestasAMostrar[j].seleccionada) selected = true;
                        }
                        if (selected == false) {
                            areErrors = true;
                            errorCamposVacios = true;
                        }
                    }
                    if (pregunta.tipoPregunta === "singleOption") {

                        if (!pregunta.valorRespuestaSimple || pregunta.valorRespuestaSimple === '') {
                            areErrors = true;
                            errorCamposVacios = true;
                        }
                    }
                }

                if (errorCamposVacios){
                    addAlert('danger', $scope.translation["ERROR_CAMPOS_VACIOS_CUESTIONARIO"]);
                }

                if (!areErrors) {

                    $scope.cuestionarios.post($scope.cuestionario).then(function () {

                        addAlert('success', $scope.translation["CUESTIONARIO_GUARDADO"]);

                        cuestionarioAPI($scope);

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }

            }

            $scope.datePicker = { opened: false };

            $scope.open = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();

                $scope.datePicker.opened = true;
            };

            $scope.getDayClass = function (date, mode) {
                if (mode === 'day') {
                    var dayToCheck = new Date(date).setHours(0, 0, 0, 0);

                    for (var i = 0; i < $scope.events.length; i++) {
                        var currentDay = new Date($scope.events[i].date).setHours(0, 0, 0, 0);

                        if (dayToCheck === currentDay) {
                            return $scope.events[i].status;
                        }
                    }
                }

                return '';
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