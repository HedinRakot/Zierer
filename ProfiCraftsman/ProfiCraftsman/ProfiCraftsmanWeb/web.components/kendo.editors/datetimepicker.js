define([
	'kendo/kendo.datetimepicker'
], function () {
    'use strict';

    var editor = function (container, options) {
        var fields = Object.getPrototypeOf(options.model).fields,
    		field = fields[options.field],
			validation = field.validation,
    		required = validation ? validation.required : null;

        var $input = $('<input />').appendTo(container).attr('name', options.field).kendoDateTimePicker({
            timeFormat: "HH:mm"
        });

        if (required) {
            var widget = $input.data('kendoDateTimePicker');
            widget.wrapper.after('<span data-for="' + options.field + '" class="k-invalid-msg" style="display: none;"></span>');

            $input.attr('required', 'required');
        }
    };

    return editor;
});