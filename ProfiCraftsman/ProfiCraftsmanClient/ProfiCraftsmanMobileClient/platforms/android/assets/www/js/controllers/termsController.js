(function () {
    'use strict';

    function TermsController($scope, globalizationService, moment, $http, $state) {
        this.$scope = $scope;
        this.$scope.locale = globalizationService.getDefaultLocale();
        this.globalizationService = globalizationService;
        this.moment = moment;
        this.http = $http;
        this.state = $state;

        var self = this;
        this.http.post(window.localStorage['baseAppPath'] + 'ClientTerms', { userLogin: window.localStorage['userLogin'] }).
            success(function (result) {
                self.terms = result;
            }).
            error(function (result) {
 
            });
    }

    TermsController.prototype.showTerm = function (term) {
        var self = this;

        window.localStorage.setItem("termId", term.id);
        self.state.go('/termDetails');
    };

    TermsController.prototype.setLocale = function () {
        this.globalizationService.setLocale(this.$scope.locale);
        this.moment.locale(this.$scope.locale);
    }

    angular.module('app.controllers').controller('TermsController', ['$scope', 'globalizationService', 'moment', '$http', '$state', TermsController]);
}())