using CoreBase.Controllers;
using CoreBase.Entities;
using CoreBase.Exceptions;
using CoreBase.Models;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.Lib.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Http;

namespace ProfiCraftsman.API.Controllers
{
    public class ProfitReportsSearchModel
    {
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }


    /// <summary>
    ///     Controller for profit reports
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.ProfitReports })]
    public partial class ProfitReportsController : ApiController
    {
        protected IAdditionalCostsManager additionalCostsManager { get; set; }
        protected IForeignProductsManager foreignProductsManager { get; set; }
        protected IOwnProductsManager ownProductsManager { get; set; }
        protected IEmployeeRateRspManager employeeRateRspManager { get; set; }
        protected IEmployeesManager employeeManager { get; set; }
        protected IOrdersManager orderManager { get; set; }
        protected IMaterialDeliveryRspManager materialDeliveryRspManager { get; set; }
        protected ISocialTaxesManager socialTaxesManager { get; set; }
        protected IInstrumentsManager instrumentsManager { get; set; }
        protected IInterestsManager interestsManager { get; set; }

        protected ITermPositionsManager termPositionsManager { get; set; }
        protected IPositionsManager positionsManager { get; set; }
        protected ITermCostsManager termCostsManager { get; set; }
        protected ITaxesManager taxesManager { get; set; }
        protected IInvoicesManager invoicesManager { get; set; }
        protected ITermsManager termsManager { get; set; }


        public ProfitReportsController(IAdditionalCostsManager additionalCostsManager, 
            IEmployeeRateRspManager employeeRateRspManager, IEmployeesManager employeeManager, IOrdersManager orderManager,
            IForeignProductsManager foreignProductsManager, IMaterialDeliveryRspManager materialDeliveryRspManager,
            ISocialTaxesManager socialTaxesManager, IInstrumentsManager instrumentsManager, IOwnProductsManager ownProductsManager,
            ITermPositionsManager termPositionsManager, IPositionsManager positionsManager, ITermCostsManager termCostsManager,
            ITaxesManager taxesManager, IInvoicesManager invoicesManager, IInterestsManager interestsManager, ITermsManager termsManager)
        {
            this.additionalCostsManager = additionalCostsManager;
            this.employeeRateRspManager = employeeRateRspManager;
            this.employeeManager = employeeManager;
            this.orderManager = orderManager;
            this.foreignProductsManager = foreignProductsManager;
            this.ownProductsManager = ownProductsManager;
            this.materialDeliveryRspManager = materialDeliveryRspManager;
            this.socialTaxesManager = socialTaxesManager;
            this.instrumentsManager = instrumentsManager;
            this.interestsManager = interestsManager;

            this.termPositionsManager = termPositionsManager;
            this.positionsManager = positionsManager;
            this.termCostsManager = termCostsManager;
            this.taxesManager = taxesManager;
            this.invoicesManager = invoicesManager;
            this.termsManager = termsManager;
        }


        public IHttpActionResult Post(ProfitReportsSearchModel model)
        {
            if (!model.FromDate.HasValue)
                model.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            if (!model.ToDate.HasValue)
                model.ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));


            //materials
            var materials = materialDeliveryRspManager.GetEntities();
            if (model.FromDate.HasValue)
            {
                materials = materials.Where(o => o.CreateDate.Date >= model.FromDate.Value);
            }

            if (model.ToDate.HasValue)
            {
                materials = materials.Where(o => o.CreateDate.Date <= model.ToDate.Value);
            }

            double materialsSum = 0;
            foreach (var materialGroup in materials.GroupBy(o => o.Materials))
            {
                var amount = materialGroup.Sum(o => o.Amount);
                materialsSum += amount * materialGroup.Key.Price;
            }


            //additional costs
            var additionalCosts = additionalCostsManager.GetEntities();
            if(model.FromDate.HasValue)
            {
                additionalCosts = additionalCosts.Where(o => o.FromDate.Date >= model.FromDate.Value);
            }

            if (model.ToDate.HasValue)
            {
                additionalCosts = additionalCosts.Where(o => (!o.ToDate.HasValue || o.ToDate.Value.Date <= model.ToDate.Value) && o.FromDate.Date <= model.ToDate.Value);
            }

            var additionalCostsSum = additionalCosts.Sum(o => o.Price);


            //foreign products
            var foreignProducts = foreignProductsManager.GetEntities();
            if (model.FromDate.HasValue)
            {
                foreignProducts = foreignProducts.Where(o => o.FromDate.Date >= model.FromDate.Value);
            }

            if (model.ToDate.HasValue)
            {
                foreignProducts = foreignProducts.Where(o => (!o.ToDate.HasValue || o.ToDate.Value.Date <= model.ToDate.Value) && o.FromDate.Date <= model.ToDate.Value);
            }

            var foreignProductsSum = foreignProducts.Sum(o => o.Price);
            

            //own products
            var ownProducts = ownProductsManager.GetEntities();
            if (model.FromDate.HasValue)
            {
                ownProducts = ownProducts.Where(o => o.FromDate.Date >= model.FromDate.Value);
            }

            if (model.ToDate.HasValue)
            {
                ownProducts = ownProducts.Where(o => (!o.ToDate.HasValue || o.ToDate.Value.Date <= model.ToDate.Value) && o.FromDate.Date <= model.ToDate.Value);
            }

            var ownProductsSum = ownProducts.Sum(o => o.Price);


            //interests
            var interests = interestsManager.GetEntities();
            if (model.FromDate.HasValue)
            {
                interests = interests.Where(o => o.FromDate.Date >= model.FromDate.Value);
            }

            if (model.ToDate.HasValue)
            {
                interests = interests.Where(o => (!o.ToDate.HasValue || o.ToDate.Value.Date <= model.ToDate.Value) && o.FromDate.Date <= model.ToDate.Value);
            }

            var interestsSum = interests.Sum(o => o.Price);


            //salary
            var salaries = SalaryHelper.GetSalary(termsManager, employeeRateRspManager, employeeManager, model.FromDate.Value, model.ToDate.Value);
            var salarySum = salaries.Sum(o => o.amount);


            //instruments
            var instruments = instrumentsManager.GetEntities();
            if (model.FromDate.HasValue)
            {
                instruments = instruments.Where(o => o.ChangeDate.Date >= model.FromDate.Value);
            }

            if (model.ToDate.HasValue)
            {
                instruments = instruments.Where(o => o.ChangeDate.Date <= model.ToDate.Value);
            }

            var instrumentsSum = instruments.Sum(o => o.BoughtPrice);


            //social taxes
            var socialTaxes = socialTaxesManager.GetEntities();
            if (model.FromDate.HasValue)
            {
                socialTaxes = socialTaxes.Where(o => o.FromDate.Date >= model.FromDate.Value);
            }

            if (model.ToDate.HasValue)
            {
                socialTaxes = socialTaxes.Where(o => (!o.ToDate.HasValue || o.ToDate.Value.Date <= model.ToDate.Value) && o.FromDate.Date <= model.ToDate.Value);
            }

            var socialTaxesSum = socialTaxes.Sum(o => o.Price);

            //orders
            var orders = orderManager.GetEntities(o => o.Terms.Any(t => t.Date >= model.FromDate.Value && t.Date <= model.ToDate.Value)).ToList();
            double totalOrdersSum = 0;
            double totalOrdersProfit = 0;
            foreach (var order in orders)
            {
                double profit = 0;
                var totalPrice = CalculationHelper.CalculateTotalPrice(order,
                    termPositionsManager, positionsManager, termCostsManager, taxesManager, model.FromDate.Value, model.ToDate.Value,
                    ref profit);

                totalOrdersSum += totalPrice;
                totalOrdersProfit += profit;
            }


            //invoices
            var invoices = invoicesManager.GetEntities(o => !o.DeleteDate.HasValue && o.ChangeDate >= model.FromDate.Value && o.ChangeDate <= model.ToDate.Value).ToList();
            double totalInvoicesSum = 0;
            foreach (var invoice in invoices)
            {
                double totalPriceWithoutDiscountWithoutTax = 0;
                double totalPriceWithoutTax = 0;
                double totalPrice = 0;
                double summaryPrice = 0;

                CalculationHelper.CalculateInvoicePrices(invoice, out totalPriceWithoutDiscountWithoutTax,
                    out totalPriceWithoutTax, out totalPrice, out summaryPrice);

                totalInvoicesSum += summaryPrice;
            }

            var totalPayedSum = invoices.SelectMany(o => o.InvoicePayments.Where(p => !p.DeleteDate.HasValue)).
                Sum(o => o.Amount);

            var totalProductsSum = totalOrdersSum + ownProductsSum;
            var grossProfit = totalProductsSum - materialsSum - instrumentsSum;
            var totalCosts = additionalCostsSum + foreignProductsSum + salarySum + socialTaxesSum;
            var operatingIncome = grossProfit - totalCosts;
            var ebit = operatingIncome - interestsSum;

            return Ok(new ProfitReportsModel ()
            {
                materialsSum = materialsSum.ToString("N2") + " EUR",
                additionalCostsSum = additionalCostsSum.ToString("N2") + " EUR",
                foreignProductsSum = foreignProductsSum.ToString("N2") + " EUR",
                ownProductsSum = ownProductsSum.ToString("N2") + " EUR",
                interestsSum = interestsSum.ToString("N2") + " EUR",
                salarySum = salarySum.ToString("N2") + " EUR",
                instrumentsSum = instrumentsSum.ToString("N2") + " EUR",
                socialTaxesSum = socialTaxesSum.ToString("N2") + " EUR",
                totalOrdersSum = totalOrdersSum.ToString("N2") + " EUR",
                totalInvoicesSum = totalInvoicesSum.ToString("N2") + " EUR",
                notBookedOrdersSum = (totalOrdersSum - totalInvoicesSum).ToString("N2") + " EUR",
                totalProductsSum = totalProductsSum.ToString("N2") + " EUR",
                grossProfit = grossProfit.ToString("N2") + " EUR",
                totalCosts = totalCosts.ToString("N2") + " EUR",
                operatingIncome = operatingIncome.ToString("N2") + " EUR",
                ebit = ebit.ToString("N2") + " EUR",
                totalPayedSum = totalPayedSum.ToString("N2") + " EUR",
                totalProfitSum = totalOrdersProfit.ToString("N2") + " EUR",
            });
        }
    }
}
