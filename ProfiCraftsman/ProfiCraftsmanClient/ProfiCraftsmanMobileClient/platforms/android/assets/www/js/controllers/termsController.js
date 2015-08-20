(function () {
    'use strict';

    function TermsController($scope, globalizationService, moment, $http) {
        this.$scope = $scope;
        this.$scope.locale = globalizationService.getDefaultLocale();
        this.globalizationService = globalizationService;
        this.moment = moment;
        this.http = $http;

        var self = this;
        this.http.post(window.localStorage['baseAppPath'] + 'ClientTerms', { userLogin: window.localStorage['userLogin'] }).
            success(function (result) {
                self.terms = result;
            }).
            error(function (result) {
                //self.orders = result.data;
            });
    }

    TermsController.prototype.setLocale = function () {
        this.globalizationService.setLocale(this.$scope.locale);
        this.moment.locale(this.$scope.locale);
    }

    angular.module('app.controllers').controller('TermsController', ['$scope', 'globalizationService', 'moment', '$http', TermsController]);
}())