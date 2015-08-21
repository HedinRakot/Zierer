define([
	'base/base-collection',
	'models/Settings/Instruments'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/Instruments',
		model: Model
	});

	return collection;
});
