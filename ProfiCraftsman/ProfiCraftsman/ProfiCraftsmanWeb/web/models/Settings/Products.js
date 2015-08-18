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
			,length: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'length'), 
				                    validation: { required: false } }			
			,width: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'width'), 
				                    validation: { required: false } }			
			,height: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'height'), 
				                    validation: { required: false } }			
			,color: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Products', 'color'), 
				                    validation: { required: false, maxLength: 50 } }			
			,price: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'price'), 
				                    validation: { required: true } }			
			,proceedsAccount: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'proceedsAccount'), 
				                    validation: { required: true } }			
			,boughtFrom: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Products', 'boughtFrom'), 
				                    validation: { required: false, maxLength: 128 } }			
			,boughtPrice: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'boughtPrice'), 
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
