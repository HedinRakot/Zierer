define(['models/Settings/Custom.Instruments'
], function (CustomProperties) {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/Instruments',
		fields: _.extend(CustomProperties(),  {
			id: { type: "number", editable: false }
			,name: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Instruments', 'name'), 
				                    validation: { required: true, maxLength: 250 } }			
			,number: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Instruments', 'number'), 
				                    validation: { required: true, maxLength: 20 } }			
			,isForAuto: { type: "boolean", 
			                        editable: Application.canTableItemBeEdit('Instruments', 'isForAuto'), 
				                    validation: { required: false } }			
			,boughtPrice: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Instruments', 'boughtPrice'), 
				                    validation: { required: true } }			
			,comment: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Instruments', 'comment'), 
				                    validation: { required: false, maxLength: 128 } }			
			,proceedsAccountId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Instruments', 'proceedsAccountId'), 
				                    validation: { required: true } }			
		}),
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
