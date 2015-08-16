define([
	'base/base-collection',
	'models/Settings/ProductTypes'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/ProductTypes',
		model: Model
	});

	return collection;
});
