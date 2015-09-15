








using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Lib.Data;
using System.Data.Entity;
using System.Linq;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Database context for for ProfiCraftsman
    /// </summary>
    public partial class ProfiCraftsmanEntities: IProfiCraftsmanEntities
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(DeliveryNoteSignaturesMapping.Instance);
            modelBuilder.Configurations.Add(OrdersMapping.Instance);
            modelBuilder.Configurations.Add(PositionsMapping.Instance);
            modelBuilder.Configurations.Add(TermEmployeesMapping.Instance);
            modelBuilder.Configurations.Add(TermPositionMaterialRspMapping.Instance);
            modelBuilder.Configurations.Add(SearchPositionViewMapping.Instance);
            modelBuilder.Configurations.Add(AdditionalCostTypesMapping.Instance);
            modelBuilder.Configurations.Add(RatesMapping.Instance);
            modelBuilder.Configurations.Add(EmployeeRateRspMapping.Instance);
            modelBuilder.Configurations.Add(TermCostsMapping.Instance);
            modelBuilder.Configurations.Add(CustomProductsMapping.Instance);
            modelBuilder.Configurations.Add(InvoicesMapping.Instance);
            modelBuilder.Configurations.Add(InvoicePositionsMapping.Instance);
            modelBuilder.Configurations.Add(ProceedsAccountsMapping.Instance);
            modelBuilder.Configurations.Add(MaterialsMapping.Instance);
            modelBuilder.Configurations.Add(ProductMaterialRspMapping.Instance);
            modelBuilder.Configurations.Add(InvoicePaymentsMapping.Instance);
            modelBuilder.Configurations.Add(MaterialDeliveryRspMapping.Instance);
            modelBuilder.Configurations.Add(ForeignProductsMapping.Instance);
            modelBuilder.Configurations.Add(SocialTaxesMapping.Instance);
            modelBuilder.Configurations.Add(AutosMapping.Instance);
            modelBuilder.Configurations.Add(PermissionMapping.Instance);
            modelBuilder.Configurations.Add(JobPositionsMapping.Instance);
            modelBuilder.Configurations.Add(RoleMapping.Instance);
            modelBuilder.Configurations.Add(EmployeesMapping.Instance);
            modelBuilder.Configurations.Add(RolePermissionRspMapping.Instance);
            modelBuilder.Configurations.Add(TermsMapping.Instance);
            modelBuilder.Configurations.Add(InvoiceStornosMapping.Instance);
            modelBuilder.Configurations.Add(UserMapping.Instance);
            modelBuilder.Configurations.Add(AdditionalCostsMapping.Instance);
            modelBuilder.Configurations.Add(TaxesMapping.Instance);
            modelBuilder.Configurations.Add(TransportProductsMapping.Instance);
            modelBuilder.Configurations.Add(CustomersMapping.Instance);
            modelBuilder.Configurations.Add(CommunicationPartnersMapping.Instance);
            modelBuilder.Configurations.Add(TransportOrdersMapping.Instance);
            modelBuilder.Configurations.Add(ProductTypesMapping.Instance);
            modelBuilder.Configurations.Add(TransportPositionsMapping.Instance);
            modelBuilder.Configurations.Add(InstrumentsMapping.Instance);
            modelBuilder.Configurations.Add(ProductsMapping.Instance);
            modelBuilder.Configurations.Add(AutoMaterialRspMapping.Instance);
            modelBuilder.Configurations.Add(AutoInstrumentRspMapping.Instance);
            modelBuilder.Configurations.Add(WarehouseMaterialsMapping.Instance);
            modelBuilder.Configurations.Add(TermPositionsMapping.Instance);
            modelBuilder.Configurations.Add(TermInstrumentsMapping.Instance);
        }

        /// <summary>
        ///     Set of <see cref="DeliveryNoteSignatures"/> entities from table dbo.DeliveryNoteSignatures
        /// </summary>
        public IQueryable<DeliveryNoteSignatures> DeliveryNoteSignatures{ get; set; }
        /// <summary>
        ///     Set of <see cref="Orders"/> entities from table dbo.Orders
        /// </summary>
        public IQueryable<Orders> Orders{ get; set; }
        /// <summary>
        ///     Set of <see cref="Positions"/> entities from table dbo.Positions
        /// </summary>
        public IQueryable<Positions> Positions{ get; set; }
        /// <summary>
        ///     Set of <see cref="TermEmployees"/> entities from table dbo.TermEmployees
        /// </summary>
        public IQueryable<TermEmployees> TermEmployees{ get; set; }
        /// <summary>
        ///     Set of <see cref="TermPositionMaterialRsp"/> entities from table dbo.TermPosition_Material_Rsp
        /// </summary>
        public IQueryable<TermPositionMaterialRsp> TermPositionMaterialRsp{ get; set; }
        /// <summary>
        ///     Set of <see cref="SearchPositionView"/> entities from table dbo.SearchPositionView
        /// </summary>
        public IQueryable<SearchPositionView> SearchPositionView{ get; set; }
        /// <summary>
        ///     Set of <see cref="AdditionalCostTypes"/> entities from table dbo.AdditionalCostTypes
        /// </summary>
        public IQueryable<AdditionalCostTypes> AdditionalCostTypes{ get; set; }
        /// <summary>
        ///     Set of <see cref="Rates"/> entities from table dbo.Rates
        /// </summary>
        public IQueryable<Rates> Rates{ get; set; }
        /// <summary>
        ///     Set of <see cref="EmployeeRateRsp"/> entities from table dbo.Employee_Rate_Rsp
        /// </summary>
        public IQueryable<EmployeeRateRsp> EmployeeRateRsp{ get; set; }
        /// <summary>
        ///     Set of <see cref="TermCosts"/> entities from table dbo.TermCosts
        /// </summary>
        public IQueryable<TermCosts> TermCosts{ get; set; }
        /// <summary>
        ///     Set of <see cref="CustomProducts"/> entities from table dbo.CustomProducts
        /// </summary>
        public IQueryable<CustomProducts> CustomProducts{ get; set; }
        /// <summary>
        ///     Set of <see cref="Invoices"/> entities from table dbo.Invoices
        /// </summary>
        public IQueryable<Invoices> Invoices{ get; set; }
        /// <summary>
        ///     Set of <see cref="InvoicePositions"/> entities from table dbo.InvoicePositions
        /// </summary>
        public IQueryable<InvoicePositions> InvoicePositions{ get; set; }
        /// <summary>
        ///     Set of <see cref="ProceedsAccounts"/> entities from table dbo.ProceedsAccounts
        /// </summary>
        public IQueryable<ProceedsAccounts> ProceedsAccounts{ get; set; }
        /// <summary>
        ///     Set of <see cref="Materials"/> entities from table dbo.Materials
        /// </summary>
        public IQueryable<Materials> Materials{ get; set; }
        /// <summary>
        ///     Set of <see cref="ProductMaterialRsp"/> entities from table dbo.Product_Material_Rsp
        /// </summary>
        public IQueryable<ProductMaterialRsp> ProductMaterialRsp{ get; set; }
        /// <summary>
        ///     Set of <see cref="InvoicePayments"/> entities from table dbo.InvoicePayments
        /// </summary>
        public IQueryable<InvoicePayments> InvoicePayments{ get; set; }
        /// <summary>
        ///     Set of <see cref="MaterialDeliveryRsp"/> entities from table dbo.Material_Delivery_Rsp
        /// </summary>
        public IQueryable<MaterialDeliveryRsp> MaterialDeliveryRsp{ get; set; }
        /// <summary>
        ///     Set of <see cref="ForeignProducts"/> entities from table dbo.ForeignProducts
        /// </summary>
        public IQueryable<ForeignProducts> ForeignProducts{ get; set; }
        /// <summary>
        ///     Set of <see cref="SocialTaxes"/> entities from table dbo.SocialTaxes
        /// </summary>
        public IQueryable<SocialTaxes> SocialTaxes{ get; set; }
        /// <summary>
        ///     Set of <see cref="Autos"/> entities from table dbo.Autos
        /// </summary>
        public IQueryable<Autos> Autos{ get; set; }
        /// <summary>
        ///     Set of <see cref="Permission"/> entities from table dbo.Permission
        /// </summary>
        public IQueryable<Permission> Permission{ get; set; }
        /// <summary>
        ///     Set of <see cref="JobPositions"/> entities from table dbo.JobPositions
        /// </summary>
        public IQueryable<JobPositions> JobPositions{ get; set; }
        /// <summary>
        ///     Set of <see cref="Role"/> entities from table dbo.Role
        /// </summary>
        public IQueryable<Role> Role{ get; set; }
        /// <summary>
        ///     Set of <see cref="Employees"/> entities from table dbo.Employees
        /// </summary>
        public IQueryable<Employees> Employees{ get; set; }
        /// <summary>
        ///     Set of <see cref="RolePermissionRsp"/> entities from table dbo.Role_Permission_Rsp
        /// </summary>
        public IQueryable<RolePermissionRsp> RolePermissionRsp{ get; set; }
        /// <summary>
        ///     Set of <see cref="Terms"/> entities from table dbo.Terms
        /// </summary>
        public IQueryable<Terms> Terms{ get; set; }
        /// <summary>
        ///     Set of <see cref="InvoiceStornos"/> entities from table dbo.InvoiceStornos
        /// </summary>
        public IQueryable<InvoiceStornos> InvoiceStornos{ get; set; }
        /// <summary>
        ///     Set of <see cref="User"/> entities from table dbo.User
        /// </summary>
        public IQueryable<User> User{ get; set; }
        /// <summary>
        ///     Set of <see cref="AdditionalCosts"/> entities from table dbo.AdditionalCosts
        /// </summary>
        public IQueryable<AdditionalCosts> AdditionalCosts{ get; set; }
        /// <summary>
        ///     Set of <see cref="Taxes"/> entities from table dbo.Taxes
        /// </summary>
        public IQueryable<Taxes> Taxes{ get; set; }
        /// <summary>
        ///     Set of <see cref="TransportProducts"/> entities from table dbo.TransportProducts
        /// </summary>
        public IQueryable<TransportProducts> TransportProducts{ get; set; }
        /// <summary>
        ///     Set of <see cref="Customers"/> entities from table dbo.Customers
        /// </summary>
        public IQueryable<Customers> Customers{ get; set; }
        /// <summary>
        ///     Set of <see cref="CommunicationPartners"/> entities from table dbo.CommunicationPartners
        /// </summary>
        public IQueryable<CommunicationPartners> CommunicationPartners{ get; set; }
        /// <summary>
        ///     Set of <see cref="TransportOrders"/> entities from table dbo.TransportOrders
        /// </summary>
        public IQueryable<TransportOrders> TransportOrders{ get; set; }
        /// <summary>
        ///     Set of <see cref="ProductTypes"/> entities from table dbo.ProductTypes
        /// </summary>
        public IQueryable<ProductTypes> ProductTypes{ get; set; }
        /// <summary>
        ///     Set of <see cref="TransportPositions"/> entities from table dbo.TransportPositions
        /// </summary>
        public IQueryable<TransportPositions> TransportPositions{ get; set; }
        /// <summary>
        ///     Set of <see cref="Instruments"/> entities from table dbo.Instruments
        /// </summary>
        public IQueryable<Instruments> Instruments{ get; set; }
        /// <summary>
        ///     Set of <see cref="Products"/> entities from table dbo.Products
        /// </summary>
        public IQueryable<Products> Products{ get; set; }
        /// <summary>
        ///     Set of <see cref="AutoMaterialRsp"/> entities from table dbo.Auto_Material_Rsp
        /// </summary>
        public IQueryable<AutoMaterialRsp> AutoMaterialRsp{ get; set; }
        /// <summary>
        ///     Set of <see cref="AutoInstrumentRsp"/> entities from table dbo.Auto_Instrument_Rsp
        /// </summary>
        public IQueryable<AutoInstrumentRsp> AutoInstrumentRsp{ get; set; }
        /// <summary>
        ///     Set of <see cref="WarehouseMaterials"/> entities from table dbo.WarehouseMaterials
        /// </summary>
        public IQueryable<WarehouseMaterials> WarehouseMaterials{ get; set; }
        /// <summary>
        ///     Set of <see cref="TermPositions"/> entities from table dbo.TermPositions
        /// </summary>
        public IQueryable<TermPositions> TermPositions{ get; set; }
        /// <summary>
        ///     Set of <see cref="TermInstruments"/> entities from table dbo.TermInstruments
        /// </summary>
        public IQueryable<TermInstruments> TermInstruments{ get; set; }
    }
}
