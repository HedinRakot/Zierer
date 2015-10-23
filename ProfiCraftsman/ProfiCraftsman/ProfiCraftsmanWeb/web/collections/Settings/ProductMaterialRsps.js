define([
	'base/base-collection',
	'models/Settings/ProductMaterialRsp'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/ProductMaterialRsps',
		model: Model
	});

	return collection;
});
