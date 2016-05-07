var bookva = angular.module('BookvaApp');

bookva.controller('userSettingsCtrl', ['$scope', '$route', '$http', '$location', '$cookies', '$uibModal',
    function ($scope, $route, $http, $location, $cookies, $uibModal) {

        'use strict';

        $scope.model = {
            
        };

        $scope.loadUserSettings = function () {
            var getUserIdReq = {
                method: 'GET',
                headers: {
                    'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                },
                url: 'api/account'
            };

            $http(getUserIdReq).then(function (response) {
                $scope.model.user = response.data;
                // var requestParams = {
                //     method: 'GET',
                //     headers: {
                //         'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                //     },
                //     url: 'api/user/' + $scope.model.id
                // };
                // $http(requestParams).then(function (response) {
                //     $scope.model.user = response.data;
                // });
            });
        };

        //TODO
        $scope.saveUserSettings = function() {
            var req = {
                method: 'POST',
                url: '...',
                headers: {
                    'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                },
                data: $scope.model.user
            };

            $http(req).success(function() {
                $scope.loadUserSettings();
            });
        };

        $scope.showChangePasswordModal = function() {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'app/settings/user/modal/changePasswordModal.html',
                controller: 'changePasswordCtrl'
            });
        };

        $scope.loadUserSettings();

    }]);