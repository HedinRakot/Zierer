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
			'#length': 'length',
			'#width': 'width',
			'#height': 'height',
			'#color': 'color',
			'#price': 'price',
			'#proceedsAccount': 'proceedsAccount',
			'#isVirtual': 'isVirtual',
			'#manufactureDate': 'manufactureDate',
			'#boughtFrom': 'boughtFrom',
			'#boughtPrice': 'boughtPrice',
			'#comment': 'comment',
			'#sellPrice': 'sellPrice',
			'#isSold': 'isSold',
			'#minPrice': 'minPrice',
			'#newPrice': 'newPrice',
			};

            return result;
		},

        render: function () {

            view.__super__.render.apply(this, arguments);

			//TODO foreach model field
			this.disableInput(this, 'number');
			this.disableInput(this, 'productTypeId', 'select');
			this.disableInput(this, 'length', 'numeric');
			this.disableInput(this, 'width', 'numeric');
			this.disableInput(this, 'height', 'numeric');
			this.disableInput(this, 'color');
			this.disableInput(this, 'price', 'numeric');
			this.disableInput(this, 'proceedsAccount', 'numeric');
			this.disableInput(this, 'isVirtual');
			this.disableInput(this, 'manufactureDate', 'date');
			this.disableInput(this, 'boughtFrom');
			this.disableInput(this, 'boughtPrice', 'numeric');
			this.disableInput(this, 'comment');
			this.disableInput(this, 'sellPrice', 'numeric');
			this.disableInput(this, 'isSold');
			this.disableInput(this, 'minPrice', 'numeric');
			this.disableInput(this, 'newPrice', 'numeric');

            return this;
        }
		,events: {
		}
    });

    return view;
});
