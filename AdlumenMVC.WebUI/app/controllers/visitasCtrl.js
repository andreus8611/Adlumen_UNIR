'use strict';
adlumenApp
    //.config(function(uiGmapGoogleMapApiProvider) {
    //    uiGmapGoogleMapApiProvider.configure({
    //        key: 'AIzaSyBxRu85_s3KiXseZG7lAQfQ2Vr6NAFPPhs',
    //        v: '3.32',
    //        libraries: 'places,weather,geometry,visualization'
    //    });
    //})
    .controller('visitasCtrl',
    [
        '$scope', 'visitasAPI', 'tareaAPI', 'translationService', 'languageService', '$window', 'uiGmapGoogleMapApi','$stateParams',
        function ($scope, visitasAPI, tareaAPI, translationService, languageService, $window, uiGmapGoogleMapApi, $stateParams) {

            var localidtarea = parseInt($stateParams.idTarea);
            var localidusuario = 0;

            $scope.getLogBook = function (visita) {
                $scope.selectedVisit = visita;
                $scope.$state.go('base.visits.logBook', { idVisita: visita.idVisita });
            };

            var getTask = function () {
                tareaAPI($scope);
                $scope.$watch('tasks', function (newValue, oldValue) {
                    if (!_.isUndefined(newValue))
                        $scope.tarea = _.findWhere(newValue, { id: localidtarea });
                });
            };

            $scope.$watchCollection('[todasLasVisitas, bdUser]', function (newValue, oldValue) {

                if (!_.isUndefined(newValue[1]))
                    localidusuario = newValue[1].idLocal;
                
                if (!_.isUndefined(newValue[0])) {

                    if (!_.isUndefined((newValue[0]).tar_Tareas)) {
                        $scope.tarea = _.first(newValue[0]).tar_Tareas;
                    }
                    else {
                        getTask();
                    }

                    $scope.visitas = _.filter(newValue[0], function (_visitas) {
                        var permisosBitacora = _.filter(_visitas.tar_Permisos_Bitacora, function (_permisos) {
                            return _permisos.idUsuario == localidusuario
                        });

                        _visitas.fecha = new Date(_visitas.fecha + 'Z');

                        return _visitas.idTarea == localidtarea && (
                            _visitas.tar_Tareas.idResponsable == localidusuario ||
                            _visitas.tar_Tareas.idUsuarioCreacion == localidusuario ||
                            permisosBitacora.length > 0);
                    });
                }

                
            });

            visitasAPI($scope);

            $scope.visitaNueva = { idVisita: 0, fecha: new Date()};
            $scope.showAlert = false;
            $scope.newVisita = false;

            $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
            $scope.format = $scope.formats[0];

            $scope.estados = [
                { id: 'A', name: 'VISITA_ABIERTA' },
                { id: 'C', name: 'VISITA_TERMINADA' },
                { id: 'E', name: 'VISITA_ELIMINADA' }
            ];


            uiGmapGoogleMapApi.then(function (maps) {
                $scope.map = {
                    center: {
                        latitude: 52.47491894326404,
                        longitude: -1.8684210293371217
                    },
                    zoom: 14,
                    bounds: {}
                };

                $scope.marker = {
                    id: 0,
                    coords: {
                        latitude: 52.47491894326404,
                        longitude: -1.8684210293371217
                    },
                    options: { draggable: false },
                    events: {
                        dragend: function (marker, eventName, args) {

                            $scope.marker.options = {
                                draggable: true,
                                labelContent: "lat: " + $scope.marker.coords.latitude + ' ' + 'lon: ' + $scope.marker.coords.longitude,
                                labelAnchor: "100 0",
                                labelClass: "marker-labels"
                            };
                        }
                    }
                };

            });

            $scope.location = '';

            $scope.doSearch = function () {
                if ($scope.location === '') {
                    alert('Directive did not update the location property in parent controller.');
                } else {
                    if ($scope.location !== '')
                    {
                        var locationName = $scope.location.name;
                        var locationAddress = $scope.location.formatted_address;
                        var lat = parseFloat($scope.location.geometry.location.lat());
                        var lng = parseFloat($scope.location.geometry.location.lng());

                        $scope.map = {
                            "center": {
                                "latitude":  lat,
                                "longitude": lng
                            },
                            "zoom": 13
                        };
                        $scope.marker = {
                            id: 0,
                            coords: {
                                latitude: lat,
                                longitude: lng
                            }
                        };
                        $scope.visitaNueva.latitud = lat;
                        $scope.visitaNueva.longitud = lng;
                        $scope.visitaNueva.ubicacion = locationName;
                        if (locationAddress !== '') {
                            $scope.visitaNueva.ubicacion = locationAddress;
                        }
                    }
                }
            };

            $scope.opened = false;

            $scope.open = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();

                $scope.opened = true;
            };

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            };

            $scope.editSelected = function () {
                $scope.visitaNueva.idVisita = this.visita.idVisita;
                $scope.visitaNueva.fecha = this.visita.fecha;
                $scope.visitaNueva.descripcion = this.visita.descripcion;
                $scope.visitaNueva.ubicacion = this.visita.ubicacion;
                $scope.visitaNueva.personaContacto = this.visita.personaContacto;
                if (this.visita.estado === 'A') $scope.newVisita = true; //Sólo se pueden modificar las visitas abiertas
            };

            $scope.showLocationInMap = function () {
                $scope.map = {
                    "center": {
                        "latitude": this.visita.latitud,
                        "longitude": this.visita.longitud
                    },
                    "zoom": 13
                };
                $scope.marker = {
                    id: 0,
                    coords: {
                        latitude: this.visita.latitud,
                        longitude: this.visita.longitud
                    }
                };
            }

            //$scope.viewLog = function () {
            //    var visitaId = this.visita.idVisita;
            //    $scope.visitaSeleccionada = visitaId;
            //    $window.location.href = '#!/logBook/' + visitaId;
            //};

            $scope.viewRights = function () {
                var visitaId = this.visita.idVisita;
                $scope.visitaSeleccionada = visitaId;
                $window.location.href = '#!/logRights/' + visitaId;
            };

            $scope.enableAddNew = function () {
                var enable = false;
                if ($scope.tarea) {
                    if ($scope.tarea.idUsuarioCreacion == localidusuario || $scope.tarea.idResponsable == localidusuario) {
                        enable = true;
                    }
                }
                    return enable;
            }

            $scope.enableEditing = function () {
                if (!_.isUndefined(this.visita)) {
                    if (this.visita.estado === 'A') { //Sólo se pueden modificar las visitas abiertas
                        if(this.visita.tar_Tareas.idResponsable == localidusuario ||
                           this.visita.tar_Tareas.idUsuarioCreacion == localidusuario) {
                            return true;
                        }
                        else {
                            var permisos = this.visita.tar_Permisos_Bitacora;
                            var allowed = false;
                            var i = 0;

                            for (i = 0; i < permisos.length; i++) {
                                if (permisos[i].idUsuario === localidusuario && permisos[i].permiso && permisos[i].permiso.indexOf("WV") !== -1) {
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

            $scope.enableEditingRights = function () {
                if (!_.isUndefined(this.visita)) {
                    if (this.visita.estado === 'A') { //Sólo se pueden modificar las visitas abiertas
                        if (this.visita.tar_Tareas.idResponsable == localidusuario) { //Sólo el responsable puede otorgar permisos
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                    else {
                        return false;
                    }
                }
            };

            $scope.getEstadoIndexById = function (idEstado) {
                for (var i = 0; i < $scope.estados.length; i++) {
                    if ($scope.estados[i].id === idEstado)
                        return i;
                }
            }

            $scope.getEstadoDescription = function (visita) {
                var estadoName;
                var estado = $scope.estados[$scope.getEstadoIndexById(visita.estado)];
                if (estado !== undefined)
                    estadoName = estado.name;
                if ($scope.translation !== undefined)
                    estadoName = $scope.translation[estadoName];
                return estadoName;
            }

            var map;
            $scope.$on('mapInitialized', function (evt, evtMap) {
                map = evtMap;
                $scope.placeMarker = function (e) {
                    var marker = new google.maps.Marker({ position: e.latLng, map: map });
                    map.panTo(e.latLng);
                }
            });

            $scope.addVisita = function () {

                $scope.alerts = [];

                var areErrors = false;

                if ($scope.visitaNueva.fecha === undefined || $scope.visitaNueva.descripcion === undefined || $scope.visitaNueva.ubicacion === undefined) {
                    areErrors = true;
                    addAlert('danger', $scope.translation["ERROR_CAMPOS_VACIOS"]);
                }

                if ($scope.visitaNueva.ubicacion === undefined) {
                    areErrors = true;
                    addAlert('danger', $scope.translation["ERROR_UBICACION_VACIA"]);
                }

                if (!areErrors) {


                    $scope.visitaNueva.action = "addmodify";
                    $scope.visitaNueva.idTarea = localidtarea;
                    $scope.todasLasVisitas.post($scope.visitaNueva).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_VISITA_GUARDADA"]);

                        $scope.visitaNueva = { idVisita: 0, fecha: new Date() };
                        $scope.newVisita = false;
                        visitasAPI($scope);

                    }, function (error) {

                        addAlert('danger', $scope.translation.ERROR_GUARDADO + ': ' + error.data.exceptionMessage);

                    });

                }
            };

            $scope.deleteVisita = function () {
                if (confirm($scope.translation["BORRAR_VISITA_CONFIRMACION"])) {
                    // Save it!
                    $scope.visitaNueva.idVisita = this.visita.idVisita;

                    $scope.alerts = [];

                    var areErrors = false;

                    if (!areErrors) {

                        $scope.visitaNueva.action = "delete";
                        $scope.todasLasVisitas.post($scope.visitaNueva).then(function () {

                            addAlert('success', $scope.translation["MENSAJE_VISITA_ELIMINADA"]);

                            $scope.visitaNueva = { idVisita: 0, fecha: new Date() };
                            $scope.newVisita = false;
                            visitasAPI($scope);

                        }, function () {

                            addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                        });

                    }
                } else {
                    // Do nothing!
                }
            };

            $scope.completeVisita = function () {
                if (confirm($scope.translation["COMPLETAR_VISITA_CONFIRMACION"])) {
                    // Lock it!
                    $scope.visitaNueva.idVisita = this.visita.idVisita;
                    $scope.alerts = [];

                    var areErrors = false;

                    if (!areErrors) {

                        $scope.visitaNueva.action = "complete";
                        $scope.todasLasVisitas.post($scope.visitaNueva).then(function () {

                            addAlert('success', $scope.translation["MENSAJE_VISITA_COMPLETADA"]);

                            $scope.visitaNueva = { idVisita: 0, fecha: new Date() };
                            $scope.newVisita = false;
                            visitasAPI($scope);

                        }, function () {

                            addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                        });

                    }
                } else {
                    // Do nothing!
                }
            };

            $scope.resetVisita = function (visitaNueva) {
                $scope.visitaNueva = { idVisita: 0, fecha: new Date() };
                $scope.newVisita = false;
                visitasAPI($scope);
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
                    (item.descripcion && item.descripcion.toLowerCase().indexOf(text.toLowerCase()) != -1) ||
                    (item.ubicacion && item.ubicacion.toLowerCase().indexOf(text.toLowerCase()) != -1)) {
                    return true;
                }
                return false;
            }
        }
    ]
);