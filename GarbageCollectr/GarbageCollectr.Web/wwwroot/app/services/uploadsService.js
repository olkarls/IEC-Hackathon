(function () {
    'use strict';

    var serviceId = 'uploadsService';
    angular.module('app').factory(serviceId, ['$http', 'common', uploadsService]);

    function uploadsService($http, common) {
        var $q = common.$q;
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(serviceId);
        var baseUrl = 'uploads/';

        var service = {
            getAll: getAll,
            get: get,
            getStatistic: getStatistic,
            create: create,
            update: update,
        };

        return service;

        function getAll() {
            return $q.when(
                $http({ method: 'GET', url: baseUrl })
            );
        }

        function get(id) {
            return $q.when(
                $http({ method: 'GET', url: baseUrl + id })
            );
        }

        function getStatistic(id) {
            return $q.when(
                $http({ method: 'GET', url: baseUrl + id + '/PlayerStatistic/' })
            );
        }

        function create(player) {
            return $http.post(baseUrl, player).then(function (response) {
                return response;
            });
        }

        function update(player) {
            return $http.put(baseUrl + player.id, player).then(function (response) {
                return response;
            });
        }
    }
})();