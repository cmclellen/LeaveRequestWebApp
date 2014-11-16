'use strict';

var myApp = angular.module('LeaveRequestWebApp', ['ui.router', 'ui.bootstrap', 'angularMoment']);

myApp.config(['$stateProvider', '$urlRouterProvider', '$httpProvider', (function () {

    function configureDefaultsForHttpProvider($httpProvider) {

        var headers = $httpProvider.defaults.headers;

        // Disable caching (specifically because IE by default caches ajax responses)
        headers.common['Cache-Control'] = 'no-cache, no-store, must-revalidate';
        headers.common['Pragma'] = 'no-cache';
        headers.common['Expires'] = '0';

        // Handling of CORS
        $httpProvider.defaults.useXDomain = true;
        delete headers.common['X-Requested-With'];
    }
    
    return function($stateProvider, $urlRouterProvider, $httpProvider) {

        configureDefaultsForHttpProvider($httpProvider);

        $urlRouterProvider.otherwise("/dashboard");

        $stateProvider
            .state('layout', {
                abstract: true,
                templateUrl: "/app/views/layout.html",
                controller: 'LayoutController'
            }).state('dashboard', {
                parent: 'layout',
                url: "/dashboard",
                templateUrl: "/app/views/dashboard.html"
            }).state('newLeaveRequest', {
                parent: 'layout',
                url: "/newLeaveRequest?userId",
                templateUrl: "/app/views/newLeaveRequest.html",
                controller: 'NewLeaveRequestController'
            }).state('viewLeaveRequests', {
                parent: 'layout',
                url: "/viewLeaveRequests?userId&managerUserId",
                templateUrl: "/app/views/viewLeaveRequests.html",
                controller: 'ViewLeaveRequestsController'
            });
    }
})()]);