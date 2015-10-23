define([
	'base/base-collection',
	'models/ProductSearch'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/ProductSearch',
		model: Model
	});

	return collection;
});
