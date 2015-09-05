define(function () {
    'use strict';

    var properties = function () {
        return {
            materialName: {
                type: "string",
                editable: false,
                validation: { required: false }
            }
        };
    };

    return properties;
});
