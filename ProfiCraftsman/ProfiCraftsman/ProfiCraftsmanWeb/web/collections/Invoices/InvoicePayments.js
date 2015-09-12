define([
	'base/base-collection',
	'models/Invoices/InvoicePayments'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/InvoicePayments',
		model: Model
	});

	return collection;
});
