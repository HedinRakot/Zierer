define([
'base/base-object-grid-view',
'collections/Settings/ProceedsAccounts',
'l!t!Settings/FilterProceedsAccounts'
], function (BaseView, Collection, FilterView) {
	'use strict';		
	var view = BaseView.extend({

        collectionType: Collection,
        
        filterView: FilterView,
        tableName: 'ProceedsAccounts',
        editUrl: '#ProceedsAccounts',
		addNewModelInline: true,
		
		showEditButton: true,
		showDeleteButton: true,

	    editItemTitle: function () {
	        return this.resources.edit;
	    },
		columns: function () {
			
			return [
				{ field: 'value', title: this.resources.value },
			];
		}

	});

	return view;
});
