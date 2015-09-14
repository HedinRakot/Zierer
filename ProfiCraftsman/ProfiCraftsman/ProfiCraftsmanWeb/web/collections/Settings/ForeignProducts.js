define([
	'base/base-collection',
	'models/Settings/ForeignProducts'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/ForeignProducts',
		model: Model
	});

	return collection;
});
