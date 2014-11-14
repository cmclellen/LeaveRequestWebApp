'use strict';

angular.extend(CompanyABC, (function () {

    var WebApi = (function () {

        function mapPath(path) {
            var path = '{0}/{1}'.format(CompanyABC.constants.WebApi_Url, path);
            return path;
        }

        return {
            mapPath: mapPath
        }
    })();

    return {
        WebApi: WebApi
    };
})());