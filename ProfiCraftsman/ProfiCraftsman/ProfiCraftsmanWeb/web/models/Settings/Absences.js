define([
], function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/Absences',
		fields:  {
			id: { type: "number", editable: false }
			,employeeId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Absences', 'employeeId'), 
				                    validation: { required: true } }			
			,description: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Absences', 'description'), 
				                    validation: { required: true, maxLength: 256 } }			
			,fromDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('Absences', 'fromDate'), 
				                    validation: { required: true, date: true } }			
			,toDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('Absences', 'toDate'), 
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
