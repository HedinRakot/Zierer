define([	
    'base/related-object-grid-view',
'collections/Invoices/InvoicePositions',
], function (BaseView, Collection) {
	'use strict';

    var view = BaseView.extend({

		collectionType: Collection,
		gridSelector: '.grid',
		tableName: 'InvoicePositions',
		showDeleteButton: false,
		showEditButton: false,
		showAddButton: false,

		initialize: function() {
			view.__super__.initialize.apply(this, arguments);

			this.defaultFiltering = { field: 'invoiceId', operator: 'eq', value: this.model.id };

			this.collection = new Collection();
		},

		columns: function () {
		   
		   return [
				{ field: 'number', title: this.resources.number, filterable: false, sortable: false },
				{ field: 'description', title: this.resources.description, filterable: false, sortable: false },
                { field: 'paymentType', title: this.resources.paymentType, collection: this.options.paymentTypes },
				{ field: 'priceString', title: this.resources.price },
				{ field: 'amount', title: this.resources.amount },
				{ field: 'totalPrice', title: this.resources.totalPrice, filterable: false, sortable: false },
			];
		},
		
		render: function () {
		    var self = this;

		    view.__super__.render.apply(self, arguments);

		    self.grid.bind('edit', function (e) {
		        e.model.invoiceId = self.model.id;

				if (e.model.isNew()) {
                    var dt = new Date(2070, 11, 31);
		            e.model.toDate = dt;
		            var numeric = e.container.find("input[name=toDate]");
					
					if(numeric != undefined && numeric.length > 0)
						numeric[0].value = dt.toLocaleDateString();
		        }
		    });

		    return self;
		}
	});

	return view;
});
