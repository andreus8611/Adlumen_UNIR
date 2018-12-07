'use strict';
adlumenApp.factory('FileUploadService', function ($http, $q) {
    var savedFilePath;
    var fac = {};
    fac.UploadFile = function (file, description) {
        UploadFile(file, description, null)
    }
    fac.UploadFile = function (file, description, path) {
        var formData = new FormData();
        formData.append("file", file);
        //We can send more data to server using append         
        formData.append("description", description);
        if (path) formData.append("pathtosave", path);

        var defer = $q.defer();
        $http.post("/UploadFiles/SaveFiles", formData,
        {
            withCredentials: true,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        }).then(
            function (d) {
                defer.resolve(d.data);
                savedFilePath = d.data.FullFilePath;
            },
            function() {
                defer.reject("File Upload Failed!");
            }
        );

        return defer.promise;

    }

    fac.getSavedFilePath = function () {
        return savedFilePath;
    }
    return fac;

});