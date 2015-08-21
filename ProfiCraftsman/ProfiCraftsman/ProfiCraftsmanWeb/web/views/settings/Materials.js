define([
'base/base-object-grid-view',
'collections/Settings/Materials',
'l!t!Settings/FilterMaterials'
], function (BaseView, Collection, FilterView) {
	'use strict';		
	var view = BaseView.extend({

        collectionType: Collection,
        
        filterView: FilterView,
        tableName: 'Materials',
        editUrl: '#Materials',
		
		
		
		showDeleteButton: true,

	    editItemTitle: function () {
	        return this.resources.edit;
	    },
		columns: function () {
			
			return [
				{ field: 'name', title: this.resources.name },
				{ field: 'number', title: this.resources.number },
				{ field: 'length', title: this.resources.length },
				{ field: 'width', title: this.resources.width },
				{ field: 'height', title: this.resources.height },
				{ field: 'color', title: this.resources.color },
				{ field: 'price', title: this.resources.price },
				{ field: 'isVirtual', title: this.resources.isVirtual , headerTitle: this.resources.isVirtual, checkbox: true},
				{ field: 'materialAmountType', title: this.resources.materialAmountType , collection: this.options.materialAmountTypes, defaultText: this.resources.pleaseSelect},
				{ field: 'isForAuto', title: this.resources.isForAuto , headerTitle: this.resources.isForAuto, checkbox: true},
				{ field: 'mustCount', title: this.resources.mustCount },
			];
		}

	});

	return view;
});
