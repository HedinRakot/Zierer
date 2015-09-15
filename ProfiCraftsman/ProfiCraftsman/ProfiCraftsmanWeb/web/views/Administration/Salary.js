define([
'base/base-object-grid-view',
'collections/Administration/Salary',
], function (BaseView, Collection) {
	'use strict';		
    
    var view = BaseView.extend({

        gridSelector: '.salaryGrid',

        collectionType: Collection,
        
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
				{ field: 'employeeName', title: this.resources.employeeName },
				{ field: 'amountString', title: this.resources.amount },
			];
		},		

		toolbar: null
	});

	return view;
});
