define([
	'base/base-object-filter-view',
	'models/Terms/FilterFreeEmployees'
], function (BaseFilterView, Filter) {
    'use strict'

    var view = BaseFilterView.extend({

        filter: Filter,

        getFilters: function () {
            debugger;
            var result = [];

            result.push({
                field: 'termId',
                operator: 'contains',
                value: this.model.get('termId')
            });

            return result;
        },

        bindings: function () {

            var self = this;

            var result = {

                '#termId': 'termId',                
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
