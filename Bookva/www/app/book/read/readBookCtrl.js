var bookva = angular.module('BookvaApp');

bookva.controller('readBookCtrl', ['$scope', '$route', '$http', '$location', '$cookies', '$routeParams', 'bookContentService',
    function ($scope, $route, $http, $location, $cookies, $routeParams, bookContentService) {

        'use strict';
        
        $scope.model= {
            book: bookContentService.getBookContent()
        };

        (function() {
            if (!$scope.model.book.id){
                var requestParams = {
                    method: 'GET',
                    headers: {
                        'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                    },
                    url: 'api/works/' + $routeParams.id
                };
                $http(requestParams).then(function (response) {
                    $scope.model.book = response.data;
                });

                if($cookies.get('bookvaUserToken')) {
                    var req = {
                        method: 'POST',
                        url: 'api/latestCollection/add/' + $scope.model.book.id,
                        headers: {
                            'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                        }
                    };

                    $http(req).success(function() {
                        //todo
                    });    
                }
            }
        })();
    }]);