define([
	'base/base-object-add-view',
    'l!t!Settings/AdditionalCostsRelationships'
], function (BaseView , TabView) {
    'use strict';

    var view = BaseView.extend({

        tabView: TabView,
        tableName: 'AdditionalCosts',
        actionUrl: '#AdditionalCosts',

		bindings: function () {

            var self = this;
            var result = {
			'#price': 'price',
			'#automatic': 'automatic',
			'#fromDate': 'fromDate',
			'#toDate': 'toDate',
			'#additionalCostTypeId': { observe: 'additionalCostTypeId',
				selectOptions: { labelPath: 'name', valuePath: 'id',
				collection: self.options.additionalCostTypes
				,defaultOption: {label: self.resources.pleaseSelect,value: null}},},
			'#proceedsAccountId': { observe: 'proceedsAccountId',
				selectOptions: { labelPath: 'name', valuePath: 'id',
				collection: self.options.proceedsAccounts
				,defaultOption: {label: self.resources.pleaseSelect,value: null}},},
			'#description': 'description',
			};

            return result;
		},

        render: function () {

            view.__super__.render.apply(this, arguments);

			//TODO foreach model field
			this.disableInput(this, 'price', 'numeric');
			this.disableInput(this, 'fromDate', 'date');
			this.disableInput(this, 'toDate', 'date');
			this.disableInput(this, 'additionalCostTypeId', 'select');
			this.disableInput(this, 'proceedsAccountId', 'select');
			this.disableInput(this, 'description');

            return this;
        }
		,events: {
		}
    });

    return view;
});
