define([
'base/base-object-grid-view',
'collections/Terms/NotProccessedPositions',
//'l!t!Settings/FilterPositions'
], function (BaseView, Collection/*, FilterView*/) {
    'use strict';

    var saveFunction = function (e, self) {
        e.preventDefault();

        var grid = self.grid,
            dataItem = grid.dataItem(grid.select()),
            model = dataItem ? self.collection.get(dataItem.id) : null;

        if (model) {
            self.options.success(model);
        } else
            self.$('.select-message').show();
    },


    view = BaseView.extend({

        collectionType: Collection,
       // filterView: FilterView,
       // filterSelector: '.filter',

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
                { field: 'orderId', operator: 'eq', value: self.model.orderId },
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

        events: {
            'dblclick .k-grid tbody tr': function (e) {
                saveFunction(e, this);
            },
            'click .selectPosition': function (e) {
                saveFunction(e, this);
            },
            'click .closePositionWindow': function (e) {
                e.preventDefault();

                this.options.closeWindow();
            }
        },

        toolbar: function () {
            var self = this;
            return [
				{
				    template: function () {
				        return '<a class="k-button k-primary selectPosition" href="#">' +
                            self.resources.select + '</a>'
				    }
				},
        		{ template: function () { return '<a class="k-button closePositionWindow" href="#">' + self.resources.cancel + '</a>' } },
        		{ template: function () { return '<span class="select-message k-widget k-tooltip k-tooltip-validation k-invalid-msg"><span class="k-icon k-warning"></span>' + self.resources.noSelectionMessage + '</span>' } }
            ];
        }

    });

    return view;
});
