'use strict';
adlumenApp.controller('indicadoresCtrl',
    [
        '$scope', '$uibModal', 'indicadoresPorProyectoAPI', 'indicadoresAPI', 'projectAPI', 'translationService', 'languageService',
        function ($scope, $uibModal, indicadoresPorProyectoAPI, indicadoresAPI, projectAPI, translationService, languageService) {

            var localidusuario = 0;
            
            $scope.$watch('bdUser', function (newValue, oldValue) {

                localidusuario = newValue.idLocal;

            });
                        
            $scope.selectedObjective = {};
            $scope.selectedIndicator = {};
            $scope.indicadoresparams = { idProyecto: 0 };
            $scope.objetivosparams = { idObjetivo: 0 };
            $scope.valorProgressVar = 0;
            $scope.type = 'success';

            $scope.clases = [
                { id: '1', name: 'OBJETIVO_GENERAL' },
                { id: '2', name: 'PROPOSITO' },
                { id: '3', name: 'RESULTADO' },
                { id: '4', name: 'ACTIVIDAD' }
            ];
            
            $scope.labels = [];
            $scope.series = [];
            $scope.data = [];
            $scope.options = {
                legend: {
                    display: true,
                    position: 'bottom'
                },
                spanGaps: true
            };
            
            //Load services
            projectAPI($scope);

            $scope.getObjectifTypeIndexById = function (idType) {
                for (var i = 0; i < $scope.clases.length; i++) {
                    if ($scope.clases[i].id === idType)
                        return i;
                }
            }

            $scope.getObjectifType = function (objetivo) {
                var typeName;
                var type = $scope.clases[$scope.getObjectifTypeIndexById(objetivo.idType.toString())];
                if (type !== undefined)
                    typeName = type.name;
                if ($scope.translation !== undefined)
                    typeName = $scope.translation[typeName];
                return typeName;
            }

            $scope.showObjetivosProyecto = function () {
                if ($scope.indicadoresparams && $scope.indicadoresparams.idProyecto) {
                    indicadoresPorProyectoAPI($scope);
                }
            }

            $scope.showIndicatorDetails = function () {
                $scope.selectedObjective.idObjetivo = this.node.id;
                $scope.objetivosparams.idObjetivo = $scope.selectedObjective.idObjetivo;

                if ($scope.objetivosparams && $scope.objetivosparams.idObjetivo) {

                    //indicadoresAPI.getIndicadoresProyecto($scope);
                    $scope.showIndicadoresProyecto(false);

                }
            };

            $scope.changeSelectedIndicator = function () {
                $scope.selectedIndicator = angular.copy(this.indicador);
                $scope.viewIndicatorDetail();
                $scope.buildGraph();
            }

            $scope.viewIndicatorDetail = function () {
                $scope.actual = 0;
                $scope.valorProgressVar = 0;
                if ($scope.selectedIndicator && $scope.selectedIndicator.datosMuestraActual && $scope.selectedIndicator.datosMuestraActual.logro) {
                    $scope.actual = $scope.selectedIndicator.datosMuestraActual.logro;
                    if ($scope.selectedIndicator.datosMuestraActual.eficacia.actual > 100) $scope.valorProgressVar = 100;
                    else $scope.valorProgressVar = $scope.selectedIndicator.datosMuestraActual.eficacia.actual;

                    if ($scope.selectedIndicator.datosMuestraActual.eficacia.name == 'MS') {
                        $scope.type = 'success';
                    } else if ($scope.selectedIndicator.datosMuestraActual.eficacia.name == 'S') {
                        $scope.type = 'warning';
                    } else if ($scope.selectedIndicator.datosMuestraActual.eficacia.name == 'I') {
                        $scope.type = 'danger';
                    } else {
                        $scope.type = 'danger';
                    }
                }
            }

            $scope.buildGraph = function () {
                var numberOfLabels = 10; //Vamos a mostrar 10 valores en el axis x

                $scope.labels = [];
                $scope.series = [];
                $scope.data = [];

                var fechas = [];

                if ($scope.selectedIndicator) {
                    if ($scope.selectedIndicator.fechaInicio && $scope.selectedIndicator.fechaFin) {
                        var diff = Math.floor(new Date($scope.selectedIndicator.fechaFin) - new Date($scope.selectedIndicator.fechaInicio));
                        var day = 1000 * 60 * 60 * 24;

                        var days = Math.floor(diff / day);
                        var months = Math.floor(days / 31);
                        var years = Math.floor(months / 12);

                        var monthsByLabel = Math.ceil(months / numberOfLabels);

                        if (monthsByLabel <= 0) monthsByLabel = 1;

                        var startdate = new Date($scope.selectedIndicator.fechaInicio);
                        var enddate = new Date($scope.selectedIndicator.fechaFin);

                        while (startdate <= enddate) {
                            var dateLabel = (startdate.getMonth() + 1) + "/" + (startdate.getYear() - 100);
                            $scope.labels.push(dateLabel);
                            fechas.push(new Date(startdate));
                            startdate.setMonth(startdate.getMonth() + monthsByLabel);
                        }

                    }

                    var serieAdata = []; //Programado
                    serieAdata.push($scope.selectedIndicator.base);
                    for (var i = 1; i < $scope.labels.length - 1; i++) {
                        serieAdata.push(null);
                    }
                    serieAdata.push($scope.selectedIndicator.meta);

                    var serieBdata = []; //Actual
                    if ($scope.selectedIndicator.datosMuestra && $scope.selectedIndicator.datosMuestra.length > 0) {
                        for (var i = 0; i < $scope.selectedIndicator.datosMuestra.length; i++) {
                            var fechaMuestra = new Date($scope.selectedIndicator.datosMuestra[i].fecha);
                            var index = 0;
                            while (index < fechas.length) {
                                if (fechaMuestra <= fechas[index]) {
                                    serieBdata.push($scope.selectedIndicator.datosMuestra[i].logro);
                                    break;
                                } else {
                                    serieBdata.push(null);
                                }
                                index++;
                            }

                        }
                    }
                    else {
                        //Necesita ser inicializado sino el gráfico no se actualiza
                        serieBdata = [0];
                    }

                    $scope.series = [$scope.translation.ACTUAL, $scope.translation.PROGRAMADO];
                    $scope.data.push(serieBdata); //Actual
                    $scope.data.push(serieAdata); //Programado

                }
            }

            //Modal
            $scope.viewIndicatorHistory = function () {

                $scope.animationsEnabled = true;
                $scope.selectedIndicator = angular.copy(this.indicador);

                var modalInstance = $uibModal.open({
                    animation: $scope.animationsEnabled,
                    templateUrl: 'modalHistoryContent.html',
                    controller: 'historicoIndicadorCtrl',
                    size: 'lg',
                    resolve: {
                        idIndicador: function () {
                            return $scope.selectedIndicator.id;
                        },
                        idProyecto: function () {
                            return $scope.indicadoresparams.idProyecto;
                        },
                        postIndicadores: function () {
                            return $scope.postIndicadores;
                        }
                    }
                });

                modalInstance.result.then(function () {
                    if ($scope.objetivosparams && $scope.objetivosparams.idObjetivo) {

                        //indicadoresAPI.updateSelectedIndicatorData($scope);
                        $scope.showIndicadoresProyecto(true);

                    }
                }, function () {

                });
            }

            $scope.showIndicadoresProyecto = function (refreshSelected) {
                indicadoresAPI.getIndicadoresProyecto($scope).then(
                    function addtoScope(indicadoresobjetivoobject) {
                        $scope.indicadoresobjetivoobject = indicadoresobjetivoobject
                        $scope.indicadoresObjetivo = indicadoresobjetivoobject.indicadoresObjetivo;

                        if (refreshSelected) {
                            if ($scope.selectedIndicator && $scope.selectedIndicator.id) {
                                var selectedId = $scope.selectedIndicator.id;
                                for (var i = 0; i < $scope.indicadoresObjetivo.length; i++) {
                                    if ($scope.indicadoresObjetivo[i].id == selectedId) {
                                        $scope.selectedIndicator = angular.copy($scope.indicadoresObjetivo[i]);
                                        $scope.viewIndicatorDetail();
                                        //$scope.buildGraph();
                                    }
                                }
                            }
                        }

                    }
                );

                $scope.postIndicadores = indicadoresAPI.getIndicadoresRestFul();
            }

            //Graphic
            $scope.onClick = function (points, evt) {
                //console.log(points, evt);
            };

            //Translation
            //Run translation if selected language changes
            $scope.translate = function () {
                translationService.getTranslation($scope, $scope.selectedLanguage);
            };

            //Init
            $scope.selectedLanguage = languageService.get();
            $scope.translate();

            //added by Ernesto Duarte, i need this to display the objective directive that i created

            $scope.$watch('indicadoresparams.idProyecto', function (newValue, oldValue) {
                if (newValue != oldValue) {
                    $scope.selectedProject = _.findWhere($scope.projects, { idProyecto: newValue });
                    
                }
            });

            $scope.$watch('treeviewObjective', function (newValue, oldValue) {
                if (newValue != oldValue) {
                    $scope.objetivosparams.idObjetivo = newValue.idObjetivo;
                    $scope.showIndicadoresProyecto(false);

                }

            });
        }
    ]
);