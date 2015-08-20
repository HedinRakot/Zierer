(function () {
    'use strict';

    function LanguageController($scope, globalizationService, moment) {
        this.$scope = $scope;
        this.$scope.locale = globalizationService.getDefaultLocale();
        this.globalizationService = globalizationService;
        this.moment = moment;
    }

    LanguageController.prototype.setLocale = function () {
        this.globalizationService.setLocale(this.$scope.locale);
        this.moment.locale(this.$scope.locale);
    }

    angular.module('app.controllers').controller('LanguageController', ['$scope', 'globalizationService', 'moment', LanguageController]);
}())