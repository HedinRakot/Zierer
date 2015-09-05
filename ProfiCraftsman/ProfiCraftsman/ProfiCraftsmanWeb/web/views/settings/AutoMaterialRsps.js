define([
    'base/related-object-grid-view',
    'collections/Settings/AutoMaterialRsps',
], function (BaseView, Collection) {
    'use strict';

    var view = BaseView.extend({

        //addNewModelView: AddNewModelView,
        collectionType: Collection,
        gridSelector: '.grid',
        tableName: 'AutoMaterialRsps',

        addingInPopup: false,

        initialize: function () {
            view.__super__.initialize.apply(this, arguments);

            this.defaultFiltering = { field: 'autoId', operator: 'eq', value: this.model.id };

            this.collection = new Collection();
        },

        columns: function () {

            return [
                 { field: 'materialName', title: this.resources.materialId, attributes: { "class": "detail-view-grid-cell" } },
                 { field: 'mustCount', title: this.resources.mustCount, attributes: { "class": "detail-view-grid-cell" } },
                 { field: 'amount', title: this.resources.amount, attributes: { "class": "detail-view-grid-cell" } },
            ];
        },

        render: function () {
            var self = this;

            view.__super__.render.apply(self, arguments);

            self.grid.bind('edit', function (e) {
                e.model.autoId = self.model.id;

                if (e.model.isNew()) {
                    var dt = new Date(2070, 11, 31);
                    e.model.toDate = dt;
                    var numeric = e.container.find("input[name=toDate]");

                    if (numeric != undefined && numeric.length > 0)
                        numeric[0].value = dt.toLocaleDateString();
                }
            });

            return self;
        },

        events: {
            'click .selectMaterial': function (e) {
                e.preventDefault();

                var self = this;

                require(['l!t!Orders/SelectMaterial'], function (View) {

                    var options = _.extend({}, self.options),
                    view = new View(options);

                    self.listenTo(view, 'selectMaterial', function (item) {

                        var model = new Backbone.Model();
                        model.isNew = function () { return true; }
                        model.url = Application.apiUrl + '/autoMaterialRsps';
                        model.set('autoId', self.model.id);
                        model.set('materialId', item.id);
                        model.set('amount', 1);

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
                });
            },
        },

        toolbar: function () {

            var self = this,
                result =
            [{
                template: function () {
                    return '<a class="k-button k-button-icontext selectMaterial" href="javascript:void(0)" data-localized="add"></a>';
                }
            }];

            return result;

        }
    });

    return view;
});
