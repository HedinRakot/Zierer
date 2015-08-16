define([
    'base-router'
], function (BaseRouter) {
	'use strict';
    
	var factory = {
	    
	    getAllMasterDataRoutes: function(baseRouter)
	    {
	        var routes = {
				'Permissions': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Permissions', false, false),
	            'Permissions/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddPermission', 'models/Settings/Permission', false, false),
	            'Permissions/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddPermission', 'models/Settings/Permission', false, false),
				'Roles': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Roles', { Permission: true, Role: true, }, false),
	            'Roles/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddRole', 'models/Settings/Role', { Permission: true, Role: true, }, false),
	            'Roles/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddRole', 'models/Settings/Role', { Permission: true, Role: true, }, false),
				'RolePermissionRsps': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/RolePermissionRsps', { Permission: true, Role: true, }, false),
	            'RolePermissionRsps/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddRolePermissionRsp', 'models/Settings/RolePermissionRsp', { Permission: true, Role: true, }, false),
	            'RolePermissionRsps/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddRolePermissionRsp', 'models/Settings/RolePermissionRsp', { Permission: true, Role: true, }, false),
				'Users': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Users', { Role: true, }, false),
	            'Users/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddUser', 'models/Settings/User', { Role: true, }, false),
	            'Users/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddUser', 'models/Settings/User', { Role: true, }, false),
				'Equipments': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Equipments', false, false),
	            'Equipments/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddEquipments', 'models/Settings/Equipments', false, false),
	            'Equipments/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddEquipments', 'models/Settings/Equipments', false, false),
				'AdditionalCosts': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/AdditionalCosts', false, false),
	            'AdditionalCosts/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddAdditionalCosts', 'models/Settings/AdditionalCosts', false, false),
	            'AdditionalCosts/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddAdditionalCosts', 'models/Settings/AdditionalCosts', false, false),
				'Taxes': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Taxes', false, false),
	            'Taxes/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddTaxes', 'models/Settings/Taxes', false, false),
	            'Taxes/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddTaxes', 'models/Settings/Taxes', false, false),
				'TransportProducts': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/TransportProducts', false, false),
	            'TransportProducts/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddTransportProducts', 'models/Settings/TransportProducts', false, false),
	            'TransportProducts/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddTransportProducts', 'models/Settings/TransportProducts', false, false),
				'Customers': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Customers', false, false),
	            'Customers/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddCustomers', 'models/Settings/Customers', false, false),
	            'Customers/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddCustomers', 'models/Settings/Customers', false, false),
				'CommunicationPartners': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/CommunicationPartners', false, false),
	            'CommunicationPartners/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddCommunicationPartners', 'models/Settings/CommunicationPartners', false, false),
	            'CommunicationPartners/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddCommunicationPartners', 'models/Settings/CommunicationPartners', false, false),
				'ProductTypes': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/ProductTypes', { Equipments: true, }, false),
	            'ProductTypes/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProductTypes', 'models/Settings/ProductTypes', { Equipments: true, }, false),
	            'ProductTypes/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProductTypes', 'models/Settings/ProductTypes', { Equipments: true, }, false),
				'ProductTypeEquipmentRsps': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/ProductTypeEquipmentRsps', { Equipments: true, }, false),
	            'ProductTypeEquipmentRsps/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProductTypeEquipmentRsp', 'models/Settings/ProductTypeEquipmentRsp', { Equipments: true, }, false),
	            'ProductTypeEquipmentRsps/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProductTypeEquipmentRsp', 'models/Settings/ProductTypeEquipmentRsp', { Equipments: true, }, false),
				'Products': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Products', { Equipments: true, ProductTypes: true, }, false),
	            'Products/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProducts', 'models/Settings/Products', { Equipments: true, ProductTypes: true, }, false),
	            'Products/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProducts', 'models/Settings/Products', { Equipments: true, ProductTypes: true, }, false),
				'ProductEquipmentRsps': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/ProductEquipmentRsps', { Equipments: true, }, false),
	            'ProductEquipmentRsps/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProductEquipmentRsp', 'models/Settings/ProductEquipmentRsp', { Equipments: true, }, false),
	            'ProductEquipmentRsps/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProductEquipmentRsp', 'models/Settings/ProductEquipmentRsp', { Equipments: true, }, false),
			}
        
	        return routes;
	    }
	};

	return factory;
});
