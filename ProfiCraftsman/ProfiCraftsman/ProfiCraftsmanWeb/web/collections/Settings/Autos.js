define([
	'base/base-collection',
	'models/Settings/Autos'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/Autos',
		model: Model
	});

	return collection;
});
