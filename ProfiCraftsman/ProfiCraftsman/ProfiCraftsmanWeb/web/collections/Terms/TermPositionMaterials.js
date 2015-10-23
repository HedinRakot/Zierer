define([
	'base/base-collection',
	'models/Terms/TermPositionMaterial'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/TermPositionMaterials',
		model: Model
	});

	return collection;
});
