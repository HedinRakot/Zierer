define([
'base/base-object-grid-view',
'collections/Settings/Autos',
'l!t!Settings/FilterAutos',
'l!t!Settings/AutosRelationships'
], function (BaseView, Collection, FilterView, DetailView) {
	'use strict';		
	var view = BaseView.extend({

        collectionType: Collection,
        detailView: DetailView,
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
