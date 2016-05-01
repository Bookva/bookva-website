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
            });
        };

        $scope.pageChanged();
    }]);

bookva.directive('bookItem', ['$route', '$location', function($route, $location){
    return {
        scope: {
            ngModel: '=model'
        },
        templateUrl: 'www/app/books/mainPage/bookItem.html'
    }
}]);