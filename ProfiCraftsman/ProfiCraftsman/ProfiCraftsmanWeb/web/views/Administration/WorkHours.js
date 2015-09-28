define([	
    'base/base-object-grid-view',
    'collections/Administration/WorkHours',
    'l!t!Administration/FilterWorkHours',
], function (BaseView, Collection, FilterView) {
	'use strict';

    var view = BaseView.extend({

		collectionType: Collection,
		gridSelector: '.grid',
		tableName: 'Trips',
        
		filterView: FilterView,

		showAddButton: false,
		showEditButton: false,
		showDeleteButton: false,

		toolbar: null,

		defaultSorting: {
		    field: 'date',
		    dir: 'desc'
		},

		initialize: function() {
			view.__super__.initialize.apply(this, arguments);			

			this.collection = new Collection();
		},

		columns: function () {

		   return [
				{ field: 'date', title: this.resources.date, format: "{0:d}", dateTime: true, sortable: false, filterable: false },
				{ field: 'duration', title: this.resources.duration, format: "{0:HH:mm}", sortable: false, filterable: false },
				{ field: 'employeeId', title: this.resources.employee, sortable: false, filterable: true, collection: this.options.employees },
				{ field: 'amountString', title: this.resources.amount, sortable: false, filterable: false },
			];
		},
		
		render: function () {
		    var self = this;

		    view.__super__.render.apply(self, arguments);
            
		    return self;
		},	
	});

	return view;
});
