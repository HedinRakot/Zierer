define(function () {
    'use strict';

    var model = Backbone.Model.extend({
        fields: {
            name: { type: "number", editable: true },
            fromDate: { type: "date", editable: true, validation: { date: true } },
            toDate: { type: "date", editable: true, validation: { date: true } },
        }
    });
    return model;
});
