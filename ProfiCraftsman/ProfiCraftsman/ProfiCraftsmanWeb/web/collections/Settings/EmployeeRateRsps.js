define([
	'base/base-collection',
	'models/Settings/EmployeeRateRsp'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/EmployeeRateRsps',
		model: Model
	});

	return collection;
});
