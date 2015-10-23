define([
	'base/base-collection',
	'models/Terms/TermPosition'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/TermPositions',
		model: Model
	});

	return collection;
});
