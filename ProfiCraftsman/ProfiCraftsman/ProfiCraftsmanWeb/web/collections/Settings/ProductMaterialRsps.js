define([
	'base/base-collection',
	'models/Settings/ProductMaterialRsp'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/ProductMaterialRsps',
		model: Model
	});

	return collection;
});
