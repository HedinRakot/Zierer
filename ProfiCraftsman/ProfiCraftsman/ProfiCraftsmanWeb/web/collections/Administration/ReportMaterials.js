define([
	'base/base-collection',
	'models/Administration/ReportMaterial'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/ReportMaterials',
		model: Model
	});

	return collection;
});
