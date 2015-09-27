define([
	'base/base-object-filter-view',
	'models/Administration/FilterWorkHours'
], function (BaseFilterView, Filter) {
    'use strict'

    var view = BaseFilterView.extend({

        filter: Filter,

        getFilters: function () {

            var result = [],
                fromDate = this.model.get('fromDate'),
                toDate = this.model.get('toDate');

            result.push({
                field: 'fromDate',
                operator: 'gte',
                value: fromDate
            });

            result.push({
                field: 'toDate',
                operator: 'lte',
                value: toDate
            });
            
            return result;
        },

        bindings: function () {

            var self = this;

            var result = {

                '#fromDate': 'fromDate',
                '#toDate': 'toDate',
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
