define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: Application.apiUrl + '/ReportMaterials',
		fields: {
		    id: { type: "number", editable: false }	
			,materialName: { type: "string", 
			                        editable: false, 
				                    validation: { required: false } }
            ,materialNumber: { type: "string", 
			                        editable: false, 
				                    validation: { required: false } }
            ,price: { type: "string", 
			                        editable: false, 
				                    validation: { required: false } }
			,amount: { type: "number", 
			                        editable: false, 
				                    validation: { required: false } }													
		}
	});
	return model;
});
