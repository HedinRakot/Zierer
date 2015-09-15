define([
	'base/base-object-filter-view',
	'models/Settings/FilterSocialTaxes'
], function (BaseFilterView, Filter) {
    'use strict'

    var view = BaseFilterView.extend({

        filter: Filter
    });

    return view;
});
