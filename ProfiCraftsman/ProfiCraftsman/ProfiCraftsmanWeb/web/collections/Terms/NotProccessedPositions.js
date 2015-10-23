define([
	'base/base-collection',
	'models/Terms/NotProccessedPosition'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/PositionSearch',
		model: Model
	});

	return collection;
});
