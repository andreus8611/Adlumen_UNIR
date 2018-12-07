'use strict';
adlumenApp.controller('empresasCtrl',
    [
        '$scope', '$uibModal', '$stateParams', 'empresasAPI', 'empresaAPI', 'idTypesAPI', 'paisesAPI', 'tiposArchivosAPI', 'empleadosAPI', 'listasTareasAPI', 'usuariosAPI', 'FileUploadService', 'uiGmapGoogleMapApi', 'uiGmapIsReady', 'translationService', 'languageService', '$window',
        function($scope, $uibModal, $stateParams, empresasAPI, empresaAPI, idTypesAPI, paisesAPI, tiposArchivosAPI, empleadosAPI, listasTareasAPI, usuariosAPI, FileUploadService, uiGmapGoogleMapApi, uiGmapIsReady, translationService, languageService, $window) {

            var localidusuario = 0;

            $scope.$watch('bdUser', function (newValue, oldValue) {

                localidusuario = newValue.idLocal;

            });

            $scope.empresasparams = { idEmpresa: 0 };
            $scope.areaActual = {};
            $scope.cargoActual = {};
            $scope.empleadoActual = {};
            $scope.proveedorActual = {};
            $scope.categoriaActual = {};
            $scope.documentoActual = {};
            $scope.alerts = [];
            $scope.showAlert = false;
            $scope.saved = false;

            $scope.empresasparams.idEmpresa = $stateParams.idEmpresa;

            $scope.tabs = [
                { index: 1, name: 'GENERAL', disabled: false, template: 'app/templates/empresas/generalView.html' },
                { index: 2, name: 'GEOREFERENCIA', disabled: false, template: 'app/templates/empresas/GeoreferenciaView.html' },
                { index: 3, name: 'AREAS', disabled: false, template: 'app/templates/empresas/areasView.html' },
                { index: 4, name: 'RECURSOS_HUMANOS', disabled: false, template: 'app/templates/empresas/recursosHumanosView.html' },
                { index: 5, name: 'PROVEEDORES', disabled: false, template: 'app/templates/empresas/proveedoresView.html' },
                { index: 6, name: 'PUBLICACIONES', disabled: false, template: 'app/templates/empresas/publicacionesView.html' },
                { index: 7, name: 'USUARIOS', disabled: false, template: 'app/templates/empresas/usuariosEmpresaView.html' }
            ]

            $scope.tabSelected = 0;
            $scope.editMode = false;
            $scope.cargoSelected = false;
            $scope.empleadoSelected = false;
            $scope.proveedorSelected = false;
            $scope.categoriaSelected = false;
            $scope.documentoSelected = false;

            //Load services
            empresasAPI($scope);
            idTypesAPI($scope);
            paisesAPI($scope);
            tiposArchivosAPI($scope);
            empleadosAPI($scope);
            listasTareasAPI($scope);
            usuariosAPI($scope);

            $scope.dismissClose = function(index) {
                $scope.alerts.splice(index, 1); 
            }

            //Edit functions
            $scope.Edit = function () {
                $scope.alerts = [];
                if ($scope.tabSelected === 2) {
                    if (!$scope.areaActual.idArea && $scope.areaActual.idArea != 0) {
                        addAlert('danger', $scope.translation["SELECCIONE_AREA"]);
                        return;
                    }
                }

                $scope.editMode = true;
                for (var i = 0; i < $scope.tabs.length ; i++) {
                    if (i == $scope.tabSelected) {
                        $scope.tabs[i].disabled = false;
                    } else {
                        $scope.tabs[i].disabled = true;
                    }
                }
            }

            $scope.CancelEdit = function () {
                $scope.editMode = false;
                $scope.FinishEdit();
                $scope.showCompanyDetails();
            }

            $scope.FinishEdit = function () {
                for (var i = 0; i < $scope.tabs.length ; i++) {
                    $scope.tabs[i].disabled = false;
                }
            }

            //Create new empresa
            $scope.crearNuevaEmpresa = function () {
                $scope.empresa = {};
                $scope.empresa.idEmpresa = 0;
                $scope.empresa.logo = '';
                $scope.Edit();
            }

            //Edit selected empresa
            $scope.showCompanyDetails = function () {
                if ($scope.empresasparams && $scope.empresasparams.idEmpresa) {
                    empresaAPI.getEmpresa($scope).then(
                        function addtoScope(empresa) {
                            $scope.empresa = empresa;
                            $scope.showLocationInMap();

                            if (empresa && empresa.areas)
                                $scope.allAreas = flattenAreas(empresa.areas, 0);
                        }
                    );
                }
            }

            $scope.viewCompanyDetails = function () {
                if ($scope.empresasparams && $scope.empresasparams.idEmpresa) {
                    if ($scope.empresasparams.idEmpresa == 0) {
                        $scope.crearNuevaEmpresa();
                    } else {
                        $scope.showCompanyDetails();
                    }
                }
            }

            $scope.viewCompanyDetails();

            uiGmapGoogleMapApi.then(function (maps) {
                $scope.map = {
                    center: {
                        latitude: 52.47491894326404,
                        longitude: -1.8684210293371217
                    },
                    zoom: 13,
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

            uiGmapIsReady.promise().then(function(instances) {
                $scope.map.object = map = instances[0].map;

                var geoTab = $('#GEOREFERENCIA').parent()[0];

                var styleChangedCallback = function(mutations) {
                    setTimeout(function() { google.maps.event.trigger(map, "resize"); }, 1000);
                }

                var observer = new MutationObserver(styleChangedCallback);
                observer.observe(geoTab, { attributes: true, attributeFilter: ['style'] });
            });

            $scope.googlePlaces = {value: ''};

            $scope.doSearch = function () {
                $scope.location = $scope.googlePlaces.value;
                if ($scope.location === '') {
                    alert('Directive did not update the location property in parent controller.');
                } else {
                    if ($scope.location !== '') {
                        var locationName = $scope.location.name;
                        var locationAddress = $scope.location.formatted_address;
                        var lat = parseFloat($scope.location.geometry.location.lat());
                        var lng = parseFloat($scope.location.geometry.location.lng());

                        $scope.map = {
                            "center": {
                                "latitude": lat,
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
                        $scope.empresa.latitude = lat;
                        $scope.empresa.longitude = lng;
                    }
                }
            };

            $scope.showLocationInMap = function () {
                $scope.map = {
                    "center": {
                        "latitude": $scope.empresa.latitude,
                        "longitude": $scope.empresa.longitude
                    },
                    "zoom": 13
                };
                $scope.marker = {
                    id: 0,
                    coords: {
                        latitude: $scope.empresa.latitude,
                        longitude: $scope.empresa.longitude
                    }
                };
            }

            var map;
            $scope.$on('mapInitialized', function (evt, evtMap) {
                map = evtMap;
                $scope.placeMarker = function (e) {
                    var marker = new google.maps.Marker({ position: e.latLng, map: map });
                    map.panTo(e.latLng);
                }
            });

            $scope.getTabHeader = function (i) {
                var header = "";
                if ($scope.tabs && $scope.translation) {
                    header = $scope.tabs[i].index + " - " + $scope.translation[$scope.tabs[i].name];
                }
                return header;
            }

            $scope.setTab = function (i) {
                if (!$scope.editMode) {
                    $scope.tabSelected = i;
                }
            }

            //$scope.tabSelected = function() {
            //    console.log($event, $selectedIndex);
            //    if (map) {
            //        google.maps.event.trigger(map, "resize");
            //    }
            //}

            //Areas
            $scope.allAreas = [];

            var flattenAreas = function(areas, level) {
                var flat = [];
                for (var i = 0, area; area = areas[i]; i++) {
                    var newArea = angular.copy(area);
                    newArea.level = level;
                    if (''.repeat)
                        newArea.displayName = '- '.repeat(level) + area.nombre;
                    else
                        newArea.displayName = area.nombre;
                    flat.push(newArea);
                    if (area.children) {
                        flat = flat.concat(flattenAreas(area.children, level + 1));
                    }
                }
                return flat;
            }

            $scope.showAreaDetails = function () {
                $scope.areaActual = angular.copy(this.node);
            };

            $scope.removeArea = function() {
                $scope.confirmDelete($scope.translation["BORRAR_AREA_CONFIRMACION"], 'area', this.node);
            }

            $scope.deleteArea = function (item) {

                $scope.alerts = [];

                var areErrors = false;

                if (!areErrors) {
                    $scope.areaActual = angular.copy(item);
                    $scope.areaActual.action = "deleteArea";
                    $scope.areaActual.userId = localidusuario;

                    var postEmpresa = empresaAPI.getRestAll();

                    postEmpresa.post($scope.areaActual).then(function () {

                        addAlert('success', $scope.translation["MSG_DELETED_ITEM"]);
                        $scope.saved = true;
                        $scope.areaActual = {};
                        $scope.showCompanyDetails();
                        $scope.editMode = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }

            }

            $scope.SaveAreas = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.areaActual.idArea == 0) $scope.areaActual.action = "addArea";
                    else $scope.areaActual.action = "modifyArea";
                    $scope.areaActual.userId = localidusuario;

                    var postEmpresa = empresaAPI.getRestAll();

                    postEmpresa.post($scope.areaActual).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_EMPRESA_GUARDADA"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.showCompanyDetails();
                        $scope.editMode = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            }

            $scope.newSubArea = function (_idPadre) {
                $scope.areaActual = {};
                $scope.areaActual.idArea = 0;
                $scope.areaActual.idPadre = _idPadre;
                $scope.areaActual.idEmpresa = $scope.empresa.idEmpresa;
                $scope.areaActual.eliminado = false;
                $scope.areaActual.nuevo = true;
                $scope.Edit();
            }

            //Cargos
            $scope.showCargoDetails = function () {
                $scope.cargoActual = angular.copy(this.node);
                $scope.cargoSelected = true;
                $scope.empleadoSelected = false;
            };

            $scope.removeCargo = function () {
                $scope.confirmDelete($scope.translation["CONFIRM_DELETE_HIERARCHY"], 'cargo', this.node);
            }

            $scope.deleteCargo = function (item) {

                $scope.alerts = [];

                var areErrors = false;

                if (!areErrors) {
                    $scope.cargoActual = angular.copy(item);
                    $scope.cargoActual.action = "deleteCargo";
                    $scope.cargoActual.userId = localidusuario;

                    var postEmpresa = empresaAPI.getRestAll();

                    postEmpresa.post($scope.cargoActual).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_EMPRESA_GUARDADA"]);
                        $scope.saved = true;
                        $scope.cargoActual = {};
                        $scope.showCompanyDetails();
                        empleadosAPI($scope);
                        $scope.editMode = false;
                        $scope.cargoSelected = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }

            }

            $scope.SaveCargos = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.cargoActual.idCargo == 0) $scope.cargoActual.action = "addCargo";
                    else $scope.cargoActual.action = "modifyCargo";
                    $scope.cargoActual.userId = localidusuario;

                    var postEmpresa = empresaAPI.getRestAll();

                    postEmpresa.post($scope.cargoActual).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_EMPRESA_GUARDADA"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.showCompanyDetails();
                        $scope.editMode = false;
                        $scope.cargoSelected = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            }

            $scope.newSubCargo = function (_idPadre) {
                $scope.cargoActual = {};
                $scope.cargoActual.idCargo = 0;
                $scope.cargoActual.idPadre = _idPadre;
                $scope.cargoActual.eliminado = false;
                $scope.cargoSelected = true;
                $scope.empleadoSelected = false;
                $scope.Edit();
            }

            //Empleados
            $scope.showEmpleadoDetails = function () {
                $scope.empleadoActual = angular.copy(this.nodeEmpleado);
                $scope.cargoSelected = false;
                $scope.empleadoSelected = true;
            };

            $scope.removeEmpleado = function () {
                $scope.confirmDelete($scope.translation["BORRAR_EMPLEADO_CONFIRMACION"], 'empleado', this.nodeEmpleado);
            }

            $scope.deleteEmpleado = function (item) {

                $scope.alerts = [];

                var areErrors = false;

                if (!areErrors) {
                    $scope.empleadoActual = angular.copy(item);
                    $scope.empleadoActual.action = "deleteEmpleado";
                    $scope.empleadoActual.userId = localidusuario;

                    var postEmpresa = empresaAPI.getRestAll();

                    postEmpresa.post($scope.empleadoActual).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_EMPRESA_GUARDADA"]);
                        $scope.saved = true;
                        $scope.empleadoActual = {};
                        $scope.showCompanyDetails();
                        empleadosAPI($scope);
                        $scope.editMode = false;
                        $scope.empleadoSelected = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }

            }

            $scope.SaveEmpleadoData = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.empleadoActual.employeeId == 0) $scope.empleadoActual.action = "addEmpleado";
                    else $scope.empleadoActual.action = "modifyEmpleado";
                    $scope.empleadoActual.userId = localidusuario;

                    var postEmpresa = empresaAPI.getRestAll();

                    postEmpresa.post($scope.empleadoActual).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_EMPRESA_GUARDADA"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.showCompanyDetails();
                        empleadosAPI($scope);
                        $scope.editMode = false;
                        $scope.empleadoSelected = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });
                }
            }

            //Save Empleado
            $scope.SaveEmpleado = function () {
                $scope.alerts = [];
                $scope.forms.employee.$setSubmitted(true);

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if (!$scope.SelectedFileForUpload && !$scope.SelectedPhotoForUpload) { //No files to upload
                        $scope.SaveEmpleadoData(); //Simple save
                    } else {
                        if ($scope.SelectedFileForUpload) {
                            $scope.CheckFileValid($scope.SelectedFileForUpload);
                            if ($scope.IsFileValid) {
                                var path = "/" + $scope.empresa.idCliente + "/orgs/" + $scope.empresa.idEmpresa + "/emp";
                                FileUploadService.UploadFile($scope.SelectedFileForUpload, $scope.FileDescription, path).then(function (d) {
                                    $scope.empleadoActual.cv = FileUploadService.getSavedFilePath();
                                    if ($scope.SelectedPhotoForUpload) {
                                        uploadEmployeePhoto();
                                    }
                                    else {
                                        $scope.SaveEmpleadoData();
                                        ClearForm();
                                    }
                                }, function (e) {
                                    addAlert('danger', e);
                                });
                            }
                        }
                        else if ($scope.SelectedPhotoForUpload) {
                            uploadEmployeePhoto();
                        }
                    }
                }
            };

            var uploadEmployeePhoto = function() {
                    $scope.CheckFileValidImage($scope.SelectedPhotoForUpload);
                    if ($scope.IsFileValid) {
                        var path = "/" + $scope.empresa.idCliente + "/orgs/" + $scope.empresa.idEmpresa + "/emp";
                        FileUploadService.UploadFile($scope.SelectedPhotoForUpload, $scope.FileDescription, path).then(function (d) {
                            $scope.empleadoActual.foto = FileUploadService.getSavedFilePath();
                            $scope.SaveEmpleadoData();
                            ClearForm();
                        }, function (e) {
                            addAlert('danger', e);
                        });
                    }
            }

            $scope.newEmpleado = function (_idPadre) {
                $scope.empleadoActual = {};
                $scope.empleadoActual.employeeId = 0;
                $scope.empleadoActual.titleId = _idPadre;
                $scope.empleadoActual.eliminado = false;
                $scope.cargoSelected = false;
                $scope.empleadoSelected = true;
                $scope.Edit();
            }

            //Proveedores
            $scope.showProveedorDetails = function () {
                $scope.proveedorActual = angular.copy(this.proveedor);
                $scope.proveedorSelected = true;
            };

            $scope.removeProveedor = function () {
                $scope.confirmDelete($scope.translation["BORRAR_PROVEEDOR_CONFIRMACION"], 'proveedor', this.proveedor);
            }

            $scope.deleteProveedor = function (item) {

                $scope.alerts = [];

                var areErrors = false;

                if (!areErrors) {
                    $scope.proveedorActual = angular.copy(item);
                    $scope.proveedorActual.action = "deleteProveedor";
                    $scope.proveedorActual.userId = localidusuario;

                    var postEmpresa = empresaAPI.getRestAll();

                    postEmpresa.post($scope.proveedorActual).then(function () {

                        addAlert('success', $scope.translation["MSG_DELETED_ITEM"]);
                        $scope.saved = true;
                        $scope.proveedorActual = {};
                        $scope.showCompanyDetails();
                        $scope.editMode = false;
                        $scope.proveedorSelected = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }

            }

            $scope.SaveProveedorData = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.proveedorActual.id == 0) $scope.proveedorActual.action = "addProveedor";
                    else $scope.proveedorActual.action = "modifyProveedor";
                    $scope.proveedorActual.userId = localidusuario;

                    var postEmpresa = empresaAPI.getRestAll();

                    postEmpresa.post($scope.proveedorActual).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_EMPRESA_GUARDADA"]);
                        $scope.saved = true;
                        $scope.proveedorActual = {};
                        $scope.FinishEdit();
                        $scope.showCompanyDetails();
                        $scope.editMode = false;
                        
                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });
                }
            }

            //Save Proveedor
            $scope.SaveProveedor = function () {
                $scope.alerts = [];
                $scope.forms.supplier.$setSubmitted(true);

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.SelectedFileForUpload) {
                        $scope.CheckFileValid($scope.SelectedFileForUpload);
                        if ($scope.IsFileValid) {
                            var path = "/" + $scope.empresa.idCliente + "/orgs/" + $scope.empresa.idEmpresa + "/sup";
                            FileUploadService.UploadFile($scope.SelectedFileForUpload, $scope.FileDescription, path).then(function (d) {
                                $scope.proveedorActual.cv = FileUploadService.getSavedFilePath();
                                $scope.SaveProveedorData();
                                ClearForm();
                            }, function (e) {
                                addAlert('danger', e);
                            });
                        }
                    }
                    else {
                        $scope.SaveProveedorData();
                    }
                }
            };

            $scope.newProveedor = function () {
                $scope.proveedorActual = {};
                $scope.proveedorActual.id = 0;
                $scope.proveedorActual.idCompany = $scope.empresa.idEmpresa;
                $scope.proveedorActual.deleted = false;
                $scope.proveedorActual.nuevo = true;
                $scope.Edit();
            }

            //Publicaciones
            $scope.showCategoryDetails = function () {
                $scope.categoriaActual = angular.copy(this.node);
                $scope.categoriaSelected = true;
                $scope.documentoSelected = false;
            };

            $scope.removeCategory = function () {
                $scope.confirmDelete($scope.translation["BORRAR_CATEGORY_CONFIRMACION"], 'categoria', this.node);
            }

            $scope.deleteCategory = function (item) {

                $scope.alerts = [];

                var areErrors = false;

                if (!areErrors) {
                    $scope.categoriaActual = angular.copy(item);
                    $scope.categoriaActual.action = "deleteCategoria";
                    $scope.categoriaActual.userId = localidusuario;

                    var postEmpresa = empresaAPI.getRestAll();

                    postEmpresa.post($scope.categoriaActual).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_EMPRESA_GUARDADA"]);
                        $scope.saved = true;
                        $scope.categoriaActual = {};
                        $scope.showCompanyDetails();
                        $scope.editMode = false;
                        $scope.categoriaSelected = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            }

            $scope.SaveCategoria = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.categoriaActual.id == 0) $scope.categoriaActual.action = "addCategoria";
                    else $scope.categoriaActual.action = "modifyCategoria";
                    $scope.categoriaActual.userId = localidusuario;

                    var postEmpresa = empresaAPI.getRestAll();

                    postEmpresa.post($scope.categoriaActual).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_EMPRESA_GUARDADA"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.showCompanyDetails();
                        $scope.editMode = false;
                        $scope.categoriaSelected = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            }

            $scope.newSubCategoria = function (_idPadre) {
                $scope.categoriaActual = {};
                $scope.categoriaActual.id = 0;
                $scope.categoriaActual.parentId = _idPadre;
                $scope.categoriaActual.status = false;
                $scope.categoriaSelected = true;
                $scope.documentoSelected = false;
                $scope.Edit();
            }
            
            $scope.showDocumentoDetails = function () {
                $scope.documentoActual = angular.copy(this.nodeDocumento);
                $scope.LoadRoles();
                $scope.documentoActual.generaTarea = false;
                $scope.categoriaSelected = false;
                $scope.documentoSelected = true;
            };

            $scope.LoadRoles = function () {
                var roles = [];
                if ($scope.empresa.availableRoles) {
                    for (var x = 0; x < $scope.empresa.availableRoles.length; x++) {
                        var included = false;
                        if($scope.documentoActual.roles){
                            if ($scope.documentoActual.roles.indexOf($scope.empresa.availableRoles[x]) > -1){
                                included = true;
                            }
                        }
                        var rol = { rol: $scope.empresa.availableRoles[x], included: included }
                        roles.push(rol);
                    }
                }
                $scope.documentoActual.rolesList = roles;
            }

            $scope.SaveDocumentoData = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.documentoActual.id == 0) $scope.documentoActual.action = "addDocumento";
                    else $scope.documentoActual.action = "modifyDocumento";
                    $scope.documentoActual.userId = localidusuario;

                    var rolesstr = null;
                    for (var x = 0; x < $scope.documentoActual.rolesList.length; x++) {
                        if ($scope.documentoActual.rolesList[x].included) {
                            if (rolesstr) rolesstr = rolesstr + "," + $scope.documentoActual.rolesList[x].rol;
                            else rolesstr = $scope.documentoActual.rolesList[x].rol;
                        }
                    }
                    $scope.documentoActual.roles = rolesstr;

                    var postEmpresa = empresaAPI.getRestAll();

                    postEmpresa.post($scope.documentoActual).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_EMPRESA_GUARDADA"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.showCompanyDetails();
                        $scope.editMode = false;
                        $scope.documentoSelected = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });
                }
            }

            //Save Documento
            $scope.SaveDocumento = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.SelectedFileForUpload) {
                        $scope.CheckFileValidDocument($scope.SelectedFileForUpload);
                        if ($scope.IsFileValid) {
                            var path = "/" + $scope.empresa.idCliente + "/" + $scope.documentoActual.categoryId;
                            FileUploadService.UploadFile($scope.SelectedFileForUpload, $scope.FileDescription, path).then(function (d) {
                                $scope.documentoActual.url = FileUploadService.getSavedFilePath();
                                $scope.documentoActual.fileTypeId = $scope.SelectedFileForUploadType;
                                $scope.SaveDocumentoData();
                                ClearForm();
                            }, function (e) {
                                addAlert('danger', e);
                            });
                        }
                    }
                    else {
                        $scope.SaveDocumentoData();
                    }
                }
            };

            $scope.removeDocument = function () {
                $scope.confirmDelete($scope.translation["BORRAR_DOCUMENTO_CONFIRMACION"], 'documento', this.nodeDocumento);
            }

            $scope.deleteDocument = function (item) {
                $scope.alerts = [];

                var areErrors = false;

                if (!areErrors) {
                    $scope.documentoActual = angular.copy(item);
                    $scope.documentoActual.action = "deleteDocumento";
                    $scope.documentoActual.userId = localidusuario;

                    var postEmpresa = empresaAPI.getRestAll();

                    postEmpresa.post($scope.documentoActual).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_EMPRESA_GUARDADA"]);
                        $scope.saved = true;
                        $scope.showCompanyDetails();
                        $scope.editMode = false;
                        $scope.documentoSelected = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });
                }
            }

            $scope.newDocumento = function (_idPadre) {
                $scope.documentoActual = {};
                $scope.documentoActual.id = 0;
                $scope.documentoActual.categoryId = _idPadre;
                $scope.LoadRoles();
                $scope.documentoActual.generaTarea = false;
                $scope.categoriaSelected = false;
                $scope.documentoSelected = true;
                $scope.Edit();
            }

            //Usuarios
            $scope.SaveUsuariosEmpresa = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    $scope.empresa.action = "modifyUsuarios";
                    $scope.empresa.userId = localidusuario;

                    var postEmpresa = empresaAPI.getRestAll();

                    postEmpresa.post($scope.empresa).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_EMPRESA_GUARDADA"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.showCompanyDetails();
                        $scope.editMode = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            }

            //General
            $scope.SaveGeneralData = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.empresa.idEmpresa == 0) $scope.empresa.action = "addGeneral";
                    else $scope.empresa.action = "modifyGeneral";
                    $scope.empresa.userId = localidusuario;

                    var postEmpresa = empresaAPI.getRestAll();

                    postEmpresa.post($scope.empresa).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_EMPRESA_GUARDADA"]);
                        $scope.saved = true;
                        $scope.FinishEdit();
                        $scope.showCompanyDetails();
                        $scope.editMode = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            }

            $scope.SaveGeneral = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if ($scope.SelectedFileForUpload) {
                        $scope.CheckFileValidImage($scope.SelectedFileForUpload);
                        if ($scope.IsFileValid) {
                            var path = "/" + $scope.empresa.idCliente + "/orgs/" + $scope.empresa.idEmpresa;
                            FileUploadService.UploadFile($scope.SelectedFileForUpload, $scope.FileDescription, path).then(function (d) {
                                $scope.empresa.logo = FileUploadService.getSavedFilePath();
                                $scope.SaveGeneralData();
                                ClearForm();
                            }, function (e) {
                                addAlert('danger', e);
                            });
                        }
                    }
                    else {
                        $scope.SaveGeneralData();
                    }
                }
            };

            $scope.EliminarEmpresa = function () {
                $scope.confirmDelete($scope.translation["BORRAR_EMPRESA_CONFIRMACION"], 'empresa', $scope.empresa);
            }

            $scope.deleteEmpresa = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    $scope.empresa.action = "deleteEmpresa";
                    $scope.empresa.userId = localidusuario;

                    var postEmpresa = empresaAPI.getRestAll();

                    postEmpresa.post($scope.empresa).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_EMPRESA_GUARDADA"]);
                        $scope.saved = true;

                        empresasAPI($scope);
                        $scope.empresasparams = { idEmpresa: 0 };
                        $scope.empresa = {};
                        $scope.editMode = false;

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            }

            $scope.validate = function () {
                var areErrors = false;

                if ($scope.tabSelected === 0) { //General
                    if (!$scope.empresa.nombre || !$scope.empresa.ubicacion || !$scope.empresa.idIdentificacionTipo || !$scope.empresa.idPais) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["EMPRESA_GENERAL_ERROR_CAMPOS_VACIOS"]);
                    }
                }
                if ($scope.tabSelected === 2) { //Areas
                    if (!$scope.areaActual.nombre || !$scope.areaActual.objetivo) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["EMPRESA_AREA_ERROR_CAMPOS_VACIOS"]);
                    }
                    if ($scope.areaActual.idResponsable) {
                        var exists = false;
                        for (var i = 0; i < $scope.empresa.areas.length; i++) {
                            exists = $scope.IsResponsableAsignado($scope.areaActual.idArea, $scope.areaActual.idResponsable, $scope.empresa.areas[i]);
                            if (exists) break;
                        }
                        if (exists) {
                            areErrors = true;
                            addAlert('danger', $scope.translation["RESPONSABLE_YA_ASIGNADO"]);
                        }
                    }
                }
                if ($scope.tabSelected === 3 && $scope.cargoSelected) { //Cargos
                    if (!$scope.cargoActual.nombre || !$scope.cargoActual.idArea || !$scope.cargoActual.perfil) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["EMPRESA_CARGO_ERROR_CAMPOS_VACIOS"]);
                    }
                }
                if ($scope.tabSelected === 3 && $scope.empleadoSelected) { //Empleados
                    if (!$scope.empleadoActual.name || !$scope.empleadoActual.lastName || !$scope.empleadoActual.idType || !$scope.empleadoActual.idNumber) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["EMPRESA_EMPLEADO_ERROR_CAMPOS_VACIOS"]);
                    }
                    else if ($scope.forms.employee.$error.email) {//!isValidEmail($scope.empleadoActual.email)) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["EMPRESA_EMPLEADO_ERROR_CORREO_INVALIDO"]);
                    }
                    else if (!$scope.empleadoActual.employeeId
                           && $scope.empleadoActual.idType
                           && $scope.empleadoActual.idNumber) {

                        var exists = false;
                        for (var i = 0; i < $scope.empresa.cargos.length; i++) {
                            exists = $scope.EmpleadoYaExiste($scope.empleadoActual.idType, $scope.empleadoActual.idNumber, $scope.empresa.cargos[i]);
                            if (exists) break;
                        }
                        if (exists) {
                            areErrors = true;
                            addAlert('danger', $scope.translation["EMPLEADO_YA_EXISTE"]);
                        }
                    }
                }
                if ($scope.tabSelected === 4) { //Proveedores
                    if (!$scope.proveedorActual.name || !$scope.proveedorActual.idIdentification || !$scope.proveedorActual.identification) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["EMPRESA_PROVEEDOR_ERROR_CAMPOS_VACIOS"]);
                    }
                    else if ($scope.forms.supplier.$error.email) {//!isValidEmail($scope.proveedorActual.mail)) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["EMPRESA_PROVEEDOR_ERROR_CORREO_INVALIDO"]);
                    }
                }
                if ($scope.tabSelected === 5 && $scope.categoriaSelected) { //Publicaciones
                    if (!$scope.categoriaActual.name || !$scope.categoriaActual.description) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["EMPRESA_CATEGORIA_ERROR_CAMPOS_VACIOS"]);
                    }
                }
                if ($scope.tabSelected === 5 && $scope.documentoSelected) { //Publicaciones
                    if (!$scope.documentoActual.title || !$scope.documentoActual.resume || !$scope.documentoActual.keyWords || (!$scope.SelectedFileForUpload && !$scope.documentoActual.url)) {
                        areErrors = true;
                        addAlert('danger', $scope.translation["EMPRESA_DOCUMENTO_ERROR_CAMPOS_VACIOS"]);
                    }
                }
                return areErrors;
            }

            $scope.IsResponsableAsignado = function (idAreaActual, idResponsable, area) {
                if (area.idResponsable == idResponsable && idAreaActual != area.idArea) return true;
                else {
                    for (var j = 0; j < area.children.length; j++) {
                        var exists = $scope.IsResponsableAsignado(idAreaActual, idResponsable, area.children[j]);
                        if (exists) return true;
                    }
                    return false;
                }
            }

            $scope.EmpleadoYaExiste = function (idType, idNumber, cargo) {
                for (var x = 0; x < cargo.empleados.length; x++) {
                    if (cargo.empleados[x].idType == idType && cargo.empleados[x].idNumber == idNumber) {
                        return true;
                    }
                }
                for (var j = 0; j < cargo.children.length; j++) {
                    var exists = $scope.EmpleadoYaExiste(idType, idNumber, cargo.children[j]);
                    if (exists) return true;
                }
                return false;
            }

            //Check file
            $scope.CheckFileValid = function (file) {
                var isValid = false;
                if ($scope.SelectedFileForUpload != null) {
                    isValid = true;
                }
                else {
                    $scope.Message = $scope.translation["SELECCIONE_ARCHIVO_PRIMERO"];
                }
                $scope.IsFileValid = isValid;
            };

            $scope.CheckFileValidImage = function (file) {
                var isValid = false;
                if (file != null) {
                    if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') && file.size <= (512 * 1024)) {
                        $scope.Message = "";
                        isValid = true;
                    }
                    else {
                        $scope.Message = $scope.translation["ARCHIVO_IMAGEN_INVALIDO"];
                    }
                }
                else {
                    $scope.Message = $scope.translation["SELECCIONE_ARCHIVO_PRIMERO"];
                }
                $scope.IsFileValid = isValid;
            };

            $scope.CheckFileValidDocument = function (file) {
                var isValid = false;
                if ($scope.SelectedFileForUpload != null) {
                    var fileextension = file.name.substr(file.name.lastIndexOf('.'));
                    var supported = false;
                    var supportedText = '';
                    if ($scope.archivostipos) {
                        for (var i = 0; i < $scope.archivostipos.length; i++) {
                            supportedText = $scope.archivostipos[i].mime_type + ', ' + supportedText;
                            if (fileextension == $scope.archivostipos[i].mime_type)
                            {
                                supported = true;
                                $scope.SelectedFileForUploadType = $scope.archivostipos[i].idTipoArchivo;
                            }
                        }
                    }
                    if (supported) {
                        $scope.Message = "";
                        isValid = true;
                    }
                    else {
                        supportedText = supportedText.substr(0, (supportedText.length - 1));
                        supportedText = supportedText + '.';
                        $scope.Message = $scope.translation["ARCHIVO_DOCUMENTO_INVALIDO"] + supportedText;
                    }
                }
                else {
                    $scope.Message = $scope.translation["SELECCIONE_ARCHIVO_PRIMERO"];
                }
                $scope.IsFileValid = isValid;
            };

            //File Select event 
            $scope.selectFileforUpload = function (file) {
                $scope.SelectedFileForUpload = file[0];
            }

            //Foto Select event 
            $scope.selectPhotoforUpload = function (file) {
                $scope.SelectedPhotoForUpload = file[0];
            }

            //Clear form 
            function ClearForm() {
                //as 2 way binding not support for File input Type so we have to clear in this way
                //you can select based on your requirement
                angular.forEach(angular.element("input[type='file']"), function (inputElem) {
                    angular.element(inputElem).val(null);
                });
                $scope.SelectedFileForUpload = null;
                $scope.SelectedPhotoForUpload = null;
            }

            //Confirmation
            $scope.confirmDelete = function (mensaje, sender, item) {
                $scope.mensajeConfirmacion = mensaje;
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: 'modalConfirmation.html',
                    controller: 'modalConfirmationInstanceCtrl',
                    size: 'sm',
                    resolve: {
                        mensaje: function () {
                            return $scope.mensajeConfirmacion;
                        }
                    }
                });

                modalInstance.result.then(function (response) {
                    //Yes
                    if (sender == 'area') { $scope.deleteArea(item); }
                    if (sender == 'cargo') { $scope.deleteCargo(item); }
                    if (sender == 'empleado') { $scope.deleteEmpleado(item); }
                    if (sender == 'proveedor') { $scope.deleteProveedor(item); }
                    if (sender == 'categoria') { $scope.deleteCategory(item); }
                    if (sender == 'documento') { $scope.deleteDocument(item); }
                    if (sender == 'empresa') { $scope.deleteEmpresa()}

                }, function () {
                    //No
                });
            };

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            };

            //Close
            $scope.close = function () {
                $window.location.href = '#!/administracion/2';
            }

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