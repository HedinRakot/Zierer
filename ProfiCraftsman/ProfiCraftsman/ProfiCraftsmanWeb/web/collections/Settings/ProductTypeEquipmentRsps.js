define([
	'base/base-collection',
	'models/Settings/ProductTypeEquipmentRsp'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/ProductTypeEquipmentRsps',
		model: Model
	});

	return collection;
});
