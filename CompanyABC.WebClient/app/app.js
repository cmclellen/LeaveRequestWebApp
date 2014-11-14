'use strict';

var myApp = angular.module('LeaveRequestWebApp', ['ui.router']);

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

        $urlRouterProvider.otherwise("/landing");

        $stateProvider
            .state('layout', {
                abstract: true,
                templateUrl: "/app/views/layout.html",
                controller: 'LayoutController'
            }).state('landing', {
                parent: 'layout',
                url: "/landing",
                templateUrl: "/app/views/landing.html"
            }).state('newLeaveRequest', {
                parent: 'layout',
                url: "/newLeaveRequest",
                templateUrl: "/app/views/newLeaveRequest.html",
                controller: 'NewLeaveRequestController'
            }).state('viewHistory', {
                parent: 'layout',
                url: "/viewHistory",
                templateUrl: "/app/views/viewHistory.html"
            });
    }
})()]);