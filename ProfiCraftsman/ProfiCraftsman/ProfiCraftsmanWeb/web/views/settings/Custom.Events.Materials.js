define([
	
], function () {
    'use strict';

    var events = {        
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