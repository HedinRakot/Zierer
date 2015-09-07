define([
	'base/base-window-view',
    'l!t!Terms/PositionSearch'
], function (BaseView, ProductSearchView) {
    'use strict';

    var view = BaseView.extend({
        width: '1060px',
        title: function () { return this.resources.title; },        

        initialize: function () {

            view.__super__.initialize.apply(this, arguments);
        },

        render: function () {
            
            view.__super__.render.apply(this, arguments);

            //todo delete this.stickit();

            var self = this;

            var options = {
                success: function (model) {

                    self.trigger('selectPosition', model);

                    self.close();
                },
                closeWindow: function () {
                    self.close();
                },
                model: self.model,
                paymentTypes: self.options.paymentTypes,
            };
            

            var productSearchView = new ProductSearchView(options);
            self.showView(productSearchView, '.positions');

            return this;
        },

        open: function (e) {
            //this.kendoWindow.wrapper.css({ top: 100 });
        }
    });
    
    return view;
});