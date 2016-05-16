(function() {
    'use strict';

    angular.module('BookvaApp.common').directive('review', function () {
        return {
            restrict: 'EA',
            templateUrl: '/www/app/common/directives/review/review.html',
            scope: {
                data: '='
            }
        };
    });
})();