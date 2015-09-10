define(function () {
	'use strict';

	var model = Backbone.Model.extend({
	    urlRoot: 'api/TermPositionMaterials',
		fields: {
		    id: { type: "number", editable: false }
            ,termPositionId: { type: "number", 
			                        editable: Application.canTableItemBeEdit('TermPositionMaterialRsp', 'termPositionId'), 
				                    validation: { required: true } }				
			,materialId: { type: "number", 
			                        editable: true, 
				                    validation: { required: true } }
            ,materialName: { type: "string", 
			                        editable: false, 
				                    validation: { required: true } }
            ,amountType: { type: "string", 
			                        editable: false, 
				                    validation: { required: true } }
			,amount: { type: "number", 
			                        editable: Application.canTableItemBeEdit('TermPositionMaterialRsp', 'amount'), 
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
