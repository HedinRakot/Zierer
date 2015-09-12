define([
	'base/base-object-add-view',
    'l!t!Settings/CustomProductsRelationships'
], function (BaseView , TabView) {
    'use strict';

    var view = BaseView.extend({

        tabView: TabView,
        tableName: 'CustomProducts',
        actionUrl: '#CustomProducts',

		bindings: function () {

            var self = this;
            var result = {
			'#name': 'name',
			'#price': 'price',
			'#auto': 'auto',
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
			this.disableInput(this, 'name');
			this.disableInput(this, 'price', 'numeric');
			this.disableInput(this, 'auto');
			this.disableInput(this, 'proceedsAccountId', 'select');

            return this;
        }
		,events: {
		}
    });

    return view;
});
