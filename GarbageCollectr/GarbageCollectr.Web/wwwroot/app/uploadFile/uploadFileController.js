﻿(function () {
    'use strict';
    var controllerId = 'uploadFileController';
    angular.module('app').controller(controllerId, ['$scope', '$http', uploadFileController]);

    function uploadFileController($scope, $http) {
        $scope.responseData = null;
        $scope.activeUserStep = "start";
        
        $scope.upload = function (file) {
            var fd = new FormData();
            fd.append("file", file.file);

            $http({
                url: 'uploads',
                method: 'POST',
                data: fd,
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            }).then(function (response) {
                console.log(response);
                $scope.responseData = response.data;

                if (!$scope.responseData.DbThings.length && $scope.responseData.PossibleThings.length) {
                    $scope.activeUserStep = 'confirmThing';
                }

                if ($scope.responseData.DbThings.length === 1) {
                    $scope.activeUserStep = "weThinkWeKnow";
                }

                if ($scope.responseData.DbThings.length > 1) {
                    $scope.activeUserStep = "moreThanOneDbThing";
                }

            }, function(response) {
                
            });
        }

        $scope.showDiv = function(div) {
            if ($scope.activeUserStep == div) {
                return true;
            }

            return false;
        }

        $scope.setActiveUserStep = function(newActiveStep) {
            $scope.activeUserStep = newActiveStep;
        }

        $scope.correctThing = function (correct, thingName) {
            if (correct) {
                $scope.choosenAlternativeThing = thingName;
                $scope.activeUserStep = "chooseMaterial";
                return;
            }

            $scope.activeUserStep = "chooseAlternativeThing";
        }

        $scope.correctThingAndMaterial = function (correct, thingName, material) {
            if (correct) {
                $scope.choosenAlternativeThing = thingName;
                $scope.choosenMaterial = material;
                $scope.activeUserStep = "weKnow";
                return;
            }

            $scope.activeUserStep = "chooseAlternativeMaterial";
        }

        $scope.chooseThing = function(thingName) {
            $scope.choosenAlternativeThing = thingName;
            $scope.activeUserStep = "chooseMaterial";
        }

        $scope.createNewThing = function (thingName, material) {
            $scope.choosenMaterial = material;

            $http({
                url: 'material?thing=' + thingName + "&materialId=" + material.Id,
                method: 'POST'
            }).then(function (response) {
                $scope.activeUserStep = "weKnow";
            }, function (response) {

            });
        }
    }
})();