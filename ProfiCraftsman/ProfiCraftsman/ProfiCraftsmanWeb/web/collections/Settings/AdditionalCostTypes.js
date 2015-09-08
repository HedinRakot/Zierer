define([
	'base/base-collection',
	'models/Settings/AdditionalCostTypes'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/AdditionalCostTypes',
		model: Model
	});

	return collection;
});
