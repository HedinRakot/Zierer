define([
	'lr!resources/Settings/Instruments',
], function (Resources) {
    'use strict';

    var extraColumns = function () {
        return [
            {
					field: "employeeName",
					title: 'Mitarbeiter',
					//width: '400px',
					sortable: false,
					filterable: false,
				}
        ];
    };

    return extraColumns;
});