'use strict';

myApp.filter('lookup', [
    function () {

        function handleNonArray(lookups, input) {
            var foundLookup = _.find(lookups, function (lookup) {
                return lookup.id === input;
            });
            return foundLookup ? foundLookup.name : input;
        }

        function handleArray(lookups, inputArr) {
            var output = inputArr.map(function (input) {
                return handleNonArray(lookups, input);
            });

            return output.sort().join(', ');
        }

        return function (input, lookups) {
            var output = null;
            if (lookups) {
                var isArray = angular.isArray(input);
                if (!isArray) {
                    output = handleNonArray(lookups, input);
                } else {
                    output = handleArray(lookups, input);
                }
            }
            return output;
        };
    }
]);