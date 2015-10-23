define([
	'base/base-collection',
	'models/Settings/AutoInstrumentRsp'
], function (BaseCollection, Model) {
    'use strict';

    var collection = BaseCollection.extend({
        url: Application.apiUrl + '/AutoInstrumentRsps',
        model: Model
    });

    return collection;
});
