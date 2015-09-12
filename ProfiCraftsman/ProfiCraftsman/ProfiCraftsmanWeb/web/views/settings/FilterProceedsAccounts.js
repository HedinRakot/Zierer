define([
	'base/base-object-filter-view',
	'models/Settings/FilterProceedsAccounts'
], function (BaseFilterView, Filter) {
    'use strict'

    var view = BaseFilterView.extend({

        filter: Filter,

        getFilters: function () {
            
            var result = [];            

            result.push({
                field: 'name',
                operator: 'eq',
                value: this.model.get('name')
            });

            return result;
        },

        render: function () {

            var self = this;
            view.__super__.renderWithoutBindings.apply(self, arguments);


            var bindings = {
                '#name': 'name',
            };

            self.stickit(self.model, bindings);

            return self;
        }
    });

    return view;
});
