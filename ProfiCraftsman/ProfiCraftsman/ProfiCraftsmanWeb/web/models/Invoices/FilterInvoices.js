define(function () {
    'use strict';

    var model = Backbone.Model.extend({
        fields: {
            name: { type: "string", editable: true },
            fromDate: { type: "date", editable: true, validation: { date: true } },
            toDate: { type: "date", editable: true, validation: { date: true } },
            isPayed: { type: "boolean", editable: true },
            autoBill: { type: "boolean", editable: true },
        }
    });
    return model;
});
