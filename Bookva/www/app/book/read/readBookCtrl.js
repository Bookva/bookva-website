var bookva = angular.module('BookvaApp');

bookva.controller('readBookCtrl', ['$scope', '$route', '$http', '$location', '$cookies', 'bookContentService',
    function ($scope, $route, $http, $location, $cookies, bookContentService) {

        'use strict';
        
        $scope.model= {
            book: bookContentService.getBookContent()
        };

        $scope.addToLatestCollection = function () {
            var req = {
                method: 'POST',
                url: 'api/latestCollection/add/' + $scope.model.book.id,
                headers: {
                    'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                }
            };

            $http(req).success(function() {
                $scope.loadUserSettings();
            });
        };

        $scope.addToLatestCollection();
    }]);