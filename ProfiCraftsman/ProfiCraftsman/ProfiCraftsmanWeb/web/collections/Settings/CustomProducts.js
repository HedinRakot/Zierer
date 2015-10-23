define([
	'base/base-collection',
	'models/Settings/CustomProducts'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/CustomProducts',
		model: Model
	});

	return collection;
});
