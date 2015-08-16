define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/OrderProductEquipments',
		fields: {
		    id: { type: "number", editable: false }
            ,orderId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('OrderProductEquipmentRsp', 'orderId'), 
				                    validation: { required: true } }			
			,productId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('OrderProductEquipmentRsp', 'productId'), 
				                    validation: { required: true } }			
			,equipmentId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('OrderProductEquipmentRsp', 'equipmentId'), 
				                    validation: { required: true } }			
			,amount: { type: "number", 
			                        editable: Application.canTableItemBeEdit('OrderProductEquipmentRsp', 'amount'), 
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
