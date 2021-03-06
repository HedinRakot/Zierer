define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: Application.apiUrl + '/Terms',
		fields: {
		    id: { type: "number", editable: false }
            ,orderId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Terms', 'orderId'), 
				                    validation: { required: false } }			
			,employees: { type: "string", 
			                        editable: false, 
				                    validation: { required: false } }			
			,autoId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Terms', 'autoId'), 
				                    validation: { required: false } }								
			,comment: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Terms', 'comment'), 
				                    validation: { required: false, maxLength: 128 } }						
            ,date: { type: "date", 
			                        editable: true,
			                        validation: { required: true, date: true } }		
            ,duration: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Terms', 'duration'), 
				                    validation: { required: true } }		
            ,status: { type: "string", 
                                    editable: false,
                                    validation: { required: false } }
            ,errorStatus: { type: "string", 
                                    editable: false,
                                    validation: { required: false } }
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
