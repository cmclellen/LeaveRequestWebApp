'use strict';

myApp.factory('eventbusService', [
    '$rootScope', function($rootScope) {

        function publish(eventName, args) {
            $rootScope.$broadcast(eventName, args);
        }

        function subscribe(eventName, args) {
            $rootScope.$on(eventName, args.callback);
        }

        return {
            publish: publish,
            subscribe: subscribe
        };
    }
]);