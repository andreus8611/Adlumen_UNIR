'use strict';
adlumenApp.controller('tareasCtrl',
    [
        '$scope', 'tareaAPI', 'projectAPI', 'listAPI', 'usuarioAPI','$uibModal',
        function ($scope, tareaAPI, projectAPI, listAPI, usuarioAPI,$uibModal) {

            projectAPI($scope);
            tareaAPI($scope);
            listAPI($scope);

            $scope.task = null;
            
            $scope.$watchCollection('[tasks, bdUser]', function (newValue, oldValue) {
                if (newValue != oldValue) {

                    if (_.indexOf(newValue[1].roles, "Admin") === -1 && _.indexOf(newValue[1].roles, "manager") === -1) {
                        $scope.tareas = _.where(newValue[0], {idResponsable: newValue[1].idLocal});
                    }
                    else {
                        $scope.tareas = newValue[0];
                    }
                                        
                }
            });

            //modal to create and update lists
            $scope.openModaList = function (list) {

                var modalInstance = $uibModal.open({
                    animation: false,
                    backdrop: 'static',
                    templateUrl: 'newList.html',
                    controller: 'listModalCtrl',
                    size: 'md',
                    resolve: {
                        list: function () {
                            return (_.isUndefined(list) ? null : list);
                        },
                        translation: function () {
                            return $scope.translation;
                        },
                        project: function () {
                            return $scope.misProyectos;
                        }
                    }


                });

                modalInstance.result.then(function (response) {
                    listAPI($scope);
                })

                
            }

            //modal to create and update task

            $scope.openModalTask = function (task) {

                var modalInstance = $uibModal.open({
                    animation: false,
                    backdrop: 'static',
                    templateUrl: 'newTask.html',
                    controller: 'taskModalCtrl',
                    size: 'md',
                    resolve: {
                        task: function () {
                            return (_.isUndefined(task) ? null : task);
                        },
                        translation: function () {
                            return $scope.translation;
                        },
                        tasks: function () {
                            return $scope.tareas;
                        },
                        minDate: function () {
                            return $scope.misProyectos.fechaInicio;
                        },
                        list: function () {
                            return $scope.misListas;
                        }
                    }


                });

                modalInstance.result.then(function (response) {
                    tareaAPI($scope);
                });
            };

            $scope.confirmDeleteTask = function(task) {
                $scope.confirmDelete({ msg: $scope.translation["CONFIRM_DELETE"] }, $scope.delete, task);
            }

            $scope.delete = function (task) {
                task.remove().then(function () {
                    tareaAPI($scope);
                },
                function (error) {
                    addAlert('danger', error.data.exceptionMessage);
                });
            }

            $scope.search = function(item) {
                var text = $scope.searchText;
                if (item.idLista == $scope.misListas.id && (
                        !text ||
                        (item.descripcion && item.descripcion.toLowerCase().indexOf(text.toLowerCase()) != -1)
                    )) {
                    return true;
                }
                return false;
            }
        }
    ]
);

