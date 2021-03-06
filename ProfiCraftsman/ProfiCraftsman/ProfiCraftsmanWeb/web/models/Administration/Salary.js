define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: Application.apiUrl + '/Salary',
		fields: {
		    id: { type: "number", editable: false }	
			,employeeName: { type: "string", 
			                        editable: false, 
				                    validation: { required: false } }			
			,amountString: { type: "string", 
			                        editable: false, 
				                    validation: { required: false } }													
		}
	});
	return model;
});
