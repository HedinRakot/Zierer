define([
	'base/base-object-filter-view',
	'models/Settings/FilterProductTypes'
], function (BaseFilterView, Filter) {
    'use strict'

    var view = BaseFilterView.extend({

        filter: Filter
    });

    return view;
});
