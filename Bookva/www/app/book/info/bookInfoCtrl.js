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

        $scope.rateBook = function(rate) {
            var rateRequest = {
                method: 'POST',
                url: 'api/works/' + $scope.model.book.id + '/rate/' + rate,
                headers: {
                    'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                }
            };

            $http(rateRequest).then(function(response) {
                $scope.pageChanged();
            });
        };

        $scope.postReview = function() {
            var reviewRequest = {
                method: 'POST',
                url: 'api/reviews/',
                headers: {
                    'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                },
                data: {
                    title: $scope.model.review.title,
                    text: $scope.model.review.text,
                    workId: $scope.model.book.id
                }
            };
            $http(reviewRequest).then(function(response) {
                $scope.pageChanged();
            });
        };

        $scope.pageChanged();
    }]);