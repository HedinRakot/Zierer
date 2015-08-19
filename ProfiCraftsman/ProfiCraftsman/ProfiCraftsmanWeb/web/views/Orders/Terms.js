define([	
    'base/related-object-grid-view',
    'collections/Terms',
], function (BaseView, Collection) {
	'use strict';

    var view = BaseView.extend({

		collectionType: Collection,
		gridSelector: '.grid',
		tableName: 'Terms',
        
        selectable: true,

		initialize: function() {
			view.__super__.initialize.apply(this, arguments);

			this.defaultFiltering = { field: 'orderId', operator: 'eq', value: this.model.id };

			this.collection = new Collection();
		},

		columns: function () {
		   
		   return [
				{ field: 'date', title: this.resources.date, format: "{0:g}", dateTime: true },
				{ field: 'employeeId', title: this.resources.employee, collection: this.options.employees, defaultText: this.resources.pleaseSelect },
				{ field: 'autoId', title: this.resources.auto, collection: this.options.autos, defaultText: this.resources.pleaseSelect },
				{ field: 'status', title: this.resources.status },
                { field: 'comment', title: this.resources.comment },
			];
		},
		
		render: function () {
		    var self = this;

		    view.__super__.render.apply(self, arguments);

		    self.grid.bind('edit', function (e) {
		        e.model.orderId = self.model.id;
		    });

		    return self;
		},

		events: {
		    //'click .print': function (e) {

		    //    e.preventDefault();
		    //    var self = this,
            //        grid = self.grid,
			//		dataItem = grid.dataItem(grid.select());

		    //    if (dataItem != undefined) {

		    //        location.href = Application.apiUrl + 'print/?printTypeId=XXX&id=' + dataItem.id;
		    //    }
		    //    else {
		    //        require(['base/information-view'], function (View) {
		    //            var view = new View({
		    //                title: ' auswählen',
		    //                message: 'Wählen Sie bitte eine  aus!'
		    //            });
		    //            self.addView(view);
		    //            self.$el.append(view.render().$el);
		    //        });
		    //    }
		    //},
		},

		toolbar: function () {
		    var self = this,
		        result =
		    [{
		        template: function () {
		            return '<a class="k-button k-button-icontext k-grid-create-inline" href="#" data-localized="add"></a>';
		        }
		    }];

		    return result;
		}
	});

	return view;
});
