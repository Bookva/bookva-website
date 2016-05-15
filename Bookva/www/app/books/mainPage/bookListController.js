var bookva = angular.module('BookvaApp');

bookva.controller('booklistCtrl', ['$scope', '$route', '$http', '$location', '$httpParamSerializer',
    function ($scope, $route, $http, $location) {

        'use strict';

        $scope.model = {

        };

        $scope.pageChanged = function() {
            var requestParams = {
                method: 'GET',
                url: 'api/works'
            };
            $http(requestParams).then(function (response) {
                $scope.model.bookList = response.data;
                $scope.model.bookList.splice(3, $scope.model.bookList.length);
            });
        };

        $scope.openBook = function (id) {
            $location.path('/book/' + id);
        };

        $scope.pageChanged();
    }]);
