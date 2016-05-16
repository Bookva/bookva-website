var bookva = angular.module('BookvaApp', ['ngRoute', 'ngCookies', 'ngSanitize', 'BookvaApp.common', 'ui.bootstrap'])
    .config(function ($routeProvider) {
        $routeProvider.when(
            '/', {templateUrl: 'app/main/mainPage.html',
            controller: 'mainPageCtrl'
        }).when('/login', {
            templateUrl: 'app/login/login.html',
            controller: 'loginCtrl'
        }).when('/register', {
            templateUrl: 'app/registration/registration.html',
            controller: 'registrationCtrl'
        }).when('/main', {
            templateUrl: 'app/books/mainPage/bookList.html',
            controller: 'booklistCtrl'
        }).when('/email', {
            templateUrl: 'app/confirm/emailConfirm.html'
        }).when ('/settings/user', {
            templateUrl: 'app/settings/user/userSettings.html',
            controller: 'userSettingsCtrl'
        }).when ('/settings/author', {
            templateUrl: 'app/settings/author/authorSettings.html',
            controller: 'authorSettingsCtrl'
        }).when ('/edit', {
            templateUrl: 'app/book/add/addBook.html',
            controller: 'addBookCtrl'
        }).when ('/edit/:id', {
            templateUrl: 'app/book/add/addBook.html',
            controller: 'addBookCtrl'
        }).when ('/book/:id/read', {
            templateUrl: 'app/book/read/readBook.html',
            controller: 'readBookCtrl'
        }).when ('/chapters', {
            templateUrl: 'app/book/chapters/chapterList.html',
            controller: 'chapterListCtrl'
        }).when ('/book/:id', {
            templateUrl: 'app/book/info/bookInfo.html',
            controller: 'bookInfoCtrl'
        }).when ('/search', {
            templateUrl: 'app/search/search.html',
            controller: 'searchCtrl'
        }).when('/errorPage', {
            templateUrl: 'app/error/404.html'
        }).otherwise({
            redirectTo: '/errorPage'
        });
    });


bookva.controller('mainController', function ($scope, $templateCache, $cookies) {
    $scope.$on('$routeChangeStart', function (event, next, current) {
        if (typeof(current) !== 'undefined') {
            if (typeof(next) !== 'undefined') {
                $templateCache.remove(next.templateUrl);
            }
        }
    });
    
    $scope.getToken = function(){
        var token = $cookies.get('bookvaUserToken');
        return token;
    }

    $scope.doLogout = function(){
        $cookies.remove('bookvaUserToken');
    }
});
