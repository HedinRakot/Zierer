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

    function SignDeliveryNoteController($scope, globalizationService, moment, $http, $state) {
        this.$scope = $scope;
        this.$scope.locale = globalizationService.getDefaultLocale();
        this.globalizationService = globalizationService;
        this.moment = moment;
        this.http = $http;
        this.state = $state;

        var self = this;

        $scope.clearVal = 2;
        $scope.saveVal = 0;

        $scope.clear = function () {
            $scope.clearVal += 1; //On this value change directive clears the context
        }

        $scope.saveToImage = function () {
            //$scope.saveVal = 1; //On this value change directive saves the signature
            $scope.clearVal = 1; //On this value change directive saves the signature
        }
    }
                
    SignDeliveryNoteController.prototype.setLocale = function () {
        this.globalizationService.setLocale(this.$scope.locale);
        this.moment.locale(this.$scope.locale);
    }

    
    angular.module('app.controllers').directive("signatureDir", ['$document', '$log', '$rootScope', '$http', '$state',
        function ($document, $log, $rootScope, $http, $state) {
        return {
            restrict: "A",
            link: function (scope, element, attrs) {
                var ctx = element[0].getContext('2d');

                ctx.canvas.width = window.innerWidth - 30;

                // the last coordinates before the current move
                var lastPt;

                function getOffset(obj) {
                    return { left: 15, top: 116 }; //Got a fixed offset
                }

                attrs.$observe("value", function (newValue) {

                    if (newValue == 1) {

                        var signatureData = ctx.canvas.toDataURL();

                        $http.post(window.localStorage['baseAppPath'] + 'ChangeTermState',
                            {
                                login: window.localStorage['userLogin'],
                                token: window.localStorage['userToken'],
                                termId: window.localStorage['termId'],
                                status: termStatusTypes.EndWork,
                                signature: signatureData
                            }).
                            success(function (result) {
                                
                                $state.go('termDetails');
                            }).
                            error(function (result) {

                            });
                    }
                    else {
                        ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);
                    }
                });
                
                //todo delete
                //attrs.$observe("saveVal", function (newValue) {

                //    var signatureData = ctx.canvas.toDataURL();

                //    var self = this;

                //    self.http.post(window.localStorage['baseAppPath'] + 'ChangeTermState',
                //        {
                //            login: window.localStorage['userLogin'],
                //            termId: window.localStorage['termId'],
                //            status: termStatusTypes.EndWork,
                //            signature: signatureData
                //        }).
                //        success(function (result) {
                //            self.term = result;

                //            self.state.go('termDetails');
                //        }).
                //        error(function (result) {

                //        });

                //});

                element.on('touchstart', function (e) {
                    e.preventDefault();
                    ctx.fillRect(e.touches[0].pageX - getOffset(element).left, e.touches[0].pageY - getOffset(element).top, 2, 2);
                    lastPt = { x: e.touches[0].pageX - getOffset(element).left, y: e.touches[0].pageY - getOffset(element).top };
                });
                element.on('touchmove', function (e) {
                    e.preventDefault();
                    if (lastPt != null) {
                        ctx.beginPath();
                        ctx.moveTo(lastPt.x, lastPt.y);
                        ctx.lineTo(e.touches[0].pageX - getOffset(element).left, e.touches[0].pageY - getOffset(element).top);
                        ctx.stroke();
                    }
                    lastPt = { x: e.touches[0].pageX - getOffset(element).left, y: e.touches[0].pageY - getOffset(element).top };
                });

                element.on('touchend', function (e) {
                    e.preventDefault();
                    lastPt = null;
                });
            }
        };
    }]);


    angular.module('app.controllers').controller('SignDeliveryNoteController', ['$scope', 'globalizationService', 'moment', '$http', '$state', SignDeliveryNoteController]);
    
}())