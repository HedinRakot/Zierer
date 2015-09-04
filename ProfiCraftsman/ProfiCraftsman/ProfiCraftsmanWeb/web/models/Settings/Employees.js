define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/Employees',
		fields: {
			id: { type: "number", editable: false }
			,number: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Employees', 'number'), 
				                    validation: { required: true } }			
			,jobPositionId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Employees', 'jobPositionId'), 
				                    validation: { required: true } }			
			,autoId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('Employees', 'autoId'), 
				                    validation: { required: false } }			
			,name: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Employees', 'name'), 
				                    validation: { required: true, maxLength: 128 } }			
			,firstName: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Employees', 'firstName'), 
				                    validation: { required: false, maxLength: 128 } }			
			,street: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Employees', 'street'), 
				                    validation: { required: false, maxLength: 128 } }			
			,zip: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Employees', 'zip'), 
				                    validation: { required: false, maxLength: 10 } }			
			,city: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Employees', 'city'), 
				                    validation: { required: false, maxLength: 128 } }			
			,country: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Employees', 'country'), 
				                    validation: { required: false, maxLength: 50 } }			
			,phone: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Employees', 'phone'), 
				                    validation: { required: false, maxLength: 20 } }			
			,mobile: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Employees', 'mobile'), 
				                    validation: { required: false, maxLength: 20 } }			
			,fax: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Employees', 'fax'), 
				                    validation: { required: false, maxLength: 20 } }			
			,email: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Employees', 'email'), 
				                    validation: { required: false, maxLength: 50 } }			
			,comment: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Employees', 'comment'), 
				                    validation: { required: false, maxLength: 128 } }			
			,color: { type: "string", 
			                        editable: Application.canTableItemBeEdit('Employees', 'color'), 
				                    validation: { required: true, maxLength: 20 } }			
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
