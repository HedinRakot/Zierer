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

    function AddNewPositionController($scope, globalizationService, moment, $http, $state) {
        this.$scope = $scope;
        this.$scope.locale = globalizationService.getDefaultLocale();
        this.globalizationService = globalizationService;
        this.moment = moment;
        this.http = $http;
        this.state = $state;

        $scope.showAvailableProducts = true;
        $scope.showConfirmation = false;

        var self = this;
        
    }

    AddNewPositionController.prototype.findProduct = function () {
        var self = this;

        this.http.post(window.localStorage['baseAppPath'] + 'GetAvailableProducts', { searchWord: self.searchWord }).
            success(function (result) {
                self.products = result;
            }).
            error(function (result) {

            });
      
    };

    AddNewPositionController.prototype.showConfirmation = function (product) {
        var self = this;

        self.product = product;
        self.$scope.selectedProduct = product.name;
        self.$scope.showAvailableProducts = false;
        self.$scope.showConfirmation = true;
    };

    AddNewPositionController.prototype.cancel = function () {
        var self = this;

        self.$scope.selectedProduct = "";
        self.$scope.showAvailableProducts = true;
        self.$scope.showConfirmation = false;
    };

    AddNewPositionController.prototype.addNewPosition = function () {
        var self = this,
            product = self.product;

        this.http.post(window.localStorage['baseAppPath'] + 'AddNewPosition',
            {
                login: window.localStorage['userLogin'],
                token: window.localStorage['userToken'],
                productId: product.id,
                termId: window.localStorage['termId'],
            }).
            success(function (result) {
                self.term = result;

                self.state.go('/enterTermPositions');
            }).
            error(function (result) {

            });
    };

    AddNewPositionController.prototype.setLocale = function () {
        this.globalizationService.setLocale(this.$scope.locale);
        this.moment.locale(this.$scope.locale);
    }

    angular.module('app.controllers').controller('AddNewPositionController', ['$scope', 'globalizationService', 'moment', '$http', '$state', AddNewPositionController]);
}())