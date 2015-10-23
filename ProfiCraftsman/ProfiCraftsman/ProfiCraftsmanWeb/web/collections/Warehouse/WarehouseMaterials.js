define([
	'base/base-collection',
	'models/Warehouse/WarehouseMaterial'
], function (BaseCollection, Model) {
    'use strict';

    var collection = BaseCollection.extend({
        url: Application.apiUrl + '/WarehouseMaterials',
        model: Model
    });

    return collection;
});
