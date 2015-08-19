define([
	'base/base-window-view',
    'l!t!Orders/MaterialSearch',
], function (BaseView, MaterialSearchView) {
    'use strict';

    var view = BaseView.extend({
        width: '1060px',
        title: function () { return this.resources.title; },
        render: function () {
            var self = this;

            view.__super__.render.apply(this, arguments);

            var options = {
                success: function (model) {
 
                    if (self.selectInnerMaterial)
                        self.trigger('selectInnerMaterial', model);
                    else
                        self.trigger('selectMaterial', model);

                    self.close();
                },
                closeWindow: function () {
                    self.close();
                },
                materialAmountTypes: self.options.materialAmountTypes,
            };

            var materialSearchView = new MaterialSearchView(options);
            self.showView(materialSearchView, '.materials');

            return this;
        },

        open: function (e) {
            //this.kendoWindow.wrapper.css({ top: 100 });
        }
    });

    return view;
});