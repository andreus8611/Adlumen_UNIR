'use strict';

var adlumenApp = angular.module('adlumenApp',
    [
        "uiGmapgoogle-maps",
        "ngResource",
        "ui.tree",
        "chart.js",
        "ui.router",
        "restangular",
        "ui.bootstrap",
        "ngAnimate",
        "angularMoment",
        "ngCookies",
        "LocalStorageModule",
        //"angular-raphael-gauge",
        "gantt",
        "gantt.table",
        "gantt.tree",
        "ui.calendar",
        "nvd3",
        "nemLogging",
        'angularjs-gauge',
        'ngSanitize',
        'ui.tinymce'
    ]);

adlumenApp.config(
    [
        '$stateProvider', '$urlRouterProvider', '$provide', '$locationProvider', '$httpProvider', 'uiGmapGoogleMapApiProvider','nemDebugProvider',
        function ($stateProvider, $urlRouterProvider, $provide, $locationProvider, $httpProvider, uiGmapGoogleMapApiProvider, nemDebugProvider) {

            var debug = nemDebugProvider.debug;
            debug.enable("app:*");

            uiGmapGoogleMapApiProvider.configure({
                key: 'AIzaSyBxRu85_s3KiXseZG7lAQfQ2Vr6NAFPPhs',
                v: '3.33',
                libraries: 'places,weather,geometry,visualization'
            });

            $httpProvider.interceptors.push('authInterceptorService');
            /*for (tpl in AdlumenConf.templates) {
                console.log(AdlumenConf.templates[tpl]);, 
                AdlumenConf.templates[tpl] = AdlumenConf.templates[tpl].replace('{version}', AdlumenConf.currentVersion);
            }*/
            adlumenApp.register = {
                factory: $provide.factory,
                service: $provide.service,
                constant: $provide.constant
            };

            Chart.defaults.global.colors = [
                '#36a2eb', '#ff6384', '#ffcd56', '#4bc0c0', '#ff9f40', '#9966ff'
            ];

            //cambiar la url periods de / por /periods cuando ya este en producción

            $stateProvider
                .state('base', {
                    //abstract: true,
                    controller: "baseCtrl",
                    templateUrl: "app/templates/base/base.html"
                })
                .state('base.dashboard', {
                    url: "/",
                    templateUrl: "app/templates/dashboard/dashboard.html",
                    controller: 'dashboardCtrl'
                })
                .state('base.periods', {
                    url: "/periods",
                    templateUrl: "app/templates/periodos/period.html"
                }).state('base.currency', {
                    url: "/currency",
                    templateUrl: "app/templates/monedas/currency.html"
                }).state('base.monedas', {
                    url: "/monedas",
                    templateUrl: "app/templates/monedas/monedas.html",
                    controller: "monedaCtrl"
                }).state('base.exchange', {
                    url: "/exchange",
                    templateUrl: "app/templates/tipo_cambio/tipocambio.html",
                    controller: "tipcambioCtrl"
                }).state('login', {
                    url: "/login",
                    templateUrl: "app/templates/account/login.html"
                }).state('forgotPassword', {
                    url: "/forgotPassword",
                    templateUrl: "app/templates/account/forgotPassword.html"
                }).state('resetPassword', {
                    url: "/resetPassword",
                    templateUrl: "app/templates/account/resetPassword.html"
                }).state('base.users', {
                    url: "/users",
                    templateUrl: "app/templates/account/users.html",
                    controller: "usersCtrl"
                }).state('base.profile', {
                    url: "/profile",
                    templateUrl: "app/templates/account/profile.html",
                    controller: "usersCtrl"
                }).state('base.facilitador', {
                    url: "/facilitators",
                    templateUrl: "app/templates/facilitadores/facilitator.html"

                }).state('base.capacitacion', {
                    url: "/capacitaciones",
                    templateUrl: "app/templates/capacitaciones/capacitacion.html"

                }).state('base.capacitacion/new', {
                    url: "/capacitaciones/add",
                    templateUrl: "app/templates/capacitaciones/formCapacitacion.html"

                }).state('base.beneficiario', {
                    url: "/beneficiarios",
                    templateUrl: "app/templates/beneficiarios/beneficiario.html"

                }).state('base.beneficiario/new', {
                    url: "/beneficiarios/add",
                    templateUrl: "app/templates/beneficiarios/formBeneficiario.html"

                })
                .state('base.beneficiario/update', {
                    url: "/beneficiarios/update",
                    templateUrl: "app/templates/beneficiarios/formBeneficiario.html"

                })
                .state('base.beneficiario/productividad', {
                    url: "/productividades/:idBeneficiario",
                    templateUrl: "app/templates/beneficiarioProductividad/productividad.html"

                }).state('base.beneficiario/productividad/new', {
                    url: "/productividades/:idBeneficiario/add",
                    templateUrl: "app/templates/beneficiarioProductividad/formProductividad.html"

                }).state('base.capacitacion/beneficiarios', {
                    url: "/capacitacion/:idCapacitacion/beneficiarios",
                    templateUrl: "app/templates/beneficiariosCapacitacion/beneficiariosCapacitacion.html"

                }).state('base.capacitacion/beneficiarios/add', {
                    url: "/capacitacion/:idCapacitacion/beneficiarios/add",
                    templateUrl: "app/templates/beneficiariosCapacitacion/formBeneficiariosCapacitacion.html"
                }).state('base.inquiries', {
                    url: "/inquiries",
                    templateUrl: "app/templates/encuestas/encuesta.html",
                    controller: "encuestasCtrl"
                }).state('base.inquiry/questionnaire', {
                    url: "/questionnaire/:idEncuesta",
                    templateUrl: "app/templates/encuestas/cuestionario.html",
                    controller: "cuestionarioCtrl"
                }).state('base.inquiry/questions', {
                    url: "/inquiry_questions/:idEncuesta",
                    templateUrl: "app/templates/encuestas/preguntas.html",
                    controller: "preguntasCtrl"
                }).state('base.visits', {
                    url: "/tasks/:idTarea/visits",
                    templateUrl: "app/templates/visitas/visitas.html",
                    controller: "visitasCtrl"
                }).state('base.visits.logBook', {
                    url: "/:idVisita/logBook",
                    templateUrl: "app/templates/visitas/bitacora.html",
                    controller: "bitacoraCtrl"
                }).state('base.visits.logRights', {
                    url: "/logRights/:idVisita",
                    templateUrl: "app/templates/visitas/permisosBitacora.html"
                }).state('base.evaluation', {
                    url: "/evaluation",
                    templateUrl: "app/templates/evaluacion/evaluacion.html",
                    controller: "evaluacionCtrl"
                }).state('base.evaluationmilestones', {
                    url: "/evaluationmilestones",
                    templateUrl: "app/templates/evaluacion/evaluacionHitos.html"
                }).state('base.indicators', {
                    url: "/indicators",
                    templateUrl: "app/templates/indicadores/indicadores.html",
                    controller: "indicadoresCtrl"
                }).state('base.companies', {
                    url: "/companies",
                    templateUrl: "app/templates/empresas/empresasView.html",
                    controller: 'empresasCtrl'
                }).state('base.financials', {
                    url: "/financials",
                    templateUrl: "app/templates/financiero/financieroView.html",
                    controller: "financieroCtrl"
                }).state('base.clients', {
                    url: "/clients",
                    templateUrl: "app/templates/client/clients.html",
                    controller: "clientCtrl"
                }).state('base.client', {
                    url: "/client",
                    templateUrl: "app/templates/client/client.html",
                    controller: "clientsingleCtrl"
                }).state('base.projects', {
                    url: "/projects/:status",
                    templateUrl: "app/templates/administracion/proyectosTabView.html",
                    controller: "proyectosCtrl",
                    params: {
                        status: { squash: true, value: null }
                    }
                }).state('base.donors', {
                    url: "/donors",
                    templateUrl: "app/templates/administracion/patrocinadoresTabView.html",
                    controller: "administracionCtrl"
                }).state('base.company', {
                    url: "/company/:idEmpresa",
                    templateUrl: "app/templates/empresas/empresasView.html"
                }).state('base.project', {
                    url: "/project/:idProyecto",
                    templateUrl: "app/templates/proyectos/proyectosView.html",
                    controller: "proyectosCtrl"
                }).state('base.mensaj', {
                    url: "/messages",
                    templateUrl: "app/templates/mensajes/mensaje.html",
                    controller: "mensajesCtrl"
                }).state('base.tare', {
                    url: "/tasks",
                    templateUrl: "app/templates/tareas/tarea.html",
                    controller: "tareasCtrl"
                }).state('base.partid', {
                    url: "/parti",
                    templateUrl: "app/templates/pry_partidas/partidas.html",
                    controller: "partidasCtrl"
                }).state('base.denied', {
                    url: "/denied",
                    templateUrl: "app/templates/errors/access_denied.html"
                }).state('base.roles', {
                    url: "/roles",
                    templateUrl: "app/templates/roles/roles.html",
                    controller: "roleCtrl"
                }).state('base.tenants', {
                    url: "/tenants",
                    templateUrl: "app/templates/tenants/tenants.html",
                    controller: "tenantsCtrl"
                });
            
            $urlRouterProvider.otherwise("/");

        }
    ]
);

