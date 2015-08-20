define([
    'base-router'
], function (BaseRouter) {
	'use strict';
    
	var factory = {
	    
	    getAllMasterDataRoutes: function(baseRouter)
	    {
	        var routes = {
				'Materials': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Materials', { MaterialAmountTypes: true, }, false),
	            'Materials/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddMaterials', 'models/Settings/Materials', { MaterialAmountTypes: true, }, false),
	            'Materials/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddMaterials', 'models/Settings/Materials', { MaterialAmountTypes: true, }, false),
				'ProductMaterialRsps': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/ProductMaterialRsps', { Materials: true, }, false),
	            'ProductMaterialRsps/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProductMaterialRsp', 'models/Settings/ProductMaterialRsp', { Materials: true, }, false),
	            'ProductMaterialRsps/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProductMaterialRsp', 'models/Settings/ProductMaterialRsp', { Materials: true, }, false),
				'Autos': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Autos', false, false),
	            'Autos/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddAutos', 'models/Settings/Autos', false, false),
	            'Autos/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddAutos', 'models/Settings/Autos', false, false),
				'Permissions': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Permissions', false, false),
	            'Permissions/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddPermission', 'models/Settings/Permission', false, false),
	            'Permissions/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddPermission', 'models/Settings/Permission', false, false),
				'JobPositions': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/JobPositions', false, false),
	            'JobPositions/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddJobPositions', 'models/Settings/JobPositions', false, false),
	            'JobPositions/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddJobPositions', 'models/Settings/JobPositions', false, false),
				'Roles': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Roles', { Permission: true, Role: true, }, false),
	            'Roles/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddRole', 'models/Settings/Role', { Permission: true, Role: true, }, false),
	            'Roles/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddRole', 'models/Settings/Role', { Permission: true, Role: true, }, false),
				'Employees': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Employees', { Autos: true, JobPositions: true, }, false),
	            'Employees/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddEmployees', 'models/Settings/Employees', { Autos: true, JobPositions: true, }, false),
	            'Employees/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddEmployees', 'models/Settings/Employees', { Autos: true, JobPositions: true, }, false),
				'RolePermissionRsps': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/RolePermissionRsps', { Permission: true, Role: true, }, false),
	            'RolePermissionRsps/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddRolePermissionRsp', 'models/Settings/RolePermissionRsp', { Permission: true, Role: true, }, false),
	            'RolePermissionRsps/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddRolePermissionRsp', 'models/Settings/RolePermissionRsp', { Permission: true, Role: true, }, false),
				'Users': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Users', { Role: true, Employees: true, }, false),
	            'Users/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddUser', 'models/Settings/User', { Role: true, Employees: true, }, false),
	            'Users/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddUser', 'models/Settings/User', { Role: true, Employees: true, }, false),
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
				'ProductTypes': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/ProductTypes', false, false),
	            'ProductTypes/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProductTypes', 'models/Settings/ProductTypes', false, false),
	            'ProductTypes/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProductTypes', 'models/Settings/ProductTypes', false, false),
				'Products': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Products', { Materials: true, ProductTypes: true, ProductAmountTypes: true, }, false),
	            'Products/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProducts', 'models/Settings/Products', { Materials: true, ProductTypes: true, ProductAmountTypes: true, }, false),
	            'Products/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProducts', 'models/Settings/Products', { Materials: true, ProductTypes: true, ProductAmountTypes: true, }, false),
			}
        
	        return routes;
	    }
	};

	return factory;
});
