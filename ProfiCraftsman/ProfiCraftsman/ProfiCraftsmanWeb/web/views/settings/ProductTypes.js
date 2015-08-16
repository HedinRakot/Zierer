define([
'base/base-object-grid-view',
'collections/Settings/ProductTypes',
'l!t!Settings/FilterProductTypes'
], function (BaseView, Collection, FilterView) {
	'use strict';		
	var view = BaseView.extend({

        collectionType: Collection,
        
        filterView: FilterView,
        tableName: 'ProductTypes',
        editUrl: '#ProductTypes',
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
