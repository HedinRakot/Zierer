(function () {
    'use strict';

    function TermPositionsController($scope, globalizationService, moment, $http, $state) {
        this.$scope = $scope;
        this.$scope.locale = globalizationService.getDefaultLocale();
        this.globalizationService = globalizationService;
        this.moment = moment;
        this.http = $http;
        this.state = $state;

        var self = this;
        this.http.post(window.localStorage['baseAppPath'] + 'ClientTermPositions', { termId: window.localStorage['termId'] }).
            success(function (result) {
                self.positions = result;
            }).
            error(function (result) {

            });
    }
    
    TermPositionsController.prototype.setLocale = function () {
        this.globalizationService.setLocale(this.$scope.locale);
        this.moment.locale(this.$scope.locale);
    }

    angular.module('app.controllers').controller('TermPositionsController', ['$scope', 'globalizationService', 'moment', '$http', '$state', TermPositionsController]);
}())