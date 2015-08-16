define([
	
], function () {
    'use strict';

    var toolbar = function () {
        var self = this,
            result =
        [{
            template: function () {
                return '<a class="k-button k-button-icontext" href="' + self.editUrl +
                '/create" data-localized="' + self.createNewItemTitle + '"></a>' +
                '<a class="k-button k-button-icontext copyProduct" href="#" data-localized="copyProduct">Kopieren</a>';
            }
        }];

        return result;
    };

    return toolbar;
});