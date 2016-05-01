var bookva = angular.module('BookvaApp');

bookva.controller('userSettingsCtrl', ['$scope', '$route', '$http', '$location', '$cookies', '$uibModal',
    function ($scope, $route, $http, $location, $cookies, $uibModal) {

        'use strict';

        $scope.model = {
            user: {
                name: 'eraser',
                imgUrl: 'https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcS24lFzLCawtyboNa2OJbNrLJvBlVtplNo-pYhMKiWpW2EhbdBqcNoFFwI',
                showEmail: false,
                collections: []
            }
        };

        //TODO
        $scope.loadUserSettings = function () {
            var requestParams = {
                method: 'GET',
                headers: {
                    'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                },
                url: '...'
            };
            $http(requestParams).then(function (response) {
                $scope.model.book = response.data;
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