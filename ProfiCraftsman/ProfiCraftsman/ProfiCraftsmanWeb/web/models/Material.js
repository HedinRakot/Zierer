define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/OrderProductMaterials',
		fields: {
		    id: { type: "number", editable: false }
            ,orderId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('OrderProductMaterialRsp', 'orderId'), 
				                    validation: { required: true } }			
			,productId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('OrderProductMaterialRsp', 'productId'), 
				                    validation: { required: true } }			
			,materialId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('OrderProductMaterialRsp', 'materialId'), 
				                    validation: { required: true } }			
			,amount: { type: "number", 
			                        editable: Application.canTableItemBeEdit('OrderProductMaterialRsp', 'amount'), 
				                    validation: { required: true } }	
		},
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
