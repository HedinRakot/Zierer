define([
	'base/base-collection',
	'models/Terms/TermPosition'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/TermPositions',
		model: Model
	});

	return collection;
});
