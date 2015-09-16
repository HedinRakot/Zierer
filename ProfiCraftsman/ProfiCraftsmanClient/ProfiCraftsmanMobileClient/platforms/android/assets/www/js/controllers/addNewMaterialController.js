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

    function AddNewMaterialController($scope, globalizationService, moment, $http, $state) {
        this.$scope = $scope;
        this.$scope.locale = globalizationService.getDefaultLocale();
        this.globalizationService = globalizationService;
        this.moment = moment;
        this.http = $http;
        this.state = $state;

        $scope.showAvailableMaterials = true;
        $scope.showConfirmation = false;

        var self = this;
        
    }

    AddNewMaterialController.prototype.findMaterial = function () {
        var self = this;

        this.http.post(window.localStorage['baseAppPath'] + 'GetAvailableMaterials', { searchWord: self.searchWord }).
            success(function (result) {
                self.materials = result;
            }).
            error(function (result) {

            });
      
    };

    AddNewMaterialController.prototype.showConfirmation = function (material) {
        var self = this;

        self.material = material;
        self.$scope.selectedMaterial = material.name;
        self.$scope.showAvailableMaterials = false;
        self.$scope.showConfirmation = true;
    };

    AddNewMaterialController.prototype.cancel = function () {
        var self = this;

        self.$scope.selectedMaterial = "";
        self.$scope.showAvailableMaterials = true;
        self.$scope.showConfirmation = false;
    };

    AddNewMaterialController.prototype.addNewMaterial = function () {
        var self = this,
            material = self.material;

        this.http.post(window.localStorage['baseAppPath'] + 'AddNewMaterial',
            {
                login: window.localStorage['userLogin'],
                token: window.localStorage['userToken'],
                materialId: material.id,
                termId: window.localStorage['termId'],
            }).
            success(function (result) {
                self.term = result;

                self.state.go('enterTermMaterials');
            }).
            error(function (result) {

            });
    };

    AddNewMaterialController.prototype.setLocale = function () {
        this.globalizationService.setLocale(this.$scope.locale);
        this.moment.locale(this.$scope.locale);
    }

    angular.module('app.controllers').controller('AddNewMaterialController', ['$scope', 'globalizationService', 'moment', '$http', '$state', AddNewMaterialController]);
}())