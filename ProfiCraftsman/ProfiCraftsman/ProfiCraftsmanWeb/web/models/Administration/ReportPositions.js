define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/ReportPositions',
		fields: {
		    id: { type: "number", editable: false }
		    ,positionNumber: { type: "string", editable: false }
			,orderId: { type: "number", 
			                        editable: false, 
				                    validation: { required: true } }					
			,price: { type: "number", 
			                        editable: false, 
			                        validation: { required: true } }
            ,priceString: { type: "string", validation: { required: false } }
            ,paymentType: { type: "number", 
			                        editable: false, 
				                    validation: { required: true } }
            ,paymentTypeString: { type: "string", validation: { required: false } }
            ,amount: { type: "number", validation: { required: true } }
            ,amountString: { type: "string", validation: { required: false } }
            ,amountType: { type: "string", 
                                    editable: false,
                                    validation: { required: true } }
            ,totalPrice: { type: "string", 
                                    editable: false,
                                    validation: { required: true } }
            ,description: {type: "string",
                                    validation: { required: true } }
            ,number: { type: "string", 
                                    editable: false, 
                                    validation: { required: true } }
            ,createDate: { type: "date", validation: { required: false } }
		}
	});
	return model;
});
