define([
	'base/base-collection',
	'models/Settings/SocialTaxes'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/SocialTaxes',
		model: Model
	});

	return collection;
});
