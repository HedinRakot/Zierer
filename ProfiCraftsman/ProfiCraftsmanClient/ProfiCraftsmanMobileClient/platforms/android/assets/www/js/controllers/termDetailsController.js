(function () {
    'use strict';

    function TermDetailsController($scope, globalizationService, moment, $http, $state) {
        this.$scope = $scope;
        this.$scope.locale = globalizationService.getDefaultLocale();
        this.globalizationService = globalizationService;
        this.moment = moment;
        this.http = $http;
        this.state = $state;

        var self = this;
        this.http.post(window.localStorage['baseAppPath'] + 'GetTerm', { termId: window.localStorage['termId'] }).
            success(function (result) {
                self.term = result;
            }).
            error(function (result) {

            });
    }
    
    TermDetailsController.prototype.setLocale = function () {
        this.globalizationService.setLocale(this.$scope.locale);
        this.moment.locale(this.$scope.locale);
    }

    angular.module('app.controllers').controller('TermDetailsController', ['$scope', 'globalizationService', 'moment', '$http', '$state', TermDetailsController]);
}())