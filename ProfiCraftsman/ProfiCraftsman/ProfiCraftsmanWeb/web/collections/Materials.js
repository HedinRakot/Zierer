define([
	'base/base-collection',
	'models/Material'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/OrderProductMaterials',
		model: Model
	});

	return collection;
});