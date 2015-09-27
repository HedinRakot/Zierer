define([
	'base/base-collection',
	'models/Administration/WorkHour'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/WorkHours',
		model: Model
	});

	return collection;
});
