(function() {
    'use strict';

    angular.module('BookvaApp.common').directive('bookItem', function () {
        return {
            scope: {
                ngModel: '=model'
            },
            templateUrl: 'app/common/directives/book/book.html'
        };
    });
})();