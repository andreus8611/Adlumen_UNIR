'use strict';
adlumenApp.controller('modaltcCtrl',
    [
        '$scope', '$uibModalInstance', 'monedaAPI',
        function ($scope, $uibModalInstance, monedaAPI) {

            monedaAPI($scope);

            var currency = {};

            $scope.showAlert = false;

            var addAlert = function (varType, varMsg) {
                $scope.alert = { type: varType, msg: varMsg };
                $scope.showAlert = true;
            };
           
            $scope.getIdCurrency = function (_currency) {
                currency = _currency;
            };

            $scope.content = [];

            $scope.getContent = function ($fileContent) {

                if ($.isEmptyObject(currency)) {

                    addAlert('danger', 'No ha seleccionado la moneda; Seleccione la moneda y vuelva a cargar el archivo');

                } else {

                    var allTextLines = $fileContent.split(/\r\n|\n/);

                    for (var i = 0; i < allTextLines.length - 1; i++) {
                        var data = allTextLines[i].split(',');
                        var tarr = [];

                        if (i > 0) {

                            tarr.push(currency.idMoneda);
                        }

                        for (var j = 0; j < data.length; j++) {
                            tarr.push(data[j]);
                        }

                        $scope.content.push(tarr);

                        addAlert('success', 'se ha cargado el archivo correctamente, se registraran los tipos de cambio para la moneda ' + currency.nombre)

                    }

                }

            };

            $scope.ok = function () {

                if ($.isEmptyObject($scope.content)) {

                    addAlert('danger', 'No se ha cargado el archivo o este no contiene datos')
                    
                } else {

                    $uibModalInstance.close({archivo: $scope.content, moneda: currency});
                }
            };

            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
            };

        }

    ]
);