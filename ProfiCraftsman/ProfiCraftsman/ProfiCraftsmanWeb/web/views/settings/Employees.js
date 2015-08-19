define([
'base/base-object-grid-view',
'collections/Settings/Employees',
'l!t!Settings/FilterEmployees'
], function (BaseView, Collection, FilterView) {
	'use strict';		
	var view = BaseView.extend({

        collectionType: Collection,
        
        filterView: FilterView,
        tableName: 'Employees',
        editUrl: '#Employees',
		
		
		
		showDeleteButton: true,

	    editItemTitle: function () {
	        return this.resources.edit;
	    },
		columns: function () {
			
			return [
				{ field: 'number', title: this.resources.number },
				{ field: 'jobPositionId', title: this.resources.jobPositionId , collection: this.options.jobPositions, defaultText: this.resources.pleaseSelect},
				{ field: 'autoId', title: this.resources.autoId , collection: this.options.autos, defaultText: this.resources.pleaseSelect},
				{ field: 'name', title: this.resources.name },
				{ field: 'firstName', title: this.resources.firstName },
			];
		}

	});

	return view;
});
