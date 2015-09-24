define([
	'base/base-collection',
	'models/Settings/NotProductiveWorkHours'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/NotProductiveWorkHours',
		model: Model
	});

	return collection;
});
