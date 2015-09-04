define([

], function () {
    'use strict';

    var events = {
        'click .selectMaterial': function (e) {
            e.preventDefault();

            var self = this;

            require(['l!t!Orders/SelectMaterial'], function (View) {

                var options = _.extend({}, self.options),
                view = new View(options);

                self.listenTo(view, 'selectMaterial', function (item) {

                    var model = new Backbone.Model();
                    model.isNew = function () { return true; }
                    model.url = Application.apiUrl + '/productMaterialRsps';
                    model.set('productId', self.model.id);
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
    };

    return events;
});