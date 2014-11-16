myApp.controller('NewLeaveRequestController', ['$scope', 'leaveRequestService', '$state', '$stateParams', function ($scope, leaveRequestService, $state, $stateParams) {

    $scope.lookups = {
        reasons: null
    };

    $scope.data = {
        startDate: null,
        endDate: null,
        reasonId: null,
        comments: null,
        userId: $stateParams.userId
    };

    $scope.submitNewLeaveRequest = function () {
        var leaveRequests = [
            $scope.data
        ];
        leaveRequestService.saveLeaveRequests(leaveRequests).then(function () {
            $state.go('dashboard');
            toastr.success('Leave request saved');
        });
    };

    $scope.open = function ($event, instanceName) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope[instanceName] = true;
    };

    function initialize() {
        var lookups = $scope.lookups;
        
        leaveRequestService.getReasons().then(function (response) {
            lookups.reasons = response.reasons;
        }, function (err) {
            console.log('err', err);
            
        });
    }
    initialize();

}]);