var bookva = angular.module('BookvaApp');

bookva.controller('chapterListCtrl', ['$scope', '$route', '$http', '$location', '$cookies',
    function ($scope, $route, $http, $location, $cookies) {

        'use strict';
        
        $scope.model =  {
            book: {
                title: "Кладбище домашних животных",
                author: "С. Кинг",
                chapters: [
                    {
                        number: "1",
                        title: "Глава 1"
                    },
                    {
                        number: "2",
                        title: "Глава 2"                        
                    },
                    {
                        number: "3",
                        title: "Глава 3"                        
                    }
                ]
            }
        }

    }]);