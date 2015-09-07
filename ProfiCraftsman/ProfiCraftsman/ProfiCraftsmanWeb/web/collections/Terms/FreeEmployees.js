define([
	'base/base-collection',
	'models/Terms/FreeEmployee'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/FreeEmployees',
		model: Model
	});

	return collection;
});
