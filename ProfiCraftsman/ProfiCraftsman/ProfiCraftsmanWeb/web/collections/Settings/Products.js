define([
	'base/base-collection',
	'models/Settings/Products'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/Products',
		model: Model
	});

	return collection;
});
