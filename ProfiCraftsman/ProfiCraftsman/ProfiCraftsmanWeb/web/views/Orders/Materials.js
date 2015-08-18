define([
    'base/related-object-grid-view',
    'collections/Materials'
], function (BaseView, Collection) {
    'use strict';

    var view = BaseView.extend({

        collectionType: Collection,
        gridSelector: '.grid',
        tableName: 'OrderProductMaterialRsps',

        addingInPopup: false,

        initialize: function () {
            view.__super__.initialize.apply(this, arguments);

            this.defaultFiltering = [
                { field: 'orderId', operator: 'eq', value: this.model.get('orderId') },
                { field: 'productId', operator: 'eq', value: this.model.get('productId') }];

            this.collection = new Collection();
        },

        columns: function () {

            return [
                 { field: 'materialId', title: this.resources.materialId, collection: this.options.materials, defaultText: this.resources.pleaseSelect, attributes: { "class": "detail-view-grid-cell" } },
                 { field: 'amount', title: this.resources.amount, attributes: { "class": "detail-view-grid-cell" } },
            ];
        },

        render: function () {
            var self = this;

            view.__super__.render.apply(self, arguments);

            self.grid.bind('edit', function (e) {

                e.model.orderId = self.model.get('orderId');
                e.model.productId = self.model.get('productId');
            });

            return self;
        }
    });

    return view;
});
