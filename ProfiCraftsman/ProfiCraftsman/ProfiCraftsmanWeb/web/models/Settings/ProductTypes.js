define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/ProductTypes',
		fields: {
			id: { type: "number", editable: false }
			,name: { type: "string", 
			                        editable: Application.canTableItemBeEdit('ProductTypes', 'name'), 
				                    validation: { required: true, maxLength: 128 } }			
			,comment: { type: "string", 
			                        editable: Application.canTableItemBeEdit('ProductTypes', 'comment'), 
				                    validation: { required: false, maxLength: 256 } }			
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
