myApp.controller('ViewLeaveRequestsController', ['$scope', '$q', 'leaveRequestService', '$stateParams', function ($scope, $q, leaveRequestService, $stateParams) {

    $scope.lookups = {
        reasons: null
    };

    $scope.data = {
        userId: $stateParams.userId,
        leaveRequests: null
    };

    function initialize() {
        var data = $scope.data;
        var lookups = $scope.lookups;
        
        var queries = [];

        queries.push({
            promise: function() {
                return leaveRequestService.getLeaveRequests({
                    userId: data.userId
                });
            },
            handleResponse: function (response) {
                data.leaveRequests = response;
            }
        });

        queries.push({
            promise: function () {
                return leaveRequestService.getReasons();
            },
            handleResponse: function (response) {
                lookups.reasons = response;
            }
        });

        var promises = queries.map(function(query) {
            return query.promise();
        });
        $q.all(promises).then(function (result) {
            for (var i = 0, len = result.length; i < len; i++) {
                queries[i].handleResponse(result[i]);
            }
        });
    }
    initialize();

}]);