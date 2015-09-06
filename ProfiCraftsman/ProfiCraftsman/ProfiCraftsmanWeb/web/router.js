define([
    'base-router',
    'router-masterdata'
], function (BaseRouter, MasterDataRouter) {
	'use strict';

	var router = Backbone.Router.extend({
		initialize: function (options) {
			var self = this;
			this.masterView = options.masterView;
			this.listenTo(Backbone, 'logged-in', function () {

				location.reload();
			});
			this.listenTo(Backbone, 'logged-out', function () {
				location.reload();
			});
			this.listenTo(Backbone, 'forbidden', function () {
			    BaseRouter.showView.call(self, self, 'l!t!errors/forbidden');
			});
		},

		routes: function() {
		    
		    var commonRoutes =
            {
                'Home': _.partial(BaseRouter.showView, this, 'l!t!home/home', {  }, { }),
                'Settings': _.partial(BaseRouter.showView, this, 'l!t!Settings/Settings'),
                'Administration': _.partial(BaseRouter.showView, this, 'l!t!Administration/Administration'),

                'Warehouse': _.partial(BaseRouter.showView, this, 'l!t!Warehouse/Warehouse'),
                'WarehouseMaterials': _.partial(BaseRouter.showView, this, 'l!t!Warehouse/WarehouseMaterials', { MaterialAmountTypes: true }),

                'Offers': _.partial(BaseRouter.showView, this, 'l!t!Orders/Offers', { ProductTypes: true, ProductAmountTypes: true, MaterialAmountTypes: true, PaymentTypes: true, Employees: true, Autos: true, Instruments: true }, { isOffer: true }),
                'Offers/create': _.partial(BaseRouter.showViewWithModel, this, 'l!t!Orders/AddOrders', 'models/Orders', { ProductTypes: true, ProductAmountTypes: true, MaterialAmountTypes: true, CommunicationPartners: true, Employees: true, Autos: true, Instruments: true }, { isOffer: true }),
                'Offers/:id': _.partial(BaseRouter.showViewWithModel, this, 'l!t!Orders/AddOrders', 'models/Orders', { ProductTypes: true, ProductAmountTypes: true, MaterialAmountTypes: true, CommunicationPartners: true, Employees: true, Autos: true, Instruments: true }, { isOffer: true }),

                'Orders': _.partial(BaseRouter.showView, this, 'l!t!Orders/Orders', { ProductTypes: true, ProductAmountTypes: true, MaterialAmountTypes: true, PaymentTypes: true, Employees: true, Autos: true, Instruments: true }, { isOffer: false }),
                'Orders/create': _.partial(BaseRouter.showViewWithModel, this, 'l!t!Orders/AddOrders', 'models/Orders', { ProductTypes: true, ProductAmountTypes: true, MaterialAmountTypes: true, CommunicationPartners: true, PaymentTypes: true, Employees: true, Autos: true, Instruments: true }, { isOffer: false }),
                'Orders/:id': _.partial(BaseRouter.showViewWithModel, this, 'l!t!Orders/AddOrders', 'models/Orders', { ProductTypes: true, ProductAmountTypes: true, MaterialAmountTypes: true, CommunicationPartners: true, PaymentTypes: true, Employees: true, Autos: true, Instruments: true }, { isOffer: false }),

                'Invoices': _.partial(BaseRouter.showView, this, 'l!t!Invoices/Invoices', { PaymentTypes: true }, false),
                'Invoices/:id': _.partial(BaseRouter.showViewWithModel, this, 'l!t!Invoices/AddInvoices', 'models/Invoices/Invoices', { PaymentIntervals: true, PaymentTypes: true }, false),
                'InvoiceStornos': _.partial(BaseRouter.showView, this, 'l!t!InvoiceStornos/Invoices', { ProceedsAccounts: true }, false),

                'Trips': _.partial(BaseRouter.showView, this, 'l!t!Administration/Trips', { Autos: true }, { }),
            };
		    
		    var result = $.extend({}, commonRoutes, MasterDataRouter.getAllMasterDataRoutes(this));

		    return result;
		}		
	});

	return router;
});