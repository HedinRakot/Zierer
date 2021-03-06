﻿define([
'base/base-object-grid-view',
'collections/Administration/ReportOrders',
'l!t!Administration/FilterReportOrders',
'l!t!Administration/ReportOrdersRelationships'
], function (BaseView, Collection, FilterView, DetailView) {
	'use strict';		
    
    var view = BaseView.extend({

        collectionType: Collection,
        detailView: DetailView,
        filterView: FilterView,
        tableName: 'Orders',
        
        showAddButton: false,
        showEditButton: false,
        showDeleteButton: false,

        gridSelector: '.reportOrders',

        editItemTitle: function () {
            return '';
        },

        defaultSorting: {
            field: 'orderNumber',
            dir: 'desc'
        },

        initialize: function () {
            view.__super__.initialize.apply(this, arguments);
            
            this.defaultFiltering = [
                { field: 'isOffer', operator: 'eq', value: false },
		        { field: 'status', operator: 'eq', value: 1 }];
        },
		
		columns: function () {
			
			return [
				{ field: 'orderNumber', title: this.resources.orderNumber },
				{ field: 'customerName', title: this.resources.customerName },
				{ field: 'communicationPartnerTitle', title: this.resources.communicationPartnerTitle },
				{ field: 'street', title: this.resources.street },
				{ field: 'zip', title: this.resources.zip },
				{ field: 'city', title: this.resources.city },
				{ field: 'totalPrice', title: this.resources.totalPrice, sortable: false, filterable: false },
				{ field: 'totalInvoicesSum', title: this.resources.totalInvoicesSum, sortable: false, filterable: false },
				{ field: 'totalPayedSum', title: this.resources.totalPayedSum, sortable: false, filterable: false }, 
				{ field: 'totalProfit', title: this.resources.totalProfit, sortable: false, filterable: false },
			];
		},		

		toolbar: null
	});

	return view;
});
