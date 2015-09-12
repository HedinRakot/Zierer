define([
	'base/base-collection',
	'models/Settings/ProceedsAccounts'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: 'api/ProceedsAccounts',
		model: Model
	});

	return collection;
});
