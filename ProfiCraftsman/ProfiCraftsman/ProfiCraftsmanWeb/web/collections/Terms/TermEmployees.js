define([
	'base/base-collection',
	'models/Terms/TermEmployee'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/TermEmployees',
		model: Model
	});

	return collection;
});
