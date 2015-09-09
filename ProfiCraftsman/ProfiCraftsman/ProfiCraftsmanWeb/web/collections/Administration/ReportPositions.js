define([
	'base/base-collection',
	'models/Administration/ReportPositions'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/ReportPositions',
		model: Model
	});

	return collection;
});
