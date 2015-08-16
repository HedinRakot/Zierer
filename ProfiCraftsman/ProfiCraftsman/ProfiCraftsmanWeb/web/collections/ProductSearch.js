define([
	'base/base-collection',
	'models/ProductSearch'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/ProductSearch',
		model: Model
	});

	return collection;
});