var serviceBase = location.origin + '/';

adlumenApp.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

adlumenApp.factory('globalAlerts', ['$rootScope',
    function($rootScope) {
        var alertService = {};
        $rootScope.globalAlerts = [];
        
        alertService.add = function(type, msg, timeout) {

            if (timeout !== null && !timeout) //si es null, la dejamos persistente, si es otra cosa falsey:
              timeout = 5000; //asignamos valor default

            var alert = { 'type': type, 'msg': msg, 'timeout': timeout };
            $rootScope.globalAlerts.push(alert);

            //if (timeout === 0)
            //    return;
            //else if (!timeout) 
            //    timeout = 5000;

            //window.setTimeout(function() {
            //    var index = $rootScope.globalAlerts.indexOf(alert);
            //    if (index > -1) {
            //        $rootScope.globalAlerts.splice(index, 1);
            //        $rootScope.$apply();
            //    }
            //}, timeout);
        }

        return alertService;
  }]);

adlumenApp.run(
    ['Restangular', 'authService', '$cookies','$rootScope','$state','translationService', 'languageService',
        function (Restangular, authService, $cookies, $rootScope, $state, translationService, languageService) {

            Restangular.setDefaultHeaders({
                'X-CSRFToken': $cookies.csrftoken
            });

            languageService.init();

            var translate = function () {
                translationService.getTranslation($rootScope, selectedLanguage);
            };

            //Init
            var selectedLanguage = languageService.get();
            translate();

            //var isValidDate = function (element) {
            //    _.each(element, function (value, key) {
            //        if (_.isArray(value)) {
            //            _.each(value, function (element, index) { isValidDate(element); });
            //        }
            //        else if (_.isObject(value)) {
            //            isValidDate(value);
            //        }
            //        else {
            //            if (_.isString(value)) {
            //                var date = new Date(value);
            //                if (_.isDate(date) && !_.isNaN(date.getTime())) {
            //                    element[key] = date;
            //                }
            //            }
            //        }
            //    });
            //};

            Restangular.addResponseInterceptor(function (data) {
                //if (_.isArray(data)) {
                //    _.each(data, function (element, index) { isValidDate(element); });
                //}
                //else if (_.isObject(data)) {
                //    isValidDate(data);
                //}

                resolveReferences(data);
                return data;
            });

            Restangular.addRequestInterceptor(function(data) {
                if (data == null) {
                    return data;
                }
                var decycled = decycle(data);
                return decycled;
            });

            $rootScope.$state = $state;

            authService.fillAuthData();
        }
    ]
);

angular.element(document).ready(function() {
    //loadScript('/Scripts/AdminLTE/app.js');
});