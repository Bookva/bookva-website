var bookva = angular.module('BookvaApp');

bookva.controller('readBookCtrl', ['$scope', '$route', '$http', '$location', 
    function ($scope, $route, $http, $location, $cookies) {

        'use strict';
        
        $scope.model = {
            book: {
                author: "С. Кинг",
                title: "Кладбище домашних животных",
                chapter: {
                    current: "Глава 1",
                    previous: "Вступление",
                    next: "Глава 2"
                },
                content: "<i>Преобразование</i> сетевых адресов (NAT) — это процесс, при котором сетевое устройство, например маршрутизатор Cisco, назначает публичный адрес узловым устройствам в пределах частной сети. NAT используют для того, чтобы сократить количество публичных IP-адресов, используемых организацией, поскольку количество доступных публичных IPv4-адресов ограничено."
            }
        }

    }]);