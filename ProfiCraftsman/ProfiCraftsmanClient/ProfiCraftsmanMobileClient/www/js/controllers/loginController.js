(function() {
    'use strict';

    function LoginController($timeout, modalWindowService, $state, $http) {
        this.timeout = $timeout;
        this.modalWindowService = modalWindowService;
        this.state = $state;
        this.http = $http;

        console.debug('LoginController created');
    }

    LoginController.prototype.doLogin = function () {
        var self = this,
            toState = self.modalWindowService.toState;
        
        self.http.post(window.localStorage['baseAppPath'] + 'ClientLogin', self.loginData).success(function (response) {

            if (response.isAuthenticated) {

                window.localStorage.setItem("userLogin", response.login);

                if (toState) {
                    self.closeLogin();
                    self.state.go(toState.name);
                }
                else {
                    self.closeLogin();
                    self.state.go('index');
                }
            }
            else {

            }
        });
    };

    LoginController.prototype.closeLogin = function () {
        this.modalWindowService.closeModalWindow();
    };

    angular.module("app.controllers").controller('LoginController', ['$timeout', 'modalWindowService', '$state', '$http', LoginController]);

}())