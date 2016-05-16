(function() {
    'use strict';

    angular.module('BookvaApp.common').directive('bookItem', function () {
        return {
            scope: {
                ngModel: '=model',
                openBook: '&'
            },
            templateUrl: '/www/app/common/directives/book/book.html'
        };
    });
})();