define([
	'base/base-collection',
	'models/Settings/Materials'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/Materials',
		model: Model
	});

	return collection;
});
