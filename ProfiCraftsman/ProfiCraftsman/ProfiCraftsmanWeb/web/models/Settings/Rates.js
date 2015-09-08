define([
], function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/Rates',
		fields:  {
			id: { type: "number", editable: false }
			,jobPositionId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Rates', 'jobPositionId'), 
				                    validation: { required: true } }			
			,price: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Rates', 'price'), 
				                    validation: { required: true } }			
			,fromDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('Rates', 'fromDate'), 
				                    validation: { required: true, date: true } }			
			,toDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('Rates', 'toDate'), 
				                    validation: { required: true, date: true } }			
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
