define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: Application.apiUrl + '/FreeEmployees',
		fields: {
		    id: { type: "number", editable: false }
			, number: {
			    type: "number",
			    editable: false,
			    validation: { required: true }
			}
			, jobPositionId: {
			    type: "number",
			    editable: false,
			    validation: { required: true }
			}
			, autoId: {
			    type: "number",
			    editable: false,
			    validation: { required: false }
			}
			, name: {
			    type: "string",
			    editable: false,
			    validation: { required: true, maxLength: 128 }
			}
			, firstName: {
			    type: "string",
			    editable: false,
			    validation: { required: false, maxLength: 128 }
			}
			, street: {
			    type: "string",
			    editable: false,
			    validation: { required: false, maxLength: 128 }
			}
			, zip: {
			    type: "string",
			    editable: false,
			    validation: { required: false, maxLength: 10 }
			}
			, city: {
			    type: "string",
			    editable: false,
			    validation: { required: false, maxLength: 128 }
			}
			, country: {
			    type: "string",
			    editable: false,
			    validation: { required: false, maxLength: 50 }
			}
			, phone: {
			    type: "string",
			    editable: false,
			    validation: { required: false, maxLength: 20 }
			}
			, mobile: {
			    type: "string",
			    editable: false,
			    validation: { required: false, maxLength: 20 }
			}
			, fax: {
			    type: "string",
			    editable: false,
			    validation: { required: false, maxLength: 20 }
			}
			, email: {
			    type: "string",
			    editable: false,
			    validation: { required: false, maxLength: 50 }
			}
			, comment: {
			    type: "string",
			    editable: false,
			    validation: { required: false, maxLength: 128 }
			}
			, color: {
			    type: "string",
			    editable: false,
			    validation: { required: true, maxLength: 20 }
			}
		}
	});
	return model;
});
