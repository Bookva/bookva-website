var bookva = angular.module('BookvaApp');

bookva.service('bookContentService', function() {

    var book = {};

    var setBook = function(bookContent) {
        book = bookContent;
    };

    var getBookContent = function(){
        return book;
    };

    return {
        setBook: setBook,
        getBookContent: getBookContent
    };

});