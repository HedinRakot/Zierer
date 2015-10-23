define([
	'base/base-collection',
	'models/Administration/ReportMaterial'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/ReportMaterials',
		model: Model
	});

	return collection;
});
