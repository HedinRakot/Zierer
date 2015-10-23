define([
	'base/base-collection',
	'models/Settings/Instruments'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/Instruments',
		model: Model
	});

	return collection;
});
