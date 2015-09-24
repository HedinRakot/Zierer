








using Microsoft.Practices.Unity;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.Lib.Managers;

namespace ProfiCraftsman.Configuration
{
    public static partial class UnityConfiguration
    {
        private static void InitializeProfiCraftsman(IUnityContainer container)
        {
            container.RegisterType<IDeliveryNoteSignaturesManager, DeliveryNoteSignaturesManager>(new PerRequestLifetimeManager());
            container.RegisterType<IOrdersManager, OrdersManager>(new PerRequestLifetimeManager());
            container.RegisterType<IPositionsManager, PositionsManager>(new PerRequestLifetimeManager());
            container.RegisterType<ITermEmployeesManager, TermEmployeesManager>(new PerRequestLifetimeManager());
            container.RegisterType<ITermPositionMaterialRspManager, TermPositionMaterialRspManager>(new PerRequestLifetimeManager());
            container.RegisterType<ISearchPositionViewManager, SearchPositionViewManager>(new PerRequestLifetimeManager());
            container.RegisterType<IAdditionalCostTypesManager, AdditionalCostTypesManager>(new PerRequestLifetimeManager());
            container.RegisterType<IRatesManager, RatesManager>(new PerRequestLifetimeManager());
            container.RegisterType<IEmployeeRateRspManager, EmployeeRateRspManager>(new PerRequestLifetimeManager());
            container.RegisterType<ITermCostsManager, TermCostsManager>(new PerRequestLifetimeManager());
            container.RegisterType<ICustomProductsManager, CustomProductsManager>(new PerRequestLifetimeManager());
            container.RegisterType<IInvoicesManager, InvoicesManager>(new PerRequestLifetimeManager());
            container.RegisterType<IInvoicePositionsManager, InvoicePositionsManager>(new PerRequestLifetimeManager());
            container.RegisterType<IProceedsAccountsManager, ProceedsAccountsManager>(new PerRequestLifetimeManager());
            container.RegisterType<IMaterialsManager, MaterialsManager>(new PerRequestLifetimeManager());
            container.RegisterType<IProductMaterialRspManager, ProductMaterialRspManager>(new PerRequestLifetimeManager());
            container.RegisterType<IInvoicePaymentsManager, InvoicePaymentsManager>(new PerRequestLifetimeManager());
            container.RegisterType<IMaterialDeliveryRspManager, MaterialDeliveryRspManager>(new PerRequestLifetimeManager());
            container.RegisterType<IForeignProductsManager, ForeignProductsManager>(new PerRequestLifetimeManager());
            container.RegisterType<ISocialTaxesManager, SocialTaxesManager>(new PerRequestLifetimeManager());
            container.RegisterType<IAutosManager, AutosManager>(new PerRequestLifetimeManager());
            container.RegisterType<IPermissionManager, PermissionManager>(new PerRequestLifetimeManager());
            container.RegisterType<IJobPositionsManager, JobPositionsManager>(new PerRequestLifetimeManager());
            container.RegisterType<IRoleManager, RoleManager>(new PerRequestLifetimeManager());
            container.RegisterType<IEmployeesManager, EmployeesManager>(new PerRequestLifetimeManager());
            container.RegisterType<IRolePermissionRspManager, RolePermissionRspManager>(new PerRequestLifetimeManager());
            container.RegisterType<ITermsManager, TermsManager>(new PerRequestLifetimeManager());
            container.RegisterType<IInvoiceStornosManager, InvoiceStornosManager>(new PerRequestLifetimeManager());
            container.RegisterType<IUserManager, UserManager>(new PerRequestLifetimeManager());
            container.RegisterType<IAdditionalCostsManager, AdditionalCostsManager>(new PerRequestLifetimeManager());
            container.RegisterType<IOrderFilesManager, OrderFilesManager>(new PerRequestLifetimeManager());
            container.RegisterType<ITaxesManager, TaxesManager>(new PerRequestLifetimeManager());
            container.RegisterType<ITransportProductsManager, TransportProductsManager>(new PerRequestLifetimeManager());
            container.RegisterType<ICustomersManager, CustomersManager>(new PerRequestLifetimeManager());
            container.RegisterType<ICommunicationPartnersManager, CommunicationPartnersManager>(new PerRequestLifetimeManager());
            container.RegisterType<IAbsencesManager, AbsencesManager>(new PerRequestLifetimeManager());
            container.RegisterType<ITransportOrdersManager, TransportOrdersManager>(new PerRequestLifetimeManager());
            container.RegisterType<IProductTypesManager, ProductTypesManager>(new PerRequestLifetimeManager());
            container.RegisterType<INotProductiveWorkHoursManager, NotProductiveWorkHoursManager>(new PerRequestLifetimeManager());
            container.RegisterType<ITransportPositionsManager, TransportPositionsManager>(new PerRequestLifetimeManager());
            container.RegisterType<IInstrumentsManager, InstrumentsManager>(new PerRequestLifetimeManager());
            container.RegisterType<IOwnProductsManager, OwnProductsManager>(new PerRequestLifetimeManager());
            container.RegisterType<IProductsManager, ProductsManager>(new PerRequestLifetimeManager());
            container.RegisterType<IAutoMaterialRspManager, AutoMaterialRspManager>(new PerRequestLifetimeManager());
            container.RegisterType<IAutoInstrumentRspManager, AutoInstrumentRspManager>(new PerRequestLifetimeManager());
            container.RegisterType<IWarehouseMaterialsManager, WarehouseMaterialsManager>(new PerRequestLifetimeManager());
            container.RegisterType<ITermPositionsManager, TermPositionsManager>(new PerRequestLifetimeManager());
            container.RegisterType<ITermInstrumentsManager, TermInstrumentsManager>(new PerRequestLifetimeManager());
        }

    }
}
