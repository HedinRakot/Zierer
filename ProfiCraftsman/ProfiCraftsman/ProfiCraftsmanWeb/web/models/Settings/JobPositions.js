define([
], function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: Application.apiUrl + '/JobPositions',
		fields:  {
			id: { type: "number", editable: false }
			,name: { type: "string", 
			                        editable: Application.canTableItemBeEdit('JobPositions', 'name'), 
				                    validation: { required: true, maxLength: 128 } }			
			,comment: { type: "string", 
			                        editable: Application.canTableItemBeEdit('JobPositions', 'comment'), 
				                    validation: { required: false, maxLength: 128 } }			
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
