var myApp = angular.module('LeaveRequestWebApp', ['ui.router']);

myApp.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    //
    // For any unmatched url, redirect to /state1
    $urlRouterProvider.otherwise("/landing");
    //
    // Now set up the states
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
}]);