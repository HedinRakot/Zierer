define([
	'base/base-collection',
	'models/Settings/Employees'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/Employees',
		model: Model
	});

	return collection;
});
