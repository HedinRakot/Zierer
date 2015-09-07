define([
    'base/related-object-grid-view',
    'collections/Positions',
    'l!t!Orders/SelectProduct',
    'l!t!Orders/SelectMaterial',
    'l!t!Orders/InnerPositions'
], function (BaseView, Collection, SelectProductView, SelectMaterialView, DetailView) {
    'use strict';

    var floatEditor = function (container, options) {
        if ((options.model.get('productId') != null && options.model.get('productId') != 0) ||
            (options.model.get('materialId') != null && options.model.get('materialId') != 0)) {
            $('<input data-role="numerictextbox" required data-text-field="' + options.field + '" data-value-field="' + options.field + '" data-bind="value:' + options.field + '"/>')
                .appendTo(container);
        }
        else {
            $('<span></span>').appendTo(container);
        }
    },

    priceTypeEditor = function (container, options) {

        if ((options.model.get('productId') != null && options.model.get('productId') != 0) ||
            (options.model.get('materialId') != null && options.model.get('materialId') != 0)) {

            $('<span tabindex="0" class="k-widget k-dropdown k-header" role="listbox" aria-busy="false" aria-disabled="false" aria-expanded="false" aria-haspopup="true" aria-readonly="false" aria-owns="" unselectable="on"><span class="k-dropdown-wrap k-state-default" unselectable="on">' + 
              '<span class="k-input" unselectable="on">Standard</span><span class="k-select" unselectable="on"><span class="k-icon k-i-arrow-s" unselectable="on">select</span></span></span>' +
              '<select name="paymentType" style="display: none;" required="required" data-role="dropdownlist" data-bind="value:paymentType">' + 
              '<option selected="selected" value="0">Standard</option><option value="1">Pauschal</option></select></span>' +
              '<div class="k-widget k-tooltip k-tooltip-validation k-invalid-msg" role="alert" style="margin: 0.5em; display: none;" data-for="paymentType">' + 
              '<span class="k-icon k-warning"> </span>Das Feld muss befüllt werden<div class="k-callout k-callout-n"></div></div>')
                .appendTo(container);
        }
        else {
            $('<span></span>').appendTo(container);
        }
    },

    booleanEditor = function (container, options) {

        if ((options.model.get('productId') != null && options.model.get('productId') != 0) ||
            (options.model.get('materialId') != null && options.model.get('materialId') != 0)) {
            $('<input name="' + options.field + '" type="checkbox" data-type="boolean" data-bind="checked:' + options.field + '">')
                .appendTo(container);
        }
        else {
            $('<input name="' + options.field + '" type="checkbox" data-type="boolean" disabled="disabled" data-bind="checked:' + options.field + '">')
                .appendTo(container);
        }
    },

    deleteAllPositions = function (dataItem) {
        var self = this;

        var model = new Backbone.Model();
        model.url = Application.apiUrl + 'deleteAllOrderPositions';
        model.set('id', self.model.id);
        model.set('isMaterialPosition', self.isMaterialPosition);

        model.save({}, {
            success: function (model, response) {
                self.grid.dataSource.read();
                self.grid.refresh();
            },
            error: function (model, response) {

                require(['base/information-view'], function (View) {
                    var view = new View({
                        title: 'Alle Positionen löschen',
                        message: 'Alle Positionen in dem ausgewählten Auftrag konnten nicht gelöscht werden.'
                    });
                    self.addView(view);
                    self.$el.append(view.render().$el);
                });
            }
        });
    },

    initDetailView = function (e) {

        var self = this;

        if((e.data.productId == null || e.data.productId == undefined) &&
           (e.data.materialId == null || e.data.materialId == undefined))
        {
            var options = _.extend({}, self.options,
                {
                    model: e.data,
                    isMaterialPosition: self.isMaterialPosition,
                    parentId: e.data.id
                }),
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
                { field: 'orderId', operator: 'eq', value: this.model.id },
                { field: 'isMaterialPosition', operator: 'eq', value: self.isMaterialPosition },
                { field: 'hasParent', operator: 'eq', value: false },
            ];

            this.collection = new Collection();
        },

        columns: function () {

            var columns = [
                { field: 'positionNumber', title: this.resources.positionNumber, filterable: false, sortable: false, width: '40px', attributes: { "class": "detail-view-grid-cell" } },
                //{ field: 'isAlternative', title: this.resources.isAlternative, headerTitle: this.resources.isAlternativeTitle, checkbox: true, width: '45px', attributes: { "class": "detail-view-grid-cell" } },
                {
                    field: 'isAlternative',
                    editor: booleanEditor,
                    template: '<input name="isAlternative" type="checkbox" disabled="disabled" #= isAlternative ? "checked" : "" #>',
                    title: this.resources.isAlternative,
                    attributes: { "class": "detail-view-grid-cell" },
                    width: '45px',
                    filterable: false, sortable: false
                },
                { field: 'number', title: this.resources.number, width: '100px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'description', title: this.resources.description, filterable: false, sortable: false, width: '300px', attributes: { "class": "detail-view-grid-cell" } },
                {
                    field: 'amount',
                    editor: floatEditor, template: "#=amountString#",
                    title: this.resources.amount,
                    attributes: { "class": "detail-view-grid-cell" },
                    width: '70px',
                    filterable: false, sortable: false
                },
                //{ field: 'amount', title: this.resources.amount, width: '70px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'amountType', title: this.resources.amountType, width: '70px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                //{ field: 'price', title: this.resources.price, width: '80px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
                {
                    field: 'price',
                    editor: floatEditor, template: "#=priceString#",
                    title: this.resources.price,
                    attributes: { "class": "detail-view-grid-cell" },
                    width: '80px',
                    filterable: false, sortable: false
                },
                //{ field: 'paymentType', title: this.resources.paymentType, filterable: false, sortable: false, collection: this.options.paymentTypes, width: '60px', attributes: { "class": "detail-view-grid-cell" } },
                {
                    field: 'paymentType',
                    editor: priceTypeEditor, template: "#=paymentTypeString#",
                    title: this.resources.paymentType,
                    attributes: { "class": "detail-view-grid-cell" },
                    width: '80px',
                    filterable: false, sortable: false
                },
                { field: 'totalPrice', title: this.resources.totalPrice, width: '80px', filterable: false, sortable: false, attributes: { "class": "detail-view-grid-cell" } },
            ];

            return columns;
        },

        render: function () {
            var self = this;

            view.__super__.render.apply(self, arguments);
            
            self.grid.bind('edit', function (e) {

                e.model.orderId = self.model.id;
                e.model.isMaterialPosition = self.isMaterialPosition;
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
            'click .selectProducts': function (e) {
                e.preventDefault();

                var self = this,
                options = _.extend({}, self.options);

                var view = new SelectProductView(options);

                self.listenTo(view, 'selectProduct', function (item) {

                    var model = new Backbone.Model();
                    model.isNew = function () { return true; }
                    model.url = Application.apiUrl + '/positions';
                    model.set('orderId', self.model.id);
                    model.set('productId', item.id);
                    model.set('price', item.get('price'));
                    model.set('amount', 1);
                    model.set('isMaterialPosition', self.isMaterialPosition);
                    model.set('isAlternarive', false);

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
            'click .selectMaterials': function (e) {
                e.preventDefault();

                var self = this,
                    view = new SelectMaterialView(self.options);

                self.listenTo(view, 'selectMaterial', function (item) {

                    var model = new Backbone.Model();
                    model.isNew = function () { return true; }
                    model.url = Application.apiUrl + '/positions';
                    model.set('orderId', self.model.id);
                    model.set('materialId', item.id);
                    model.set('price', item.get('price'));
                    model.set('amount', 1);
                    model.set('isMaterialPosition', self.isMaterialPosition);
                    model.set('isAlternarive', false);

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
            'click .deleteAllPositions': function (e) {
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
                        (self.isMaterialPosition ? 'selectMaterials' : 'selectProducts') + '" style="min-width: 180px;" href="#" data-localized="' +
                        (self.isMaterialPosition ? 'addMaterial' : 'addProduct') + '"></a>' +
                    '<a class="k-button k-button-icontext k-grid-create-inline" href="#" data-localized="addGroup" style="min-width: 180px;"></a>' +
		            '<a class="k-button k-button-icontext deleteAllPositions"  style="min-width: 120px;"href="#" data-localized="deleteAllPositions"></a>';
		        }
		    }];

            return result;
        }
    });

    return view;
});
