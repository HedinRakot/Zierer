define([
], function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/Interests',
		fields:  {
			id: { type: "number", editable: false }
			,description: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Interests', 'description'), 
				                    validation: { required: true, maxLength: 256 } }			
			,price: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Interests', 'price'), 
				                    validation: { required: true } }			
			,proceedsAccountId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Interests', 'proceedsAccountId'), 
				                    validation: { required: true } }			
			,fromDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('Interests', 'fromDate'), 
				                    validation: { required: true, date: true } }			
			,toDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('Interests', 'toDate'), 
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
