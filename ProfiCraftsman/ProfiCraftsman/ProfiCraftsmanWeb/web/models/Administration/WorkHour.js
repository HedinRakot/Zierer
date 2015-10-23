define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: Application.apiUrl + '/WorkHours',
		fields: {
		    id: { type: "number", editable: false }	
			,employeeName: { type: "string", 
			                        editable: false, 
				                    validation: { required: false } }			
			,employeeId: { type: "number", 
			                        editable: false, 
				                    validation: { required: false } }													
            ,date: { type: "date", 
			                        editable: true,
			                        validation: { required: true, date: true } }		
            ,duration: { type: "string", 
                                    editable: false,
                                    validation: { required: false } }
            ,amountString: { type: "string", 
                                    editable: false,
                                    validation: { required: false } }
            ,amount: { type: "number", 
                                    editable: false,
                                    validation: { required: false } }
		}
	});
	return model;
});
