define([
	'base/base-object-filter-view',
	'models/Warehouse/FilterWarehouseMaterials'
], function (BaseFilterView, Filter) {
    'use strict'

    var view = BaseFilterView.extend({

        filter: Filter,

        getFilters: function () {

            var result = [],
                isLessAsMustAmount = this.model.get('isLessAsMustAmount'),
                name = this.model.get('name'),
                isLessAsMustAmountStatus = 1;

            if (isLessAsMustAmount == true) {
                isLessAsMustAmountStatus = 2
            }

            result.push({
                field: 'isLessAsMustAmountStatus',
                operator: 'eq',
                value: isLessAsMustAmountStatus
            });

            result.push({
                field: 'name',
                operator: 'contains',
                value: this.model.get('name')
            });

            return result;
        },

        bindings: function () {

            var self = this;

            var result = {

                '#name': 'name',
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
