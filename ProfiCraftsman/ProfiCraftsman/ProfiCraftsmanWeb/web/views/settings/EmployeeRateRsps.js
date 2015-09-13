define([	
    'base/related-object-grid-view',
'collections/Settings/EmployeeRateRsps',
'l!t!Settings/AddEmployeeRateRsp'
], function (BaseView, Collection, AddNewModelView) {
	'use strict';

	var view = BaseView.extend({

		addNewModelView: AddNewModelView,
		collectionType: Collection,
		gridSelector: '.grid',
		tableName: 'EmployeeRateRsps',
        
        addingInPopup: false,

		initialize: function() {
			view.__super__.initialize.apply(this, arguments);

			this.defaultFiltering = { field: 'employeeId', operator: 'eq', value: this.model.id };

			this.collection = new Collection();
		},

		columns: function () {
		   
		   return [
				{ field: 'jobPositionId', title: this.resources.jobPositionId , collection: this.options.jobPositions, defaultText: this.resources.pleaseSelect, attributes: { "class": "detail-view-grid-cell" }},
				{ field: 'fromDate', title: this.resources.fromDate , format: '{0:d}', attributes: { "class": "detail-view-grid-cell" }},
				{ field: 'toDate', title: this.resources.toDate , format: '{0:d}', attributes: { "class": "detail-view-grid-cell" }},
				{ field: 'salaryType', title: this.resources.salaryType , collection: this.options.salaryTypes, defaultText: this.resources.pleaseSelect, attributes: { "class": "detail-view-grid-cell" }},
				{ field: 'salary', title: this.resources.salary , attributes: { "class": "detail-view-grid-cell" }},
			];
		},
		
		render: function () {
		    var self = this;

		    view.__super__.render.apply(self, arguments);

		    self.grid.bind('edit', function (e) {
		        e.model.employeeId = self.model.id;

				if (e.model.isNew()) {
                    var dt = new Date(2070, 11, 31);
		            e.model.toDate = dt;
		            var numeric = e.container.find("input[name=toDate]");
					
					if(numeric != undefined && numeric.length > 0)
						numeric[0].value = kendo.format("{0:d}", dt);
		        }
		    });

		    return self;
		}

		
	});

	return view;
});
