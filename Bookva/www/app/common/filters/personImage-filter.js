(function() {
    'use strict';

    angular.module('BookvaApp.common').filter('personFilter', function () {
        return function (imageSource) {
            return imageSource ? imageSource : 'http://style.anu.edu.au/_anu/4/images/placeholders/person.png';
        };
    });
})();