﻿define([
'base/base-object-grid-view',
'collections/Settings/ForeignProducts',
], function (BaseView, Collection) {
	'use strict';		
    
    var view = BaseView.extend({

        gridSelector: '.foreignProductsGrid',

        collectionType: Collection,
        tableName: 'ForeignProducts',
        
        showAddButton: false,
        showEditButton: false,
        showDeleteButton: false,

        editItemTitle: function () {
            return '';
        },

        defaultSorting: {
            field: 'id',
            dir: 'desc'
        },

        initialize: function () {

            view.__super__.initialize.apply(this, arguments);

            var today = new Date();
            var fromDate = new Date(today.getFullYear(), today.getMonth(), 1);

            var days = new Date(today.getYear(),
                    today.getMonth() + 1,
                    0).getDate();

            var toDate = new Date(today.getFullYear(), today.getMonth(), days);

            this.defaultFiltering = [
                { field: 'fromDate', operator: 'gte', value: fromDate },
		        { field: 'toDate', operator: 'lte', value: toDate }];
        },
		
		columns: function () {
			
		    return [
                { field: 'description', title: this.resources.description },
				{ field: 'price', title: this.resources.price },
				{ field: 'fromDate', title: this.resources.fromDate, format: '{0:d}' },
				{ field: 'toDate', title: this.resources.toDate, format: '{0:d}' },
				{ field: 'proceedsAccountId', title: this.resources.proceedsAccountId, collection: this.options.proceedsAccounts },
			];
		},		

		toolbar: null
	});

	return view;
});
