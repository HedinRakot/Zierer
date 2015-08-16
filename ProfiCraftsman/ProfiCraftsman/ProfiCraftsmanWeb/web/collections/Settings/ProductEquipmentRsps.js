define([
	'base/base-collection',
	'models/Settings/ProductEquipmentRsp'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/ProductEquipmentRsps',
		model: Model
	});

	return collection;
});
