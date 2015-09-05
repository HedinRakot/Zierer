define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/TermEmployees',
		fields: {
		    id: { type: "number", editable: false }
			,termId: { type: "number", 

				                    validation: { required: true } }		
			,employeeId: { type: "number", 
			                        editable: true, 
				                    validation: { required: true } }				
		}
	});
	return model;
});
