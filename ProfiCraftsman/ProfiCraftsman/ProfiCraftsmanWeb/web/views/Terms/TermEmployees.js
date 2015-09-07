define([
    'base/related-object-grid-view',
    'collections/Terms/TermEmployees',
    'l!t!Terms/SelectEmployee',
], function (BaseView, Collection, SelectEmployeeView) {
    'use strict';

    var view = BaseView.extend({

        collectionType: Collection,
        gridSelector: '.grid',
        tableName: 'TermEmployees',

        addingInPopup: false,
        showEditButton: false,
        
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
                { field: 'employeeId', title: this.resources.employee, collection: this.options.employees, defaultText: this.resources.pleaseSelect, attributes: { "class": "detail-view-grid-cell" } },
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
            'click .selectEmployees': function (e) {
                e.preventDefault();

                var self = this,
                options = _.extend({}, self.options);

                var view = new SelectEmployeeView(options);

                self.listenTo(view, 'selectEmployee', function (item) {

                    var model = new Backbone.Model();
                    model.isNew = function () { return true; }
                    model.url = Application.apiUrl + '/termEmployees';
                    model.set('termId', self.model.id);
                    model.set('employeeId', item.id);

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
		            return '<a class="k-button k-button-icontext selectEmployees" style="min-width: 180px;" href="#" data-localized="add"></a>';
		        }
		    }];

            return result;
        }
    });

    return view;
});
