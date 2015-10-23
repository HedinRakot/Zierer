define([
	'base/base-collection',
	'models/Settings/AdditionalCostTypes'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/AdditionalCostTypes',
		model: Model
	});

	return collection;
});
