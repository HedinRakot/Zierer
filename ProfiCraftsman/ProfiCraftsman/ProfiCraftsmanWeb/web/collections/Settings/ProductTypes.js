define([
	'base/base-collection',
	'models/Settings/ProductTypes'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/ProductTypes',
		model: Model
	});

	return collection;
});
