define([
	
], function () {
    'use strict';

    var events = {
        'dblclick .k-grid tbody tr:not(k-detail-row) td:not(.k-hierarchy-cell,.k-detail-cell,.commands,.detail-view-grid-cell)': function (e) {

            var self = this,
                dataItem = self.grid.dataItem(e.currentTarget.parentElement);

            if (dataItem != undefined && dataItem.id != undefined &&
                dataItem.id != 0) {
                location.href = self.editUrl + '/' + dataItem.id;
            }
        },
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