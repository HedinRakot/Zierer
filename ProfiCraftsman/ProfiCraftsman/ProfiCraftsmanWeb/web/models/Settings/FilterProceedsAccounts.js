define(function () {
    'use strict';

    var model = Backbone.Model.extend({
        fields: {
            name: { type: "number", editable: true },
        }
    });
    return model;
});
