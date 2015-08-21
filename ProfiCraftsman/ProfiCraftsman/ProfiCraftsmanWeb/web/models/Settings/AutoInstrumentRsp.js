define(function () {
    'use strict';

    var model = Backbone.Model.extend({
        urlRoot: 'api/AutoInstrumentRsps',
        fields: {
            id: { type: "number", editable: false }
			, autoId: {
			    type: "number",
			    editable: Application.canTableItemBeEdit('AutoInstrumentRsp', 'autoId'),
			    validation: { required: true }
			}
			, instrumentId: {
			    type: "number",
			    editable: Application.canTableItemBeEdit('AutoInstrumentRsp', 'instrumentId'),
			    validation: { required: true }
			}
			, amount: {
			    type: "number",
			    editable: Application.canTableItemBeEdit('AutoInstrumentRsp', 'amount'),
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
