define([
], function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: Application.apiUrl + '/ProceedsAccounts',
		fields:  {
			id: { type: "number", editable: false }
			,value: { type: "number", 
			                        editable: Application.canTableItemBeEdit('ProceedsAccounts', 'value'), 
				                    validation: { required: true } }			
		},
		defaults: function () {
			var dnf = new Date();
			var dnt = new Date(2070,11,31);
			return {
				fromDate: dnf, 
				toDate: dnt
			};
		}
	});
	return model;
});
