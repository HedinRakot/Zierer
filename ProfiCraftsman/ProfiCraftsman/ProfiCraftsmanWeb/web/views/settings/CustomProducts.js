define([
'base/base-object-grid-view',
'collections/Settings/CustomProducts',
'l!t!Settings/FilterCustomProducts'
], function (BaseView, Collection, FilterView) {
	'use strict';		
	var view = BaseView.extend({

        collectionType: Collection,
        
        filterView: FilterView,
        tableName: 'CustomProducts',
        editUrl: '#CustomProducts',
		addNewModelInline: true,
		
		showEditButton: true,
		showDeleteButton: true,

	    editItemTitle: function () {
	        return this.resources.edit;
	    },
		columns: function () {
			
			return [
				{ field: 'name', title: this.resources.name },
				{ field: 'price', title: this.resources.price },
				{ field: 'auto', title: this.resources.auto , headerTitle: this.resources.auto, checkbox: true},
			];
		}

	});

	return view;
});
