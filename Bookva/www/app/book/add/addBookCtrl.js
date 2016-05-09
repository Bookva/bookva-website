var bookva = angular.module('BookvaApp');

bookva.controller('addBookCtrl', ['$scope', '$route', '$http', '$location', '$cookies', '$uibModal',
    function ($scope, $route, $http, $location, $cookies, $uibModal) {

        'use strict';

        $scope.model = {
            book: {
                title: "Кладбище домашних животных",
                authorsIds: [],
                genres: [],
                keywords: [],
                imgUrl: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS1BSiF2eB_J50OrBFW6_Z4wbKhiQ3id8sbdIOxI7izCiachPGnSBfFR5xfZg",
                description: "Тут должно было быть очень крутое описание книги. Но его пока нет потому что разрабы - ленивые :)",
                extract1: "Отрывок 1. Тут тоже должен был быть милый отрывок из книги, но это всего лишь тестовые данные",
                extract2: "",
                extract3: "",
                isAnonymous: false,
                status: "Posted",
                yearCreated: "",
                text: "",
                coverSource: "",
                previewCoverSource: "",

            }
        };

        $scope.addExtract = function(extractToEdit, extractName) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'app/book/add/modal/addExtract.html',
                controller: 'addExtractCtrl',
                size: 'md',
                resolve: {
                    extract: function () {
                        return {
                            text: extractToEdit
                        }
                    }
                }
            });
            modalInstance.result.then(function (result) {
                $scope.model.book[extractName] = result;
            });
        };
    }]);