'use strict';
adlumenApp.controller('evaluacionHitosCtrl',
    [
        '$scope', 'evaluacionHitosAPI', 'projectAPI', 'periodAPI', 'translationService', 'languageService',
        function ($scope, evaluacionHitosAPI, projectAPI, periodAPI, translationService, languageService) {

            var localidusuario = 0;

            $scope.$watch('bdUser', function (newValue, oldValue) {

                localidusuario = newValue.idLocal;

            });

            $scope.evaluacionHitoNueva = {};
            $scope.evaluacionparams = { idProyecto: 0, idPeriodo: 0 };
            $scope.showAlert = false;
            $scope.newEvaluacionHito = false;

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

                if ($scope.evaluacioneshitos) {
                    $scope.filteredEvaluacionesHitos = $scope.evaluacioneshitos.slice(begin, end);
                }
            }

            $scope.showEvaluacionesHito = function () {

                if ($scope.evaluacionparams && $scope.evaluacionparams.idProyecto && $scope.evaluacionparams.idPeriodo) {

                    evaluacionHitosAPI($scope);
                    
                }

            }

            $scope.$watch('currentPage + numPerPage', function () {
                $scope.setFiltered();
            });

            $scope.getTemplate = function (evaluacionhito) {
                if (evaluacionhito.idHitoPeriodo === $scope.evaluacionHitoNueva.idPeriodo &&
                    evaluacionhito.idResultado === $scope.evaluacionHitoNueva.idResultado &&
                    evaluacionhito.idActividad === $scope.evaluacionHitoNueva.idActividad &&
                    evaluacionhito.idIndicador === $scope.evaluacionHitoNueva.idHito &&
                    $scope.newEvaluacionHito) return 'editEvaluacionHito';
                else return 'displayEvaluacionHito';
            };

            $scope.editSelectedEvaluacionHito = function () {
                $scope.evaluacionHitoNueva.idProyecto = $scope.evaluacionparams.idProyecto;
                $scope.evaluacionHitoNueva.idPeriodo = this.evaluacionhito.idHitoPeriodo;
                $scope.evaluacionHitoNueva.idResultado = this.evaluacionhito.idResultado;
                $scope.evaluacionHitoNueva.idActividad = this.evaluacionhito.idActividad;
                $scope.evaluacionHitoNueva.idHito = this.evaluacionhito.idIndicador;
                $scope.evaluacionHitoNueva.observacionED = this.evaluacionhito.observacionED;
                $scope.evaluacionHitoNueva.observacionUrip = this.evaluacionhito.observacionUrip;
                $scope.evaluacionHitoNueva.idUsuario = localidusuario;

                $scope.evaluacionHitoNueva.porcentajeHito = this.evaluacionhito.porcentajeHito;
                $scope.evaluacionHitoNueva.cv = this.evaluacionhito.cv;
                $scope.evaluacionHitoNueva.adh = this.evaluacionhito.adh;

                $scope.evaluacionHitoNueva.codigo = this.evaluacionhito.codigo
                $scope.evaluacionHitoNueva.activityCode = this.evaluacionhito.activityCode
                $scope.evaluacionHitoNueva.descripcion = this.evaluacionhito.descripcion
                $scope.evaluacionHitoNueva.peso = this.evaluacionhito.peso
                $scope.evaluacionHitoNueva.hito = this.evaluacionhito.hito
                $scope.evaluacionHitoNueva.periodo = this.evaluacionhito.periodo

                $scope.newEvaluacionHito = true;
            };

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            };

            $scope.closeAlert = function(index) {
                $scope.alerts.splice(index, 1);
            }

            $scope.modifyEvaluacionHito = function () {
                $scope.alerts = [];

                var areErrors = false;

                if (!areErrors) {

                    $scope.evaluacionHitoNueva.action = "modify";
                    $scope.postRestangular.post($scope.evaluacionHitoNueva).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_EVALUACION_GUARDADO"]);

                        $scope.evaluacionHitoNueva = { };
                        $scope.newEvaluacionHito = false;
                        evaluacionHitosAPI($scope);

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            };

            $scope.resetEvaluacionHito = function () {
                $scope.evaluacionHitoNueva = { };
                $scope.newEvaluacionHito = false;
                evaluacionHitosAPI($scope);
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