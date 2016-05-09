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

        $scope.addKeyword = function() {
            $scope.model.book.keywords.push(
                {
                    id: null,
                    value: $scope.model.keyword
                }
            );
            $scope.model.keyword = '';
        };
        
        $scope.deleteKeyword = function(keyword) {
            var index = $scope.model.book.keywords.indexOf(keyword);
            $scope.model.book.keywords.splice(index, 1);
        };

        $scope.addGenre = function() {
            $scope.model.book.genres.push(
                {
                    id: null,
                    value: $scope.model.genre
                }
            );
            $scope.model.genre = '';
        };
        
        $scope.deleteGenre = function(genre) {
            var index = $scope.model.book.genres.indexOf(genre);
            $scope.model.book.genres.splice(index, 1);
        };

        $scope.addBook = function() {

            if($scope.model.book.status) {
                $scope.model.book.status = 'Drafted'
            } else {
                //TODO check status
                $scope.model.book.status = 'Published'
            }

            var req = {
                method: 'POST',
                //TODO check method
                url: '...',
                headers: {
                    'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                },
                data: $scope.model.book
            };

            $http(req).success(function() {
                $location.path('/settings/author');
            });
        };
    }]);