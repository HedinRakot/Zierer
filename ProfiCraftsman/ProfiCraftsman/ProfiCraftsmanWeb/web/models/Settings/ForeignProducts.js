define([
], function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: Application.apiUrl + '/ForeignProducts',
		fields:  {
			id: { type: "number", editable: false }
			,description: { type: "string", 
			                        editable: Application.canTableItemBeEdit('ForeignProducts', 'description'), 
				                    validation: { required: true, maxLength: 256 } }			
			,price: { type: "number", 
			                        editable: Application.canTableItemBeEdit('ForeignProducts', 'price'), 
				                    validation: { required: true } }			
			,fromDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('ForeignProducts', 'fromDate'), 
				                    validation: { required: true, date: true } }			
			,toDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('ForeignProducts', 'toDate'), 
				                    validation: { required: false, date: true } }			
			,proceedsAccountId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('ForeignProducts', 'proceedsAccountId'), 
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
