define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/Trips',
		fields: {
		    id: { type: "number", editable: false }	
			,employees: { type: "string", 
			                        editable: false, 
				                    validation: { required: false } }			
			,autoId: { type: "number", 
			                        editable: false, 
				                    validation: { required: false } }													
            ,date: { type: "date", 
			                        editable: true,
			                        validation: { required: true, date: true } }		
            ,duration: { type: "date", 
                                    editable: false,
                                    validation: { required: false } }
		}
	});
	return model;
});
