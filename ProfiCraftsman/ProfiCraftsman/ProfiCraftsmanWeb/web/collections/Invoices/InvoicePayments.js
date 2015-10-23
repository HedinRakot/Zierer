define([
	'base/base-collection',
	'models/Invoices/InvoicePayments'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/InvoicePayments',
		model: Model
	});

	return collection;
});
