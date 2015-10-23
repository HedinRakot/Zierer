define([
	'base/base-collection',
	'models/Settings/ProceedsAccounts'
], function (BaseCollection, Model) {
	'use strict';

	var collection = BaseCollection.extend({
	    url: Application.apiUrl + '/ProceedsAccounts',
		model: Model
	});

	return collection;
});
