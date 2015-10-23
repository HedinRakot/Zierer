define([
	'base/base-collection',
	'models/Administration/WorkHour'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/WorkHours',
		model: Model
	});

	return collection;
});
