(function () {
    'use strict';
    var controllerId = 'yourGarbageController';
    angular.module('app').controller(controllerId, ['$scope', '$http', yourGarbageController]);

    function yourGarbageController($scope, $http) {
        $scope.responseData = null;
        $scope.isLoading = false;
        $scope.garbageChartConfig = initGarbageChart();

        $scope.getGarbage = function (postalCode) {
            $scope.isLoading = true;
            $http({
                url: 'stats',
                method: 'POST',
                params: {
                    postalCode: postalCode
                }
            }).then(function (response) {
                console.log(response);
                $scope.responseData = response.data;
                $scope.isLoading = false;

                $scope.garbageChartConfig = initGarbageChart($scope.responseData);

            }, function (response) {

            });
        }

        function initGarbageChart(garbageData) {
            var xTitle = '';
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

            angular.forEach(garbageData, function (garbage) {
                categories.push(garbage.CollectedAt);

                if (garbage.WasteType == 'Hushållsavfall') {
                    series[0].data.push(
                    {
                        y: garbage.TotalWeight

                    });
                }

                if (garbage.WasteType == 'Matavfall') {
                    series[1].data.push({ y: garbage.TotalWeight });
                }
            });

            var chart = initLineChart(xTitle, categories, colors, series);
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