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
        
        if (term.status == termStatusTypes.EnterPositions || term.status == termStatusTypes.CheckPositions)
            self.state.go('/enterTermPositions');
        else if (term.status == termStatusTypes.EnterMaterials || term.status == termStatusTypes.CheckMaterials)
            self.state.go('/enterTermMaterials');
        else if (term.status == termStatusTypes.ShowDeliveryNote)
            self.state.go('/showDeliveryNote');
        else if (term.status == termStatusTypes.SignDeliveryNote)
            self.state.go('/signDeliveryNote');
        else
            self.state.go('termDetails');
    };

    TermsController.prototype.setLocale = function () {
        this.globalizationService.setLocale(this.$scope.locale);
        this.moment.locale(this.$scope.locale);
    }

    angular.module('app.controllers').controller('TermsController', ['$scope', 'globalizationService', 'moment', '$http', '$state', TermsController]);
}())