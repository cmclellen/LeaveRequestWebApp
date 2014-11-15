﻿myApp.controller('NewLeaveRequestController', ['$scope', 'leaveRequestService', '$stateParams', function ($scope, leaveRequestService, $stateParams) {

    $scope.lookups = {
        reasons: null
    };

    $scope.data = {
        startDate: null,
        endDate: null,
        reasonId: null,
        comment: null,
        userId: $stateParams.userId
    };

    $scope.submitNewLeaveRequest = function () {
        var leaveRequests = [
            $scope.data
        ];
        leaveRequestService.saveLeaveRequests(leaveRequests).then(function () {
            toastr.success('submit it to their manager for approval');
        });
    };

    $scope.open = function ($event, instanceName) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope[instanceName] = true;
    };

    function initialize() {
        var lookups = $scope.lookups;

        console.log('calling service...');
        leaveRequestService.getReasons().then(function (response) {
            lookups.reasons = response.reasons;
        }, function (err) {
            console.log('err', err);
            
        });
    }
    initialize();

}]);