'use strict';
adlumenApp.controller('dashboardCtrl',
    [
        '$scope', 'projectAPI', 'idiomasAPI', 'translationService', 'languageService', '$window','uiCalendarConfig','$compile','$filter',
        function ($scope, projectAPI, idiomasAPI, translationService, languageService, $window, uiCalendarConfig, $compile, $filter) {

            projectAPI($scope);
            
            //initializing objectives configuration charts
            
            /* event source that contains custom events on the scope */

            var date = new Date();
            var d = date.getDate();
            var m = date.getMonth();
            var y = date.getFullYear();

            $scope.events = [];


            $scope.objectivesGantt = [];

            var calendarText = "";

            $scope.$watch('translation', function (newValue, oldValue) {
                if (!_.isUndefined(newValue)) {
                    $scope.pryefectividadChart.text = newValue.EFECTIVIDAD;
                    $scope.pryeficaciaChart.text = newValue.EFICACIA;
                    $scope.pryeficienciaChart.text = newValue.EFICIENCIA;
                    $scope.efectividadChart.text = newValue.EFECTIVIDAD;
                    $scope.eficaciaChart.text = newValue.EFICACIA;
                    $scope.eficienciaChart.text = newValue.EFICIENCIA;
                    
                }
                
            });

            $scope.efectividadChart = {
                name: ' ',
                opacity: 0.55,
                value: 0,
                text: false,
                arcColor: '#57E0EA',
                bgArcColor: 'grey'
            };

            $scope.eficaciaChart = {
                name: ' ',
                opacity: 0.55,
                value: 0,
                text: false,
                arcColor: '#57E0EA',
                bgArcColor: 'grey'
            };

            $scope.eficienciaChart = {
                name: ' ',
                opacity: 0.55,
                value: 0,
                text: false,
                arcColor: '#57E0EA',
                bgArcColor: 'grey'
            };
            
            //initializing project configuration charts

            $scope.pryefectividadChart = {
                name: ' ',
                opacity: 0.55,
                value: 0,
                text: false,
                arcColor: '#57E0EA',
                bgArcColor: 'grey'
            };

            $scope.pryeficaciaChart = {
                name: ' ',
                opacity: 0.55,
                value: 0,
                text: false,
                arcColor: '#57E0EA',
                bgArcColor: 'grey'
            };

            $scope.pryeficienciaChart = {
                name: ' ',
                opacity: 0.55,
                value: 0,
                text: false,
                arcColor: '#57E0EA',
                bgArcColor: 'grey'
            };

            $scope.progressbarColor = function (color) {

                var value = null;

                switch (color) {
                    case 'green':
                        value = 'success';
                        break;
                    case 'yellow':
                        value = 'warning';
                        break;
                    case 'red':
                        value = 'danger';
                        break;
                }

                return value;
            };

            //This object is usted to manage the over achievement for efectiveness, eficacy and eficiency

            $scope.tooltipOverAchievement = { efectividad: "", eficacia: "", eficiencia: "" };

            //listening the project selected in the dropdown

            $scope.$watch('selectedProject', function (newValue, oldValue) {
                if (newValue !== oldValue) {
                    $scope.projectGoal = _.findWhere(newValue.objectives, { idPadre: 0 });
                    $scope.treeviewObjective = $scope.projectGoal;
                    $scope.pryefectividadChart.value = $scope.projectGoal.efectividad || 0.000001;
                    $scope.pryeficaciaChart.value = $scope.projectGoal.eficacia || 0.000001;
                    $scope.pryeficienciaChart.value = $scope.projectGoal.eficiencia || 0.000001;
                    $scope.pryefectividadChart.arcColor = $scope.projectGoal.efectividadColor;
                    $scope.pryeficaciaChart.arcColor = $scope.projectGoal.eficaciaColor;
                    $scope.pryeficienciaChart.arcColor = $scope.projectGoal.eficienciaColor;
                    setBudgetBarGraph(newValue);
                    setMultiBarGraph(newValue);

                    //disbursement calendar
                    _.each(newValue.disbursementCalendar, function (element, index) {
                        $scope.eventSources.push(
                            [{ title: $filter('currency')(element.monto, newValue.m_Monedas.representacion, 2), start: element.fechaProgramada, allDay: true, disbursementCalendar: element }]
                        );
                    });

                    //gantt
                    $scope.objectivesGantt.push(
                        {
                            name: $scope.projectGoal.descripcion,
                            id: $scope.projectGoal.idObjetivo,
                            tasks: [{
                                name: $scope.projectGoal.descripcion,
                                color: '#4682B4',
                                id: $scope.projectGoal.idObjetivo,
                                from: $scope.projectGoal.fechaInicio,
                                to: $scope.projectGoal.fechaFin
                            }]
                        });

                    _.each(newValue.objectives, function (element, index) {
                        if (element.idObjetivo !== $scope.projectGoal.idObjetivo) {
                            $scope.objectivesGantt.push(
                           {
                               name: element.descripcion,
                               id: element.idObjetivo,
                               parent: (_.findWhere(newValue.objectives, { idObjetivo: element.idPadre })).descripcion,
                               tasks: [{
                                   name: element.descripcion,
                                   id: element.idObjetivo,
                                   color: '#4682B4',
                                   from: element.fechaInicio,
                                   to: element.fechaFin
                               }]
                           });
                        }
                    });
                }
            });

            //listening the projects api

            $scope.$watch(
                // This is the listener function
                function () { return $scope.projects; },
                // This is the change handler
                function (newValue, oldValue) {
                    if (newValue !== oldValue) {
                        // Only increment the counter if the value changed

                        $scope.selectedProject = _.where(newValue, {idEstado: 2})[0];
                        $scope.treeviewObjective = newValue[0].objectives[0];

                    }
                });


            //listener for the efectiveness, eficacy and eficiency
            $scope.$watch('treeviewObjective',

                function (newValue, oldValue) {
                    if (newValue !== oldValue) {

                        $scope.efectividadChart.value = newValue.efectividad || 0.000001;
                        $scope.eficaciaChart.value = newValue.eficacia || 0.000001;
                        $scope.eficienciaChart.value = newValue.eficiencia || 0.000001;


                        if (newValue.efectividad > 100) {
                            $scope.efectividadChart.arcColor = '#9400D3';
                        }
                        else {
                            $scope.efectividadChart.arcColor = newValue.efectividadColor;
                        }

                        if (newValue.eficacia > 100) {
                            $scope.eficaciaChart.arcColor = '#9400D3';
                        }
                        else {
                            $scope.eficaciaChart.arcColor = newValue.eficaciaColor;
                        }

                        if (newValue.eficiencia > 100) {
                            $scope.eficienciaChart.arcColor = '#9400D3';
                        }
                        else {
                            $scope.eficienciaChart.arcColor = newValue.eficienciaColor;
                        }
                                                
                        $scope.selectedIndicator = newValue.indicators[0];
                        $scope.setIndicator(newValue.indicators[0]);
                    }
                });

            $scope.showAlert = false;            

            //get active projects count

            $scope.projectsCount = function (_projects, type) {

                var filteredProjects;

                switch (type) {
                    case "a":
                        filteredProjects = _.where(_projects, { idEstado: 2 });
                        break;
                    case "f":
                        filteredProjects = _.where(_projects, { idEstado: 1 });
                        break;
                    case "c":
                        filteredProjects = _.where(_projects, { eliminado: "True" });
                        break;
                }

                return filteredProjects.length;
            };

            //get the indicator and the last sample registered for that indicator

            $scope.setIndicator = function (indicator) {
                $scope.selectedIndicator = indicator;
                $scope.lastSample = _.findWhere(indicator.samples, { idDatosMuestra: indicator.idDatosMuestra });
                
            };

            //define the labels and data for the budget bar chart

            var setBudgetBarGraph = function (project) {

                $scope.projectLabels = [$scope.translation.PRESUPUESTO_PROYECTO];
                $scope.projectSeries = [$scope.translation.PRESUPUESTO, $scope.translation.EJECUTADO, $scope.translation.SALDO];

                var executed = 0;

                _.each(project.objectives, function (objective) {
                    executed = executed + objective.expensives || 0 ;
                });

                var balance = project.presupuesto - executed;

                $scope.barColors = [{
                    fillColor: 'lightblue',
                    strokeColor: 'blue',
                },
                {
                    fillColor: 'lightred',
                    strokeColor: 'red',
                },
                {
                    fillColor: 'lightgreen',
                    strokeColor: 'green',
                }];

                $scope.projectData = [
                    [project.presupuesto],
                    [executed],
                    [balance]
                ];
            };
            
            //configuration for dibursment calendar

            /* Render Tooltip */
            $scope.eventRender = function (event, element, view) {
                element.attr({
                    'tooltip': event.disbursementCalendar.nombre + ' ' + event.title,
                    'tooltip-append-to-body': true
                });
                $compile(element)($scope);
            };


            /* config object */
            $scope.uiConfig = {
                calendar: {
                    height: 450,
                    editable: true,
                    header: {
                        left: 'title',
                        center: '',
                        right: 'today prev,next'
                    },
                    stick: true,
                    eventRender: $scope.eventRender
                }
            };

            $scope.changeLang = function () {
                if ($scope.changeTo === 'Hungarian') {
                    $scope.uiConfig.calendar.dayNames = ["Vasárnap", "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek", "Szombat"];
                    $scope.uiConfig.calendar.dayNamesShort = ["Vas", "Hét", "Kedd", "Sze", "Csüt", "Pén", "Szo"];
                    $scope.changeTo = 'English';
                } else {
                    $scope.uiConfig.calendar.dayNames = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
                    $scope.uiConfig.calendar.dayNamesShort = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
                    $scope.changeTo = 'Hungarian';
                }
            };
            
            /* event sources array*/
            $scope.eventSources = [$scope.events];



            //Configure multibar chart
            var setMultiBarGraph = function (project) {
                $scope.MultiBarOptions = {
                    chart: {
                        type: 'multiBarHorizontalChart',
                        height: 600,
                        x: function (d) { return d.label; },
                        y: function (d) { return d.value; },
                        showControls: false,
                        showValues: true,
                        duration: 500,
                        xAxis: {
                            showMaxMin: false
                        },
                        yAxis: {
                            axisLabel: '%',
                            tickFormat: function (d) {
                                return d3.format(',.2f')(d);
                            }
                        },
                        margin: { "left": 130 }
                    }
                };

                $scope.MultiBarOptions.chart.height = project.objectives.length * 25;

                $scope.dataMultiBarEfectividad = [
                    {
                        "key": $scope.translation.SOBRE_CUMPLIMIENTO + " > 100%" ,
                        "color": "#2980b9",
                        "values": []
                    },
                    {
                        "key": $scope.translation.MUY_SATISFACTORIO + " > " + project.nivelesAceptacion[0].valor + "% < 100%",
                        "color": "green",
                        "values": []
                    },
                    {
                        "key": $scope.translation.SATISFACTORIO + " > " + project.nivelesAceptacion[1].valor + "% < " + +project.nivelesAceptacion[0].valor + "%",
                        "color": "yellow",
                        "values": []
                    },
                    {
                        "key": $scope.translation.INSATISFACTORIO + " " + $scope.translation.MUY_INSATISFACTORIO + " < " + project.nivelesAceptacion[1].valor + "%",
                        "color": "red",
                        "values": []
                    }
                ];

                $scope.dataMultiBarEficacia = [
                    {
                        "key": $scope.translation.SOBRE_CUMPLIMIENTO + " > 100%",
                        "color": "#2980b9",
                        "values": []
                    },
                    {
                        "key": $scope.translation.MUY_SATISFACTORIO + " > " + project.nivelesAceptacion[0].valor + "% < 100%",
                        "color": "green",
                        "values": []
                    },
                    {
                        "key": $scope.translation.SATISFACTORIO + " > " + project.nivelesAceptacion[1].valor + "% < " + +project.nivelesAceptacion[0].valor + "%",
                        "color": "yellow",
                        "values": []
                    },
                    {
                        "key": $scope.translation.INSATISFACTORIO + " " + $scope.translation.MUY_INSATISFACTORIO + " < " + project.nivelesAceptacion[1].valor + "%",
                        "color": "red",
                        "values": []
                    }
                ];

                $scope.dataMultiBarEficiencia = [
                    {
                        "key": $scope.translation.SOBRE_CUMPLIMIENTO + " > 100%",
                        "color": "#2980b9",
                        "values": []
                    },
                    {
                        "key": $scope.translation.MUY_SATISFACTORIO + " > " + project.nivelesAceptacion[0].valor + "% < 100%",
                        "color": "green",
                        "values": []
                    },
                    {
                        "key": $scope.translation.SATISFACTORIO + " > " + project.nivelesAceptacion[1].valor + "% < " + +project.nivelesAceptacion[0].valor + "%",
                        "color": "yellow",
                        "values": []
                    },
                    {
                        "key": $scope.translation.INSATISFACTORIO + " " + $scope.translation.MUY_INSATISFACTORIO + " < " + project.nivelesAceptacion[1].valor + "%",
                        "color": "red",
                        "values": []
                    }
                ];

                _.each(_.sortBy(project.objectives,
                    function (objective) { return parseInt(objective.idObjetivo) })
                    , function (objective) {
                        if (objective.idNivelAceptacionEfectividad === 1 && objective.efectividad > 100) {
                            $scope.dataMultiBarEfectividad[0].values.push({ "label": objective.objectiveType.descripcion + " " + (objective.codigo === "0" ? "" : objective.codigo), "value": objective.efectividad });
                        } else if (objective.idNivelAceptacionEfectividad === 1 && objective.efectividad <= 100) {
                            $scope.dataMultiBarEfectividad[1].values.push({ "label": objective.objectiveType.descripcion + " " + (objective.codigo === "0" ? "" : objective.codigo), "value": objective.efectividad });
                        } else if (objective.idNivelAceptacionEfectividad === 2) {
                            $scope.dataMultiBarEfectividad[2].values.push({ "label": objective.objectiveType.descripcion + " " + (objective.codigo === "0" ? "" : objective.codigo), "value": objective.efectividad });
                        } else {
                            $scope.dataMultiBarEfectividad[3].values.push({ "label": objective.objectiveType.descripcion + " " + (objective.codigo === "0" ? "" : objective.codigo), "value": objective.efectividad });
                        }

                        if (objective.idNivelAceptacionEficacia === 1 && objective.eficacia > 100) {
                            $scope.dataMultiBarEficacia[0].values.push({ "label": objective.objectiveType.descripcion + " " + (objective.codigo === "0" ? "" : objective.codigo), "value": objective.eficacia });
                        } else if (objective.idNivelAceptacionEficacia === 1 && objective.eficacia <= 100) {
                            $scope.dataMultiBarEficacia[1].values.push({ "label": objective.objectiveType.descripcion + " " + (objective.codigo === "0" ? "" : objective.codigo), "value": objective.eficacia });
                        } else if (objective.idNivelAceptacionEficacia === 2) {
                            $scope.dataMultiBarEficacia[2].values.push({ "label": objective.objectiveType.descripcion + " " + (objective.codigo === "0" ? "" : objective.codigo), "value": objective.eficacia });
                        } else {
                            $scope.dataMultiBarEficacia[3].values.push({ "label": objective.objectiveType.descripcion + " " + (objective.codigo === "0" ? "" : objective.codigo), "value": objective.eficacia });
                        }

                        if (objective.idNivelAceptacionEficiencia === 1 && objective.eficiencia > 100) {
                            $scope.dataMultiBarEficiencia[0].values.push({ "label": objective.objectiveType.descripcion + " " + (objective.codigo === "0" ? "" : objective.codigo), "value": objective.eficiencia });
                        } else if (objective.idNivelAceptacionEficiencia === 1 && objective.eficiencia <= 100) {
                            $scope.dataMultiBarEficiencia[1].values.push({ "label": objective.objectiveType.descripcion + " " + (objective.codigo === "0" ? "" : objective.codigo), "value": objective.eficiencia });
                        } else if (objective.idNivelAceptacionEficiencia === 2) {
                            $scope.dataMultiBarEficiencia[2].values.push({ "label": objective.objectiveType.descripcion + " " + (objective.codigo === "0" ? "" : objective.codigo), "value": objective.eficiencia });
                        } else {
                            $scope.dataMultiBarEficiencia[3].values.push({ "label": objective.objectiveType.descripcion + " " + (objective.codigo === "0" ? "" : objective.codigo), "value": objective.eficiencia });
                        }
                    });
            }
        }
    ]
);

