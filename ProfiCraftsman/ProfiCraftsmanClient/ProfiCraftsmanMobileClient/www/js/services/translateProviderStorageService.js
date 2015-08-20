(function () {
    'use strict';

    function translateProviderStorageService($window) {
        this.localStorage = $window.localStorage;
    }

    translateProviderStorageService.prototype.put = function (name, value) {
        this.localStorage[name] = value;
    }

    translateProviderStorageService.prototype.get = function (name) {
        return this.localStorage[name];
    }

    angular.module('app.services').service('translateProviderStorageService', ['$window', translateProviderStorageService]);
}())