adlumenApp.controller('listModalCtrl',
    [
        '$scope', 'listAPI', '$uibModalInstance','list', 'translation','project',
        function ($scope, listAPI, $uibModalInstance, list, translation, project) {

            //initialize variables

            listAPI($scope);

            $scope.translation = translation;

            if(_.isNull(list)) {
                $scope.editMode = false;
                $scope.list = {};
                $scope.headerTitle = translation.NUEVA_LISTA;
            }
            else {
                $scope.editMode = true;
                $scope.list = list;
                $scope.headerTitle = translation.MODIFICAR_LISTA;
            }

            //initialize alerts

            $scope.alerts = [];

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            }

            //save list
            
            $scope.save = function (idUsuario) {

                $scope.list.idUsuario = idUsuario;
                $scope.list.idProyecto = project.idProyecto;

                if (!$scope.list.descripcion || _.isEmpty($scope.list.descripcion.trim())) {
                    addAlert('danger', 'Un campo requerido se encuentra vacío.');
                    return;
                }
                var exists = _.find($scope.listas, function (x) { 
                    return x.idProyecto == project.idProyecto && x.descripcion.trim() == $scope.list.descripcion.trim(); 
                });
                if (exists) {
                    addAlert('danger', 'El campo debe ser único.');
                    return;
                }

                if ($scope.editMode === false) {
                    $scope.listas.post($scope.list).then(function (result) {

                        $uibModalInstance.close(result);

                    }, function (error) {
                        addAlert('danger', error.data.exceptionMessage);
                    });
                }
                else {
                    var list = {
                        id: $scope.list.id,
                        descripcion: $scope.list.descripcion,
                        idUsuario: idUsuario
                    };
                    $scope.list.customPUT(list).then(function(result) {
                        $uibModalInstance.close(result);
                    }, function (error) {
                        addAlert('danger', error.data.exceptionMessage);
                    });
                }

            };

            $scope.close = function () {
                $uibModalInstance.dismiss('cancel');
            };

        }



    ]
);

adlumenApp.controller('taskModalCtrl',
    [
        '$scope', 'tasks', '$uibModalInstance', 'usuarioAPI', 'translation', 'task', 'list', 'minDate',
        function ($scope, tasks, $uibModalInstance, usuarioAPI, translation, task, list, minDate) {

            //initialize variables

            usuarioAPI($scope);
            
            $scope.translation = translation;

            $scope.minDate = minDate;

            if (_.isNull(task)) {
                $scope.editMode = false;
                $scope.task = {};
                $scope.headerTitle = translation.NUEVA_TAREA;
            }
            else {
                $scope.editMode = true;
                task.fechaFin = new Date(task.fechaFin);
                task.fechaInicio = new Date(task.fechaInicio);
                $scope.task = task;
                $scope.task.done = task.idUsuarioCompletado != null;
                $scope.headerTitle = translation.MODIFICAR_TAREA;

                $scope.$watch('usuarios', function (newValue, oldValue) {
                    if (newValue != oldValue) {
                        $scope.responsable = _.findWhere(newValue, { idUsuario: task.idResponsable });
                    }
                });

            }
            
            //initialize alerts
            $scope.showAlert = false;
            $scope.alerts = [];

            var addAlert = function (varType, varMsg) {
                $scope.alerts.push({ type: varType, msg: varMsg });
                $scope.showAlert = true;
            }

            //datepicker configuration

            $scope.statusfechaInicio = { opened: false };

            $scope.openfechaInicio = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();
                $scope.statusfechaInicio.opened = true;
            };

            $scope.statusfechaFin = { opened: false };

            $scope.openfechaFin = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();
                $scope.statusfechaFin.opened = true;
            };

            $scope.maxDate = new Date(2020, 5, 22);

            //Save task

            $scope.save = function(idUsuario) {

                if ($scope.task.fechaInicio > $scope.task.fechaFin) {
                    addAlert('danger', $scope.translation["ERROR_FECHAINICIO_FECHAFIN_INVALIDAS"]);
                    return;
                }

                $scope.task.idUsuario = idUsuario;
                $scope.task.idLista = list.id;
                $scope.task.idResponsable = $scope.responsable.idUsuario;

                if ($scope.task.done === true) 
                    $scope.task.idUsuarioCompletado = idUsuario;
                else
                    $scope.task.idUsuarioCompletado = null;

                if ($scope.editMode === false) {
                   tasks.post($scope.task).then(function (result) {

                        $uibModalInstance.close(result);

                    }, function (error) {
                        addAlert('danger', error.data.exceptionMessage);
                    });
                }
                else {
                    $scope.task.put().then(function (result) {
                        $uibModalInstance.close(result);
                    }, function (error) {
                        addAlert('danger', error.data.exceptionMessage);
                    });
                }
            };

            $scope.close = function () {
                $uibModalInstance.dismiss('cancel');
            };
        }
    ]
);