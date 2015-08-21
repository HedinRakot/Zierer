define([
	'base/base-object-add-view',
    'l!t!Settings/InstrumentsRelationships'
], function (BaseView , TabView) {
    'use strict';

    var view = BaseView.extend({

        tabView: TabView,
        tableName: 'Instruments',
        actionUrl: '#Instruments',

		bindings: function () {

            var self = this;
            var result = {
			'#name': 'name',
			'#number': 'number',
			'#proceedsAccount': 'proceedsAccount',
			'#isForAuto': 'isForAuto',
			'#boughtPrice': 'boughtPrice',
			'#comment': 'comment',
			};

            return result;
		},

        render: function () {

            view.__super__.render.apply(this, arguments);

			//TODO foreach model field
			this.disableInput(this, 'name');
			this.disableInput(this, 'number');
			this.disableInput(this, 'proceedsAccount', 'numeric');
			this.disableInput(this, 'isForAuto');
			this.disableInput(this, 'boughtPrice', 'numeric');
			this.disableInput(this, 'comment');

            return this;
        }
		,events: {
		}
    });

    return view;
});
