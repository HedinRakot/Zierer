define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/Products',
		fields: {
			id: { type: "number", editable: false }
			,number: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Products', 'number'), 
				                    validation: { required: true, maxLength: 20 } }			
			,productTypeId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'productTypeId'), 
				                    validation: { required: false } }			
			,price: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'price'), 
				                    validation: { required: true } }			
			,proceedsAccount: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'proceedsAccount'), 
				                    validation: { required: true } }			
			,comment: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Products', 'comment'), 
				                    validation: { required: false, maxLength: 128 } }			
			,name: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Products', 'name'), 
				                    validation: { required: true, maxLength: 250 } }			
			,productAmountType: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'productAmountType'), 
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
