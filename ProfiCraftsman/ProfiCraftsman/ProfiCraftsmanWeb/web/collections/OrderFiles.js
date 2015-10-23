define([
	'base/base-collection',
	'models/OrderFiles'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/OrderFiles',
		model: Model
	});

	return collection;
});
