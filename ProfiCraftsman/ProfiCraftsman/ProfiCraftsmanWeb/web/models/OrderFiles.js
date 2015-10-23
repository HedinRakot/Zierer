define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: Application.apiUrl + '/OrderFiles',
		fields: {
		    id: { type: "number", editable: false }
			,orderId: { type: "number", 
				                    validation: { required: true } }		
            ,fileName: {type: "string",
                                    editable: false,
                                    validation: { required: true } }
            ,filePath: {type: "string",
                                    editable: false,
                                    validation: { required: false } }
            ,comment: { type: "string", 
                                    editable: true, 
                                    validation: { required: false } }
		}
	});
	return model;
});
