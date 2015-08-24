(function () {
    'use strict';

    var termStatusTypes =
    {
        /// <summary>
        /// Open
        /// </summary>
        Open: 0,
        /// <summary>
        /// Begin Trip
        /// </summary>
        BeginTrip: 1,
        /// <summary>
        /// End Trip
        /// </summary>
        EndTrip: 2,
        /// <summary>
        /// Begin Work
        /// </summary>
        BeginWork: 3,
        /// <summary>
        /// End Work
        /// </summary>
        EndWork: 4,
        /// <summary>
        /// Begin Return Trip
        /// </summary>
        BeginReturnTrip: 5,
        /// <summary>
        /// End Return Trip
        /// </summary>
        EndReturnTrip: 6,
        /// <summary>
        /// Canceled
        /// </summary>
        Canceled: 7,
    };

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

    TermDetailsController.prototype.beginTrip = function () {
        var self = this;

        var self = this;
        this.http.post(window.localStorage['baseAppPath'] + 'ChangeTermState',
            {
                login: window.localStorage['userLogin'],
                termId: window.localStorage['termId'],
                status: termStatusTypes.BeginTrip,
            }).
            success(function (result) {
                self.term = result;
                
                self.state.go('/termDetails');
            }).
            error(function (result) {

            });
    };

    TermDetailsController.prototype.beginWork = function () {
        var self = this;

        var self = this;
        this.http.post(window.localStorage['baseAppPath'] + 'ChangeTermState',
            {
                login: window.localStorage['userLogin'],
                termId: window.localStorage['termId'],
                status: termStatusTypes.BeginWork,
            }).
            success(function (result) {
                self.term = result;

                self.state.go('/termDetails');
            }).
            error(function (result) {

            });
    };
    
    TermDetailsController.prototype.setLocale = function () {
        this.globalizationService.setLocale(this.$scope.locale);
        this.moment.locale(this.$scope.locale);
    }

    angular.module('app.controllers').controller('TermDetailsController', ['$scope', 'globalizationService', 'moment', '$http', '$state', TermDetailsController]);
}())