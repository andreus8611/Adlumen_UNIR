'use strict';
adlumenApp.controller('partidasCtrl',
    [
        '$scope', 'partidaAPI',
        function ($scope, partidaAPI) {

            partidaAPI($scope);
            $scope.partidasGastos = true;


            //GuardarPartidas
            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            }

            $scope.inputTarea = {
                Abrevi: "",
                codigo: "",
                nombre: "",
                    
            }

            $scope.resetTexts = function () {
                $scope.inputTarea.Abrevi = "";
                $scope.inputTarea.codigo = "";
                $scope.inputTarea.nombre = "";
                $scope.newTarea = false;
            }

            $scope.addPartida = function () {
                        
                $scope.alerts = [];
                var existErrors = false;

                if ($scope.inputTarea.Abrevi === "" || $scope.inputTarea.codigo === "" || $scope.inputTarea.nombre === "") {
                    existErrors = true;
                    addAlert('danger', 'Por favor llene todos los campos');
                }

                var exists = _.find($scope.partidas, function(partida) {
                    return partida.codigo == $scope.inputTarea.codigo || partida.nombre == $scope.inputTarea.nombre;
                });
                if (exists) {
                    addAlert('danger', 'El código y el nombre deben ser únicos.');
                    return;
                }

                if (!existErrors) {
                        $scope.partidas.post($scope.inputTarea).then(function () {

                        addAlert('success', 'Partida agregado exitosamente');
                        partidaAPI($scope);
                        $scope.resetTexts();
                        $scope.NuevasPartidaGastos = false;
                        $scope.partidasGastos = true;
                            

                    }, function () {
                        addAlert('danger', 'Ha ocurrido un error, el registro no ha podido completarse');
                    });
                }
            }
            // Fin de Guardar Nueva Lista





            //vER LA INFORMACION PARA MODIFICAR
            $scope.selectPartidaGastos = function(partida) {
                $scope.newPartida = partida;
                $scope.modificarPartidaGastos = true;
                $scope.partidasGastos = false;
            }

            $scope.cancel = function() {
                $scope.newPartida = null;
                $scope.modificarPartidaGastos = false;
                $scope.partidasGastos = true;
            }

            //Modificar
            $scope.editar = function (id, Abrevi, codigo, nombre) {

                $scope.alerts = [];
                var existErrors = false;

                var p = $scope.newPartida; 

                if (p.Abrevi === "" || p.codigo === "" || p.nombre === "") {
                    existErrors = true;
                    addAlert('danger', 'Por favor llene todos los campos');
                }

                var exists = _.find($scope.partidas, function(partida) {
                    return (partida.codigo == p.codigo
                        || partida.nombre == p.nombre)
                        && partida.idpartidagasto != p.idpartidagasto;
                });
                if (exists) {
                    addAlert('danger', 'El código y el nombre deben ser únicos.');
                    return;
                }

                $scope.newPartida.put().then(function () {
                    partidaAPI($scope);
                    $scope.modificarPartidaGastos = false;
                    $scope.partidasGastos = true;
                    addAlert('success', 'El elemento se guardo correctamente.');
                }, function() {
                    addAlert('danger', 'Ocurrió un error.');
                });
            }

            $scope.eliminar = function (id) {
                $scope.partidas.remove({ id: id }).then(function () {
                    $scope.alerts = [];
                    partidaAPI($scope);
                    addAlert('success', 'Partida eliminada');
                }, function() {

                });
            }

            $scope.closeAlert = function(index) {
                $scope.alerts.splice(index, 1);
            }


        //    //Seleccionar fecha de Nueva Tarea
        //    $scope.validarFechaInicio = function () {

        //        if ($scope.inputTarea.FechaInicio == "") {
        //            $scope.calendarioInicio = true;
        //        }
        //        else {

        //            $scope.calendarioInicio = false;
        //        }

        //    }
        //    $scope.validarFechaFin = function () {

        //        if ($scope.inputTarea.fechaFinal == "") {
        //            $scope.calendarioFin = true;

        //        }
        //        else {

        //            $scope.calendarioFin = false;

        //        }
        //    }
        //    //Seleccionar fecha de Nueva Tarea

        //    //Seleccionar fecha de Modificar Tarea Tarea
        //    $scope.validarFechaInicioMod = function () {

        //        if ($scope.inputTarea.FechaInicio == "") {
        //            $scope.calendarioInicioMod = true;
        //            $scope.txtFechaInicio = false;
        //            $scope.Inicio = true;
        //        }
        //        else {

        //            $scope.calendarioInicioMod = false;
        //            $scope.txtFechaInicio = true;
        //            $scope.Inicio = false;
        //        }

        //    }
        //    $scope.validarFechaFinMod = function () {

        //        if ($scope.inputTarea.fechaFinal == "") {
        //            $scope.calendarioFinMod = true;
        //            $scope.txtFechaFinal = false;
        //            $scope.Fin = true;

        //        }
        //        else {

        //            $scope.calendarioFinMod = false;
        //            $scope.Fin = false;
        //            $scope.txtFechaFinal = true;
        //        }
        //    }
        //    //Seleccionar fecha de Modificar Tarea



        //    //Guardar nueva tarea
        //    var addAlert = function (varType, varMsg) {
        //        $scope.alerts.push({ type: varType, msg: varMsg });
        //        $scope.showAlert = true;
        //    }

        //    $scope.inputTarea = {
        //        descTarea: "",
        //        txtPrioridad: "",
        //        FechaInicio: "",
        //        fechaFinal: "",
        //    }
        //    $scope.resetTexts = function () {
        //        $scope.inputTarea.descTarea = "";
        //        $scope.inputTarea.txtPrioridad = "";
        //        $scope.inputTarea.FechaInicio = "";
        //        $scope.inputTarea.fechaFinal = "";
        //        $scope.inputTarea.txtResponsable = "";
        //        $scope.newTarea = false;

        //    };
        //    $scope.addTarea = function (idLista, idUsuario, edo) {

        //        $scope.alerts = [];
        //        $scope.inputTarea.txtLista = idLista;
        //        $scope.inputTarea.txtUsuario = idUsuario;
        //        $scope.inputTarea.txtEdo = edo;

        //        var existErrors = false;

        //        if ($scope.inputTarea.descTarea === "" || $scope.inputTarea.FechaInicio === "" || $scope.inputTarea.fechaFinal == "") {
                 
        //            existErrors = true;
        //            addAlert('danger', 'Por favor llene todos los campos');
                   

        //        }
        //        else {
        //            if ($scope.inputTarea.txtPrioridad === "") {
        //                $scope.inputTarea.txtPrioridad = "False";
                       
        //            }
        //            existErrors = false;
        //        }

        //        if (!existErrors) {
        //            $scope.tareas.post($scope.inputTarea).then(function () {

        //                addAlert('success', 'Tarea agregado exitosamente');

        //                tareaAPI($scope);
        //                $scope.resetTexts();
        //                $scope.nuevaTarea = false;
        //                $scope.tarea = true;


        //            }, function () {
        //                addAlert('danger', 'Ha ocurrido un error, el registro no ha podido completarse');
        //            });
        //        }
        //    }
        //    // Fin de Guardar Nueva Lista

        //    //vER LA INFORMACION PARA MODIFICAR
        //    $scope.selectTareasGuardadas = function (tarea, prioridad) {
        //        $scope.newtarea = tarea;
        //        $scope.tarea = false;
        //        $scope.modificarTarea = true;
        //        $scope.Fin = true;
        //        $scope.Inicio = true;
        //        $scope.inputTarea.txtPrioridad = $scope.newtarea.prioridad;
        //        console.log($scope.newtarea, $scope.selected);
        //    }


        //    //

        //    //Editar Registro
        //    $scope.edit = function (id, descrip, idResponsable, prioridad, inicio, Fin, idUsurioModifica, forma) {


        //        if (descrip == undefined) {
        //            descrip = $scope.newtarea.descripcion
        //        }

        //        if (idResponsable == undefined) {
        //            idResponsable = $scope.newtarea.idResponsable
        //        }

        //        if (inicio == "") {
        //            inicio = $scope.newtarea.fechaInicio
        //        }
              
        //        if (Fin == "") {
        //            Fin = $scope.newtarea.fechaFin
        //        }
             
        //        $scope.newtarea.put({ id: id, descrip: descrip, idResponsable: idResponsable, prioridad: prioridad, inicio: inicio, Fin: Fin, idUsurioModifica: idUsurioModifica, forma: forma }).then(function () {

        //            tareaAPI($scope);
        //            console.log("exito");


        //        }, function () {
        //            console.log("fracaso");
        //        }

        //        );

        //    }

        //    //

        //    //Elimnar registro

        //    $scope.editEstado = function (id, idUsuarioMod, forma) {
                
                
        //        forma=forma;
        //        $scope.newtarea.put({ id: id, idUsurioModifica: idUsurioModifica, forma: forma }).then(function () {
                   
        //            tareaAPI($scope);
        //            console.log("exito");


        //        }, function () {
        //            console.log("fracaso");
        //        }

        //           );

        //    }


        //    //Mostrar LAgregarLista
        //    $scope.selectListas = function () {
        //        $scope.ListasNuevas = true;
        //        $scope.tarea = false;
        //    }
        //    $scope.selectListadoListas = function (lista) {

        //        $scope.newLista = lista;
        //        $scope.ListasxProyecto = false;
        //        $scope.Listas2 = true;
        //    }



        //    // agregar Una _Lista
        //    $scope.inputLista = {
        //        descLista: "",
        //        idUsuario: "",
        //        idProyecto:"",
               
        //    }
        //    $scope.resetTexts2 = function () {
        //        $scope.inputLista.descLista = "";
        //        $scope.inputLista.idUsuario = "";
        //        $scope.inputLista.idProyecto = "";
                
        //    };
        //    $scope.addLista = function (descrpLista, idUsuario, idProyecto) {
        //        $scope.alerts = [];
        //        $scope.inputLista.idUsuario = idUsuario;
        //        $scope.inputLista.idProyecto = idProyecto;
        //        $scope.inputLista.descLista = descrpLista;
        //        var existErrors2 = false;
        //        if ($scope.inputLista.idUsuario === "" || $scope.inputLista.idProyecto === "" || $scope.inputLista.descLista === "") {
        //            existErrors2 = true;
        //            addAlert('danger', 'Por favor llene todos los campos');
                   
        //        }
        //        else {
        //            existErrors2 = false;
        //        }

        //        if (!existErrors2) {
                    
        //            $scope.listas.post($scope.inputLista).then(function () {
                        

        //                addAlert('success', 'Mensaje agregado exitosamente');
        //                listAPI($scope);
                        
        //                $scope.inputLista.descLista = "";
        //                $scope.ListasNuevas = false;
                       

        //            }, function () {
                      
        //               addAlert('danger', 'Ha ocurrido un error, el registro no ha podido completarse');
        //            });
        //        }
        //    }

        //    //Visualizar las listas creadas
        //    $scope.verListas = function () {
        //        $scope.ListasxProyecto = true;
        //        $scope.ListasNuevas = false;
        //        $scope.tarea = false;

        //    }
           

        //    //Modificacion de la Lista 
        //    $scope.editListas = function (id, idProyecto, descripcion, idUsurioModifica) {

               
        //        if (idProyecto == undefined) {
        //            descrip = $scope.newtarea.idProyecto
        //        }

        //        if (descripcion == undefined) {
        //            descripcion = $scope.newtarea.descripcion
        //        }
                            
        //        $scope.newLista.put({ id: id, idProyecto: idProyecto, descripcion: descripcion, idUsurioModifica: idUsurioModifica }).then(function () {
                   
        //           listAPI($scope);
        //            console.log("exito");


        //        }, function () {
        //            console.log("fracaso");
        //        }

        //        );

        //    }

            

        //    // Listas

            

        }


        
    ]
);