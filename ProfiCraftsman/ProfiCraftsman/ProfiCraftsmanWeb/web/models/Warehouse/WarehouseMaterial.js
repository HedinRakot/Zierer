define(function () {
    'use strict';

    var model = Backbone.Model.extend({
        urlRoot: 'api/WarehouseMaterials',
        fields: {
            id: { type: "number", editable: false }
			, materialId: {
			    type: "number",
			    editable: Application.canTableItemBeEdit('WarehouseMaterial', 'materialId'),
			    validation: { required: true }
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
