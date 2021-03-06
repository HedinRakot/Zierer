define([
	'base/base-object-tab-view',
    'kendo/kendo.tabstrip'
], function (BaseView) {
    'use strict';

    var view = BaseView.extend({

        tabs: function () {
            
            var result = [
                { view: 'l!t!Terms/TermEmployees', selector: '.employees' },
                { view: 'l!t!Terms/TermPositions', selector: '.products' },
                { view: 'l!t!Terms/TermInstruments', selector: '.instruments' },
                { view: 'l!t!Terms/TermCosts', selector: '.costs' },
            ];
            
            return result;
        }
    });

    return view;
});
