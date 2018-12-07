'use strict';
adlumenApp.controller('formulaCtrl',
    [
        '$scope', '$uibModal', '$uibModalInstance', 'variablesAPI', 'unidadOperativa', 'unidadOperativaId', 'translationService', 'languageService',
        function ($scope, $uibModal, $uibModalInstance, variablesAPI, unidadOperativa, unidadOperativaId, translationService, languageService) {

            $scope.unidadOperativa = unidadOperativa;
            $scope.unidadOperativaId = unidadOperativaId;
            $scope.formulaTxt = null;
            $scope.formulaAntes = null;
            $scope.formulaNombres = null;
            $scope.formulaIds = null;
            
            $scope.variablesId = null;

            $scope.validated = true;

            $scope.variablesInFormula = [];

            $scope.alerts = [];
            $scope.showAlert = true;

            $scope.selectedVariable = null;


            $scope.close = function () {
                $scope.alerts = [];
                var areErrors
                if ($scope.formulaTxt && !$scope.validated) {
                    areErrors = true;
                    addAlert('danger', $scope.translation["ERROR_FORMULA_DEBE_VALIDARSE"]);
                } else if (!$scope.formulaTxt) {
                    var returnObject = null;
                    $uibModalInstance.close(returnObject);
                } else {
                    var returnObject = { formulaNombre: $scope.formulaNombre, formulaIds: $scope.formulaIds };
                    $uibModalInstance.close(returnObject);
                }
            };

            $scope.$watch('formulaTxt', function () {
                $scope.validated = false;
            });

            $scope.editarFormula = function (){
                //hacemos un split de las variables y una vez en un array hacemos la consulta en la DB
                //cargamos la hidenfield hfVariablesId y hacemos databind a gvVariables
                var strFormulaNombre = "";
                var strFormulaComas = "";
                $scope.formulaTxt = "";
                $scope.formulaAntes = "";

                if ($scope.unidadOperativaId) {
                    var strArreglo = $scope.unidadOperativaId.split('|');
                    var strId = "";

                    for (var i = 0; i < strArreglo.length; i++) {
                        if (strArreglo[i].indexOf("$") === 0) {
                            strId = strId + strArreglo[i] + "|";
                        }
                    }
                    $scope.variablesId = strId;

                    //escribimos la formula con nombres!!
                    for (var i = 0; i < strArreglo.length; i++) {
                        if (strArreglo[i].indexOf("$") === 0) {
                            for (var j = 0; j < $scope.variables.length; j++) {
                                var strTemp = $scope.variables[j].idVariable;
                                strArreglo[i] = strArreglo[i].replace("$", "");

                                if (String(strTemp) === strArreglo[i]) {
                                    strArreglo[i] = $scope.variables[j].nombre;
                                    var incluido = (_.where($scope.variablesInFormula, { idVariable: strTemp })).length > 0;
                                    if (!incluido) {
                                        $scope.variablesInFormula.push($scope.variables[j]);
                                    }
                                }
                            }
                        }
                        if (strArreglo[i]) {
                            strFormulaNombre = strFormulaNombre + strArreglo[i];
                            strFormulaComas = strFormulaComas + strArreglo[i] + "|";
                        }
                    }
                }
                $scope.formulaNombres = strFormulaNombre;
                $scope.formulaAntes = strFormulaComas;
                $scope.formulaTxt = strFormulaNombre;
            }

            $scope.loadData = function () {
                variablesAPI.getVariables().then(
                    function addtoScope(variables) {
                        $scope.variables = variables;
                        $scope.editarFormula();
                    }
                );
            }

            $scope.loadData();

            $scope.escribir = function (strValor) {
                //Guardo la formula anterior para la funcion deshacer. 
                $scope.formulaAntes = $scope.formulaAntes + strValor + "|";
                //Escribo en la formula
                $scope.formulaTxt = $scope.formulaTxt + strValor;
            }

            $scope.escribirVariable = function (variable) {
                $scope.variablesId = $scope.variablesId + variable.idVariable + "|";
                $scope.escribir(variable.nombre);
            }

            $scope.getVariablesTemplate = function (variable) {
                if ($scope.selectedVariable && variable.nombre == $scope.selectedVariable.nombre) return 'editVariableTemplate';
                else return 'displayVariableTemplate';
            }

            $scope.getNewVariablesTemplate = function () {
                if ($scope.selectedVariable && $scope.selectedVariable.idVariable === 0) return 'editVariableTemplate';
                else return null;
            }

            $scope.crearNuevaVariable = function () {
                $scope.selectedVariable = { idVariable: 0 };
            }

            $scope.editVariable = function () {
                $scope.selectedVariable = this.variable;
            }

            $scope.cancelEdit = function () {
                $scope.selectedVariable = null;
                $scope.loadData();
            }

            $scope.limpiarFormula = function () {
                $scope.formulaNombres = "";
                $scope.formulaAntes = "";
                $scope.formulaTxt = "";
            };

            $scope.validar = function () {
                $scope.alerts = [];
                $scope.formulaNombre = "";
                $scope.formulaIds = "";
                var strFormulaComas = $scope.formulaAntes;
                var strFormula = $scope.formulaTxt;
                if (strFormula)
                {
                    var strChekea = strFormula;
                    var strFormulaId = strFormulaComas;
                    var intAncho = strFormulaComas.length;
                    strFormulaComas = strFormulaComas.substring(0, intAncho - 1);

                    // 1-reemplazo variables con y en strChekea y con los $ID en strFormulaId 

                    for (var j = 0; j < $scope.variablesInFormula.length; j++)
                    {
                        strChekea = strChekea.replace($scope.variablesInFormula[j].nombre, "y");
                        strFormulaId = strFormulaId.replace($scope.variablesInFormula[j].nombre, "$" + $scope.variablesInFormula[j].idVariable);
                    }

                    var objCheckea = { action: "checkFormula", strFormula: strChekea };

                    var txtMsg = "";

                    var postProyecto = variablesAPI.getRestAll();
                    postProyecto.post(objCheckea).then(function (mensaje) {
                        if (mensaje != "OK") {
                            txtMsg = mensaje;
                            $scope.formulaNombre = "";
                            $scope.formulaIds = "";
                            $scope.validated = true;
                            addAlert('danger', $scope.translation[txtMsg]);
                        } else {
                            $scope.formulaNombre = strFormula;
                            $scope.formulaIds = strFormulaId;
                            $scope.validated = true;
                            addAlert('success', $scope.translation["FORMULA_CORRECTA"]);
                        }
                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            };

            $scope.saveVariable = function () {
                $scope.alerts = [];

                var areErrors = $scope.validate();

                if (!areErrors) {
                    if (!$scope.selectedVariable.idVariable) $scope.selectedVariable.action = "addVariable";
                    else $scope.selectedVariable.action = "modifyVariable";

                    var postProyecto = variablesAPI.getRestAll();
                    postProyecto.post($scope.selectedVariable).then(function (idVariable) {

                        addAlert('success', $scope.translation["MENSAJE_VARIABLE_GUARDADA"]);

                        if (!$scope.selectedVariable.idVariable && idVariable) $scope.selectedVariable.idVariable = parseInt(JSON.parse(idVariable));
                        var incluido = (_.where($scope.variablesInFormula, { idVariable: $scope.selectedVariable.idVariable })).length > 0;
                        if (!incluido) {
                            $scope.variablesInFormula.push($scope.selectedVariable);
                        }

                        $scope.selectedVariable = null;
                        $scope.loadData();

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            }

            $scope.deleteVariable = function () {
                $scope.alerts = [];

                $scope.selectedVariable = this.variable;

                var areErrors = $scope.validate();

                if (!areErrors) {
                    $scope.selectedVariable.action = "deleteVariable";

                    var postProyecto = variablesAPI.getRestAll();
                    postProyecto.post($scope.selectedVariable).then(function () {

                        addAlert('success', $scope.translation["MENSAJE_VARIABLE_GUARDADA"]);

                        $scope.selectedVariable = null;
                        $scope.loadData();

                    }, function () {

                        addAlert('danger', $scope.translation["ERROR_GUARDADO"]);

                    });

                }
            }

            $scope.validate = function () {
                var areErrors = false;
                if (!$scope.selectedVariable.nombre || !$scope.selectedVariable.fuenteInformacion) {
                    areErrors = true;
                    addAlert('danger', $scope.translation["ERROR_CAMPOS_VACIOS"]);
                }
                if (!$scope.selectedVariable.idVariable === 0) {
                    var incluido = (_.where($scope.variablesInFormula, { nombre: $scope.selectedVariable.nombre })).length > 0;
                    if (!incluido) {
                        $scope.areErrors = true;
                        addAlert('danger', $scope.translation["ERROR_VARIABLE_YA_EXISTE"]);
                    }
                }

                return areErrors;
            }

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
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
