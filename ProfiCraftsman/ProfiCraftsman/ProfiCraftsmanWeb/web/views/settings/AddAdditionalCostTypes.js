define([
	'base/base-object-add-view',
    'l!t!Settings/AdditionalCostTypesRelationships'
], function (BaseView , TabView) {
    'use strict';

    var view = BaseView.extend({

        tabView: TabView,
        tableName: 'AdditionalCostTypes',
        actionUrl: '#AdditionalCostTypes',

		bindings: function () {

            var self = this;
            var result = {
			'#name': 'name',
			};

            return result;
		},

        render: function () {

            view.__super__.render.apply(this, arguments);

			//TODO foreach model field
			this.disableInput(this, 'name');

            return this;
        }
		,events: {
		}
    });

    return view;
});
