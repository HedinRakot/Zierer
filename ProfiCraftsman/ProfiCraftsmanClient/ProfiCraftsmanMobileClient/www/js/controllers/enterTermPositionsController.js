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

    function EnterTermPositionsController($scope, globalizationService, moment, $http, $state) {
        this.$scope = $scope;
        this.$scope.locale = globalizationService.getDefaultLocale();
        this.globalizationService = globalizationService;
        this.moment = moment;
        this.http = $http;
        this.state = $state;

        var self = this;
        this.http.post(window.localStorage['baseAppPath'] + 'GetTerm', { 
            termId: window.localStorage['termId'],
            withPositions: true
        }).
        success(function (result) {
            self.term = result;
        }).
        error(function (result) {

        });
    }


    EnterTermPositionsController.prototype.checkPositions = function () {
        var self = this;

        var self = this;
        this.http.post(window.localStorage['baseAppPath'] + 'ChangeTermState',
            {
                login: window.localStorage['userLogin'],
                termId: window.localStorage['termId'],
                status: termStatusTypes.CheckPositions,
                positions: self.term.positions,
            }).
            success(function (result) {
                self.term = result;

                self.state.go('/termDetails');
            }).
            error(function (result) {

            });
    };

        
    EnterTermPositionsController.prototype.setLocale = function () {
        this.globalizationService.setLocale(this.$scope.locale);
        this.moment.locale(this.$scope.locale);
    }

    angular.module('app.controllers').controller('EnterTermPositionsController', ['$scope', 'globalizationService', 'moment', '$http', '$state', EnterTermPositionsController]);
}())