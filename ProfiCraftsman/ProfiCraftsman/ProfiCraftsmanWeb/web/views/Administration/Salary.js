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
