define([
], function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/AdditionalCosts',
		fields:  {
			id: { type: "number", editable: false }
			,description: { type: "string", 
			                        editable: Application.canTableItemBeEdit('AdditionalCosts', 'description'), 
				                    validation: { required: false, maxLength: 128 } }			
			,price: { type: "number", 
			                        editable: Application.canTableItemBeEdit('AdditionalCosts', 'price'), 
				                    validation: { required: true } }			
			,automatic: { type: "boolean", 
			                        editable: Application.canTableItemBeEdit('AdditionalCosts', 'automatic'), 
				                    validation: { required: false } }			
			,fromDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('AdditionalCosts', 'fromDate'), 
				                    validation: { required: true, date: true } }			
			,toDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('AdditionalCosts', 'toDate'), 
				                    validation: { required: false, date: true } }			
			,additionalCostTypeId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('AdditionalCosts', 'additionalCostTypeId'), 
				                    validation: { required: true } }			
			,proceedsAccountId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('AdditionalCosts', 'proceedsAccountId'), 
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
