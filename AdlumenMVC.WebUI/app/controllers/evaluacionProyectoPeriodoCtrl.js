'use strict';
adlumenApp.controller('evaluacionProyectoPeriodoCtrl',
    [
        '$scope', 'evaluacionProyectoPeriodoAPI', 'evaluacionActivitiesAPI', 'projectAPI', 'translationService', 'languageService',
        function ($scope, evaluacionProyectoPeriodoAPI, evaluacionActivitiesAPI, projectAPI, translationService, languageService) {

            var localidusuario = 0;

            $scope.$watch('bdUser', function (newValue, oldValue) {

                localidusuario = newValue.idLocal;

            });

            $scope.evaluacionProyectoPeriodoNueva = {};
            $scope.evaluacionparams = { idProyecto: 0, idPeriodo: 0 };
            $scope.showAlert = false;
            $scope.newEvaluacionProyectoPeriodo = false;

            $scope.evaluacionActividadesNueva = {};
            $scope.newEvaluacionActividades = false;

            $scope.currentPageProyectos = 1;
            $scope.currentPageActivities = 1;
            $scope.numPerPage = 4;

            //Load services
            projectAPI($scope);

            $scope.setFilteredProjects = function () {
                var begin = (($scope.currentPageProyectos - 1) * $scope.numPerPage)
                , end = begin + $scope.numPerPage;

                if ($scope.evaluacionesproyectoperiodo) {
                    $scope.filteredProyectos = $scope.evaluacionesproyectoperiodo.slice(begin, end);
                }
            }

            $scope.setFilteredActivities = function () {
                var begin = (($scope.currentPageActivities - 1) * $scope.numPerPage)
                , end = begin + $scope.numPerPage;

                if ($scope.evaluacionesactividades) {
                    $scope.filteredActividades = $scope.evaluacionesactividades.slice(begin, end);
                }
            }

            $scope.showEvaluacionesProyectoPeriodo = function () {
                if ($scope.evaluacionparams && $scope.evaluacionparams.idProyecto) {
                    evaluacionProyectoPeriodoAPI($scope);
                }
            }

            $scope.$watch('currentPageProyectos + numPerPage', function () {
                $scope.setFilteredProjects();
            });

            $scope.$watch('currentPageActivities + numPerPage', function () {
                $scope.setFilteredActivities();
            });
            
            $scope.getTemplateEvaluacionProyecto = function (evaluacionproyectoperiodo) {
                if (evaluacionproyectoperiodo.idperiodo === $scope.evaluacionProyectoPeriodoNueva.idPeriodo &&
                    $scope.newEvaluacionProyectoPeriodo) return 'editEvaluacionPeriodo';
                else return 'displayEvaluacionPeriodo';
            };

            $scope.editSelectedEvaluacionPeriodo = function () {
                $scope.evaluacionProyectoPeriodoNueva.idProyecto = $scope.evaluacionparams.idProyecto;
                $scope.evaluacionProyectoPeriodoNueva.idPeriodo = this.evaluacionproyectoperiodo.idperiodo;
                $scope.evaluacionProyectoPeriodoNueva.periodo = this.evaluacionproyectoperiodo.periodo;
                $scope.evaluacionProyectoPeriodoNueva.datosfinancieros = this.evaluacionproyectoperiodo.datosfinancieros;
                $scope.evaluacionProyectoPeriodoNueva.observaciones = this.evaluacionproyectoperiodo.observaciones;
                $scope.evaluacionProyectoPeriodoNueva.recomendaciones = this.evaluacionproyectoperiodo.recomendaciones;
                $scope.evaluacionProyectoPeriodoNueva.idUsuario = localidusuario;

                $scope.newEvaluacionProyectoPeriodo = true;
            };

            $scope.viewDetails = function () {
                $scope.evaluacionProyectoPeriodoNueva.idProyecto = $scope.evaluacionparams.idProyecto;
                $scope.evaluacionProyectoPeriodoNueva.idPeriodo = this.evaluacionproyectoperiodo.idperiodo;
                $scope.evaluacionProyectoPeriodoNueva.periodo = this.evaluacionproyectoperiodo.periodo;
                $scope.evaluacionProyectoPeriodoNueva.datosfinancieros = this.evaluacionproyectoperiodo.datosfinancieros;
                $scope.evaluacionProyectoPeriodoNueva.observaciones = this.evaluacionproyectoperiodo.observaciones;
                $scope.evaluacionProyectoPeriodoNueva.recomendaciones = this.evaluacionproyectoperiodo.recomendaciones;
                $scope.evaluacionProyectoPeriodoNueva.idUsuario = localidusuario;

                $scope.evaluacionparams.idPeriodo = this.evaluacionproyectoperiodo.idperiodo;

                $scope.newEvaluacionProyectoPeriodo = false;

                if ($scope.evaluacionparams && $scope.evaluacionparams.idPeriodo) {

                    evaluacionActivitiesAPI($scope);

                }
            }

            $scope.getTemplateEvaluacionActividades = function (evaluacionactividades) {
                if (evaluacionactividades.idobjetivo === $scope.evaluacionActividadesNueva.idObjetivo &&
                    $scope.newEvaluacionActividades) return 'editEvaluacionActividades';
                else return 'displayEvaluacionActividades';
            };

            $scope.editSelectedEvaluacionActividades = function () {
                $scope.evaluacionActividadesNueva.idProyecto = $scope.evaluacionparams.idProyecto;
                $scope.evaluacionActividadesNueva.idPeriodo = this.evaluacionactividades.idperiodo;
                $scope.evaluacionActividadesNueva.idObjetivo = this.evaluacionactividades.idobjetivo;
                $scope.evaluacionActividadesNueva.observaciones = this.evaluacionactividades.observaciones;
                $scope.evaluacionActividadesNueva.idUsuario = localidusuario;

                $scope.evaluacionActividadesNueva.name = this.evaluacionactividades.name;
                $scope.evaluacionActividadesNueva.descripcion = this.evaluacionactividades.descripcion;

                $scope.newEvaluacionActividades = true;
            };

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            };

            $scope.closeAlert = function(index) {
                $scope.alerts.splice(index, 1);
            }

            var addAlert1 = function (varType, varMsg) {
                $scope.alerts1.push({ type: varType, msg: varMsg });
                $scope.showAlert1 = true;
            };

            $scope.closeAlert1 = function(index) {
                $scope.alerts1.splice(index, 1);
            }

            $scope.modifyEvaluacionProyectoPeriodo = function () {
                $scope.alerts = [];

                var areErrors = false;

                if (!areErrors) {

                    $scope.evaluacionProyectoPeriodoNueva.action = "modify";
                    $scope.postRestangular.post($scope.evaluacionProyectoPeriodoNueva).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_EVALUACION_GUARDADO"]);

                        $scope.evaluacionProyectoPeriodoNueva = {};
                        $scope.newEvaluacionActividades = false;
                        evaluacionProyectoPeriodoAPI($scope);

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            };

            $scope.resetEvaluacionProyectoPeriodo = function () {
                $scope.evaluacionProyectoPeriodoNueva = {};
                $scope.newEvaluacionProyectoPeriodo = false;
                evaluacionProyectoPeriodoAPI($scope);
            };

            $scope.modifyEvaluacionActividades = function () {
                $scope.alerts1 = [];

                var areErrors = false;

                if (!areErrors) {

                    $scope.evaluacionActividadesNueva.action = "modify";
                    $scope.postRestangularActividades.post($scope.evaluacionActividadesNueva).then(function () {

                        addAlert1('success', $scope.translation["MENSAJE_EVALUACION_GUARDADO"]);

                        $scope.evaluacionActividadesNueva = {};
                        $scope.newEvaluacionProyectoPeriodo = false;
                        evaluacionActivitiesAPI($scope);

                    }, function () {

                        addAlert1('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            };

            $scope.resetEvaluacionActividades = function () {
                $scope.evaluacionActividadesNueva = {};
                $scope.newEvaluacionProyectoPeriodo = false;
                evaluacionActivitiesAPI($scope);
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