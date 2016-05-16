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

            $scope.loadCollections();
        };

        $scope.loadCollections = function() {
            var loadCollectionReq = {
                method: 'GET',
                headers: {
                    'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                },
                url: 'api/favourites'
            };
            $http(loadCollectionReq).then(function (response) {
                $scope.model.favouriteCollection = response.data;
            });

            loadCollectionReq.url = 'api/latestCollection';
            $http(loadCollectionReq).then(function (response) {
                $scope.model.latestCollection = response.data;
            });

            loadCollectionReq.url = 'api/readCollection';
            $http(loadCollectionReq).then(function (response) {
                $scope.model.readCollection = response.data;
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
                templateUrl: '/www/app/settings/user/modal/changePasswordModal.html',
                controller: 'changePasswordCtrl'
            });
        };

        $scope.openBook = function (id) {
            $location.path('/book/' + id);
        };

        $scope.loadUserSettings();

    }]);