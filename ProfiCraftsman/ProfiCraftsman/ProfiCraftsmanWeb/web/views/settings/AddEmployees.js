define([
	'base/base-object-add-view',
    'l!t!Settings/EmployeesRelationships'
], function (BaseView , TabView) {
    'use strict';

    var view = BaseView.extend({

        tabView: TabView,
        tableName: 'Employees',
        actionUrl: '#Employees',

		bindings: function () {

            var self = this;
            var result = {
			'#number': 'number',
			'#autoId': { observe: 'autoId',
				selectOptions: { labelPath: 'name', valuePath: 'id',
				collection: self.options.autos
				,defaultOption: {label: self.resources.pleaseSelect,value: null}},},
			'#name': 'name',
			'#firstName': 'firstName',
			'#street': 'street',
			'#zip': 'zip',
			'#city': 'city',
			'#country': 'country',
			'#phone': 'phone',
			'#mobile': 'mobile',
			'#fax': 'fax',
			'#email': 'email',
			'#comment': 'comment',
			'#color': 'color',
			};

            return result;
		},

        render: function () {

            view.__super__.render.apply(this, arguments);

			//TODO foreach model field
			this.disableInput(this, 'number', 'numeric');
			this.disableInput(this, 'autoId', 'select');
			this.disableInput(this, 'name');
			this.disableInput(this, 'firstName');
			this.disableInput(this, 'street');
			this.disableInput(this, 'zip');
			this.disableInput(this, 'city');
			this.disableInput(this, 'country');
			this.disableInput(this, 'phone');
			this.disableInput(this, 'mobile');
			this.disableInput(this, 'fax');
			this.disableInput(this, 'email');
			this.disableInput(this, 'comment');
			this.disableInput(this, 'color');

            return this;
        }
		,events: {
		}
    });

    return view;
});
