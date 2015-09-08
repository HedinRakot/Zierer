define(function () {
    'use strict';

    var properties = function () {
        return {
            employeeName: {
                type: "string",
                editable: false,
                validation: { required: false }
            }
        };
    };

    return properties;
});
