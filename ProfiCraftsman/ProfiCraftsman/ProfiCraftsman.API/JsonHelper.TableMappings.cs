﻿








using CoreBase;
using System.Collections.Generic;

namespace ProfiCraftsman.API
{
    public static partial class JsonHelper
    {
        private static void ProfiCraftsmanTableMappings(IDictionary<string, TableMapping> tables)
        {
            tables.Add("Permission", new TableMapping("Permission", "Permission", 2)
            {
                {"Name", "name"},
                {"Description", "description"},
            });

            tables.Add("Role", new TableMapping("Role", "Role", 1)
            {
                {"Name", "name"},
            });

            tables.Add("Role_Permission_Rsp", new TableMapping("Role_Permission_Rsp", "RolePermissionRsp", 2)
            {
                {"RoleId", "roleId"},
                {"PermissionId", "permissionId"},
            });

            tables.Add("User", new TableMapping("User", "User", 4)
            {
                {"RoleId", "roleId"},
                {"Login", "login"},
                {"Name", "name"},
                {"Password", "password"},
            });

            tables.Add("Equipments", new TableMapping("Equipments", "Equipments", 1)
            {
                {"Description", "description"},
            });

            tables.Add("AdditionalCosts", new TableMapping("AdditionalCosts", "AdditionalCosts", 6)
            {
                {"Name", "name"},
                {"Description", "description"},
                {"Price", "price"},
                {"Automatic", "automatic"},
                {"IncludeInFirstBill", "includeInFirstBill"},
                {"ProceedsAccount", "proceedsAccount"},
            });

            tables.Add("Taxes", new TableMapping("Taxes", "Taxes", 3)
            {
                {"Value", "value"},
                {"FromDate", "fromDate"},
                {"ToDate", "toDate"},
            });

            tables.Add("TransportProducts", new TableMapping("TransportProducts", "TransportProducts", 4)
            {
                {"Name", "name"},
                {"Description", "description"},
                {"Price", "price"},
                {"ProceedsAccount", "proceedsAccount"},
            });

            tables.Add("Customers", new TableMapping("Customers", "Customers", 22)
            {
                {"Number", "number"},
                {"Name", "name"},
                {"Street", "street"},
                {"ZIP", "zip"},
                {"City", "city"},
                {"Country", "country"},
                {"Phone", "phone"},
                {"Mobile", "mobile"},
                {"Fax", "fax"},
                {"Email", "email"},
                {"Comment", "comment"},
                {"IBAN", "iban"},
                {"BIC", "bic"},
                {"WithTaxes", "withTaxes"},
                {"AutoDebitEntry", "autoDebitEntry"},
                {"AutoBill", "autoBill"},
                {"Discount", "discount"},
                {"UstId", "ustId"},
                {"Bank", "bank"},
                {"AccountNumber", "accountNumber"},
                {"BLZ", "blz"},
                {"IsProspectiveCustomer", "isProspectiveCustomer"},
            });

            tables.Add("CommunicationPartners", new TableMapping("CommunicationPartners", "CommunicationPartners", 7)
            {
                {"Name", "name"},
                {"FirstName", "firstName"},
                {"CustomerId", "customerId"},
                {"Phone", "phone"},
                {"Mobile", "mobile"},
                {"Fax", "fax"},
                {"Email", "email"},
            });

            tables.Add("ProductTypes", new TableMapping("ProductTypes", "ProductTypes", 2)
            {
                {"Name", "name"},
                {"Comment", "comment"},
            });

            tables.Add("ProductType_Equipment_Rsp", new TableMapping("ProductType_Equipment_Rsp", "ProductTypeEquipmentRsp", 3)
            {
                {"ProductTypeId", "productTypeId"},
                {"EquipmentId", "equipmentId"},
                {"Amount", "amount"},
            });

            tables.Add("Products", new TableMapping("Products", "Products", 17)
            {
                {"Number", "number"},
                {"ProductTypeId", "productTypeId"},
                {"Length", "length"},
                {"Width", "width"},
                {"Height", "height"},
                {"Color", "color"},
                {"Price", "price"},
                {"ProceedsAccount", "proceedsAccount"},
                {"IsVirtual", "isVirtual"},
                {"ManufactureDate", "manufactureDate"},
                {"BoughtFrom", "boughtFrom"},
                {"BoughtPrice", "boughtPrice"},
                {"Comment", "comment"},
                {"SellPrice", "sellPrice"},
                {"IsSold", "isSold"},
                {"MinPrice", "minPrice"},
                {"NewPrice", "newPrice"},
            });

            tables.Add("Product_Equipment_Rsp", new TableMapping("Product_Equipment_Rsp", "ProductEquipmentRsp", 3)
            {
                {"ProductId", "productId"},
                {"EquipmentId", "equipmentId"},
                {"Amount", "amount"},
            });

        }
    }
}
