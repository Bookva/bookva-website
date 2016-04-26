var bookva = angular.module('BookvaApp');

bookva.controller('bookInfoCtrl', ['$scope', '$route', '$http', '$location', '$cookies', '$routeParams',
    function ($scope, $route, $http, $location, $cookies, $routeParams) {

        'use strict';

        $scope.model = {

        };

        $scope.pageChanged = function() {
            var requestParams = {
                method: 'GET',
                url: 'api/works/' + $routeParams.id
            };
            $http(requestParams).then(function (response) {
                $scope.model.book = response.data;
            });
        };

        $scope.pageChanged();
    }]);