define([
	'base/base-object-filter-view',
	'models/Administration/FilterTrips'
], function (BaseFilterView, Filter) {
    'use strict'

    var view = BaseFilterView.extend({

        filter: Filter,

        getFilters: function () {

            var result = [],
                isLessAsMustAmount = this.model.get('isLessAsMustAmount'),
                isLessAsMustAmountStatus = 1;

            if (isLessAsMustAmount == true) {
                isLessAsMustAmountStatus = 2
            }

            result.push({
                field: 'isLessAsMustAmountStatus',
                operator: 'eq',
                value: isLessAsMustAmountStatus
            });
            
            return result;
        },

        bindings: function () {

            var self = this;

            var result = {

                '#isLessAsMustAmount': 'isLessAsMustAmount'
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
