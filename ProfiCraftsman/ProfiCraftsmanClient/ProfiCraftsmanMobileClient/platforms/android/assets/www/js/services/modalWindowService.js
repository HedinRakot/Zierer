(function () {
    'use strict';

    function modalWindowService($ionicModal) {
        this.ionicModal = $ionicModal;
        this.modal = null;
        this.toState = null;
    }

    modalWindowService.prototype.showModalWindowFromTemplate = function (scope, template, toState) {
        var self = this;
        this.ionicModal.fromTemplateUrl(template, {
            scope: scope
        }).then(function (modal) {

            self.toState = toState;

            self.modal = modal;
            self.modal.show();
        });
    }

    modalWindowService.prototype.closeModalWindow = function () {
        this.modal.hide();
    }

    angular.module('app.services').service('modalWindowService', ['$ionicModal', modalWindowService]);
}())