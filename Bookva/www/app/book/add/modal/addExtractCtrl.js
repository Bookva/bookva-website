var bookva = angular.module('BookvaApp');

bookva.controller('addExtractCtrl',
    function($scope, $http, $uibModalInstance, extract) {
        "use strict";
        $scope.extract = {
            text: extract.text
        };
        
        $scope.saveChanges = function() {
            $uibModalInstance.close($scope.extract.text);
        };

        $scope.closeModal = function() {
            $uibModalInstance.dismiss('cancel');
        };
    });