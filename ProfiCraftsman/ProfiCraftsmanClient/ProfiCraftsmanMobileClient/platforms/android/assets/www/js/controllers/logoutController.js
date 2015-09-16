(function () {
    'use strict';

    function LogoutController($state, $http) {
        this.state = $state;
        this.http = $http;
    }

    LogoutController.prototype.doLogout = function () {

        window.localStorage.setItem("userLogin", "null");
        window.localStorage.setItem("userToken", "null");
    };
    
    angular.module("app.controllers").controller('LogoutController', ['$state', '$http', LogoutController]);

}())