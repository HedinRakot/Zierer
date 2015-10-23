define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: Application.apiUrl + '/InvoicePayments',
		fields: {
			id: { type: "number", editable: false }
			,invoiceId: { type: "number", 
			                        editable: true, 
			                        validation: { required: true }}
            ,amount: { type: "number", 
			                        editable: true, 
			                        validation: { required: true }}
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
