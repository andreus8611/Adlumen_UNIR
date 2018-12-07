'use strict';
adlumenApp.controller('tipcambioCtrl',
    [
        '$scope', '$uibModal', 'tcAPI',
        function ($scope, $uibModal, tcAPI) {

            $scope.init = function () {

                //años del 1900 al 2100

                for (var i = 1900; i <= 2100; i++) {

                    if (i === 1900) {
                        $scope.arrayYears.push({ nombre: i, value: true });
                    } else {
                        $scope.arrayYears.push({ nombre: i, value: false });
                    }
                }

                //capturar llamada asincrona de la web api

                getTcAPI();
                  
            };

            var getTcAPI = function () {

                tcAPI.getRestangular.then(
                   function (tipcambios) {

                       //agrupar los valores por moneda

                       $scope.exchangeList = _.groupBy(tipcambios, function (tipcambio) {
                           return tipcambio.nombre;

                       });


                       //construir una matriz de monedas con el nombre y un valor booleano para los radio list
                       if (!$.isEmptyObject($scope.exchangeList)) {

                           _.each($scope.exchangeList, function (exchange, key) {

                               var existMoneda = (_.findWhere($scope.arrayMonedas, { id: exchange[0].idMoneda }))

                               if ($scope.arrayMonedas.length === 0 || typeof existMoneda === 'undefined') {

                                   $scope.arrayMonedas.push({ id: exchange[0].idMoneda, nombre: key, value: false });
                               }

                           });

                           //primer radio list por default verdadero

                           $scope.arrayMonedas[0].value = true;

                       };

                   });

            };
          
            //Definiendo las alertas

            $scope.$watch()

            $scope.showAlert = false;

            var addAlert = function (varType, varMsg) {
                $scope.alert = { type: varType, msg: varMsg };
                $scope.showAlert = true;
            };

            //crear array de monedas

            $scope.arrayMonedas = [];

            //crear el array de años

            $scope.arrayYears = []

            //crear el array de meses

            $scope.arrayMeses = [
                { id: 1, nombre: "Enero", value: true },
                { id: 2, nombre: "Febrero", value: false },
                { id: 3, nombre: "Marzo", value: false },
                { id: 4, nombre: "Abril", value: false },
                { id: 5, nombre: "Mayo", value: false },
                { id: 6, nombre: "Junio", value: false },
                { id: 7, nombre: "Julio", value: false },
                { id: 8, nombre: "Agosto", value: false },
                { id: 9, nombre: "Septiembre", value: false },
                { id: 10, nombre: "Octubre", value: false },
                { id: 11, nombre: "Noviembre", value: false },
                { id: 12, nombre: "Diciembre", value: false }
            ];

            //cambia a verdadero el radio que se clickea y falso el resto

            $scope.changeRadio = function (elementArray, item) {

                if (!item.value) {
                    _.each(elementArray, function (element, index) {

                        if (element.nombre != item.nombre) {
                            elementArray[index].value = false
                        } else {
                            elementArray[index].value = true;
                        }

                    });
                }

            };

            //Buscar los tipos de cambio segun moneda, mes y año

            $scope.searchExchange = function (_moneda, _month, _year) {

                _moneda = _.where($scope.arrayMonedas, { value: true })[0].nombre;
                _month = _.where($scope.arrayMeses, { value: true })[0].id;
                _year = _.where($scope.arrayYears, { value: true })[0].nombre;

                $scope.exchanges = _.filter(
                    _.result($scope.exchangeList, _moneda), function (exchange) {
                        return new Date(exchange.fecTipCambio).getMonth() + 1 === _month && new Date(exchange.fecTipCambio).getFullYear() === _year;
                    });

            };

            //abrir el modal para cargar el archivo de excel

            $scope.openModal = function () {

                var modalInstance = $uibModal.open({
                    templateUrl: '/app/templates/tipo_cambio/modaltc.html',
                    controller: 'modaltcCtrl'

                });

                modalInstance.result.then(function (content) {
                    
                   saveExchanges(content.archivo, content.moneda);

                }, function () {
                    addAlert('danger', 'Ocurrió un error vuelva a cargar el archivo');
                });
            };

            //post a la base de datos con el archivo de excel.

            function saveExchanges(archivo, newMoneda) {

                tcAPI.postRestangular.post({ exchangeRates: archivo }).then(
                    function () {

                        getTcAPI();

                        addAlert('success', 'Los tipos de cambio fueron cargados correctamente!!');
                    },
                    function () {
                        addAlert('danger', 'ocurrio un error comuniquese con el administrador del sistema');
                        console.log("error");
                    });

            };

        }
    ]
);