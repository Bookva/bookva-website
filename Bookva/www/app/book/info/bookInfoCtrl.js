var bookva = angular.module('BookvaApp');

bookva.controller('bookInfoCtrl', ['$scope', '$route', '$http', '$location', '$cookies', '$routeParams', 'bookContentService',
    function ($scope, $route, $http, $location, $cookies, $routeParams, bookContentService) {

        'use strict';

        $scope.model = {

        };

        $scope.pageChanged = function() {
            var requestParams = {
                method: 'GET',
                headers: {
                    'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                },
                url: 'api/works/' + $routeParams.id
            };
            $http(requestParams).then(function (response) {
                $scope.model.book = response.data;
            });

            var token = $cookies.get('bookvaUserToken');

            if(token) {
                var loadCollectionReq = {
                    method: 'GET',
                    headers: {
                        'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                    },
                    url: 'api/favourites'
                };
                $http(loadCollectionReq).then(function (response) {
                    var favouriteCollection = response.data;
                    $scope.model.favourite = false;
                    favouriteCollection.forEach(function(item){
                        if(item.id == $routeParams.id) {
                            $scope.model.favourite = true;
                        }
                    })
                });

                loadCollectionReq.url = 'api/latestCollection';
                $http(loadCollectionReq).then(function (response) {
                    var latestCollection = response.data;
                    $scope.model.latestCollection = false;
                    latestCollection.forEach(function(item){
                        if(item.id == $routeParams.id) {
                            $scope.model.latestCollection = true;
                        }
                    });
                });

                loadCollectionReq.url = 'api/readCollection';
                $http(loadCollectionReq).then(function (response) {
                    var readCollection = response.data;
                    $scope.model.readCollection = false;
                    readCollection.forEach(function(item){
                        if(item.id == $routeParams.id) {
                            $scope.model.readCollection = true;
                        }
                    });
                });
            }
        };

        $scope.addToCollection = function(collectionName) {
            var req = {
                method: 'POST',
                url: 'api/' + collectionName + '/add/' + $scope.model.book.id,
                headers: {
                    'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                }
            };

            $http(req).success(function() {
                $scope.model[collectionName] = true;
            });
        };

        $scope.removeFromCollection = function(collectionName) {
            var req = {
                method: 'DELETE',
                url: 'api/' + collectionName + '/delete/' + $scope.model.book.id,
                headers: {
                    'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                }
            };

            $http(req).success(function() {
                $scope.model[collectionName] = false;
            });
        };
        
        $scope.loadCollectionStats = function() {
            var token = $cookies.get('bookvaUserToken');
            return !!token;
        };
            
        $scope.rateBook = function(rate) {
            var rateRequest = {
                method: 'POST',
                url: 'api/works/' + $scope.model.book.id + '/rate/' + rate,
                headers: {
                    'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                }
            };

            $http(rateRequest).then(function(response) {
                $scope.pageChanged();
            });
        };

        $scope.readBook = function(text, prevChapter, currentChapter, nextChapter) {
            var textToRead = {
                id: $scope.model.book.id,
                content: text,
                authors: $scope.model.book.authors,
                chapter: {
                  current: currentChapter,
                  previous: prevChapter,
                  next: nextChapter
                },
                title: $scope.model.book.title
            };
            
            bookContentService.setBook(textToRead);
            $location.path('/read');
            //pass data to service
        };

        $scope.postReview = function() {
            var reviewRequest = {
                method: 'POST',
                url: 'api/reviews/',
                headers: {
                    'Authorization': 'Bearer ' + $cookies.get('bookvaUserToken')
                },
                data: {
                    title: $scope.model.review.title,
                    text: $scope.model.review.text,
                    workId: $scope.model.book.id
                }
            };
            $http(reviewRequest).then(function(response) {
                $scope.pageChanged();
            });
        };

        $scope.pageChanged();
    }]);