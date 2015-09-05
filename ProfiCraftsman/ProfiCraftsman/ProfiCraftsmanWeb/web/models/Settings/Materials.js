define([
], function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/Materials',
		fields:  {
			id: { type: "number", editable: false }
			,name: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Materials', 'name'), 
				                    validation: { required: true, maxLength: 250 } }			
			,number: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Materials', 'number'), 
				                    validation: { required: true, maxLength: 20 } }			
			,length: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Materials', 'length'), 
				                    validation: { required: false } }			
			,width: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Materials', 'width'), 
				                    validation: { required: false } }			
			,height: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Materials', 'height'), 
				                    validation: { required: false } }			
			,color: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Materials', 'color'), 
				                    validation: { required: false, maxLength: 50 } }			
			,price: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Materials', 'price'), 
				                    validation: { required: true } }			
			,proceedsAccount: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Materials', 'proceedsAccount'), 
				                    validation: { required: true } }			
			,isVirtual: { type: "boolean", 
			                        editable: Application.canTableItemBeEdit('Materials', 'isVirtual'), 
				                    validation: { required: false } }			
			,boughtFrom: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Materials', 'boughtFrom'), 
				                    validation: { required: false, maxLength: 128 } }			
			,boughtPrice: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Materials', 'boughtPrice'), 
				                    validation: { required: true } }			
			,comment: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Materials', 'comment'), 
				                    validation: { required: false, maxLength: 128 } }			
			,materialAmountType: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Materials', 'materialAmountType'), 
				                    validation: { required: true } }			
			,isForAuto: { type: "boolean", 
			                        editable: Application.canTableItemBeEdit('Materials', 'isForAuto'), 
				                    validation: { required: false } }			
			,mustCount: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Materials', 'mustCount'), 
				                    validation: { required: false } }			
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
