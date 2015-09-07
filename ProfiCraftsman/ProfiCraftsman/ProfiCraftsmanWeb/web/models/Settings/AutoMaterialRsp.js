define(function () {
    'use strict';

    var model = Backbone.Model.extend({
        urlRoot: 'api/AutoMaterialRsps',
        fields: {
            id: { type: "number", editable: false }
			, autoId: {
			    type: "number",
			    editable: Application.canTableItemBeEdit('AutoMaterialRsp', 'autoId'),
			    validation: { required: true }
			}
			, materialId: {
			    type: "number",
			    editable: Application.canTableItemBeEdit('AutoMaterialRsp', 'materialId'),
			    validation: { required: true }
			}
            , materialName: {
                type: "string",
                editable: false,
                validation: { required: false }
            }
			, amount: {
			    type: "number",
			    editable: Application.canTableItemBeEdit('AutoMaterialRsp', 'amount'),
			    validation: { required: true }
			},
			restAmount: {
			    type: "number", editable: true, validation: { required: false }
			},
			mustCount: {
			    type: "number",
			    editable: false,
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
