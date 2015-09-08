define([	
    'base/related-object-grid-view',
'collections/Settings/ProductMaterialRsps',
'l!t!Settings/AddProductMaterialRsp',
'Settings/Custom.ProductMaterialRsp',
'Settings/Custom.Events.ProductMaterialRsp',
'Settings/Custom.Toolbar.ProductMaterialRsp'
], function (BaseView, Collection, AddNewModelView, CustomColumns, CustomEvents, CustomToolbar) {
	'use strict';

	var view = BaseView.extend({

		addNewModelView: AddNewModelView,
		collectionType: Collection,
		gridSelector: '.grid',
		tableName: 'ProductMaterialRsps',
        
        addingInPopup: false,

		initialize: function() {
			view.__super__.initialize.apply(this, arguments);

			this.defaultFiltering = { field: 'productId', operator: 'eq', value: this.model.id };

			this.collection = new Collection();
		},

		columns: function () {
		   
		   return $.merge( CustomColumns(),
[
				{ field: 'amount', title: this.resources.amount , attributes: { "class": "detail-view-grid-cell" }},
			]);
		},
		
		render: function () {
		    var self = this;

		    view.__super__.render.apply(self, arguments);

		    self.grid.bind('edit', function (e) {
		        e.model.productId = self.model.id;

				if (e.model.isNew()) {
                    var dt = new Date(2070, 11, 31);
		            e.model.toDate = dt;
		            var numeric = e.container.find("input[name=toDate]");
					
					if(numeric != undefined && numeric.length > 0)
						numeric[0].value = kendo.format("{0:d}", dt);
		        }
		    });

		    return self;
		}

				,events: CustomEvents
		,toolbar: CustomToolbar
		,selectable: true

	});

	return view;
});
