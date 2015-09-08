define([
'base/base-object-grid-view',
'collections/Settings/Rates',
'l!t!Settings/FilterRates'
], function (BaseView, Collection, FilterView) {
	'use strict';		
	var view = BaseView.extend({

        collectionType: Collection,
        
        filterView: FilterView,
        tableName: 'Rates',
        editUrl: '#Rates',
		addNewModelInline: true,
		
		showEditButton: true,
		showDeleteButton: true,

	    editItemTitle: function () {
	        return this.resources.edit;
	    },
		columns: function () {
			
			return [
				{ field: 'jobPositionId', title: this.resources.jobPositionId , collection: this.options.jobPositions, defaultText: this.resources.pleaseSelect},
				{ field: 'price', title: this.resources.price },
				{ field: 'fromDate', title: this.resources.fromDate , format: '{0:d}'},
				{ field: 'toDate', title: this.resources.toDate , format: '{0:d}'},
			];
		}

	});

	return view;
});
