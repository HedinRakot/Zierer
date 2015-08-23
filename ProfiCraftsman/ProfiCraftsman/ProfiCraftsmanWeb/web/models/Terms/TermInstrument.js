define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/TermInstruments',
		fields: {
		    id: { type: "number", editable: false }
		    ,positionNumber: { type: "string", editable: false }
			,termId: { type: "number", 

				                    validation: { required: true } }		
			,instrumentId: { type: "number", 
			                        editable: true, 
				                    validation: { required: false } }				
            ,description: {type: "string",
                                    editable: false,
                                    validation: { required: true } }
            ,number: { type: "string", 
                                    editable: false, 
                                    validation: { required: true } }
		}
	});
	return model;
});
