define([
	'base/base-collection',
	'models/Settings/Rates'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/Rates',
		model: Model
	});

	return collection;
});
