define([
'base/base-object-grid-view',
'collections/Settings/OwnProducts',
'l!t!Settings/FilterOwnProducts'
], function (BaseView, Collection, FilterView) {
	'use strict';		
	var view = BaseView.extend({

        collectionType: Collection,
        
        filterView: FilterView,
        tableName: 'OwnProducts',
        editUrl: '#OwnProducts',
		addNewModelInline: true,
		
		showEditButton: true,
		showDeleteButton: true,

	    editItemTitle: function () {
	        return this.resources.edit;
	    },
		columns: function () {
			
			return [
				{ field: 'description', title: this.resources.description },
				{ field: 'price', title: this.resources.price },
				{ field: 'fromDate', title: this.resources.fromDate , format: '{0:d}'},
				{ field: 'toDate', title: this.resources.toDate , format: '{0:d}'},
				{ field: 'proceedsAccountId', title: this.resources.proceedsAccountId , collection: this.options.proceedsAccounts, defaultText: this.resources.pleaseSelect},
			];
		}

	});

	return view;
});
