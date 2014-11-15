'use strict';

myApp.controller('LayoutController', ['$scope', 'leaveRequestService', function ($scope, leaveRequestService) {
    
    $scope.data = {
        users: null
    };

    function initialize() {
        var data = $scope.data;
        leaveRequestService.getUsers().then(function(response) {
            data.users = response;
        });
    }
    initialize();

}]);