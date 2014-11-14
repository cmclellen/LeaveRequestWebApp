/// <reference path="location-service.js" />
'use strict';

myApp.factory('leaveRequestService', ['$http', '$q', 'eventbusService', function ($http, $q, eventbusService) {

    var urlBase = CompanyABC.WebApi.mapPath('api/LeaveRequest/');

    function getReasons() {
        var deferred = $q.defer();
        var url = urlBase.concat('GetReasons');
        $http.get(url)
            .success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });
        return deferred.promise;
    };

    return {
        getReasons: getReasons
    };

}]);