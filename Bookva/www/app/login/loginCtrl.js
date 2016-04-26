var bookva = angular.module('BookvaApp');

bookva.controller('loginCtrl', ['$scope', '$route', '$http', '$location', '$cookies',
    function ($scope, $route, $http, $location, $cookies) {

        'use strict';

        $scope.model = {
            rememberMe: false,
            user: {
                grant_type: 'password'
            }
        };

        $scope.login = function(){
            var loginRequest = {
                method: 'POST',
                url: 'Token',
                headers: {
                    'cache-control': 'no-cache',
                    'content-type': 'application/x-www-form-urlencoded'
                },
                data: $.param($scope.model.user)
            };

            $http(loginRequest).then(function(response) {
                $cookies.put('bookvaUserToken', response.data.access_token);
                $location.path('/main');
            });
        }

    }]);