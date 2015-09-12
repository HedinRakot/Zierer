define([
	'base/base-object-add-view',
    'l!t!Settings/ProductsRelationships'
], function (BaseView , TabView) {
    'use strict';

    var view = BaseView.extend({

        tabView: TabView,
        tableName: 'Products',
        actionUrl: '#Products',

		bindings: function () {

            var self = this;
            var result = {
			'#number': 'number',
			'#productTypeId': { observe: 'productTypeId',
				selectOptions: { labelPath: 'name', valuePath: 'id',
				collection: self.options.productTypes
				,defaultOption: {label: self.resources.pleaseSelect,value: null}},},
			'#price': 'price',
			'#comment': 'comment',
			'#name': 'name',
			'#productAmountType': { observe: 'productAmountType',
				selectOptions: { labelPath: 'name', valuePath: 'id',
				collection: self.options.productAmountTypes
				,defaultOption: {label: self.resources.pleaseSelect,value: null}},},
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
			this.disableInput(this, 'number');
			this.disableInput(this, 'productTypeId', 'select');
			this.disableInput(this, 'price', 'numeric');
			this.disableInput(this, 'comment');
			this.disableInput(this, 'name');
			this.disableInput(this, 'productAmountType', 'select');
			this.disableInput(this, 'proceedsAccountId', 'select');

            return this;
        }
		,events: {
		}
    });

    return view;
});
