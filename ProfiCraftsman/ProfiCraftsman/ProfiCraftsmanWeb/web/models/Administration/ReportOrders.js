define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/ReportOrders',
		fields: {
			id: { type: "number", editable: false }
			,customerName: { type: "string", 
			                        editable: false, 
				                    validation: { required: true } }			
			,communicationPartnerTitle: { type: "string", 
			                        editable: false, 
				                    validation: { required: false } }					
			,street: { type: "string", 
			                        editable: false, 
				                    validation: { required: true } }			
			,zip: { type: "string", 
			                        editable: false, 
				                    validation: { required: true } }			
			,city: { type: "string", 
			                        editable: false, 
				                    validation: { required: true } }							
			,orderNumber: { type: "string", 
			                        editable: false, 
				                    validation: { required: false} }
            ,createDate: { type: "date", 
			                        editable: false,
			                        validation: { required: false } }			
            ,status: { type: "number", 
                                    editable: false,
                                    validation: { required: false } }
            ,totalPrice: { type: "string", 
			                        editable: false, 
				                    validation: { required: false} }
            ,totalInvoicesSum: { type: "string", 
			                        editable: false, 
				                    validation: { required: false} }
		},
		defaults: function () {
			var dnf = new Date();
			var dnt = new Date(2070,11,31);
			return {
				fromDate: dnf, 
				toDate: dnt
			};
		}
	});
	return model;
});
