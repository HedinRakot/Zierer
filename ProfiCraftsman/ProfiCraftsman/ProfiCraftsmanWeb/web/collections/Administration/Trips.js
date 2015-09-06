define([
	'base/base-collection',
	'models/Administration/Trip'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/Trips',
		model: Model
	});

	return collection;
});
