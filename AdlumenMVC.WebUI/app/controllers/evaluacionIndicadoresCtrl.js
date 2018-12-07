'use strict';
adlumenApp.controller('evaluacionIndicadoresCtrl',
    [
        '$scope', 'evaluacionIndicadoresAPI', 'projectAPI', 'periodAPI', 'translationService', 'languageService',
        function ($scope, evaluacionIndicadoresAPI, projectAPI, periodAPI, translationService, languageService) {

            var localidusuario = 0;

            $scope.$watch('bdUser', function (newValue, oldValue) {

                localidusuario = newValue.idLocal;

            });

            $scope.evaluacionIndicadorNueva = {};
            $scope.evaluacionparams = { idProyecto: 0, idPeriodo: 0 };
            $scope.showAlert = false;
            $scope.newEvaluacionIndicador = false;

            $scope.currentPage = 1;
            $scope.numPerPage = 8;

            //Load services
            projectAPI($scope);
            periodAPI($scope);

            $scope.showPeriods = function () {

                $scope.periodsByProject = _.result($scope.periodsList, $scope.evaluacionparams.idProyecto);
            }

            $scope.setFiltered = function () {
                var begin = (($scope.currentPage - 1) * $scope.numPerPage)
                , end = begin + $scope.numPerPage;

                if ($scope.evaluacionesindicadores) {
                    $scope.filteredIndicadores = $scope.evaluacionesindicadores.slice(begin, end);
                }
            }

            $scope.showEvaluacionesIndicador = function () {

                if ($scope.evaluacionparams && $scope.evaluacionparams.idProyecto && $scope.evaluacionparams.idPeriodo) {

                    evaluacionIndicadoresAPI($scope);

                }

            }

            $scope.$watch('currentPage + numPerPage', function () {
                $scope.setFiltered();
            });

            $scope.getTemplate = function (evaluacionindicador) {
                if (evaluacionindicador.idHitoPeriodo === $scope.evaluacionIndicadorNueva.idPeriodo &&
                    evaluacionindicador.idobjetivo === $scope.evaluacionIndicadorNueva.idResultado &&
                    evaluacionindicador.idIndicador === $scope.evaluacionIndicadorNueva.idHito &&
                    $scope.newEvaluacionIndicador) return 'editEvaluacionIndicador';
                else return 'displayEvaluacionIndicador';
            };

            $scope.editSelectedEvaluacionIndicador = function () {
                $scope.evaluacionIndicadorNueva.idProyecto = $scope.evaluacionparams.idProyecto;
                $scope.evaluacionIndicadorNueva.idPeriodo = this.evaluacionindicador.idHitoPeriodo;
                $scope.evaluacionIndicadorNueva.idResultado = this.evaluacionindicador.idobjetivo;
                $scope.evaluacionIndicadorNueva.idHito = this.evaluacionindicador.idIndicador;
                $scope.evaluacionIndicadorNueva.observacionED = this.evaluacionindicador.observacionED;
                $scope.evaluacionIndicadorNueva.observacionUrip = this.evaluacionindicador.observacionUrip;
                $scope.evaluacionIndicadorNueva.idUsuario = localidusuario;

                $scope.evaluacionIndicadorNueva.porcentajeHito = this.evaluacionindicador.porcentajeHito;
                $scope.evaluacionIndicadorNueva.cv = this.evaluacionindicador.cv;
                $scope.evaluacionIndicadorNueva.adh = this.evaluacionindicador.adh;

                $scope.evaluacionIndicadorNueva.ml = this.evaluacionindicador.ml;
                $scope.evaluacionIndicadorNueva.hito = this.evaluacionindicador.hito;
                $scope.evaluacionIndicadorNueva.peso = this.evaluacionindicador.peso;

                $scope.newEvaluacionIndicador = true;
            };

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            };

            $scope.closeAlert = function(index) {
                $scope.alerts.splice(index, 1);
            }

            $scope.modifyEvaluacionIndicador = function () {
                $scope.alerts = [];

                var areErrors = false;

                if (!areErrors) {

                    $scope.evaluacionIndicadorNueva.action = "modify";
                    $scope.postRestangular.post($scope.evaluacionIndicadorNueva).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_EVALUACION_GUARDADO"]);

                        $scope.evaluacionIndicadorNueva = {};
                        $scope.newEvaluacionIndicador = false;
                        evaluacionIndicadoresAPI($scope);

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            };

            $scope.resetEvaluacionIndicador = function () {
                $scope.evaluacionIndicadorNueva = {};
                $scope.newEvaluacionIndicador = false;
                evaluacionIndicadoresAPI($scope);
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