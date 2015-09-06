define([
    'base/related-object-grid-view',
    'collections/Terms/TermPositions',
    'l!t!Terms/SelectPosition',
], function (BaseView, Collection, SelectPositionView) {
    'use strict';

    var deleteAllTermPositions = function (dataItem) {
        var self = this;

        var model = new Backbone.Model();
        model.url = Application.apiUrl + 'deleteAllTermPositions';
        model.set('id', self.model.id);

        model.save({}, {
            success: function (model, response) {
                self.grid.dataSource.read();
                self.grid.refresh();
            },
            error: function (model, response) {

                require(['base/information-view'], function (View) {
                    var view = new View({
                        title: 'Alle Positionen löschen',
                        message: 'Alle Positionen in dem ausgewählten Termin konnten nicht gelöscht werden.'
                    });
                    self.addView(view);
                    self.$el.append(view.render().$el);
                });
            }
        });
    },

    view = BaseView.extend({

        collectionType: Collection,
        gridSelector: '.grid',
        tableName: 'TermPositions',

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
                { field: 'positionNumber', title: this.resources.positionNumber, filterable: false, sortable: false, width: '40px', attributes: { "class": "detail-view-grid-cell" } },
                { field: 'isAlternative', title: this.resources.isAlternative, headerTitle: this.resources.isAlternativeTitle, checkbox: true, width: '45px', attributes: { "class": "detail-view-grid-cell" } },
                { field: 'number', title: this.resources.number, width: '100px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'description', title: this.resources.description, filterable: false, sortable: false, width: '300px', attributes: { "class": "detail-view-grid-cell" } },
                { field: 'amount', title: this.resources.amount, width: '70px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'proccessedAmount', title: this.resources.proccessedAmount, width: '70px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'amountType', title: this.resources.amountType, width: '70px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'price', title: this.resources.price, width: '80px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'paymentType', title: this.resources.paymentType, filterable: false, sortable: false, collection: this.options.paymentTypes, width: '60px', attributes: { "class": "detail-view-grid-cell" } },
                { field: 'totalPrice', title: this.resources.totalPrice, width: '80px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
            ];

            return columns;
        },

        render: function () {
            var self = this;

            view.__super__.render.apply(self, arguments);
            
            self.grid.bind('edit', function (e) {

                e.model.termId = self.model.id;
            });

            self.grid.bind('dataBinding', function (e) {

                if (e.items) {
                    for (var i = 0; i < e.items.length; i++) {
                        e.items[i].positionNumber = i + 1;
                    }
                }
            });

            return self;
        },

        events: {
            'click .selectPositions': function (e) {
                e.preventDefault();

                var self = this,
                options = _.extend({}, self.options);

                var view = new SelectPositionView(options);

                self.listenTo(view, 'selectPosition', function (item) {

                    var model = new Backbone.Model();
                    model.isNew = function () { return true; }
                    model.url = Application.apiUrl + '/termPositions';
                    model.set('termId', self.model.id);
                    model.set('positionId', item.id);
                    model.set('amount', item.get('amount'));

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
            'click .deleteAllTermPositions': function (e) {
                e.preventDefault();

                var self = this;

                require(['base/confirmation-view'], function (View) {

                    var view = new View({
                        title: 'Alle Positionen löschen',
                        message: 'Möchten Sie alle Positionen in dem ausgewählten Termin löschen?'
                    });

                    self.listenTo(view, 'continue', _.bind(deleteAllTermPositions, self));
                    self.addView(view);
                    self.$el.append(view.render().$el);
                });
            }
        },

        toolbar: function () {
            var self = this,
		        result =
		    [{
		        template: function () {
		            return '<a class="k-button k-button-icontext selectPositions" style="min-width: 180px;" href="#" data-localized="addPosition"></a>' +
		            '<a class="k-button k-button-icontext deleteAllTermPositions"  style="min-width: 120px;"href="#" data-localized="deleteAllTermPositions"></a>';
		        }
		    }];

            return result;
        }
    });

    return view;
});
