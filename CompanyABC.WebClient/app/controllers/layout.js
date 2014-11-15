'use strict';

myApp.controller('LayoutController', ['$scope', '$q', '$window', '$state', 'leaveRequestService', function ($scope, $q, $window, $state, leaveRequestService) {

    $scope.$window = $window;

    $scope.data = {
        users: null,
        selectedUser: null
    };

    $scope.lookups = {
        userRoles: null
    };

    $scope.$watch('data.selectedUser', function (newValue) {
        var data = $scope.data;
        var lookups = $scope.lookups;
        if (newValue) {
            var foundUserRole = _.find(lookups.userRoles, function(userRole) {
                return userRole.id === newValue.userRoleId;
            });
            data.selectedUser.userRole = foundUserRole;
        }
        $state.go('dashboard');
    });

    function initialize() {
        var data = $scope.data;
        var lookups = $scope.lookups;

        var queries = [];

        // Fetch users
        queries.push({
            promise: function() {
                return leaveRequestService.getUsers();
            },
            handleResponse: function (response) {
                data.users = response;
            }
        });

        // Fetch user roles
        queries.push({
            promise: function () {
                return leaveRequestService.getUserRoles();
            },
            handleResponse: function(response) {
                lookups.userRoles = response;
            }
        });

        // Execute and handle queries
        var promises = queries.map(function(query) {
            return query.promise();
        });
        $q.all(promises).then(function(result) {
            for (var i = 0, len = result.length; i < len; i++) {
                queries[i].handleResponse(result[i]);
            }
        });
    }
    initialize();

}]);