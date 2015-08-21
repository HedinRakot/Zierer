define([
	'base/base-object-tab-view',
    'kendo/kendo.tabstrip'
], function (BaseView) {
    'use strict';

    var view = BaseView.extend({

        tabs: function () {
            
            var result = [
				{ view: 'l!t!Settings/AutoMaterialRsps', selector: '.materials'},
{ view: 'l!t!Settings/AutoInstrumentRsps', selector: '.instruments'},
                
            ];
            
            return result;
        }
    });

    return view;
});
