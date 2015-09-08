﻿








using CoreBase;
using System.Collections.Generic;

namespace ProfiCraftsman.API
{
    public static partial class JsonHelper
    {
        private static void ProfiCraftsmanTableMappings(IDictionary<string, TableMapping> tables)
        {
            tables.Add("AdditionalCostTypes", new TableMapping("AdditionalCostTypes", "AdditionalCostTypes", 1)
            {
                {"Name", "name"},
            });

            tables.Add("Rates", new TableMapping("Rates", "Rates", 4)
            {
                {"JobPositionId", "jobPositionId"},
                {"Price", "price"},
                {"FromDate", "fromDate"},
                {"ToDate", "toDate"},
            });

            tables.Add("Employee_Rate_Rsp", new TableMapping("Employee_Rate_Rsp", "EmployeeRateRsp", 5)
            {
                {"EmployeeId", "employeeId"},
                {"JobPositionId", "jobPositionId"},
                {"CustomPrice", "customPrice"},
                {"FromDate", "fromDate"},
                {"ToDate", "toDate"},
            });

            tables.Add("CustomProducts", new TableMapping("CustomProducts", "CustomProducts", 2)
            {
                {"Price", "price"},
                {"Name", "name"},
            });

            tables.Add("Materials", new TableMapping("Materials", "Materials", 15)
            {
                {"Name", "name"},
                {"Number", "number"},
                {"Length", "length"},
                {"Width", "width"},
                {"Height", "height"},
                {"Color", "color"},
                {"Price", "price"},
                {"ProceedsAccount", "proceedsAccount"},
                {"IsVirtual", "isVirtual"},
                {"BoughtFrom", "boughtFrom"},
                {"BoughtPrice", "boughtPrice"},
                {"Comment", "comment"},
                {"MaterialAmountType", "materialAmountType"},
                {"IsForAuto", "isForAuto"},
                {"MustCount", "mustCount"},
            });

            tables.Add("Product_Material_Rsp", new TableMapping("Product_Material_Rsp", "ProductMaterialRsp", 3)
            {
                {"ProductId", "productId"},
                {"MaterialId", "materialId"},
                {"Amount", "amount"},
            });

            tables.Add("Autos", new TableMapping("Autos", "Autos", 3)
            {
                {"Number", "number"},
                {"Comment", "comment"},
                {"LastInspectionDate", "lastInspectionDate"},
            });

            tables.Add("Permission", new TableMapping("Permission", "Permission", 2)
            {
                {"Name", "name"},
                {"Description", "description"},
            });

            tables.Add("JobPositions", new TableMapping("JobPositions", "JobPositions", 2)
            {
                {"Name", "name"},
                {"Comment", "comment"},
            });

            tables.Add("Role", new TableMapping("Role", "Role", 1)
            {
                {"Name", "name"},
            });

            tables.Add("Employees", new TableMapping("Employees", "Employees", 15)
            {
                {"Number", "number"},
                {"JobPositionId", "jobPositionId"},
                {"AutoId", "autoId"},
                {"Name", "name"},
                {"FirstName", "firstName"},
                {"Street", "street"},
                {"ZIP", "zip"},
                {"City", "city"},
                {"Country", "country"},
                {"Phone", "phone"},
                {"Mobile", "mobile"},
                {"Fax", "fax"},
                {"Email", "email"},
                {"Comment", "comment"},
                {"Color", "color"},
            });

            tables.Add("Role_Permission_Rsp", new TableMapping("Role_Permission_Rsp", "RolePermissionRsp", 2)
            {
                {"RoleId", "roleId"},
                {"PermissionId", "permissionId"},
            });

            tables.Add("User", new TableMapping("User", "User", 5)
            {
                {"RoleId", "roleId"},
                {"Login", "login"},
                {"Name", "name"},
                {"Password", "password"},
                {"EmployeeId", "employeeId"},
            });

            tables.Add("AdditionalCosts", new TableMapping("AdditionalCosts", "AdditionalCosts", 7)
            {
                {"Description", "description"},
                {"Price", "price"},
                {"Automatic", "automatic"},
                {"ProceedsAccount", "proceedsAccount"},
                {"FromDate", "fromDate"},
                {"ToDate", "toDate"},
                {"AdditionalCostTypeId", "additionalCostTypeId"},
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

            tables.Add("Instruments", new TableMapping("Instruments", "Instruments", 6)
            {
                {"Name", "name"},
                {"Number", "number"},
                {"ProceedsAccount", "proceedsAccount"},
                {"IsForAuto", "isForAuto"},
                {"BoughtPrice", "boughtPrice"},
                {"Comment", "comment"},
            });

            tables.Add("Products", new TableMapping("Products", "Products", 7)
            {
                {"Number", "number"},
                {"ProductTypeId", "productTypeId"},
                {"Price", "price"},
                {"ProceedsAccount", "proceedsAccount"},
                {"Comment", "comment"},
                {"Name", "name"},
                {"ProductAmountType", "productAmountType"},
            });

        }
    }
}
