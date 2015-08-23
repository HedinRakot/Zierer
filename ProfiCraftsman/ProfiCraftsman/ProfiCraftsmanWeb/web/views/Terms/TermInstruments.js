define([
    'base/related-object-grid-view',
    'collections/Terms/TermInstruments',
], function (BaseView, Collection) {
    'use strict';

    var view = BaseView.extend({

        collectionType: Collection,
        gridSelector: '.grid',
        tableName: 'TermInstruments',

        addingInPopup: false,
        
        initialize: function () {
            view.__super__.initialize.apply(this, arguments);

            var self = this;

            this.defaultFiltering = [
                { field: 'termId', operator: 'eq', value: this.model.id },
            ];

            this.collection = new Collection();
        },

        columns: function () {

            var columns = [
                { field: 'instrumentId', title: this.resources.description, collection: this.options.instruments, defaultText: this.resources.pleaseSelect, attributes: { "class": "detail-view-grid-cell" } },
            ];

            return columns;
        },

        render: function () {
            var self = this;

            view.__super__.render.apply(self, arguments);
            
            self.grid.bind('edit', function (e) {
                
                e.model.termId = self.model.id;
            });

            return self;
        },
    });

    return view;
});
