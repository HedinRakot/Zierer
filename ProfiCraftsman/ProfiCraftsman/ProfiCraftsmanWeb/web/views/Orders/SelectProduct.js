define([
	'base/base-window-view',
    'l!t!Orders/ProductSearch'
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

            this.stickit();

            var self = this,
                selectInnerProduct = self.options.selectInnerProduct;

            var options = {
                success: function (model) {

                    if(selectInnerProduct)
                        self.trigger('selectInnerProduct', model);
                    else
                        self.trigger('selectProduct', model);

                    self.close();
                },
                closeWindow: function () {
                    self.close();
                },
                productTypes: self.options.productTypes,
                productAmountTypes: self.options.productAmountTypes,
            };
            

            var productSearchView = new ProductSearchView(options);
            self.showView(productSearchView, '.products');

            return this;
        },

        open: function (e) {
            //this.kendoWindow.wrapper.css({ top: 100 });
        }
    });
    
    return view;
});