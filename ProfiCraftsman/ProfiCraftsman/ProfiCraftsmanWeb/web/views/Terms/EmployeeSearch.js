define([
'base/base-object-grid-view',
'collections/Terms/FreeEmployees',
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

            //this.defaultFiltering = [
            //    { field: 'orderId', operator: 'eq', value: self.model.orderId },
            //];

            this.collection = new Collection();
        },

        render: function () {

            var self = this;

            view.__super__.render.apply(self, arguments);

            return self;
        },

        columns: function () {

            return [
				{ field: 'number', title: this.resources.number },
				{ field: 'name', title: this.resources.name },
				{ field: 'firstName', title: this.resources.firstName },
            ];
        },

        events: {
            'dblclick .k-grid tbody tr': function (e) {
                saveFunction(e, this);
            },
            'click .selectEmployee': function (e) {
                saveFunction(e, this);
            },
            'click .closeWindow': function (e) {
                e.preventDefault();

                this.options.closeWindow();
            }
        },

        toolbar: function () {
            var self = this;
            return [
				{
				    template: function () {
				        return '<a class="k-button k-primary selectEmployee" href="#">' +
                            self.resources.select + '</a>'
				    }
				},
        		{ template: function () { return '<a class="k-button closeWindow" href="#">' + self.resources.cancel + '</a>' } },
        		{ template: function () { return '<span class="select-message k-widget k-tooltip k-tooltip-validation k-invalid-msg"><span class="k-icon k-warning"></span>' + self.resources.noSelectionMessage + '</span>' } }
            ];
        }

    });

    return view;
});
