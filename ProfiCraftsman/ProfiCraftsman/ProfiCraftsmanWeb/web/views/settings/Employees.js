define([
'base/base-object-grid-view',
'collections/Settings/Employees',
'l!t!Settings/FilterEmployees',
'l!t!Settings/EmployeesRelationships',
'Settings/Custom.Employees'
], function (BaseView, Collection, FilterView, DetailView, CustomColumns) {
	'use strict';		
	var view = BaseView.extend({

        collectionType: Collection,
        detailView: DetailView,
        filterView: FilterView,
        tableName: 'Employees',
        editUrl: '#Employees',
		
		
		
		showDeleteButton: true,

	    editItemTitle: function () {
	        return this.resources.edit;
	    },
		columns: function () {
			
			return $.merge( CustomColumns(),
[
				{ field: 'number', title: this.resources.number },
				{ field: 'jobPositionId', title: this.resources.jobPositionId , collection: this.options.jobPositions, defaultText: this.resources.pleaseSelect},
				{ field: 'autoId', title: this.resources.autoId , collection: this.options.autos, defaultText: this.resources.pleaseSelect},
				{ field: 'name', title: this.resources.name },
				{ field: 'firstName', title: this.resources.firstName },
			]);
		}

	});

	return view;
});
