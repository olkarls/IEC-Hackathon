(function () {
    'use strict';
    var controllerId = 'uploadFileController';
    angular.module('app').controller(controllerId, ['$scope', '$http', uploadFileController]);

    function uploadFileController($scope, $http) {
        $scope.upload = function (file) {
            var fd = new FormData();
            fd.append("file", file.file);
            $http.post("uploads", fd, {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            });
        }
    }
})();