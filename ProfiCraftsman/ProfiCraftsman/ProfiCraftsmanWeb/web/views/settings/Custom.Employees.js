define([
	'lr!resources/Settings/Custom.Employee',
], function (Resources) {
    'use strict';

    var extraColumns = function () {
        return [
            {
                field: "color",
                title: Resources.Color,
                width: '20px',
                sortable: false,
                filterable: false,
                template: function (dataItem) {
                    var result = '<div class="color-box" style="background-color: ' + dataItem.color + ';"></div>'
                    return result;
                },
                editor: function (container, options) {
                    var $input = $('<input name="color" type="text" data-role="colorpicker" />');
                    container.append($input);
                }
            },
            {
                field: "jobPosition",
                title: Resources.JobPosition,
                width: '200px',
                sortable: false,
                filterable: false,
            }
        ];
    };

    return extraColumns;
});