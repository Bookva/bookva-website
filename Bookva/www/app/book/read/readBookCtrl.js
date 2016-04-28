var bookva = angular.module('BookvaApp');

bookva.controller('readBookCtrl', ['$scope', '$route', '$http', '$location', '$cookies', 'bookContentService',
    function ($scope, $route, $http, $location, $cookies, bookContentService) {

        'use strict';
        
        $scope.model= {
            book: bookContentService.getBookContent()
        }
    }]);