define([
	'base/base-collection',
	'models/Settings/AutoMaterialRsp'
], function (BaseCollection, Model) {
    'use strict';

    var collection = BaseCollection.extend({
        url: 'api/AutoMaterialRsps',
        model: Model
    });

    return collection;
});
