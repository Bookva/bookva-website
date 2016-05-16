(function() {
    'use strict';

    angular.module('BookvaApp.common').filter('lengthFilter', function () {
        return function (length) {
            return length ? length : 0;
        };
    });
})();