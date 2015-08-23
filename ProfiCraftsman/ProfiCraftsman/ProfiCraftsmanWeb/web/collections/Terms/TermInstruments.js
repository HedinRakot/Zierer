define([
	'base/base-collection',
	'models/Terms/TermInstrument'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/TermInstruments',
		model: Model
	});

	return collection;
});
