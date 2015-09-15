define([
'base/base-object-grid-view',
'collections/Settings/SocialTaxes',
'l!t!Settings/FilterSocialTaxes'
], function (BaseView, Collection, FilterView) {
	'use strict';		
	var view = BaseView.extend({

        collectionType: Collection,
        
        filterView: FilterView,
        tableName: 'SocialTaxes',
        editUrl: '#SocialTaxes',
		addNewModelInline: true,
		
		showEditButton: true,
		showDeleteButton: true,

	    editItemTitle: function () {
	        return this.resources.edit;
	    },
		columns: function () {
			
			return [
				{ field: 'employeeId', title: this.resources.employeeId , collection: this.options.employees, defaultText: this.resources.pleaseSelect},
				{ field: 'description', title: this.resources.description },
				{ field: 'price', title: this.resources.price },
				{ field: 'proceedsAccountId', title: this.resources.proceedsAccountId , collection: this.options.proceedsAccounts, defaultText: this.resources.pleaseSelect},
				{ field: 'fromDate', title: this.resources.fromDate , format: '{0:d}'},
				{ field: 'toDate', title: this.resources.toDate , format: '{0:d}'},
			];
		}

	});

	return view;
});
