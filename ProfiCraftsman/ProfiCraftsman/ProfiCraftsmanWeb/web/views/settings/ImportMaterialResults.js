define([
	'base/base-grid-view',
	'backbone.stickit'
], function (BaseView, KendoWidgetForm) {
    var view = BaseView.extend({
        showDeleteButton: false,
        showEditButton: false,
        showAddButton: false,

        sortable: false,
        filterable: false,
        remoteDataSource: false,

        gridSelector: '.grid',

        columns: function () {
            return [
				{ field: "rowNumber", title: 'Zeile Nummer' },
				{ field: "description", title: 'Beschreibung' }
            ]
        },

        bindings: {
            '.createdMaterials': 'createdMaterials',
            '.updatedMaterials': 'updatedMaterials'
        },

        render: function () {
            view.__super__.render.apply(this, arguments);

            this.stickit();

            return this;
        }
    });

    return view;
});