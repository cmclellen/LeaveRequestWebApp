myApp.controller('NewLeaveRequestController', ['$scope', 'leaveRequestService', function ($scope, leaveRequestService) {

    $scope.lookups = {
        reasons: null
    };

    $scope.models = {
        applicationName: 'Awesome Leave Request App'
    };

    $scope.submitNewLeaveRequest = function() {
        toastr.success('submit it to their manager for approval');
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