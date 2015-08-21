define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/Positions',
		fields: {
		    id: { type: "number", editable: false }
		    ,positionNumber: { type: "number", editable: false }
		    ,parentId: { type: "number", editable: false }
		    ,hasParent: { type: "boolean", editable: false }
			,orderId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Positions', 'orderId'), 
				                    validation: { required: true } }		
            ,isMaterialPosition: { type: "boolean", 
			                        editable: Application.canTableItemBeEdit('Positions', 'isMaterialPosition'), 
				                    validation: { required: true } }	
            ,isAlternative: { type: "boolean", 
			                        editable: Application.canTableItemBeEdit('Positions', 'isAlternative'), 
				                    validation: { required: false } }	
			,productId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Positions', 'productId'), 
				                    validation: { required: false } }			
			,materialId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Positions', 'materialId'), 
				                    validation: { required: false } }			
			,price: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Positions', 'price'), 
			                        validation: { required: true } }
            ,priceString: { type: "string", validation: { required: false } }
            ,paymentType: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Positions', 'paymentType'), 
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
		}
	});
	return model;
});
