var bookva = angular.module('BookvaApp');

bookva.controller('addBookCtrl', ['$scope', '$route', '$http', '$location', '$cookies',
    function ($scope, $route, $http, $location, $cookies) {

        'use strict';

        $scope.model = {
            book: {
                title: "Кладбище домашних животных",
                author: "С. Кинг",
                genres: [
                    "Триллер", "Мистика", "Ужасы"
                ],
                keywords: [],
                imgUrl: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS1BSiF2eB_J50OrBFW6_Z4wbKhiQ3id8sbdIOxI7izCiachPGnSBfFR5xfZg",
                description: "Тут должно было быть очень крутое описание книги. Но его пока нет потому что разрабы - ленивые :)",
                extracts: [
                    {
                        text: "Отрывок 1. Тут тоже должен был быть милый отрывок из книги, но это всего лишь тестовые данные"
                    }
                ]
            }
        }
    }]);