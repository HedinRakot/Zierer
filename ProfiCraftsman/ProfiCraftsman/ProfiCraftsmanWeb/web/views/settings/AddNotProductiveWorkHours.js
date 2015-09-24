define([
	'base/base-object-add-view',
    'l!t!Settings/NotProductiveWorkHoursRelationships'
], function (BaseView , TabView) {
    'use strict';

    var view = BaseView.extend({

        tabView: TabView,
        tableName: 'NotProductiveWorkHours',
        actionUrl: '#NotProductiveWorkHours',

		bindings: function () {

            var self = this;
            var result = {
			'#employeeId': { observe: 'employeeId',
				selectOptions: { labelPath: 'name', valuePath: 'id',
				collection: self.options.employees
				,defaultOption: {label: self.resources.pleaseSelect,value: null}},},
			'#description': 'description',
			'#fromDate': 'fromDate',
			'#toDate': 'toDate',
			};

            return result;
		},

        render: function () {

            view.__super__.render.apply(this, arguments);

			//TODO foreach model field
			this.disableInput(this, 'employeeId', 'select');
			this.disableInput(this, 'description');
			this.disableInput(this, 'fromDate', 'date');
			this.disableInput(this, 'toDate', 'date');

            return this;
        }
		,events: {
		}
    });

    return view;
});
