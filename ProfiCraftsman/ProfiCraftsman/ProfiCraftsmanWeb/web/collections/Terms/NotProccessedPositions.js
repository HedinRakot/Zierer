define([
	'base/base-collection',
	'models/Terms/NotProccessedPosition'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/PositionSearch',
		model: Model
	});

	return collection;
});
