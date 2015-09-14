define([
	'base/base-object-add-view',
    'l!t!Settings/ForeignProductsRelationships'
], function (BaseView , TabView) {
    'use strict';

    var view = BaseView.extend({

        tabView: TabView,
        tableName: 'ForeignProducts',
        actionUrl: '#ForeignProducts',

		bindings: function () {

            var self = this;
            var result = {
			'#description': 'description',
			'#price': 'price',
			'#fromDate': 'fromDate',
			'#toDate': 'toDate',
			'#proceedsAccountId': { observe: 'proceedsAccountId',
				selectOptions: { labelPath: 'name', valuePath: 'id',
				collection: self.options.proceedsAccounts
				,defaultOption: {label: self.resources.pleaseSelect,value: null}},},
			};

            return result;
		},

        render: function () {

            view.__super__.render.apply(this, arguments);

			//TODO foreach model field
			this.disableInput(this, 'description');
			this.disableInput(this, 'price', 'numeric');
			this.disableInput(this, 'fromDate', 'date');
			this.disableInput(this, 'toDate', 'date');
			this.disableInput(this, 'proceedsAccountId', 'select');

            return this;
        }
		,events: {
		}
    });

    return view;
});
