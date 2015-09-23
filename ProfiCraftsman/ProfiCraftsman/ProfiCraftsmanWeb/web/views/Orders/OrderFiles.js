define([	
    'base/related-object-grid-view',
    'collections/OrderFiles',
], function (BaseView, Collection) {
	'use strict';

    var view = BaseView.extend({

		collectionType: Collection,
		gridSelector: '.grid',
		tableName: 'OrderFiles',
        
		initialize: function() {
			view.__super__.initialize.apply(this, arguments);

			this.defaultFiltering = { field: 'orderId', operator: 'eq', value: this.model.id };

			this.collection = new Collection();
		},

		columns: function () {

		   return [
                {
                    field: 'fileName',
                    template: '<a href="' + Application.apiUrl + 'GetOrderFile/' + '#= id #" target="_blank">#= fileName #</a>',
                    title: this.resources.fileName,
                    attributes: { "class": "detail-view-grid-cell" },
                    filterable: false, sortable: false
                },
                { field: 'comment', title: this.resources.comment, attributes: { "class": "detail-view-grid-cell" } },
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
		    'click .addOrderFile': function (e) {

		        e.preventDefault();
		        var self = this,
                    grid = self.grid;;

		        require(['l!t!Orders/AddFiles'], function (View) {
		            var view = new View({
                        grid: grid,
		                orderId: self.model.id
		            });
		            self.addView(view);
		            self.$el.append(view.render().$el);
		        });
		    },
		},

		toolbar: function () {
		    var self = this,
		        result =
		    [{
		        template: function () {
		            return '<a class="k-button k-button-icontext addOrderFile" href="#" data-localized="add" style="min-width: 160px;"></a>';
		        }
		    }];

		    return result;
		}
	});

	return view;
});
