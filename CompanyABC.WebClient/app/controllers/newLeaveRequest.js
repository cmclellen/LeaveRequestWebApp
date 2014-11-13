myApp.controller('NewLeaveRequestController', ['$scope', function ($scope) {

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
        lookups.reasons = [
            { name: 'Annual' },
            { name: 'Personal' },
            { name: 'Compassionate' },
            { name: 'Parental' }
        ];
    }
    initialize();

}]);