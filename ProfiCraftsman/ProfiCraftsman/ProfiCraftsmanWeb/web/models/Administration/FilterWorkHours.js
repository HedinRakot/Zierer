define(function () {
    'use strict';

    var model = Backbone.Model.extend({
        fields: {
            fromDate: { type: "date", editable: true, validation: { date: true } },
            toDate: { type: "date", editable: true, validation: { date: true } },
        },
        defaults: function () {

            var today = new Date();
            var fromDate = new Date(today.getFullYear(), today.getMonth(), 1);

            var days = new Date(today.getYear(),
                    today.getMonth() + 1,
                    0).getDate();

            var toDate = new Date(today.getFullYear(), today.getMonth(), days);
            return {
                fromDate: kendo.format("{0:yyyy'-'MM'-'dd'T'HH':'mm':'ss}", fromDate),
                toDate: kendo.format("{0:yyyy'-'MM'-'dd'T'HH':'mm':'ss}", toDate)
            };
        }
    });
    return model;
});
