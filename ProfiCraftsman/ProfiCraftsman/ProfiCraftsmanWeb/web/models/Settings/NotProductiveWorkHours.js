define([
], function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/NotProductiveWorkHours',
		fields:  {
			id: { type: "number", editable: false }
			,employeeId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('NotProductiveWorkHours', 'employeeId'), 
				                    validation: { required: true } }			
			,description: { type: "string", 
			                        editable: Application.canTableItemBeEdit('NotProductiveWorkHours', 'description'), 
				                    validation: { required: true, maxLength: 256 } }			
			,fromDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('NotProductiveWorkHours', 'fromDate'), 
				                    validation: { required: true, date: true } }			
			,toDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('NotProductiveWorkHours', 'toDate'), 
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
