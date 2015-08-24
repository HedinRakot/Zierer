(function () {
    'use strict';

    var termStatusTypes =
    {
        /// <summary>
        /// Open
        /// </summary>
        Open: 0,
        /// <summary>
        /// Begin Trip Departure Selection
        /// </summary>
        BeginTripDepartureSelection: 1,
        /// <summary>
        /// Begin Trip
        /// </summary>
        BeginTrip: 2,
        /// <summary>
        /// End Trip
        /// </summary>
        EndTrip: 3,
        /// <summary>
        /// Begin Work
        /// </summary>
        BeginWork: 4,
        /// <summary>
        /// Enter positions
        /// </summary>
        EnterPositions: 5,
        /// <summary>
        /// Check positions
        /// </summary>
        CheckPositions: 6,
        /// <summary>
        /// Enter materials
        /// </summary>
        EnterMaterials: 7,
        /// <summary>
        /// Check materials
        /// </summary>
        CheckMaterials: 8,
        /// <summary>
        /// Show Delivery Note
        /// </summary>
        ShowDeliveryNote: 9,
        /// <summary>
        /// Sign Delivery Note
        /// </summary>
        SignDeliveryNote: 10,
        /// <summary>
        /// End Work
        /// </summary>
        EndWork: 11,
        /// <summary>
        /// Begin Return Trip
        /// </summary>
        BeginReturnTrip: 12,
        /// <summary>
        /// End Return Trip
        /// </summary>
        EndReturnTrip: 13,
        /// <summary>
        /// Canceled
        /// </summary>
        Canceled: 14,
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


    TermDetailsController.prototype.beginTripDepartureSelection = function () {
        var self = this;

        var self = this;
        this.http.post(window.localStorage['baseAppPath'] + 'ChangeTermState',
            {
                login: window.localStorage['userLogin'],
                termId: window.localStorage['termId'],
                status: termStatusTypes.BeginTripDepartureSelection,
            }).
            success(function (result) {
                self.term = result;

                self.state.go('/termDetails');
            }).
            error(function (result) {

            });
    };

    TermDetailsController.prototype.beginTrip = function (beginTripFromOffice) {
        var self = this;

        var self = this;
        this.http.post(window.localStorage['baseAppPath'] + 'ChangeTermState',
            {
                login: window.localStorage['userLogin'],
                termId: window.localStorage['termId'],
                status: termStatusTypes.BeginTrip,
                beginTripFromOffice: beginTripFromOffice
            }).
            success(function (result) {
                self.term = result;
                
                self.state.go('/termDetails');
            }).
            error(function (result) {

            });
    };

    TermDetailsController.prototype.endTrip = function () {
        var self = this;

        var self = this;
        this.http.post(window.localStorage['baseAppPath'] + 'ChangeTermState',
            {
                login: window.localStorage['userLogin'],
                termId: window.localStorage['termId'],
                status: termStatusTypes.EndTrip,
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

    TermDetailsController.prototype.enterPositions = function () {
        var self = this;

        var self = this;
        this.http.post(window.localStorage['baseAppPath'] + 'ChangeTermState',
            {
                login: window.localStorage['userLogin'],
                termId: window.localStorage['termId'],
                status: termStatusTypes.EnterPositions,
            }).
            success(function (result) {
                self.term = result;

                self.state.go('/enterTermPositions');
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