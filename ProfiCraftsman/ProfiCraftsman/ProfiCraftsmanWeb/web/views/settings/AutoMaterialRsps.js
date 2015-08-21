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
                 { field: 'materialId', title: this.resources.materialId, collection: this.options.materials, defaultText: this.resources.pleaseSelect, attributes: { "class": "detail-view-grid-cell" } },
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
        }
    });

    return view;
});
