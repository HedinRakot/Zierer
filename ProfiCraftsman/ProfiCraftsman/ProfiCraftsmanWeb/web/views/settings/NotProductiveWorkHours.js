define([
'base/base-object-grid-view',
'collections/Settings/NotProductiveWorkHours',
'l!t!Settings/FilterNotProductiveWorkHours'
], function (BaseView, Collection, FilterView) {
	'use strict';		
	var view = BaseView.extend({

        collectionType: Collection,
        
        filterView: FilterView,
        tableName: 'NotProductiveWorkHours',
        editUrl: '#NotProductiveWorkHours',
		addNewModelInline: true,
		
		showEditButton: true,
		showDeleteButton: true,

	    editItemTitle: function () {
	        return this.resources.edit;
	    },
		columns: function () {
			
			return [
				{ field: 'employeeId', title: this.resources.employeeId , collection: this.options.employees, defaultText: this.resources.pleaseSelect},
				{ field: 'description', title: this.resources.description },
				{ field: 'fromDate', title: this.resources.fromDate , format: '{0:g}', dateTime: true},
				{ field: 'toDate', title: this.resources.toDate , format: '{0:g}', dateTime: true},
			];
		}

	});

	return view;
});
