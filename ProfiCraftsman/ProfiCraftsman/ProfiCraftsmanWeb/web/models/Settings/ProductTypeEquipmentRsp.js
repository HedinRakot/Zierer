define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/ProductTypeEquipmentRsps',
		fields: {
			id: { type: "number", editable: false }
			,productTypeId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('ProductTypeEquipmentRsp', 'productTypeId'), 
				                    validation: { required: true } }			
			,equipmentId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('ProductTypeEquipmentRsp', 'equipmentId'), 
				                    validation: { required: true } }			
			,amount: { type: "number", 
			                        editable: Application.canTableItemBeEdit('ProductTypeEquipmentRsp', 'amount'), 
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
