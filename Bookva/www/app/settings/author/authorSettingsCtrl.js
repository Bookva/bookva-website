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
                dateOfBirth: 12-30-1990,
                pictureSource: 'https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcS24lFzLCawtyboNa2OJbNrLJvBlVtplNo-pYhMKiWpW2EhbdBqcNoFFwI',
                previewPictureSource: 'https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcS24lFzLCawtyboNa2OJbNrLJvBlVtplNo-pYhMKiWpW2EhbdBqcNoFFwI',
                works: []
            }
        };

        $scope.onStartup = function() {
            //get user's author id if exists
            var id = 1;
            if(id){
                delete $scope.model.author;
            } else {
                $scope.model.author.id = id;
            }
        };
        
        $scope.onStartup();
    }]);