define([
	'base/base-collection',
	'models/Settings/AutoInstrumentRsp'
], function (BaseCollection, Model) {
    'use strict';

    var collection = BaseCollection.extend({
        url: 'api/AutoInstrumentRsps',
        model: Model
    });

    return collection;
});
