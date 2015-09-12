define([
	'base/base-object-tab-view',
    'kendo/kendo.tabstrip',
    'mixins/bound-form',
    'mixins/kendo-widget-form',
	'mixins/kendo-validator-form',
    'models/Administration/FilterProfitReports'
], function (BaseView, KendoTab, BoundForm, KendoWidgetForm, KendoValidatorForm, FilterModel) {
    'use strict';

    var toggle = function () {
        this.$('.advanced').toggle();
    },

	setFilters = function () {
	    var self = this,
			dataSource = self.$el.find('.grid').data('kendoGrid').dataSource, //self.options.grid.dataSource,
			expression = dataSource.filter() || { filters: [], logic: 'and' };

	    if (self.validate()) {
	        var sourceFilters = self.getFilters();

	        _.each(sourceFilters, function (sourceFilter) {
	            if (!sourceFilter.value) {
	                var targetFilter = _.findWhere(expression.filters, { field: sourceFilter.field, operator: sourceFilter.operator }),
						index = expression.filters.indexOf(targetFilter);

	                if (index > -1)
	                    expression.filters.splice(index, 1);
	            }
	            else {
	                var match = _.filter(expression.filters, function (targetFilter) {
	                    if (sourceFilter.field === targetFilter.field && sourceFilter.operator === targetFilter.operator) {
	                        targetFilter.value = sourceFilter.value;

	                        return true;
	                    }
	                });

	                if (!match.length)
	                    expression.filters.push(sourceFilter);
	            }
	        });


	        dataSource.filter(expression);
	    }
	},

    view = BaseView.extend({

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

        initialize: function () {
            view.__super__.initialize.apply(this, arguments);

            this.model = new FilterModel();
        },

        render: function () {
            var self = this;

            view.__super__.render.apply(self, arguments);

            self.$el.delegate('button[type=submit]', 'click.base-filter-view', function (e) {
                e.preventDefault();

                setFilters.call(self);
            });

            self.$el.delegate('button[type=reset]', 'click.base-filter-view', function (e) {
                e.preventDefault();

                self.model.clear().set(self.model.defaults);

                setFilters.call(self);
            });

            self.$el.delegate('.toggle', 'click.base-filter-view', _.bind(toggle, this));

            return self;
        },

        tabs: function () {
            
            var result = [
                { view: 'l!t!Administration/ReportAdditionalCosts', selector: '.additionalCosts' },
            ];
            
            return result;
        }
    });

    view.mixin(BoundForm);
    view.mixin(KendoValidatorForm);
    view.mixin(KendoWidgetForm);

    return view;
});
