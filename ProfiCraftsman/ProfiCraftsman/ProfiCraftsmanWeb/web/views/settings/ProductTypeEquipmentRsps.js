define([	
    'base/related-object-grid-view',
'collections/Settings/ProductTypeEquipmentRsps',
'l!t!Settings/AddProductTypeEquipmentRsp'
], function (BaseView, Collection, AddNewModelView) {
	'use strict';

	var view = BaseView.extend({

		addNewModelView: AddNewModelView,
		collectionType: Collection,
		gridSelector: '.grid',
		tableName: 'ProductTypeEquipmentRsps',
        
        addingInPopup: false,

		initialize: function() {
			view.__super__.initialize.apply(this, arguments);

			this.defaultFiltering = { field: 'productTypeId', operator: 'eq', value: this.model.id };

			this.collection = new Collection();
		},

		columns: function () {
		   
		   return [
				{ field: 'equipmentId', title: this.resources.equipmentId , collection: this.options.equipments, defaultText: this.resources.pleaseSelect, attributes: { "class": "detail-view-grid-cell" }},
				{ field: 'amount', title: this.resources.amount , attributes: { "class": "detail-view-grid-cell" }},
			];
		},
		
		render: function () {
		    var self = this;

		    view.__super__.render.apply(self, arguments);

		    self.grid.bind('edit', function (e) {
		        e.model.productTypeId = self.model.id;

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
