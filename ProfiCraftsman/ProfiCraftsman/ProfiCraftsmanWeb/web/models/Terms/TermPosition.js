define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/TermPositions',
		fields: {
		    id: { type: "number", editable: false }
		    ,positionNumber: { type: "string", editable: false }
			,termId: { type: "number", 

				                    validation: { required: true } }		
            ,isAlternative: { type: "boolean", 
			                        editable: false, 
				                    validation: { required: false } }	
			,positionId: { type: "number", 
			                        editable: false, 
				                    validation: { required: false } }				
			,price: { type: "string", 
			                        editable: false, 
			                        validation: { required: true } }
            ,paymentType: { type: "number", 
			                        editable: false, 
				                    validation: { required: true } }
            ,amount: { type: "number", editable: true, validation: { required: true } }
            ,proccessedAmount: { type: "number", editable: true, validation: { required: false } }
            ,amountType: { type: "string", 
                                    editable: false,
                                    validation: { required: true } }
            ,totalPrice: { type: "string", 
                                    editable: false,
                                    validation: { required: true } }
            ,description: {type: "string",
                                    editable: false,
                                    validation: { required: true } }
            ,comment: {type: "string",
                                    editable: true,
                                    validation: { required: false } }
            ,number: { type: "string", 
                                    editable: false, 
                                    validation: { required: true } }
		}
	});
	return model;
});
