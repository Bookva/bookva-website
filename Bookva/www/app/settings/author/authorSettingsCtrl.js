var bookva = angular.module('BookvaApp');

bookva.controller('authorSettingsCtrl', ['$scope', '$route', '$http', '$location', '$cookies',
    function ($scope, $route, $http, $location, $cookies) {

        'use strict';

        $scope.model = {
            author: {
                name: 'Doge',
                surname: 'Author',
                pseudonym: 'DOGE',
                usePseudonym: false,
                dateOfBirth: 30/12/1950,
                pictureSource: 'https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcS24lFzLCawtyboNa2OJbNrLJvBlVtplNo-pYhMKiWpW2EhbdBqcNoFFwI',
                previewPictureSource: 'https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcS24lFzLCawtyboNa2OJbNrLJvBlVtplNo-pYhMKiWpW2EhbdBqcNoFFwI',
                works: []
            }
        };
        
        $scope.loadAuthorSettings = function () {
            var getUserIdReq = {
                method: 'GET',
                headers: {
                    'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                },
                url: 'api/account'
            };

            $http(getUserIdReq).then(function (response) {
                $scope.model.id = response.data.authorId;

                if($scope.model.id != null) {
                    var requestParams = {
                        method: 'GET',
                        headers: {
                            'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                        },
                        url: 'api/authors/' + $scope.model.id
                    };
                    $http(requestParams).then(function (response) {
                        $scope.model.author = response.data;
                        $scope.model.author.id = id;
                    });
                }
            });

        };

        $scope.saveAuthorSettings = function() {

            var req = {
                url: 'api/authors',
                headers: {
                    'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                },
                data: $scope.model.author
            };
            
            if($scope.model.author.id) {
                req.method = 'PUT';
            } else {
                req.method = 'POST';
            }
            
            $http(req).success(function() {
                $scope.loadAuthorSettings();
            });
        };
        
        $scope.loadAuthorSettings();
    }]);