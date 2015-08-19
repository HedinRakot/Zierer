define([
	'base/base-object-add-view',
    'l!t!Settings/AutosRelationships'
], function (BaseView , TabView) {
    'use strict';

    var view = BaseView.extend({

        tabView: TabView,
        tableName: 'Autos',
        actionUrl: '#Autos',

		bindings: function () {

            var self = this;
            var result = {
			'#number': 'number',
			'#comment': 'comment',
			'#lastInspectionDate': 'lastInspectionDate',
			};

            return result;
		},

        render: function () {

            view.__super__.render.apply(this, arguments);

			//TODO foreach model field
			this.disableInput(this, 'number');
			this.disableInput(this, 'comment');
			this.disableInput(this, 'lastInspectionDate', 'date');

            return this;
        }
		,events: {
		}
    });

    return view;
});
