define([
'base/base-object-grid-view',
'collections/Terms/NotProccessedPositions',
], function (BaseView, Collection) {
    'use strict';

    var view = BaseView.extend({

        collectionType: Collection,
        
        showDeleteButton: false,
        showEditButton: false,
        showAddButton: false,

        selectable: true,
        pageSizes: null,
        gridSelector: '.grid',

        initialize: function () {
            view.__super__.initialize.apply(this, arguments);

            var self = this;

            this.defaultFiltering = [
                { field: 'orderId', operator: 'eq', value: this.model.id },
            ];

            this.collection = new Collection();
        },

        render: function () {

            var self = this;

            view.__super__.render.apply(self, arguments);

            self.grid.bind('dataBinding', function (e) {

                if (e.items) {
                    for (var i = 0; i < e.items.length; i++) {
                        e.items[i].positionNumber = i + 1;
                    }
                }
            });

            return self;
        },

        columns: function () {

            return [
				{ field: 'positionNumber', title: this.resources.positionNumber, filterable: false, sortable: false, width: '40px', attributes: { "class": "detail-view-grid-cell" } },
                { field: 'isAlternative', title: this.resources.isAlternative, headerTitle: this.resources.isAlternativeTitle, checkbox: true, width: '45px', attributes: { "class": "detail-view-grid-cell" } },
                { field: 'number', title: this.resources.number, width: '100px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'description', title: this.resources.description, filterable: false, sortable: false, width: '300px', attributes: { "class": "detail-view-grid-cell" } },
                { field: 'amount', title: this.resources.amount, width: '70px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'amountType', title: this.resources.amountType, width: '70px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'price', title: this.resources.price, width: '80px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'paymentType', title: this.resources.paymentType, filterable: false, sortable: false, collection: this.options.paymentTypes, width: '60px', attributes: { "class": "detail-view-grid-cell" } },
                { field: 'totalPrice', title: this.resources.totalPrice, width: '80px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
            ];
        },
        
        toolbar: null,

    });

    return view;
});
