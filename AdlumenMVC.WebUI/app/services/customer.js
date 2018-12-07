'use strict';
adlumenApp.service("clienteAPI",
    [
        'Restangular',
        function (Restangular) {

            var _clients = Restangular.all('api/cliente');

            this.getCliente = function (id) {
                return _clients.getList().then(function (clients) {
                    return _.findWhere(clients, { id: id });
                });
            }

            this.getProjectsByClient = function (id) {
                return Restangular.one('api/cliente', id);
            };

            this.getRestAll = function () {
                return _clients;
            }

            this.save = function (client) {
                return _clients.post(client);
            };

        }
    ]
)