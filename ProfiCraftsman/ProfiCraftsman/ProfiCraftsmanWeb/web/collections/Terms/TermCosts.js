define([
	'base/base-collection',
	'models/Terms/TermCosts'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/TermCosts',
		model: Model
	});

	return collection;
});
