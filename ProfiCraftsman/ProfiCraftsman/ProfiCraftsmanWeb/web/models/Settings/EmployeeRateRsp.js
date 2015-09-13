define([
], function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/EmployeeRateRsps',
		fields:  {
			id: { type: "number", editable: false }
			,employeeId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('EmployeeRateRsp', 'employeeId'), 
				                    validation: { required: true } }			
			,jobPositionId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('EmployeeRateRsp', 'jobPositionId'), 
				                    validation: { required: true } }			
			,fromDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('EmployeeRateRsp', 'fromDate'), 
				                    validation: { required: true, date: true } }			
			,toDate: { type: "date", 
			                        editable: Application.canTableItemBeEdit('EmployeeRateRsp', 'toDate'), 
				                    validation: { required: true, date: true } }			
			,salaryType: { type: "number", 
			                        editable: Application.canTableItemBeEdit('EmployeeRateRsp', 'salaryType'), 
				                    validation: { required: true } }			
			,salary: { type: "number", 
			                        editable: Application.canTableItemBeEdit('EmployeeRateRsp', 'salary'), 
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
