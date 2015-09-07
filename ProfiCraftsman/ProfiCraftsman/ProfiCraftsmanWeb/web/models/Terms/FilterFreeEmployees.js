define(function () {
    'use strict';

    var model = Backbone.Model.extend({
        fields: {
            termId: { type: "number", editable: true },
        }
    });
    return model;
});
