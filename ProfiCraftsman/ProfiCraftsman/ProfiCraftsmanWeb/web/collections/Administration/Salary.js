define([
	'base/base-collection',
	'models/Administration/Salary'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/Salary',
		model: Model
	});

	return collection;
});
