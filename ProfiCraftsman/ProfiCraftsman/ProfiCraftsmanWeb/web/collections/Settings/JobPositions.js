define([
	'base/base-collection',
	'models/Settings/JobPositions'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/JobPositions',
		model: Model
	});

	return collection;
});
