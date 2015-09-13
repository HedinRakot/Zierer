define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/ProfitReports',
		fields: {
				
			additionalCostsSum: { type: "string", 
			                        editable: false, 
			                        validation: { required: false } }	
		}
	});
	return model;
});
