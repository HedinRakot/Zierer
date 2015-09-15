define([
	'base/base-object-tab-view',
    'kendo/kendo.tabstrip',
    'mixins/bound-form',
    'mixins/kendo-widget-form',
	'mixins/kendo-validator-form',
    'models/Administration/FilterProfitReports',
    'models/Administration/ProfitReports',
], function (BaseView, KendoTab, BoundForm, KendoWidgetForm, KendoValidatorForm, FilterModel, Model) {
    'use strict';

    var toggle = function () {
        this.$('.advanced').toggle();
    },

	setFilters = function () {
	    var self = this;

	    self.gridNames.forEach(function(gridName, i) {

	        var dataSource = self.$el.find(gridName).data('kendoGrid').dataSource,
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
	    });
	},

    getValues = function (self) {

        self.model.save({
            fromDate: self.filterModel.get('fromDate'),
            toDate: self.filterModel.get('toDate')
        },
        {
            success: function (model, response) {

            },
            error: function (model, response) {

                require(['base/information-view'], function (View) {
                    var view = new View({
                        title: 'Fehler',
                        message: 'Die Daten konnten nicht geladen werden. Versuchen Sie bitte später nochmals.'
                    });
                    self.addView(view);
                    self.$el.append(view.render().$el);
                });
            }
        });
    },

    view = BaseView.extend({

        gridNames: ['.additionalCostsGrid', '.salaryGrid', /*'.reportOrders',*/ '.foreignProductsGrid', '.materialsGrid'],
        
        getFilters: function () {

            var result = [],
                fromDate = this.filterModel.get('fromDate'),
                toDate = this.filterModel.get('toDate');

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

        initialize: function () {
            view.__super__.initialize.apply(this, arguments);

            var self = this;

            self.filterModel = new FilterModel();

            self.model = new Model();

            getValues(self);
        },

        render: function () {
            var self = this;

            view.__super__.render.apply(self, arguments);

            self.stickit(self.filterModel, {

                '#fromDate': 'fromDate',
                '#toDate': 'toDate',
            });


            var bindingsModel = {
                '#materialsSum': 'materialsSum',
                '#additionalCostsSum': 'additionalCostsSum',
                '#foreignProductsSum': 'foreignProductsSum',
                '#salary': 'salary',
                '#totalOrdersSum': 'totalOrdersSum',
            };

            self.stickit(self.model, bindingsModel);


            self.$el.delegate('button[type=submit]', 'click.base-filter-view', function (e) {
                e.preventDefault();

                setFilters.call(self);

                getValues(self);
            });

            self.$el.delegate('button[type=reset]', 'click.base-filter-view', function (e) {
                e.preventDefault();

                self.filterModel.clear().set(self.filterModel.defaults);

                getValues(self);

                setFilters.call(self);
            });

            self.$el.delegate('.toggle', 'click.base-filter-view', _.bind(toggle, this));
           
            return self;
        },

        tabs: function () {

            var result = [
                { view: 'l!t!Administration/ReportMaterials', selector: '.materials' },
                { view: 'l!t!Administration/ReportAdditionalCosts', selector: '.additionalCosts' },
                { view: 'l!t!Administration/ReportForeignProducts', selector: '.foreignProducts' },
                { view: 'l!t!Administration/Salary', selector: '.salary' },
                { view: 'l!t!Administration/ReportOrders', selector: '.orders' },
            ];

            return result;
        }
    });

    view.mixin(BoundForm);
    view.mixin(KendoValidatorForm);
    view.mixin(KendoWidgetForm);
    
    return view;
});
