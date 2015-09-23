define([
	'base/base-object-tab-view',
    'kendo/kendo.tabstrip'
], function (BaseView) {
    'use strict';

    var view = BaseView.extend({

        tabs: function () {
            
            var result = [
                { view: 'l!t!Orders/FreePositions', selector: '.freePositions' },
                { view: 'l!t!Orders/ProductPositions', selector: '.products' },
                { view: 'l!t!Orders/MaterialPositions', selector: '.materials' },
                { view: 'l!t!Terms/Terms', selector: '.terms' },
                { view: 'l!t!Orders/OrderFiles', selector: '.orderFiles' },
            ];
            
            return result;
        }
    });

    return view;
});
