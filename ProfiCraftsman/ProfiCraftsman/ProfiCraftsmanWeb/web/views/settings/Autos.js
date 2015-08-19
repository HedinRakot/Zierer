define([
'base/base-object-grid-view',
'collections/Settings/Autos',
'l!t!Settings/FilterAutos'
], function (BaseView, Collection, FilterView) {
	'use strict';		
	var view = BaseView.extend({

        collectionType: Collection,
        
        filterView: FilterView,
        tableName: 'Autos',
        editUrl: '#Autos',
		addNewModelInline: true,
		
		showEditButton: true,
		showDeleteButton: true,

	    editItemTitle: function () {
	        return this.resources.edit;
	    },
		columns: function () {
			
			return [
				{ field: 'number', title: this.resources.number },
				{ field: 'comment', title: this.resources.comment },
				{ field: 'lastInspectionDate', title: this.resources.lastInspectionDate , format: '{0:d}'},
			];
		}

	});

	return view;
});
