var bookva = angular.module('BookvaApp');

bookva.controller('changePasswordCtrl', ['$scope', '$route', '$http', '$location', '$cookies', '$uibModalInstance',
    function ($scope, $route, $http, $location, $cookies, $uibModalInstance) {

        'use strict';

        $scope.model = {
        };

        $scope.ok = function () {
            var req = {
                method: 'POST',
                url: 'api/account/changePassword',
                headers: {
                    'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                },
                data: $scope.model
            };

            $http(req).success(function() {
                $uibModalInstance.close();
            });
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
    }]);