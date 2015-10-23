define([
	'base/base-collection',
	'models/Terms/TermEmployee'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/TermEmployees',
		model: Model
	});

	return collection;
});
