(function () {
    'use strict';

    var app = angular.module('app', [
        'flow',
        'ngRoute'
    ]);

    app.config(['$routeProvider',
        function ($routeProvider) {
            $routeProvider.
                when('/', {
                    templateUrl: 'app/uploadFile/uploadFile.html',
                    controller: 'uploadFileController'
                }).
        otherwise({
            redirectTo: '/uploadFile'
        });
        }]);
})();