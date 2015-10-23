define([
], function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: Application.apiUrl + '/SocialTaxes',
		fields:  {
			id: { type: "number", editable: false }
			,employeeId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('SocialTaxes', 'employeeId'), 
				                    validation: { required: true } }			
			,description: { type: "string", 
			                        editable: Application.canTableItemBeEdit('SocialTaxes', 'description'), 
				                    validation: { required: false, maxLength: 256 } }			
			,price: { type: "number", 
			                        editable: Application.canTableItemBeEdit('SocialTaxes', 'price'), 
				                    validation: { required: true } }			
			,proceedsAccountId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('SocialTaxes', 'proceedsAccountId'), 
				                    validation: { required: true } }			
			,fromDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('SocialTaxes', 'fromDate'), 
				                    validation: { required: true, date: true } }			
			,toDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('SocialTaxes', 'toDate'), 
				                    validation: { required: false, date: true } }			
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
