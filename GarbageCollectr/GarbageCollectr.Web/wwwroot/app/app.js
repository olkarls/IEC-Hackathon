(function () {
    'use strict';

    var app = angular.module('app', [
        'flow',
        'ngRoute',
        'highcharts-ng'
    ]);

    app.config(['$routeProvider',
        function ($routeProvider) {
            $routeProvider.
                when('/', {
                    templateUrl: 'app/uploadFile/uploadFile.html',
                    controller: 'uploadFileController'
                }).
                when('/yourGarbage', {
                    templateUrl: 'app/yourGarbage/yourGarbage.html',
                    controller: 'yourGarbageController'
                }).
        otherwise({
            redirectTo: '/'
        });
        }]);
})();