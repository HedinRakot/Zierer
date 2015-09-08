define([
	'base/base-collection',
	'models/Settings/CustomProducts'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/CustomProducts',
		model: Model
	});

	return collection;
});
