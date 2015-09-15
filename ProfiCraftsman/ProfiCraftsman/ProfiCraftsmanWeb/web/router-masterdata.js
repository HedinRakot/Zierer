define([
    'base-router'
], function (BaseRouter) {
	'use strict';
    
	var factory = {
	    
	    getAllMasterDataRoutes: function(baseRouter)
	    {
	        var routes = {
				'AdditionalCostTypes': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/AdditionalCostTypes', false, false),
	            'AdditionalCostTypes/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddAdditionalCostTypes', 'models/Settings/AdditionalCostTypes', false, false),
	            'AdditionalCostTypes/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddAdditionalCostTypes', 'models/Settings/AdditionalCostTypes', false, false),
				'Rates': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Rates', { JobPositions: true, }, false),
	            'Rates/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddRates', 'models/Settings/Rates', { JobPositions: true, }, false),
	            'Rates/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddRates', 'models/Settings/Rates', { JobPositions: true, }, false),
				'EmployeeRateRsps': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/EmployeeRateRsps', { JobPositions: true, SalaryTypes: true, }, false),
	            'EmployeeRateRsps/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddEmployeeRateRsp', 'models/Settings/EmployeeRateRsp', { JobPositions: true, SalaryTypes: true, }, false),
	            'EmployeeRateRsps/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddEmployeeRateRsp', 'models/Settings/EmployeeRateRsp', { JobPositions: true, SalaryTypes: true, }, false),
				'CustomProducts': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/CustomProducts', { ProceedsAccounts: true, }, false),
	            'CustomProducts/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddCustomProducts', 'models/Settings/CustomProducts', { ProceedsAccounts: true, }, false),
	            'CustomProducts/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddCustomProducts', 'models/Settings/CustomProducts', { ProceedsAccounts: true, }, false),
				'ProceedsAccounts': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/ProceedsAccounts', false, false),
	            'ProceedsAccounts/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProceedsAccounts', 'models/Settings/ProceedsAccounts', false, false),
	            'ProceedsAccounts/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProceedsAccounts', 'models/Settings/ProceedsAccounts', false, false),
				'Materials': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Materials', { MaterialAmountTypes: true, ProceedsAccounts: true, }, false),
	            'Materials/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddMaterials', 'models/Settings/Materials', { MaterialAmountTypes: true, ProceedsAccounts: true, }, false),
	            'Materials/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddMaterials', 'models/Settings/Materials', { MaterialAmountTypes: true, ProceedsAccounts: true, }, false),
				'ProductMaterialRsps': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/ProductMaterialRsps', false, false),
	            'ProductMaterialRsps/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProductMaterialRsp', 'models/Settings/ProductMaterialRsp', false, false),
	            'ProductMaterialRsps/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProductMaterialRsp', 'models/Settings/ProductMaterialRsp', false, false),
				'ForeignProducts': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/ForeignProducts', { ProceedsAccounts: true, }, false),
	            'ForeignProducts/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddForeignProducts', 'models/Settings/ForeignProducts', { ProceedsAccounts: true, }, false),
	            'ForeignProducts/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddForeignProducts', 'models/Settings/ForeignProducts', { ProceedsAccounts: true, }, false),
				'SocialTaxes': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/SocialTaxes', { ProceedsAccounts: true, Employees: true, }, false),
	            'SocialTaxes/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddSocialTaxes', 'models/Settings/SocialTaxes', { ProceedsAccounts: true, Employees: true, }, false),
	            'SocialTaxes/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddSocialTaxes', 'models/Settings/SocialTaxes', { ProceedsAccounts: true, Employees: true, }, false),
				'Autos': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Autos', { Instruments: true, }, false),
	            'Autos/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddAutos', 'models/Settings/Autos', { Instruments: true, }, false),
	            'Autos/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddAutos', 'models/Settings/Autos', { Instruments: true, }, false),
				'Permissions': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Permissions', false, false),
	            'Permissions/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddPermission', 'models/Settings/Permission', false, false),
	            'Permissions/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddPermission', 'models/Settings/Permission', false, false),
				'JobPositions': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/JobPositions', false, false),
	            'JobPositions/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddJobPositions', 'models/Settings/JobPositions', false, false),
	            'JobPositions/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddJobPositions', 'models/Settings/JobPositions', false, false),
				'Roles': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Roles', { Permission: true, Role: true, }, false),
	            'Roles/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddRole', 'models/Settings/Role', { Permission: true, Role: true, }, false),
	            'Roles/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddRole', 'models/Settings/Role', { Permission: true, Role: true, }, false),
				'Employees': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Employees', { Autos: true, JobPositions: true, SalaryTypes: true, }, false),
	            'Employees/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddEmployees', 'models/Settings/Employees', { Autos: true, JobPositions: true, SalaryTypes: true, }, false),
	            'Employees/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddEmployees', 'models/Settings/Employees', { Autos: true, JobPositions: true, SalaryTypes: true, }, false),
				'RolePermissionRsps': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/RolePermissionRsps', { Permission: true, Role: true, }, false),
	            'RolePermissionRsps/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddRolePermissionRsp', 'models/Settings/RolePermissionRsp', { Permission: true, Role: true, }, false),
	            'RolePermissionRsps/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddRolePermissionRsp', 'models/Settings/RolePermissionRsp', { Permission: true, Role: true, }, false),
				'Users': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Users', { Role: true, Employees: true, }, false),
	            'Users/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddUser', 'models/Settings/User', { Role: true, Employees: true, }, false),
	            'Users/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddUser', 'models/Settings/User', { Role: true, Employees: true, }, false),
				'AdditionalCosts': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/AdditionalCosts', { AdditionalCostTypes: true, ProceedsAccounts: true, }, false),
	            'AdditionalCosts/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddAdditionalCosts', 'models/Settings/AdditionalCosts', { AdditionalCostTypes: true, ProceedsAccounts: true, }, false),
	            'AdditionalCosts/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddAdditionalCosts', 'models/Settings/AdditionalCosts', { AdditionalCostTypes: true, ProceedsAccounts: true, }, false),
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
				'Instruments': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Instruments', { ProceedsAccounts: true, }, false),
	            'Instruments/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddInstruments', 'models/Settings/Instruments', { ProceedsAccounts: true, }, false),
	            'Instruments/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddInstruments', 'models/Settings/Instruments', { ProceedsAccounts: true, }, false),
				'Products': _.partial(BaseRouter.showView, baseRouter, 'l!t!Settings/Products', { ProductTypes: true, ProductAmountTypes: true, ProceedsAccounts: true, }, false),
	            'Products/create': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProducts', 'models/Settings/Products', { ProductTypes: true, ProductAmountTypes: true, ProceedsAccounts: true, }, false),
	            'Products/:id': _.partial(BaseRouter.showViewWithModel, baseRouter, 'l!t!Settings/AddProducts', 'models/Settings/Products', { ProductTypes: true, ProductAmountTypes: true, ProceedsAccounts: true, }, false),
			}
        
	        return routes;
	    }
	};

	return factory;
});
