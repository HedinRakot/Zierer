define([
    'base/base-object-grid-view',
    'collections/Warehouse/WarehouseMaterials',
    'l!t!Orders/SelectMaterial',
    'l!t!Warehouse/FilterWarehouseMaterials',
], function (BaseView, Collection, SelectMaterialView, FilterView) {
    'use strict';

    var view = BaseView.extend({

        filterView: FilterView,
        collectionType: Collection,
        gridSelector: '.grid',
        tableName: 'WarehouseMaterials',

        addingInPopup: false,
        showEditButton: true,
        showDeleteButton: true,

        initialize: function () {

            view.__super__.initialize.apply(this, arguments);

            var self = this;
            
            this.collection = new Collection();
        },

        columns: function () {

            return [
                 { field: 'materialNumber', title: this.resources.materialNumber },
                 { field: 'materialName', title: this.resources.materialName },
                 { field: 'mustAmount', title: this.resources.mustAmount },
                 { field: 'isAmount', title: this.resources.isAmount },
            ];
        },

        render: function () {
            var self = this;

            view.__super__.render.apply(self, arguments);
            
            return self;
        },

        events: {

            'click .selectMaterials': function (e) {
                e.preventDefault();

                var self = this,
                    view = new SelectMaterialView(self.options);

                self.listenTo(view, 'selectMaterial', function (item) {


                    var model = new Backbone.Model();
                    model.isNew = function () { return true; }
                    model.url = Application.apiUrl + '/WarehouseMaterials';
                    model.set('materialId', item.id);
                    model.set('isAmount', 0);
                    model.set('mustAmount', 0);

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
		            return '<a class="k-button k-button-icontext selectMaterials" style="min-width: 180px;" href="#" data-localized="addMaterial"></a>';
		        }
		    }];

            return result;
        }
    });

    return view;
});
