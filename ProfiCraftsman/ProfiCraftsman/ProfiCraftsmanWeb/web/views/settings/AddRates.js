define([
	'base/base-object-add-view',
    'l!t!Settings/RatesRelationships'
], function (BaseView , TabView) {
    'use strict';

    var view = BaseView.extend({

        tabView: TabView,
        tableName: 'Rates',
        actionUrl: '#Rates',

		bindings: function () {

            var self = this;
            var result = {
			'#jobPositionId': { observe: 'jobPositionId',
				selectOptions: { labelPath: 'name', valuePath: 'id',
				collection: self.options.jobPositions
				,defaultOption: {label: self.resources.pleaseSelect,value: null}},},
			'#price': 'price',
			'#fromDate': 'fromDate',
			'#toDate': 'toDate',
			};

            return result;
		},

        render: function () {

            view.__super__.render.apply(this, arguments);

			//TODO foreach model field
			this.disableInput(this, 'jobPositionId', 'select');
			this.disableInput(this, 'price', 'numeric');
			this.disableInput(this, 'fromDate', 'date');
			this.disableInput(this, 'toDate', 'date');

            return this;
        }
		,events: {
		}
    });

    return view;
});
