define([
	'base/base-collection',
	'models/Administration/ReportOrders'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/ReportOrders',
		model: Model
	});

	return collection;
});
