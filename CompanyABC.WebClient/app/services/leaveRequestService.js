/// <reference path="location-service.js" />
'use strict';

myApp.factory('leaveRequestService', ['$http', '$q', 'eventbusService', function ($http, $q, eventbusService) {

    var urlBase = CompanyABC.WebApi.mapPath('api/LeaveRequest/');

    function getReasons() {
        var config = {
            cache: true
        };
        var deferred = $q.defer();
        var url = urlBase.concat('GetReasons');
        $http.get(url, config)
            .success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });
        return deferred.promise;
    };

    function getUserRoles() {
        var config = {
            cache: true
        };
        var deferred = $q.defer();
        var url = urlBase.concat('GetUserRoles');
        $http.get(url, config)
            .success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });
        return deferred.promise;
    };

    function saveLeaveRequests(args) {
        var deferred = $q.defer();
        var url = urlBase.concat('SaveLeaveRequests');
        $http.post(url, args)
            .success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                deferred.reject(err);
            });
        return deferred.promise;
    };

    function getUsers() {
        var deferred = $q.defer();
        var url = urlBase.concat('GetUsers');
        $http.get(url)
            .success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                deferred.reject(err);
            });
        return deferred.promise;
    };

    function getLeaveRequests(args) {
        var deferred = $q.defer();
        var url = urlBase.concat('GetLeaveRequests');
        $http.post(url, args)
            .success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                deferred.reject(err);
            });
        return deferred.promise;
    };
    
    function approveLeaveRequest(args) {
        var deferred = $q.defer();
        var url = urlBase.concat('ApproveLeaveRequest');
        $http.post(url, args)
            .success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                deferred.reject(err);
            });
        return deferred.promise;
    };
    
    return {

        // Lookups
        getReasons: getReasons,
        getUserRoles: getUserRoles,

        // Other
        approveLeaveRequest: approveLeaveRequest,
        getLeaveRequests: getLeaveRequests,
        saveLeaveRequests: saveLeaveRequests,
        getUsers: getUsers
    };

}]);