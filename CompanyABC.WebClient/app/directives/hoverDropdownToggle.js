'use strict';

myApp.directive('hoverDropdownToggle', [
    function () {

        return {
            restrict: 'A',
            link: function(scope, elem) {
                console.log('here');
                elem.on('mouseenter', function() {
                    var dropdownMenu = elem.parent('.dropdown');
                    dropdownMenu.addClass('open');
                }).on('mousexit', function() {
                    var dropdownMenu = elem.parent('.dropdown');
                    dropdownMenu.removeClass('open');
                });
            }
        };
    }
]);