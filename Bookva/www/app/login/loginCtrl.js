var bookva = angular.module('BookvaApp');

bookva.controller('loginCtrl', ['$scope', '$route', '$http', '$location', '$cookies',
    function ($scope, $route, $http, $location, $cookies) {

        'use strict';

        $scope.model = {
            rememberMe: false
        };

        $scope.login = function(){
            $cookies.put('bookvaUserToken', 'newToken');
            var req = {
                method: 'GET',
                url: 'token',
                data: "username=" + $scope.model.username + "&password=" + $scope.model.password +
                "&grant_type=password"
            };

            $http(req).success(function() {
                $cookies.put('bookvaUserToken', 'newToken');
                $location.path('/main');
                //todo: implement login validation and redirecting to main page
            });
        }

    }]);