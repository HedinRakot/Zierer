define([
	'base/base-object-add-view',
    
], function (BaseView ) {
    'use strict';

    var view = BaseView.extend({

        
        tableName: 'ProductMaterialRsp',
        actionUrl: '#ProductMaterialRsps',

		bindings: function () {

            var self = this;
            var result = {
			'#productId': 'productId',
			'#materialId': 'materialId',
			'#amount': 'amount',
			};

            return result;
		},

        render: function () {

            view.__super__.render.apply(this, arguments);

			//TODO foreach model field
			this.disableInput(this, 'productId', 'numeric');
			this.disableInput(this, 'amount', 'numeric');

            return this;
        }
    });

    return view;
});
