define([
	'base/base-object-add-view',
    
], function (BaseView ) {
    'use strict';

    var view = BaseView.extend({

        
        tableName: 'EmployeeRateRsp',
        actionUrl: '#EmployeeRateRsps',

		bindings: function () {

            var self = this;
            var result = {
			'#employeeId': 'employeeId',
			'#jobPositionId': { observe: 'jobPositionId',
				selectOptions: { labelPath: 'name', valuePath: 'id',
				collection: self.options.jobPositions
				,defaultOption: {label: self.resources.pleaseSelect,value: null}},},
			'#fromDate': 'fromDate',
			'#toDate': 'toDate',
			'#salaryType': { observe: 'salaryType',
				selectOptions: { labelPath: 'name', valuePath: 'id',
				collection: self.options.salaryTypes
				,defaultOption: {label: self.resources.pleaseSelect,value: null}},},
			'#salary': 'salary',
			};

            return result;
		},

        render: function () {

            view.__super__.render.apply(this, arguments);

			//TODO foreach model field
			this.disableInput(this, 'employeeId', 'numeric');
			this.disableInput(this, 'jobPositionId', 'select');
			this.disableInput(this, 'fromDate', 'date');
			this.disableInput(this, 'toDate', 'date');
			this.disableInput(this, 'salaryType', 'select');
			this.disableInput(this, 'salary', 'numeric');

            return this;
        }
    });

    return view;
});
