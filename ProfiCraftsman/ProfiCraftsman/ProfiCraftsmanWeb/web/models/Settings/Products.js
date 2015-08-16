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
				                    validation: { required: true } }			
			,length: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'length'), 
				                    validation: { required: true } }			
			,width: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'width'), 
				                    validation: { required: true } }			
			,height: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'height'), 
				                    validation: { required: true } }			
			,color: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Products', 'color'), 
				                    validation: { required: true, maxLength: 50 } }			
			,price: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'price'), 
				                    validation: { required: true } }			
			,proceedsAccount: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'proceedsAccount'), 
				                    validation: { required: true } }			
			,isVirtual: { type: "boolean", 
			                        editable: Application.canTableItemBeEdit('Products', 'isVirtual'), 
				                    validation: { required: false } }			
			,manufactureDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('Products', 'manufactureDate'), 
				                    validation: { required: false, date: true } }			
			,boughtFrom: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Products', 'boughtFrom'), 
				                    validation: { required: false, maxLength: 128 } }			
			,boughtPrice: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'boughtPrice'), 
				                    validation: { required: false } }			
			,comment: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Products', 'comment'), 
				                    validation: { required: false, maxLength: 128 } }			
			,sellPrice: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'sellPrice'), 
				                    validation: { required: true } }			
			,isSold: { type: "boolean", 
			                        editable: Application.canTableItemBeEdit('Products', 'isSold'), 
				                    validation: { required: false } }			
			,minPrice: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'minPrice'), 
				                    validation: { required: true } }			
			,newPrice: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Products', 'newPrice'), 
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
