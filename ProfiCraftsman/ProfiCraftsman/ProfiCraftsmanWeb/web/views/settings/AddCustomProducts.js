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
			'#price': 'price',
			'#name': 'name',
			};

            return result;
		},

        render: function () {

            view.__super__.render.apply(this, arguments);

			//TODO foreach model field
			this.disableInput(this, 'price', 'numeric');
			this.disableInput(this, 'name');

            return this;
        }
		,events: {
		}
    });

    return view;
});
