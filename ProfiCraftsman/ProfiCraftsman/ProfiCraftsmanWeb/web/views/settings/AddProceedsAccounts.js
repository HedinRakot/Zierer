define([
	'base/base-object-add-view',
    'l!t!Settings/ProceedsAccountsRelationships'
], function (BaseView , TabView) {
    'use strict';

    var view = BaseView.extend({

        tabView: TabView,
        tableName: 'ProceedsAccounts',
        actionUrl: '#ProceedsAccounts',

		bindings: function () {

            var self = this;
            var result = {
			'#value': 'value',
			};

            return result;
		},

        render: function () {

            view.__super__.render.apply(this, arguments);

			//TODO foreach model field
			this.disableInput(this, 'value', 'numeric');

            return this;
        }
		,events: {
		}
    });

    return view;
});
