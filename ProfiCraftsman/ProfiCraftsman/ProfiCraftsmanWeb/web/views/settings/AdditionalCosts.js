define([
'base/base-object-grid-view',
'collections/Settings/AdditionalCosts',
'l!t!Settings/FilterAdditionalCosts'
], function (BaseView, Collection, FilterView) {
	'use strict';		
	var view = BaseView.extend({

        collectionType: Collection,
        
        filterView: FilterView,
        tableName: 'AdditionalCosts',
        editUrl: '#AdditionalCosts',
		addNewModelInline: true,
		
		showEditButton: true,
		showDeleteButton: true,

	    editItemTitle: function () {
	        return this.resources.edit;
	    },
		columns: function () {
			
			return [
				{ field: 'price', title: this.resources.price },
				{ field: 'fromDate', title: this.resources.fromDate , format: '{0:d}'},
				{ field: 'toDate', title: this.resources.toDate , format: '{0:d}'},
				{ field: 'additionalCostTypeId', title: this.resources.additionalCostTypeId , collection: this.options.additionalCostTypes, defaultText: this.resources.pleaseSelect},
				{ field: 'proceedsAccountId', title: this.resources.proceedsAccountId , collection: this.options.proceedsAccounts, defaultText: this.resources.pleaseSelect},
				{ field: 'description', title: this.resources.description },
			];
		}

	});

	return view;
});
