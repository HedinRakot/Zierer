define([
], function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: Application.apiUrl + '/Autos',
		fields:  {
			id: { type: "number", editable: false }
			,number: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Autos', 'number'), 
				                    validation: { required: true, maxLength: 20 } }			
			,comment: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Autos', 'comment'), 
				                    validation: { required: false, maxLength: 128 } }			
			,lastInspectionDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('Autos', 'lastInspectionDate'), 
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
