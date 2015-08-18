define([
'base/base-object-grid-view',
'collections/Settings/Products',
'l!t!Settings/FilterProducts',
'l!t!Settings/ProductsRelationships',
'Settings/Custom.Events.Products',
'Settings/Custom.Toolbar.Products'
], function (BaseView, Collection, FilterView, DetailView, CustomEvents, CustomToolbar) {
	'use strict';		
	var view = BaseView.extend({

        collectionType: Collection,
        detailView: DetailView,
        filterView: FilterView,
        tableName: 'Products',
        editUrl: '#Products',
		
		
		
		showDeleteButton: true,

	    editItemTitle: function () {
	        return this.resources.edit;
	    },
		columns: function () {
			
			return [
				{ field: 'number', title: this.resources.number },
				{ field: 'productTypeId', title: this.resources.productTypeId , collection: this.options.productTypes, defaultText: this.resources.pleaseSelect},
				{ field: 'price', title: this.resources.price },
				{ field: 'name', title: this.resources.name },
				{ field: 'productAmountType', title: this.resources.productAmountType , collection: this.options.productAmountTypes, defaultText: this.resources.pleaseSelect},
			];
		}

		,events: CustomEvents
		,toolbar: CustomToolbar
		,selectable: true
	});

	return view;
});
