define([
	'base/base-collection',
	'models/Administration/ReportPositions'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/ReportPositions',
		model: Model
	});

	return collection;
});
