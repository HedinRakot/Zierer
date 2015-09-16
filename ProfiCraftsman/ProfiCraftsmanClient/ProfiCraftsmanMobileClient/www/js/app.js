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

    angular.module('app', ['ionic', 'app.services', 'app.controllers', 'pascalprecht.translate', 'angularMoment'])
        .run(function ($ionicPlatform, $translate, translateProviderStorageService, amMoment, $rootScope, modalWindowService) {
            
            window.localStorage.setItem("baseAppPath", "http://localhost:55992/api/");

            $ionicPlatform.ready(function () {
                // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
                // for form inputs)
                if (window.cordova && window.cordova.plugins && window.cordova.plugins.Keyboard) {
                    cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
                }
                if (window.StatusBar) {
                    // org.apache.cordova.statusbar required
                    StatusBar.styleDefault();
                }
            });

            if ($translate.storageKey) {
                var currentLang = translateProviderStorageService.get($translate.storageKey());
                if (currentLang) {
                    amMoment.changeLocale(currentLang);
                }
            }

            $rootScope.$on('$stateChangeStart', function (event, toState, toParams) {

                var requireLogin = toState.data && toState.data.requireLogin;

                if (requireLogin && (window.localStorage['userLogin'] == undefined || window.localStorage['userLogin'] == "null")) {

                    event.preventDefault();

                    modalWindowService.showModalWindowFromTemplate($rootScope, 'templates/login.html', toState);
                }
            });

        })
        .config(function ($compileProvider, $stateProvider, $translateProvider, $urlRouterProvider, $ionicConfigProvider, $httpProvider) {
            $compileProvider.aHrefSanitizationWhitelist(/^\s*(https?|ftp|mailto|file|ghttps?|ms-appx|x-wmapp0):/);
            // // Use $compileProvider.urlSanitizationWhitelist(...) for Angular 1.2
            $compileProvider.imgSrcSanitizationWhitelist(/^\s*(https?|ftp|file|ms-appx|x-wmapp0):|data:image\//);

            $stateProvider                
                .state('settings', {
                    url: "/settings",
                    views: {
                        'menuContent': {
                            templateUrl: "templates/settings/settings.html"
                        }
                    }
                })
                .state('/language', {
                    url: "/settings/language",
                    views: {
                        'menuContent': {
                            templateUrl: "templates/settings/language.html"
                        }
                    }

                })
                .state('help', {
                    url: "/help",
                    views: {
                        'menuContent': {
                            templateUrl: "templates/help.html"
                        }
                    }
                })
                .state('index', {
                    url: "/index",
                    views: {
                        'menuContent': {
                            templateUrl: "index.html"
                        }
                    }
                })
                .state('terms', {
                    url: "/terms",
                    views: {
                        'menuContent': {
                            templateUrl: "templates/terms/terms.html"
                        }
                    },
                    data: {
                        requireLogin: true
                    }
                })
                .state('termDetails', {
                    url: "/termDetails",
                    views: {
                        'menuContent': {
                            templateUrl: "templates/terms/termDetails.html"
                        }
                    },
                    data: {
                        requireLogin: true
                    }
                })
                .state('enterTermPositions', {
                    url: "/enterTermPositions",
                    views: {
                        'menuContent': {
                            templateUrl: "templates/terms/enterTermPositions.html"
                        }
                    },
                    data: {
                        requireLogin: true
                    }
                })
                .state('enterTermMaterials', {
                    url: "/enterTermMaterials",
                    views: {
                        'menuContent': {
                            templateUrl: "templates/terms/enterTermMaterials.html"
                        }
                    },
                    data: {
                        requireLogin: true
                    }
                })
                .state('showDeliveryNote', {
                    url: "/showDeliveryNote",
                    views: {
                        'menuContent': {
                            templateUrl: "templates/terms/showDeliveryNote.html"
                        }
                    },
                    data: {
                        requireLogin: true
                    }
                })
                .state('signDeliveryNote', {
                    url: "/signDeliveryNote",
                    views: {
                        'menuContent': {
                            templateUrl: "templates/terms/signDeliveryNote.html"
                        }
                    },
                    data: {
                        requireLogin: true
                    }
                })
                .state('addNewPosition', {
                    url: "/addNewPosition",
                    views: {
                        'menuContent': {
                            templateUrl: "templates/terms/addNewPosition.html"
                        }
                    },
                    data: {
                        requireLogin: true
                    }
                })
                .state('addNewMaterial', {
                    url: "/addNewMaterial",
                    views: {
                        'menuContent': {
                            templateUrl: "templates/terms/addNewMaterial.html"
                        }
                    },
                    data: {
                        requireLogin: true
                    }
                });

            // if none of the above states are matched, use this as the fallback
            $urlRouterProvider.otherwise('/help');

            $translateProvider.useStaticFilesLoader({
                prefix: 'languages/',
                suffix: '.json'
            });

            $translateProvider.preferredLanguage('de');
            $translateProvider.fallbackLanguage('de');
            $translateProvider.useStorage('translateProviderStorageService');
            $ionicConfigProvider.tabs.position('bottom');

            $httpProvider.interceptors.push(function () {
                return {
                    responseError: function (rejection) {
                        //TODO check response error and show login form if error 401
                        return rejection;
                    }
                }
            });
        });

    angular.module('app.controllers', []);
    angular.module('app.services', []);
}())