'use strict';
adlumenApp.service('commonModel', function () {

    this._object = {};

    this.setObject = function (name, params) {
        return this._object[name] = params;
    }
    
    this.getObject= function(name){
        var objectTmp = this._object[name];
        delete this._object[name];
        return objectTmp;
    }
    
    this.getNewObject= function(name){
        var objectTmp = this._object[name];
        return objectTmp;  
    }

    this.deleteObject= function(name){
        delete this._object[name];
    }

})