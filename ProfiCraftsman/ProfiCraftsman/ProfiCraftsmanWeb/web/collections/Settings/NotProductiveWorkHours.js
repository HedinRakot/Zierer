define([
	'base/base-collection',
	'models/Settings/NotProductiveWorkHours'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/NotProductiveWorkHours',
		model: Model
	});

	return collection;
});
