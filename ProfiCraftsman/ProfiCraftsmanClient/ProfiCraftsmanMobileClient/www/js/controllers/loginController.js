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

        //console.log('Doing login', this.loginData);

        self.http.post(window.localStorage['baseAppPath'] + 'ClientLogin', self.loginData).success(function (response) {

            if (response.isAuthenticated) {

                window.localStorage['userLogin'] = response.login;

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
                //todo 
            }
        });

        //this.timeout(function () {
        //    self.closeLogin();
        //}, 1000);
    };

    LoginController.prototype.closeLogin = function () {
        this.modalWindowService.closeModalWindow();
    };

    angular.module("app.controllers").controller('LoginController', ['$timeout', 'modalWindowService', '$state', '$http', LoginController]);

}())