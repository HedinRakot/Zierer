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
			'#description': 'description',
			'#price': 'price',
			'#automatic': 'automatic',
			'#proceedsAccount': 'proceedsAccount',
			'#fromDate': 'fromDate',
			'#toDate': 'toDate',
			'#additionalCostTypeId': { observe: 'additionalCostTypeId',
				selectOptions: { labelPath: 'name', valuePath: 'id',
				collection: self.options.additionalCostTypes
				,defaultOption: {label: self.resources.pleaseSelect,value: null}},},
			};

            return result;
		},

        render: function () {

            view.__super__.render.apply(this, arguments);

			//TODO foreach model field
			this.disableInput(this, 'description');
			this.disableInput(this, 'price', 'numeric');
			this.disableInput(this, 'proceedsAccount', 'numeric');
			this.disableInput(this, 'fromDate', 'date');
			this.disableInput(this, 'toDate', 'date');
			this.disableInput(this, 'additionalCostTypeId', 'select');

            return this;
        }
		,events: {
		}
    });

    return view;
});
