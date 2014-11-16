myApp.controller('ViewLeaveRequestsController', ['$scope', '$window', '$q', 'leaveRequestService', '$stateParams', function ($scope, $window, $q, leaveRequestService, $stateParams) {

    $scope.$window = $window;

    $scope.lookups = {
        reasons: null
    };

    $scope.data = {
        userId: $stateParams.userId || null,
        managerUserId: $stateParams.managerUserId || null,
        leaveRequests: null,
        userRoleId: $stateParams.managerUserId ? $window.CompanyABC.Constants.UserRole.Manager : $window.CompanyABC.Constants.UserRole.NonManager
    };

    $scope.approveLeaveRequest = function(leaveRequest, isApproved) {

        var args = {
            leaveRequestId: leaveRequest.id,
            leaveRequestStatusId: isApproved ? $window.CompanyABC.Constants.LeaveRequestStatus.Approved : $window.CompanyABC.Constants.LeaveRequestStatus.Rejected
        };
        leaveRequestService.approveLeaveRequest(args).then(function() {
            $scope.$broadcast('listing-refresh');
            toastr.success('Leave request updated');
        });
    };

    $scope.$on('listing-refresh', function () {
        var query = getLeaveRequestsQuery;
        query.promise().then(function(response) {
            query.handleResponse(response);
        });
    });

    var getLeaveRequestsQuery = {
        promise: function() {
            var data = $scope.data;
            data.leaveRequests = null;
            return leaveRequestService.getLeaveRequests({
                userId: data.userId,
                managerUserId: data.managerUserId
            });
        },
        handleResponse: function(response) {
            var data = $scope.data;
            data.leaveRequests = response;
        }
    };

    function initialize() {
        
        var queries = [];

        queries.push(getLeaveRequestsQuery);

        queries.push({
            promise: function () {
                return leaveRequestService.getReasons();
            },
            handleResponse: function (response) {
                var lookups = $scope.lookups;
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