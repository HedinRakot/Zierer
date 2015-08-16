define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/ProductEquipmentRsps',
		fields: {
			id: { type: "number", editable: false }
			,productId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('ProductEquipmentRsp', 'productId'), 
				                    validation: { required: true } }			
			,equipmentId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('ProductEquipmentRsp', 'equipmentId'), 
				                    validation: { required: true } }			
			,amount: { type: "number", 
			                        editable: Application.canTableItemBeEdit('ProductEquipmentRsp', 'amount'), 
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
