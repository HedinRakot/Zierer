define([
	'base/base-object-add-view',
    'l!t!Settings/MaterialsRelationships'
], function (BaseView , TabView) {
    'use strict';

    var view = BaseView.extend({

        tabView: TabView,
        tableName: 'Materials',
        actionUrl: '#Materials',

		bindings: function () {

            var self = this;
            var result = {
			'#name': 'name',
			'#number': 'number',
			'#length': 'length',
			'#width': 'width',
			'#height': 'height',
			'#color': 'color',
			'#price': 'price',
			'#isVirtual': 'isVirtual',
			'#boughtFrom': 'boughtFrom',
			'#boughtPrice': 'boughtPrice',
			'#comment': 'comment',
			'#materialAmountType': { observe: 'materialAmountType',
				selectOptions: { labelPath: 'name', valuePath: 'id',
				collection: self.options.materialAmountTypes
				,defaultOption: {label: self.resources.pleaseSelect,value: null}},},
			'#isForAuto': 'isForAuto',
			'#mustCount': 'mustCount',
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
			this.disableInput(this, 'number');
			this.disableInput(this, 'length', 'numeric');
			this.disableInput(this, 'width', 'numeric');
			this.disableInput(this, 'height', 'numeric');
			this.disableInput(this, 'color');
			this.disableInput(this, 'price', 'numeric');
			this.disableInput(this, 'isVirtual');
			this.disableInput(this, 'boughtFrom');
			this.disableInput(this, 'boughtPrice', 'numeric');
			this.disableInput(this, 'comment');
			this.disableInput(this, 'materialAmountType', 'select');
			this.disableInput(this, 'isForAuto');
			this.disableInput(this, 'mustCount', 'numeric');
			this.disableInput(this, 'proceedsAccountId', 'select');

            return this;
        }
		,events: {
		}
    });

    return view;
});
