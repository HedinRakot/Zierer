define([
	'base/base-collection',
	'models/Settings/JobPositions'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/JobPositions',
		model: Model
	});

	return collection;
});
