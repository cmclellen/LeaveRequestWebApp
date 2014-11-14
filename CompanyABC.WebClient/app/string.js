'use strict';

$.extend(String.prototype, (function () {

    function format() {
        var content = this;
        for (var i = 0; i < arguments.length; i++) {
            var replacement = '{' + i + '}';
            content = content.replace(replacement, arguments[i]);
        }
        return content;
    }

    function endsWith(suffix) {
        return (this.substr(this.length - suffix.length) === suffix);
    }

    function startsWith(prefix) {
        return (this.substr(0, prefix.length) === prefix);
    }

    return {
        format: format,
        endsWith: endsWith,
        startsWith: startsWith
    };

})());

angular.extend(String, {
    Empty: ''
});