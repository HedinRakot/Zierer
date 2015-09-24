








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

            tables.Add("Employee_Rate_Rsp", new TableMapping("Employee_Rate_Rsp", "EmployeeRateRsp", 6)
            {
                {"EmployeeId", "employeeId"},
                {"JobPositionId", "jobPositionId"},
                {"FromDate", "fromDate"},
                {"ToDate", "toDate"},
                {"SalaryType", "salaryType"},
                {"Salary", "salary"},
            });

            tables.Add("CustomProducts", new TableMapping("CustomProducts", "CustomProducts", 4)
            {
                {"Name", "name"},
                {"Price", "price"},
                {"Auto", "auto"},
                {"ProceedsAccountId", "proceedsAccountId"},
            });

            tables.Add("ProceedsAccounts", new TableMapping("ProceedsAccounts", "ProceedsAccounts", 1)
            {
                {"Value", "value"},
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
                {"IsVirtual", "isVirtual"},
                {"BoughtFrom", "boughtFrom"},
                {"BoughtPrice", "boughtPrice"},
                {"Comment", "comment"},
                {"MaterialAmountType", "materialAmountType"},
                {"IsForAuto", "isForAuto"},
                {"MustCount", "mustCount"},
                {"ProceedsAccountId", "proceedsAccountId"},
            });

            tables.Add("Product_Material_Rsp", new TableMapping("Product_Material_Rsp", "ProductMaterialRsp", 3)
            {
                {"ProductId", "productId"},
                {"MaterialId", "materialId"},
                {"Amount", "amount"},
            });

            tables.Add("ForeignProducts", new TableMapping("ForeignProducts", "ForeignProducts", 5)
            {
                {"Description", "description"},
                {"Price", "price"},
                {"FromDate", "fromDate"},
                {"ToDate", "toDate"},
                {"ProceedsAccountId", "proceedsAccountId"},
            });

            tables.Add("SocialTaxes", new TableMapping("SocialTaxes", "SocialTaxes", 6)
            {
                {"EmployeeId", "employeeId"},
                {"Description", "description"},
                {"Price", "price"},
                {"ProceedsAccountId", "proceedsAccountId"},
                {"FromDate", "fromDate"},
                {"ToDate", "toDate"},
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

            tables.Add("Employees", new TableMapping("Employees", "Employees", 14)
            {
                {"Number", "number"},
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
                {"Price", "price"},
                {"Automatic", "automatic"},
                {"FromDate", "fromDate"},
                {"ToDate", "toDate"},
                {"AdditionalCostTypeId", "additionalCostTypeId"},
                {"ProceedsAccountId", "proceedsAccountId"},
                {"Description", "description"},
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

            tables.Add("Absences", new TableMapping("Absences", "Absences", 4)
            {
                {"EmployeeId", "employeeId"},
                {"Description", "description"},
                {"FromDate", "fromDate"},
                {"ToDate", "toDate"},
            });

            tables.Add("ProductTypes", new TableMapping("ProductTypes", "ProductTypes", 2)
            {
                {"Name", "name"},
                {"Comment", "comment"},
            });

            tables.Add("NotProductiveWorkHours", new TableMapping("NotProductiveWorkHours", "NotProductiveWorkHours", 4)
            {
                {"EmployeeId", "employeeId"},
                {"Description", "description"},
                {"FromDate", "fromDate"},
                {"ToDate", "toDate"},
            });

            tables.Add("Instruments", new TableMapping("Instruments", "Instruments", 6)
            {
                {"Name", "name"},
                {"Number", "number"},
                {"IsForAuto", "isForAuto"},
                {"BoughtPrice", "boughtPrice"},
                {"Comment", "comment"},
                {"ProceedsAccountId", "proceedsAccountId"},
            });

            tables.Add("OwnProducts", new TableMapping("OwnProducts", "OwnProducts", 5)
            {
                {"Description", "description"},
                {"Price", "price"},
                {"FromDate", "fromDate"},
                {"ToDate", "toDate"},
                {"ProceedsAccountId", "proceedsAccountId"},
            });

            tables.Add("Products", new TableMapping("Products", "Products", 7)
            {
                {"Number", "number"},
                {"ProductTypeId", "productTypeId"},
                {"Price", "price"},
                {"Comment", "comment"},
                {"Name", "name"},
                {"ProductAmountType", "productAmountType"},
                {"ProceedsAccountId", "proceedsAccountId"},
            });

        }
    }
}
