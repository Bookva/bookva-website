(function() {
    'use strict';

    angular.module('BookvaApp.common').filter('coverFilter', function () {
        return function (imageSource) {
            return imageSource ? imageSource : 'https://upload.wikimedia.org/wikipedia/ru/thumb/a/ac/No_image_available.svg/600px-No_image_available.svg.png';
        };
    });
})();