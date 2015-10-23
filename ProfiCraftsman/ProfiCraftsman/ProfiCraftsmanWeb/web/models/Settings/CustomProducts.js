define([
], function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: Application.apiUrl + '/CustomProducts',
		fields:  {
			id: { type: "number", editable: false }
			,name: { type: "string", 
			                        editable: Application.canTableItemBeEdit('CustomProducts', 'name'), 
				                    validation: { required: true, maxLength: 256 } }			
			,price: { type: "number", 
			                        editable: Application.canTableItemBeEdit('CustomProducts', 'price'), 
				                    validation: { required: true } }			
			,auto: { type: "boolean", 
			                        editable: Application.canTableItemBeEdit('CustomProducts', 'auto'), 
				                    validation: { required: false } }			
			,proceedsAccountId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('CustomProducts', 'proceedsAccountId'), 
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
