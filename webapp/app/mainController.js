var bookva = angular.module('BookvaApp', ['ngRoute', 'ngCookies'])
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
