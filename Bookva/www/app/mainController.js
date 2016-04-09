var bookva = angular.module('BookvaApp', ['ngRoute', 'ngCookies'])
    .config(function ($routeProvider) {
        $routeProvider.when(
            '/', {templateUrl: 'www/app/main/mainPage.html',
            controller: 'mainPageCtrl'
        }).when('/login', {
            templateUrl: 'www/app/login/login.html',
            controller: 'loginCtrl'
        }).when('/register', {
            templateUrl: 'www/app/registration/registration.html',
            controller: 'registrationCtrl'
        }).when('/main', {
            templateUrl: 'www/app/bookList/bookList.html',
            controller: 'booklistCtrl'
        }).when('/email', {
            templateUrl: 'www/app/confirm/emailConfirm.html'
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
});
