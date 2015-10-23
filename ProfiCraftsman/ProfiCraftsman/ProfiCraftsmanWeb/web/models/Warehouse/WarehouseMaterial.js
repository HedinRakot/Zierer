define(function () {
    'use strict';

    var model = Backbone.Model.extend({
        urlRoot: Application.apiUrl + '/WarehouseMaterials',
        fields: {
            id: { type: "number", editable: false }
			, materialId: {
			    type: "number",
			    editable: Application.canTableItemBeEdit('WarehouseMaterial', 'materialId'),
			    validation: { required: true }
			}, materialName: {
			    type: "string",
			    editable: false,
			    validation: { required: false }
			}, materialNumber: {
			    type: "string",
			    editable: false,
			    validation: { required: false }
			}
			,isAmount: {
			    type: "number",
			    editable: Application.canTableItemBeEdit('WarehouseMaterial', 'isAmount'),
			    validation: { required: true }
			},
			mustAmount: {
			    type: "number",
			    editable: Application.canTableItemBeEdit('WarehouseMaterial', 'mustAmount'),
			    validation: { required: true }
			}
        },
        defaults: function () {
            var dnf = new Date();
            var dnt = new Date(2070, 11, 31);
            return {
                fromDate: dnf,
                toDate: dnt
            };
        }
    });
    return model;
});
