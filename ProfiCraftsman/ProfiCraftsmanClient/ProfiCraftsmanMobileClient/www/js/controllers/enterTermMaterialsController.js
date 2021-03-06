﻿(function () {
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

    function EnterTermMaterialsController($scope, globalizationService, moment, $http, $state) {
        this.$scope = $scope;
        this.$scope.locale = globalizationService.getDefaultLocale();
        this.globalizationService = globalizationService;
        this.moment = moment;
        this.http = $http;
        this.state = $state;

        var self = this;
        this.http.post(window.localStorage['baseAppPath'] + 'GetTerm', { 
            termId: window.localStorage['termId'],
            withMaterials: true
        }).
        success(function (result) {
            self.term = result;
        }).
        error(function (result) {

        });
    }


    EnterTermMaterialsController.prototype.checkMaterials = function () {

        var self = this;

        this.http.post(window.localStorage['baseAppPath'] + 'ChangeTermState',
            {
                login: window.localStorage['userLogin'],
                token: window.localStorage['userToken'],
                termId: window.localStorage['termId'],
                status: termStatusTypes.CheckMaterials,
                materials: self.term.materials,
                withMaterials: true,
            }).
            success(function (result) {
                self.term = result;

                self.state.go('enterTermMaterials');
            }).
            error(function (result) {

            });
    };

    EnterTermMaterialsController.prototype.goToEnterMaterials = function () {

        var self = this;

        self.term.status = termStatusTypes.EnterMaterials;

        self.state.go('enterTermMaterials');
    };

    EnterTermMaterialsController.prototype.goBack = function () {

        var self = this;

        if (self.term.status == termStatusTypes.EnterMaterials) {

            this.http.post(window.localStorage['baseAppPath'] + 'ChangeTermState',
            {
                login: window.localStorage['userLogin'],
                token: window.localStorage['userToken'],
                termId: window.localStorage['termId'],
                status: termStatusTypes.CheckPositions,
                positions: [],
                withPositions: true,
            }).
            success(function (result) {
                self.term = result;

                self.state.go('enterTermPositions');
            }).
            error(function (result) {

            });
        }
        else {
            self.term.status = termStatusTypes.EnterMaterials;
            self.state.go('enterTermMaterials');
        }
    };

    EnterTermMaterialsController.prototype.showDeliveryNote = function () {

        var self = this;

        this.http.post(window.localStorage['baseAppPath'] + 'ChangeTermState',
            {
                login: window.localStorage['userLogin'],
                token: window.localStorage['userToken'],
                termId: window.localStorage['termId'],
                status: termStatusTypes.ShowDeliveryNote,
                withPositions: true,
                withMaterials: true,
            }).
            success(function (result) {
                self.term = result;

                self.state.go('showDeliveryNote');
            }).
            error(function (result) {

            });
    };

    EnterTermMaterialsController.prototype.addNewMaterial = function () {

        var self = this;

        self.state.go('addNewMaterial');
    };

        
    EnterTermMaterialsController.prototype.setLocale = function () {
        this.globalizationService.setLocale(this.$scope.locale);
        this.moment.locale(this.$scope.locale);
    }

    angular.module('app.controllers').controller('EnterTermMaterialsController', ['$scope', 'globalizationService', 'moment', '$http', '$state', EnterTermMaterialsController]);
}())