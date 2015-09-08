define([
	'base/base-collection',
	'models/Settings/EmployeeRateRsp'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/EmployeeRateRsps',
		model: Model
	});

	return collection;
});
