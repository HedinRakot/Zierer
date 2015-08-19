define([
	'base/base-collection',
	'models/Settings/Employees'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/Employees',
		model: Model
	});

	return collection;
});
