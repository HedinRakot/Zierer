define([
    'base/related-object-grid-view',
    'collections/Administration/ReportPositions',
], function (BaseView, Collection) {
    'use strict';

    var view = BaseView.extend({

        collectionType: Collection,
        gridSelector: '.grid',
        tableName: 'Positions',

        showAddButton: false,
        showEditButton: false,
        showDeleteButton: false,

        addingInPopup: false,

        initialize: function () {
            view.__super__.initialize.apply(this, arguments);

            var self = this;

            this.defaultFiltering = [
                { field: 'orderId', operator: 'eq', value: this.model.id },
            ];

            this.collection = new Collection();
        },

        columns: function () {

            var columns = [
                //{ field: 'positionNumber', title: this.resources.positionNumber, filterable: false, sortable: false, width: '40px', attributes: { "class": "detail-view-grid-cell" } },
                { field: 'createDate', title: this.resources.date, width: '50px', format: '{0:d}', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'number', title: this.resources.number, width: '100px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'description', title: this.resources.description, filterable: false, sortable: false, width: '300px', attributes: { "class": "detail-view-grid-cell" } },
                { field: 'amount', title: this.resources.amount, width: '70px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'amountType', title: this.resources.amountType, width: '70px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'price', title: this.resources.price, width: '80px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'paymentType', title: this.resources.paymentType, filterable: false, sortable: false, collection: this.options.paymentTypes, width: '60px', attributes: { "class": "detail-view-grid-cell" } },
                { field: 'totalPrice', title: this.resources.totalPrice, width: '80px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
            ];

            return columns;
        },

        render: function () {
            var self = this;

            view.__super__.render.apply(self, arguments);
            
            self.grid.bind('edit', function (e) {

                e.model.orderId = self.model.id;
            });            

            return self;
        },

        toolbar: null
    });

    return view;
});
