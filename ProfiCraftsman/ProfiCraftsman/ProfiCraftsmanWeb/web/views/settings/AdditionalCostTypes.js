define([
'base/base-object-grid-view',
'collections/Settings/AdditionalCostTypes',
'l!t!Settings/FilterAdditionalCostTypes'
], function (BaseView, Collection, FilterView) {
	'use strict';		
	var view = BaseView.extend({

        collectionType: Collection,
        
        filterView: FilterView,
        tableName: 'AdditionalCostTypes',
        editUrl: '#AdditionalCostTypes',
		addNewModelInline: true,
		
		showEditButton: true,
		showDeleteButton: true,

	    editItemTitle: function () {
	        return this.resources.edit;
	    },
		columns: function () {
			
			return [
				{ field: 'name', title: this.resources.name },
			];
		}

	});

	return view;
});
