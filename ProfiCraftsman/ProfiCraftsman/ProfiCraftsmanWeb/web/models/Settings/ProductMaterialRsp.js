define(['models/Settings/Custom.ProductMaterialRsp'
], function (CustomProperties) {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: Application.apiUrl + '/ProductMaterialRsps',
		fields: _.extend(CustomProperties(),  {
			id: { type: "number", editable: false }
			,productId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('ProductMaterialRsp', 'productId'), 
				                    validation: { required: true } }			
			,materialId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('ProductMaterialRsp', 'materialId'), 
				                    validation: { required: true } }			
			,amount: { type: "number", 
			                        editable: Application.canTableItemBeEdit('ProductMaterialRsp', 'amount'), 
				                    validation: { required: false } }			
		}),
		defaults: function () {
			var dnf = new Date();
			var dnt = new Date(2070,11,31);
			return {
				fromDate: dnf, 
				toDate: dnt
			};
		}
	});
	return model;
});
