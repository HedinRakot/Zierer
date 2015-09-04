define([
	'lr!resources/Settings/ProductMaterialRsps',
], function (Resources) {
    'use strict';

    var extraColumns = function () {
        return [
            {
					field: "materialName",
					title: Resources.materialId,
					//width: '400px',
					sortable: false,
					filterable: false,
				}
        ];
    };

    return extraColumns;
});