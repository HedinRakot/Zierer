(function() {
    'use strict';

    function LoginController($scope, $timeout, modalWindowService, $state, $http) {
        this.timeout = $timeout;
        this.modalWindowService = modalWindowService;
        this.state = $state;
        this.http = $http;
        this.$scope = $scope;

        console.debug('LoginController created');
        $scope.loginWrong = false;
        $scope.employeeNotSet = false;
    }

    LoginController.prototype.doLogin = function () {
        var self = this,
            toState = self.modalWindowService.toState;
        
        
        self.http.post(window.localStorage['baseAppPath'] + 'ClientLogin', self.loginData).success(function (response) {

            if (response.isAuthenticated) {

                window.localStorage.setItem("userLogin", response.login);
                window.localStorage.setItem("userToken", response.token);

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

                self.$scope.loginWrong = false;
                self.$scope.employeeNotSet = false;

                if (response.modelState) {
                    if (response.modelState.login[0] == "loginWrong") {
                        self.$scope.loginWrong = true;
                    }
                    else if (response.modelState.login[0] == "employeeNotSet") {
                        self.$scope.employeeNotSet = true;
                    }
                }
                else {
                    self.$scope.loginWrong = true;
                }
            }
        });
    };

    LoginController.prototype.closeLogin = function () {
        this.modalWindowService.closeModalWindow();
    };

    angular.module("app.controllers").controller('LoginController', ['$scope', '$timeout', 'modalWindowService', '$state', '$http', LoginController]);

}())