var bookva = angular.module('BookvaApp');

bookva.controller('registrationCtrl', ['$scope', '$route', '$http', '$location', '$httpParamSerializer',
    function ($scope, $route, $http, $location, $httpParamSerializer) {

        'use strict';
        $scope.model = {
            
        };

        $scope.register = function(){
            var req = {
                method: 'POST',
                url: 'api/account/register',
                data: $scope.model.user
            };

            $http(req).success(function() {
                    $location.path('/email');
                });
        }

    }]);
