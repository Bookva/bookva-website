var bookva = angular.module('BookvaApp');

bookva.controller('registrationCtrl', ['$scope', '$route', '$http', '$location',
    function ($scope, $route, $http, $location) {

        'use strict';

        $scope.model = {
            rememberMe: false
        }

    }]);