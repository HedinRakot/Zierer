define([
    'base/related-object-grid-view',
    'collections/Terms/TermCosts',
    'l!t!Terms/SelectCustomProduct',
], function (BaseView, Collection, SelectCustomProductView) {
    'use strict';

    var view = BaseView.extend({

        collectionType: Collection,
        gridSelector: '.grid',
        tableName: 'TermCosts',

        addingInPopup: false,
        
        initialize: function () {
            view.__super__.initialize.apply(this, arguments);

            var self = this;

            this.defaultFiltering = [
                { field: 'termId', operator: 'eq', value: this.model.id },
            ];

            this.collection = new Collection();
        },

        columns: function () {

            var columns = [
                { field: 'name', title: this.resources.name, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'price', title: this.resources.price, attributes: { "class": "detail-view-grid-cell" } },
            ];

            return columns;
        },

        render: function () {
            var self = this;

            view.__super__.render.apply(self, arguments);
            
            self.grid.bind('edit', function (e) {
                
                e.model.termId = self.model.id;
            });

            return self;
        },

        events: {
            'click .selectCustomProducts': function (e) {
                e.preventDefault();

                var self = this,
                options = _.extend({}, self.options);

                var view = new SelectCustomProductView(options);

                self.listenTo(view, 'selectCustomProduct', function (item) {

                    var model = new Backbone.Model();
                    model.isNew = function () { return true; }
                    model.url = Application.apiUrl + '/termCosts';
                    model.set('termId', self.model.id);
                    model.set('price', item.get('price'));
                    model.set('name', item.get('name'));

                    model.save({}, {
                        data: kendo.stringify(model),
                        method: 'post',
                        contentType: 'application/json',
                        success: function (response) {
                            self.grid.dataSource.read();
                            self.grid.refresh();
                        },
                        error: function (model, response) {
                            //TODO
                        }
                    });
                });

                self.addView(view);
                self.$el.append(view.render().$el);
            },
        },

        toolbar: function () {
            var self = this,
		        result =
		    [{
		        template: function () {
		            return '<a class="k-button k-button-icontext k-grid-create-inline" href="#" data-localized="add"></a>' +
                           '<a class="k-button k-button-icontext selectCustomProducts" style="min-width: 180px;" href="#" data-localized="addCustomProduct"></a>';
		        }
		    }];

            return result;
        }
    });

    return view;
});
