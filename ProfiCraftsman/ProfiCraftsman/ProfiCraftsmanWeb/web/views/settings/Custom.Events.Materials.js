define([
	
], function () {
    'use strict';

    var copyProduct = function (dataItem) {
        var self = this;

        var model = new Backbone.Model();
        model.url = Application.apiUrl + 'copyProduct';
        model.set('id', dataItem.id);
        model.save({}, {
            success: function (model, response) {

                if (model.id != 0)
                    location.href = '#Products/' + model.id;
                else {
                    require(['base/information-view'], function (View) {
                        var view = new View({
                            title: 'Produkt kopieren',
                            message: "Das ausgewählte Produkt konnte nicht kopiert werden."
                        });
                        self.addView(view);
                        self.$el.append(view.render().$el);
                    });
                }
            },
            error: function (model, response) {

                require(['base/information-view'], function (View) {
                    var view = new View({
                        title: 'Produkt kopieren',
                        message: 'Das ausgewählte Produkt konnte nicht kopiert werden.'
                    });
                    self.addView(view);
                    self.$el.append(view.render().$el);
                });
            }
        });
    },

    events = {        
        'click .import-materials': function () {
            var self = this;

            require(['l!t!Settings/ImportMaterials'], function (View) {
                var view = new View();
                self.listenToOnce(view, 'close', function () {
                    self.grid.dataSource.read();
                    self.grid.refresh();
                });

                self.addView(view);
                self.$el.append(view.render().$el);
            });
        },
    };

    return events;
});