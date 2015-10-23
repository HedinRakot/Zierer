define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: Application.apiUrl + '/TermCosts',
		fields: {
		    id: { type: "number", editable: false }
			,termId: { type: "number", 
				                    validation: { required: true } }		
			,price: { type: "number", 
			                        editable: true, 
				                    validation: { required: true } }
            ,costs: { type: "number", 
			                        editable: true, 
				                    validation: { required: true } }
            ,proceedsAccountId: { type: "number", 
			                        editable: true, 
				                    validation: { required: true } }
            ,name: { type: "string", 
                                    editable: true, 
                                    validation: { required: true } }
		}
	});
	return model;
});
