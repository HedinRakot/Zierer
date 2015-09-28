define([
	'base/base-collection',
	'models/Settings/Interests'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/Interests',
		model: Model
	});

	return collection;
});
