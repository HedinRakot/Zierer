define([
	'base/base-collection',
	'models/Settings/SocialTaxes'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/SocialTaxes',
		model: Model
	});

	return collection;
});
