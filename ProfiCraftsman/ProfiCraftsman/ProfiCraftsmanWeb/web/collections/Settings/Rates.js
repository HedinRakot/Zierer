define([
	'base/base-collection',
	'models/Settings/Rates'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/Rates',
		model: Model
	});

	return collection;
});
