﻿(function () {
    'use strict';

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
                .state('myServices', {
                    url: '/myServices',
                    abstract: true,
                    views: {
                        'menuContent': {
                            templateUrl: "templates/myServices/myServices.html"
                        }
                    },
                    data: {
                        requireLogin: true
                    }
                })
                .state('myServices.myData', {
                    url: '/myData',
                    views: {
                        'myData-tab': {
                            templateUrl: "templates/myServices/myData.html"
                        }
                    }
                })
                .state('myServices.services', {
                    url: '/services',
                    views: {
                        'services-tab': {
                            templateUrl: "templates/myServices/services.html"
                        }
                    }
                })
                .state('myServices.jobOffers', {
                    url: '/jobOffers',
                    views: {
                        'jobOffers-tab': {
                            templateUrl: "templates/myServices/jobOffers.html"
                        }
                    }
                })
                .state('findMaster', {
                    url: "/findMaster",
                    views: {
                        'menuContent': {
                            templateUrl: "templates/findMaster.html"
                        }
                    }
                })
                .state('hotOffers', {
                    url: "/hotOffers",
                    views: {
                        'menuContent': {
                            templateUrl: "templates/hotOffers.html"
                        }
                    }
                })
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
                .state('selectionMaster', {
                    url: "/selectionMaster",
                    views: {
                        'menuContent': {
                            templateUrl: "templates/selectionMaster.html"
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
                            templateUrl: "templates/terms.html"
                        }
                    },
                    data: {
                        requireLogin: true
                    }
                });

            // if none of the above states are matched, use this as the fallback
            $urlRouterProvider.otherwise('/findMaster');

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