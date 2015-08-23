define([
	'base/base-collection',
	'models/Terms/Term'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/Terms',
		model: Model
	});

	return collection;
});
