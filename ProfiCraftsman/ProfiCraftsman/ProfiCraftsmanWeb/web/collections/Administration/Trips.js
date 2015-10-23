define([
	'base/base-collection',
	'models/Administration/Trip'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/Trips',
		model: Model
	});

	return collection;
});
