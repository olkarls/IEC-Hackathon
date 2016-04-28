(function () {
    'use strict';

    var serviceId = 'fileService';
    angular.module('app').factory(serviceId, ['$http', 'common', fileService]);

    function fileService($http, common) {
        var $q = common.$q;
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(serviceId);
        var baseUrl = 'uploads/';

        var service = {
            createFile: createFile
        };

        return service;

        function createFile() {
            return $q.when(
                $http({ method: 'POST', url: baseUrl })
            );
        }
    }
})();