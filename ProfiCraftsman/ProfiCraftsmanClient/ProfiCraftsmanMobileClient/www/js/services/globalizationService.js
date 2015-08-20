(function () {
    'use strict';

    function globalizationService($translate, moment) {
        this.$translate = $translate;
        this.moment = moment;
    }

    globalizationService.prototype.getDefaultLocale = function () {
        return this.$translate.use();
    }

    globalizationService.prototype.setLocale = function (locale) {
        this.$translate.use(locale);
    }

    angular.module('app.services').service('globalizationService', ['$translate', 'moment', globalizationService]);
}())