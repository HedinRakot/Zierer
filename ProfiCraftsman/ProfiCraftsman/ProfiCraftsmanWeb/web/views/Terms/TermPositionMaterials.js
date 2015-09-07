define([
    'base/related-object-grid-view',
    'collections/Terms/TermPositionMaterials',
    'l!t!Orders/SelectMaterial',
], function (BaseView, Collection, SelectMaterialView) {
    'use strict';

    var view = BaseView.extend({

        collectionType: Collection,
        gridSelector: '.grid',
        tableName: 'TermPositionMaterialRsps',

        addingInPopup: false,

        initialize: function () {
            view.__super__.initialize.apply(this, arguments);

            this.defaultFiltering = [
                { field: 'termPositionId', operator: 'eq', value: this.model.id }];

            this.collection = new Collection();
        },

        columns: function () {

            return [
                 { field: 'materialName', title: this.resources.materialId, attributes: { "class": "detail-view-grid-cell" } },
                 { field: 'amount', title: this.resources.amount, attributes: { "class": "detail-view-grid-cell" } },
            ];
        },

        render: function () {
            var self = this;

            view.__super__.render.apply(self, arguments);

            self.grid.bind('edit', function (e) {

                e.model.termPositionId = self.model.id;
            });

            return self;
        },

        events: {
            'click .selectPositionMaterials': function (e) {
                e.preventDefault();

                var self = this,
                    options = _.extend({ selectPositionMaterial: true }, self.options),
                    view = new SelectMaterialView(options);

                self.listenTo(view, 'selectPositionMaterial', function (item) {

                    var model = new Backbone.Model();
                    model.isNew = function () { return true; }
                    model.url = Application.apiUrl + '/positionMaterials';
                    model.set('positionId', self.model.id);
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
            },
        },

        toolbar: function () {
            var self = this,
		        result =
		    [{
		        template: function () {
		            return '<a class="k-button k-button-icontext selectPositionMaterials" href="javascript:void(0)" data-localized="add"></a>';
		        }
		    }];

            return result;
        }
    });

    return view;
});
