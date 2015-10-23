define([
	'base/base-collection',
	'models/Settings/OwnProducts'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/OwnProducts',
		model: Model
	});

	return collection;
});
