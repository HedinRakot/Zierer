define([
    'base/related-object-grid-view',
    'collections/Invoices/AddInvoicePositions'
], function (BaseView, Collection) {
    'use strict';

    var dateEditor = function (cont, options) {

        if (options.model.get('isProductPosition')) {
            $('<input data-role="datepicker" required data-text-field="' + options.field + '" data-value-field="' + options.field + '" data-bind="value:' + options.field + '"/>')
                .appendTo(cont);
        }
        else {
            var textValue = options.model.get(options.field),
                value = kendo.format("{0:d}", value == null ? "" : value);

            $('<span>' + value + '</span>').appendTo(cont);
        }
    },

    view = BaseView.extend({

        collectionType: Collection,
        gridSelector: '.grid',
        tableName: 'Positions',
        showAddButton: false,      

        initialize: function () {
            view.__super__.initialize.apply(this, arguments);

            var self = this;

            this.defaultFiltering = [
                { field: 'invoiceId', operator: 'eq', value: this.model.id },
            ];

            this.collection = new Collection();
        },

        columns: function () {
            return [
                 { field: 'description', title: this.resources.description, filterable: false, sortable: false },
                 { field: 'paymentType', title: this.resources.paymentType, collection: this.options.paymentTypes },
                 { field: 'price', title: this.resources.price },
                 { field: 'amount', title: this.resources.amount },
                 { field: 'totalPrice', title: this.resources.totalPrice, filterable: false, sortable: false },
            ];
        },

        render: function () {
            var self = this;

            view.__super__.render.apply(self, arguments);

            return self;
        }
    });

    return view;
});
