define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/ProfitReports',
	    fields: {
				
			additionalCostsSum: { type: "string", 
			                        editable: false, 
			                        validation: { required: false } }
            ,foreignProductsSum: { type: "string", 
			                        editable: false, 
			                        validation: { required: false } }	
            ,materialsSum: { type: "string", 
			                        editable: false, 
			                        validation: { required: false } }	
            ,totalOrdersSum: { type: "string", 
			                        editable: false, 
			                        validation: { required: false } }	
            ,totalInvoicesSum: { type: "string", 
			                        editable: false, 
			                        validation: { required: false } }	
            ,totalPayedSum: { type: "string", 
			                        editable: false, 
			                        validation: { required: false } }	
            ,totalProfitSum: { type: "string", 
			                        editable: false, 
			                        validation: { required: false } }	
            ,salary: { type: "string", 
			                        editable: false, 
			                        validation: { required: false } }	
            ,ownProductsSum: { type: "string", 
			                        editable: false, 
			                        validation: { required: false } }	
	    }
	});
	return model;
});
