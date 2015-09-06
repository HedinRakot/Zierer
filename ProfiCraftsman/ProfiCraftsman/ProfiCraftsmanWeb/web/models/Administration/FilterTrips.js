define(function () {
    'use strict';

    var model = Backbone.Model.extend({
        fields: {
            isLessAsMustAmount: { type: "boolean", editable: true },
        }
    });
    return model;
});
