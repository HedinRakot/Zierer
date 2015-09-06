define([
	'base/base-object-filter-view',
	'models/Administration/FilterTrips'
], function (BaseFilterView, Filter) {
    'use strict'

    var view = BaseFilterView.extend({

        filter: Filter,

        getFilters: function () {

            var result = [],
                isGreaterAsDefault = this.model.get('isGreaterAsDefault'),
                isGreaterAsDefaultStatus = 1;

            if (isGreaterAsDefault == true) {
                isGreaterAsDefaultStatus = 2
            }

            result.push({
                field: 'isGreaterAsDefaultStatus',
                operator: 'eq',
                value: isGreaterAsDefaultStatus
            });
            
            return result;
        },

        bindings: function () {

            var self = this;

            var result = {

                '#isGreaterAsDefault': 'isGreaterAsDefault'
            };

            return result;
        },
        
        render: function () {

            var self = this;

            view.__super__.renderWithoutBindings.apply(self, arguments);

            return self;
        }
    });

    return view;
});
