define([
'base/base-object-grid-view',
'collections/Settings/JobPositions',
'l!t!Settings/FilterJobPositions'
], function (BaseView, Collection, FilterView) {
	'use strict';		
	var view = BaseView.extend({

        collectionType: Collection,
        
        filterView: FilterView,
        tableName: 'JobPositions',
        editUrl: '#JobPositions',
		addNewModelInline: true,
		
		showEditButton: true,
		showDeleteButton: true,

	    editItemTitle: function () {
	        return this.resources.edit;
	    },
		columns: function () {
			
			return [
				{ field: 'name', title: this.resources.name },
				{ field: 'comment', title: this.resources.comment },
			];
		}

	});

	return view;
});
