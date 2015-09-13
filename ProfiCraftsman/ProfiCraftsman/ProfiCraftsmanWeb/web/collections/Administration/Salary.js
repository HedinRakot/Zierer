define([
	'base/base-collection',
	'models/Administration/Salary'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/Salary',
		model: Model
	});

	return collection;
});
