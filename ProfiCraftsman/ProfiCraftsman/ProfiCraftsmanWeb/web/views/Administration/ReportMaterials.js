define([
'base/base-object-grid-view',
'collections/Administration/ReportMaterials',
], function (BaseView, Collection) {
	'use strict';		
    
    var view = BaseView.extend({

        gridSelector: '.materialsGrid',

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
				
				{ field: 'materialNumber', title: this.resources.materialNumber },
				{ field: 'materialName', title: this.resources.materialName },
				{ field: 'amount', title: this.resources.amount },
                { field: 'price', title: this.resources.price },
			];
		},		

		toolbar: null
	});

	return view;
});
