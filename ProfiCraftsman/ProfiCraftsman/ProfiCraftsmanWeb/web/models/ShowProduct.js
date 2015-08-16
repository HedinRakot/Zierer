﻿define(function () {
    'use strict';

    var model = Backbone.Model.extend({
        fields: {
            productTypeId: { type: "number", editable: true, validation: { required: false, } },
            name: { type: "string", editable: true, validation: { required: false, } },
            equipments: {},
        }
    });
    return model;
});