define([
    'base/related-object-grid-view',
    'collections/Positions',
    'l!t!Orders/SelectProduct',
    'l!t!Orders/SelectMaterial',
    'l!t!Orders/Materials',
], function (BaseView, Collection, SelectProductView, SelectMaterialView, DetailView) {
    'use strict';

    var descriptionEditor = function (container, options) {
        if (options.model.get('containerId') == null) {
            $('<input type="text" class="k-textbox" required data-text-field="' + options.field + '" data-value-field="' + options.field + '" data-bind="value:' + options.field + '"/>')
                .appendTo(container);

            //$('<span class="k-widget k-numerictextbox">' +
            //    '<span class="k-numeric-wrap k-state-default">' +
            //        '<input tabindex="0" class="k-formatted-value k-input" aria-disabled="false" aria-readonly="false" style="display: inline-block;" type="text">' +
            //        '<input class="k-input" role="spinbutton" aria-disabled="false" aria-readonly="false" aria-valuenow="-1" style="display: none;" required="required" type="text" data-role="numerictextbox" data-bind="value:amount" data-value-field="amount" data-text-field="amount">' +
            //        '<span class="k-select"><span class="k-link" style="-ms-touch-action: double-tap-zoom pinch-zoom;" unselectable="on">' +
            //            '<span title="Wert erhöhen" class="k-icon k-i-arrow-n" unselectable="on">Wert erhöhen</span>' +
            //        '</span>' +
            //        '<div class="k-widget k-tooltip k-tooltip-validation k-invalid-msg" role="alert" style="margin: 0.5em; display: none;" data-for="_amount_"><span class="k-icon k-warning"> </span>Das Feld muss befüllt werden<div class="k-callout k-callout-n"></div></div>' +
            //        '<span class="k-link" style="-ms-touch-action: double-tap-zoom pinch-zoom;" unselectable="on">' +
            //            '<span title="Wert verkleinern" class="k-icon k-i-arrow-s" unselectable="on">Wert verkleinern</span>' +
            //        '</span>' +
            //    '</span>' +
            //'</span></span>' +
            //'<div class="k-widget k-tooltip k-tooltip-validation k-invalid-msg" style="margin: 0.5em; display: none;" data-for="' +
            //    options.field + '" role="alert"><span class="k-icon k-warning"> </span>Das Feld muss befüllt werden<div class="k-callout k-callout-n"></div></div>').appendTo(container);
            ////$('<div class="k-widget k-tooltip k-tooltip-validation k-invalid-msg" style="margin: 0.5em; display: none;" data-for="' +
            ////    options.field + '" role="alert"><span class="k-icon k-warning"> </span>Das Feld muss befüllt werden<div class="k-callout k-callout-n"></div></div>').appendTo(container);
        }
        else {
            $('<span>' + options.model.get(options.field) + '</span>').appendTo(container);
        }
    },

    deleteAllPositions = function (dataItem) {
        var self = this;

        var model = new Backbone.Model();
        model.url = Application.apiUrl + 'deleteAllOrderPositions';

        model.set('id', self.model.id);
        model.set('parentId', self.model.id);
        model.set('isMaterialPosition', self.model.isMaterialPosition);

        model.save({}, {
            success: function (model, response) {
                self.grid.dataSource.read();
                self.grid.refresh();
            },
            error: function (model, response) {

                require(['base/information-view'], function (View) {
                    var view = new View({
                        title: 'Alle Positionen löschen',
                        message: 'Alle Positionen in dem ausgewählte Auftrag konnten nicht gelöscht werden.'
                    });
                    self.addView(view);
                    self.$el.append(view.render().$el);
                });
            }
        });
    },

    initDetailView = function (e) {

        var self = this;

        if (e.data.productId != null && e.data.productId != undefined) {
            var options = _.extend({}, self.options, { model: e.data }),
                view = new self.detailView(options);

            self.addView(view);
            e.detailRow.find('.detailsContainer').append(view.render().$el);

            e.masterRow.data('detail-view', view);
        }
    },


    view = BaseView.extend({

        isMaterialPosition: null,
        parentId: null,
        selectProductView: SelectProductView,
        selectMaterialView: SelectMaterialView,
        collectionType: Collection,
        gridSelector: '.grid',
        tableName: 'Positions',

        addingInPopup: false,

        initDetailView: initDetailView,
        detailView: DetailView,


        initialize: function () {
            view.__super__.initialize.apply(this, arguments);

            var self = this;

            this.defaultFiltering = [
                { field: 'orderId', operator: 'eq', value: this.model.orderId },
                { field: 'isMaterialPosition', operator: 'eq', value: self.options.isMaterialPosition },
                { field: 'parentId', operator: 'eq', value: self.options.parentId },
            ];

            this.collection = new Collection();
        },

        columns: function () {

            var columns = [
                { field: 'positionNumber', title: this.resources.positionNumber, filterable: false, sortable: false, width: '40px', attributes: { "class": "detail-view-grid-cell" } },
                { field: 'isAlternative', title: this.resources.isAlternative, headerTitle: this.resources.isAlternativeTitle, checkbox: true, width: '45px', attributes: { "class": "detail-view-grid-cell" } },
                { field: 'number', title: this.resources.number, width: '100px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                //{ field: 'description', title: this.resources.description, filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                {
                    field: 'description',
                    editor: descriptionEditor, template: "#=description#",
                    title: this.resources.description,
                    attributes: { "class": "detail-view-grid-cell" },
                    width: '300px',
                    filterable: false, sortable: false
                },
                { field: 'amount', title: this.resources.amount, width: '70px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
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

                if (e.model.id == 0)
                    e.model.isNew = function () { return true; }

                e.model.orderId = self.model.orderId;
            });

            return self;
        },

        events: {
            'click .selectInnerProducts': function (e) {
                e.preventDefault();

                var self = this,
                    options = _.extend({ selectInnerProduct: true }, self.options),
                    view = new SelectProductView(options);

                self.listenTo(view, 'selectInnerProduct', function (item) {

                    var model = new Backbone.Model();
                    model.isNew = function () { return true; }
                    model.url = Application.apiUrl + '/positions';
                    model.set('orderId', self.model.orderId);
                    model.set('productId', item.id);
                    model.set('price', item.get('price'));
                    model.set('amount', 1);
                    model.set('isMaterialPosition', self.options.isMaterialPosition);
                    model.set('isAlternarive', false);
                    model.set('parentId', self.options.parentId);

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
            'click .selectInnerMaterials': function (e) {
                e.preventDefault();

                var self = this,
                    options = _.extend({ selectInnerMaterial: true }, self.options),
                    view = new SelectMaterialView(self.options);

                self.listenTo(view, 'selectInnerMaterial', function (item) {

                    var model = new Backbone.Model();
                    model.isNew = function () { return true; }
                    model.url = Application.apiUrl + '/positions';
                    model.set('orderId', self.model.orderId);
                    model.set('materialId', item.id);
                    model.set('price', item.get('price'));
                    model.set('amount', 1);
                    model.set('isMaterialPosition', self.options.isMaterialPosition);
                    model.set('isAlternarive', false);
                    model.set('parentId', self.options.parentId);

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
            'click .deleteAllInnerPositions': function (e) {
                e.preventDefault();

                var self = this;

                require(['base/confirmation-view'], function (View) {

                    var view = new View({
                        title: 'Alle Positionen löschen',
                        message: 'Möchten Sie alle Positionen in dem ausgewählten Auftrag löschen?'
                    });

                    self.listenTo(view, 'continue', _.bind(deleteAllPositions, self));
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
		            return '<a class="k-button k-button-icontext ' +
                        (self.isMaterialPosition ? 'selectInnerMaterials' : 'selectInnerProducts') + '" style="min-width: 180px;" href="#" data-localized="' +
                        (self.isMaterialPosition ? 'addMaterial' : 'addProduct') + '"></a>' +
		            '<a class="k-button k-button-icontext deleteAllInnerPositions"  style="min-width: 120px;"href="#" data-localized="deleteAllPositions"></a>';
		        }
		    }];

            return result;
        }
    });

    return view;
});
