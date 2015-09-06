define(function () {
    'use strict';

    var model = Backbone.Model.extend({
        fields: {
            isGreaterAsDefault: { type: "boolean", editable: true },
        }
    });
    return model;
});
