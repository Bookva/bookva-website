var bookva = angular.module('BookvaApp');

bookva.controller('authorSettingsCtrl', ['$scope', '$route', '$http', '$location', '$cookies',
    function ($scope, $route, $http, $location, $cookies) {

        'use strict';

        $scope.model = {
            author: {
                name: 'Doge Author',
                alias: 'DOGE',
                imgUrl: 'https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcS24lFzLCawtyboNa2OJbNrLJvBlVtplNo-pYhMKiWpW2EhbdBqcNoFFwI',
                books: []
            },
            useAlias: false
        }
    }]);