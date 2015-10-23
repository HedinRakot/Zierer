define([
	'base/base-collection',
	'models/Settings/Absences'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/Absences',
		model: Model
	});

	return collection;
});
