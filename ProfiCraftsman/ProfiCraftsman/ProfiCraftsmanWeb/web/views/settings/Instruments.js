define([
'base/base-object-grid-view',
'collections/Settings/Instruments',
'l!t!Settings/FilterInstruments'
], function (BaseView, Collection, FilterView) {
	'use strict';		
	var view = BaseView.extend({

        collectionType: Collection,
        
        filterView: FilterView,
        tableName: 'Instruments',
        editUrl: '#Instruments',
		addNewModelInline: true,
		
		showEditButton: true,
		showDeleteButton: true,

	    editItemTitle: function () {
	        return this.resources.edit;
	    },
		columns: function () {
			
			return [
				{ field: 'name', title: this.resources.name },
				{ field: 'number', title: this.resources.number },
				{ field: 'proceedsAccount', title: this.resources.proceedsAccount },
				{ field: 'isForAuto', title: this.resources.isForAuto , headerTitle: this.resources.isForAuto, checkbox: true},
				{ field: 'boughtPrice', title: this.resources.boughtPrice },
				{ field: 'comment', title: this.resources.comment },
			];
		}

	});

	return view;
});
