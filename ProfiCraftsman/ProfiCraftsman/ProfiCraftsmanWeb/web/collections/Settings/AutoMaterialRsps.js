define([
	'base/base-collection',
	'models/Settings/AutoMaterialRsp'
], function (BaseCollection, Model) {
    'use strict';

    var collection = BaseCollection.extend({
        url: Application.apiUrl + '/AutoMaterialRsps',
        model: Model
    });

    return collection;
});
