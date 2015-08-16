define([
'base/base-object-grid-view',
'collections/ProductSearch'
], function (BaseView, Collection) {
    'use strict';

    var saveFunction = function (e, self) {
        e.preventDefault();

        var grid = self.grid,
            dataItem = grid.dataItem(grid.select()),
            model = dataItem ? self.collection.get(dataItem.id) : null;
            
            if (model) {
                model.fromDate = dataItem.fromDate;
                model.toDate = dataItem.toDate;
                self.options.success(model);
            } else
                self.$('.select-message').show();
        },


    view = BaseView.extend({

	    collectionType: Collection,
	    //filterView: FilterView,
	    filterSelector: '.filter',

	    showDeleteButton: false,
	    showEditButton: false,
	    showAddButton: false,

	    selectable: true,
	    pageSizes: null,
	    gridSelector: '.grid',

	    initialize: function () {
	        view.__super__.initialize.apply(this, arguments);

	        this.collection = new Collection();
	    },

	    render: function () {

	        var self = this;

	        view.__super__.render.apply(self, arguments);            

	        var path = 'l!t!Orders/FilterProductSmart';
	        if (self.options.isOffer) {
	            path = 'l!t!Orders/FilterOffersProductSmart';
	        }

	        require([path], function (View) {

	            self.showView(new View(
                        {
                            grid: self.grid,
                            productTypes: self.options.productTypes,
                            equipments: self.options.equipments
                        }
                    ),
                    self.filterSelector);
	        });

	        return self;
	    },

		columns: function () {
			
		    return [
				{ field: 'number', title: this.resources.number, filterable: false },
				{ field: 'productTypeId', title: this.resources.productTypeId, collection: this.options.productTypes, defaultText: this.resources.pleaseSelect },
				{ field: 'length', title: this.resources.length, filterable: false },
				{ field: 'width', title: this.resources.width, filterable: false },
				{ field: 'height', title: this.resources.height, filterable: false },
				{ field: 'color', title: this.resources.color, filterable: false },
				{ field: 'price', title: this.resources.price, filterable: false },
				{ field: 'isVirtual', title: this.resources.isVirtual, headerTitle: this.resources.isVirtual, checkbox: true, filterable: false },
				{ field: 'sellPrice', title: this.resources.sellPrice, filterable: false },
		    ];
		},

		events: {
		    'dblclick .k-grid tbody tr': function (e) {
		        saveFunction(e, this);
		    },
		    'click .selectProduct': function (e) {
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
				        return '<a class="k-button k-primary selectProduct" href="#">' +
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
