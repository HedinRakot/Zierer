define([
	'base/base-object-add-view',
    
], function (BaseView ) {
    'use strict';

    var view = BaseView.extend({

        
        tableName: 'ProductEquipmentRsp',
        actionUrl: '#ProductEquipmentRsps',

		bindings: function () {

            var self = this;
            var result = {
			'#productId': 'productId',
			'#equipmentId': { observe: 'equipmentId',
				selectOptions: { labelPath: 'name', valuePath: 'id',
				collection: self.options.equipments
				,defaultOption: {label: self.resources.pleaseSelect,value: null}},},
			'#amount': 'amount',
			};

            return result;
		},

        render: function () {

            view.__super__.render.apply(this, arguments);

			//TODO foreach model field
			this.disableInput(this, 'productId', 'numeric');
			this.disableInput(this, 'equipmentId', 'select');
			this.disableInput(this, 'amount', 'numeric');

            return this;
        }
    });

    return view;
});
