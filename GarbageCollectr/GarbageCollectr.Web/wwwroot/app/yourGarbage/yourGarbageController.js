(function () {
    'use strict';
    var controllerId = 'yourGarbageController';
    angular.module('app').controller(controllerId, ['$scope', '$http', yourGarbageController]);

    function yourGarbageController($scope, $http) {
        $scope.responseData = null;
        $scope.isLoading = false;

        $scope.upload = function (file) {
            $scope.isLoading = true;

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
                $scope.isLoading = false;


            }, function (response) {

            });
        }

        function initGarbageChart(garbageData) {
            var xTitle = 'Garbage weight';
            var categories = [];
            var colors = ['#43c83c', '#2995C7'];
            var series = [{
                name: "Matavfall",
                hasCustomFlag: true,
                data: []
            },
            {
                name: "Hushållsavfall",
                hasCustomFlag: true,
                data: []
            }
            ];

            var maxNumberOfTourParticipants = 0;

            angular.forEach(playerStats1.tourStats.placeInEachTournament, function (tourPlayer1) {
                angular.forEach(playerStats2.tourStats.placeInEachTournament, function (tourPlayer2) {
                    if (tourPlayer1.tourId === tourPlayer2.tourId) {
                        var player1Tour = {
                            y: tourPlayer1.place,
                            tourParticipants: tourPlayer1.tourParticipants
                        };
                        var player2Tour = {
                            y: tourPlayer2.place,
                            tourParticipants: tourPlayer2.tourParticipants
                        };

                        series[0].data.push(player1Tour);
                        series[1].data.push(player2Tour);
                        categories.push(tourPlayer1.tourName);

                        if (tourPlayer1.tourParticipants > maxNumberOfTourParticipants) {
                            maxNumberOfTourParticipants = tourPlayer1.tourParticipants;
                        }
                    }
                });
            });

            vm.compareNoOfTournamentBothParticipatedIn = series[0].data.length;

            var chart = initLineChart(xTitle, categories, colors, series, maxNumberOfTourParticipants);
            return chart;
        }

        function initLineChart(xTitle, categories, colors, series, yMax) {
            return {
                title: {
                    text: xTitle
                },
                xAxis: {
                    categories: categories
                },
                yAxis: {
                    min: 1,
                    max: yMax,
                    tickInterval: 1,
                    reversed: true,
                    title: {
                        text: ''
                    }
                },
                options: {
                    colors: colors,
                    legend: {
                        align: 'center',
                        x: 0,
                        verticalAlign: 'bottom',
                        y: 0,
                        floating: false,
                        backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                        borderColor: '#CCC',
                        borderWidth: 1,
                        shadow: false
                    }
                },
                series: series
            };
        }

    }
})();