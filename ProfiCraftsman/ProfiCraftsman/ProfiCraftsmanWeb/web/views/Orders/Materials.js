define([
    'base/related-object-grid-view',
    'collections/Materials'
], function (BaseView, Collection) {
    'use strict';

    var view = BaseView.extend({

        collectionType: Collection,
        gridSelector: '.grid',
        tableName: 'PositionMaterialRsps',

        addingInPopup: false,

        initialize: function () {
            view.__super__.initialize.apply(this, arguments);

            this.defaultFiltering = [
                { field: 'positionId', operator: 'eq', value: this.model.id }];

            this.collection = new Collection();
        },

        columns: function () {

            return [
                 { field: 'materialId', title: this.resources.materialId, collection: this.options.materials, defaultText: this.resources.pleaseSelect, attributes: { "class": "detail-view-grid-cell" } },
                 { field: 'amount', title: this.resources.amount, attributes: { "class": "detail-view-grid-cell" } },
            ];
        },

        render: function () {
            var self = this;

            view.__super__.render.apply(self, arguments);

            self.grid.bind('edit', function (e) {

                e.model.positionId = self.model.id;
            });

            return self;
        }
    });

    return view;
});
