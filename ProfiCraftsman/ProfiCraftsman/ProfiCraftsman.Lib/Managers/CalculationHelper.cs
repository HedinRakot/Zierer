using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace ProfiCraftsman.Lib.Managers
{
    public static class CalculationHelper
    {
        public static void CalculateInvoicePrices(Invoices entity, 
            out double totalPriceWithoutDiscountWithoutTax,
            out double totalPriceWithoutTax,
            out double totalPrice,
            out double summaryPrice)
        {
            totalPriceWithoutDiscountWithoutTax = 0;
            totalPriceWithoutTax = 0;
            totalPrice = 0;

            var allPositions = entity.InvoicePositions.Where(o => !o.DeleteDate.HasValue).ToList();

            //total price for positions
            foreach (var position in allPositions)
            {
                totalPriceWithoutDiscountWithoutTax += CalculatePositionPrice(position.Price, position.Amount, position.Payment);
            }
            
            summaryPrice = CalculateTaxesAndDiscount(entity.Discount, entity.TaxValue, entity.WithTaxes, entity.ManualPrice,
                ref totalPriceWithoutDiscountWithoutTax, ref totalPriceWithoutTax, ref totalPrice);
        }

        public static void CalculateOrderPrices(Orders entity,
            ITaxesManager taxesManager,
            out double totalPriceWithoutDiscountWithoutTax,
            out double totalPriceWithoutTax,
            out double totalPrice,
            out double summaryPrice)
        {
            totalPriceWithoutDiscountWithoutTax = 0;
            totalPriceWithoutTax = 0;
            totalPrice = 0;

            var allPositions = entity.Positions.Where(o => !o.DeleteDate.HasValue).ToList();
            //Product prices
            foreach (var position in allPositions)
            {
                totalPriceWithoutDiscountWithoutTax += CalculatePositionPrice(position.Price, position.Amount, position.Payment);
            }

            var taxValue = CalculateTaxes(taxesManager);

            summaryPrice = CalculateTaxesAndDiscount(entity.Discount ?? 0, taxValue, entity.Customers.WithTaxes, null,
                ref totalPriceWithoutDiscountWithoutTax, ref totalPriceWithoutTax, ref totalPrice);
        }

        public static double CalculateTotalPrice(Orders order,
            ITermPositionsManager termPositionsManager,
            IPositionsManager positionsManager,
            ITermCostsManager termCostsManager,
            ITaxesManager taxesManager,
            DateTime? fromDate,
            DateTime? toDate,
            ref double profit)
        {
            double result = 0;

            //TODO discuss with customer - take positions where proccessed amount not null (but take with 0)
            var termPositions = termPositionsManager.GetEntities(o => !o.DeleteDate.HasValue && o.Terms.OrderId == order.Id && o.ProccessedAmount.HasValue).ToList();

            foreach (var termPosition in termPositions)
            {
                //positions
                if (termPosition.ProccessedAmount.Value > 0)
                {
                    var positionProfit = CalculatePositionPrice(termPosition.Positions.Price, termPosition.ProccessedAmount.Value,
                        termPosition.Positions.Payment);

                    result += positionProfit;

                    //todo calculate profit
                    profit += positionProfit;
                }

                //materials
                foreach (var material in termPosition.TermPositionMaterialRsps.Where(o => !o.DeleteDate.HasValue && o.Amount.HasValue))
                {
                    var amount = material.Amount.Value;
                    if (material.Materials.MaterialAmountTypes == MaterialAmountTypes.Meter)
                    {
                        if (material.Materials.Length != 0)
                        {
                            amount = amount / (double)material.Materials.Length.Value;
                        }
                        else
                        {
                            //todo
                        }
                    }

                    result += CalculatePositionPrice(material.Materials.Price, amount, PaymentTypes.Standard);

                    var materialProfit = material.Materials.Price * amount - material.Materials.BoughtPrice * amount;
                    profit += materialProfit;
                }
            }

            //material positions without terms
            var materialPositionsWithoutTerms = positionsManager.GetEntities(o => o.OrderId == order.Id && !o.DeleteDate.HasValue &&
                !o.TermId.HasValue && o.MaterialId.HasValue && o.IsMaterialPosition).ToList();
            foreach (var position in materialPositionsWithoutTerms)
            {
                var price = CalculatePositionPrice(position.Price, position.Amount, position.Payment);

                result += price;

                profit += price - position.Materials.BoughtPrice * position.Amount;
            }

            //extra costs
            var termCosts = termCostsManager.GetEntities(o => !o.DeleteDate.HasValue && o.Terms.OrderId == order.Id).ToList();
            foreach (var termCost in termCosts)
            {
                var price = CalculatePositionPrice(termCost.Price, 1, PaymentTypes.Standard);

                result += price;

                profit += price - termCost.Costs;
            }


            //TODO get taxes from invoices and calculate taxes only for open positions
            var taxes = CalculateTaxes(taxesManager);

            var taxValue = (result / (double)100) * taxes;
            if (order.Customers.WithTaxes)
            {
                //with taxes
                result += taxValue;
            }

            return result;
        }
        
        public static double CalculateTaxes(ITaxesManager taxesManager)
        {
            var taxValues = taxesManager.GetEntities(o => o.FromDate.Date <= DateTime.Now.Date && o.ToDate.Date >= DateTime.Now).ToList();
            double taxValue = 19;
            if (taxValues.Count != 0)
            {
                var minToDate = taxValues.Min(o => o.ToDate.Date);
                var temp = taxValues.FirstOrDefault(o => o.ToDate.Date == minToDate);
                if (temp != null)
                {
                    taxValue = temp.Value;
                }
            }
            return taxValue;
        }        

        private static double CalculateTaxesAndDiscount(double discount,
            double taxes,
            bool withTaxes,
            double? manualPrice,
            ref double totalPriceWithoutDiscountWithoutTax, 
            ref double totalPriceWithoutTax, 
            ref double totalPrice)
        {
            double summaryPrice = 0;
            //discount only for products
            var discountValue = (totalPriceWithoutDiscountWithoutTax / (double)100) * discount;
            
            //discount
            totalPriceWithoutTax = totalPriceWithoutDiscountWithoutTax - discountValue;

            var taxValue = (totalPriceWithoutTax / (double)100) * taxes;
            if (withTaxes)
            {
                //with taxes
                totalPrice = totalPriceWithoutTax + taxValue;
            }
            else
            {
                //without taxes
                totalPrice = totalPriceWithoutTax;
            }

            //override total price with manual price
            if (manualPrice.HasValue)
            {
                summaryPrice = manualPrice.Value;
            }
            else
            {
                summaryPrice = totalPrice;
            }

            totalPriceWithoutDiscountWithoutTax = Math.Round(totalPriceWithoutDiscountWithoutTax, 2);
            totalPriceWithoutTax = Math.Round(totalPriceWithoutTax, 2);
            totalPrice = Math.Round(totalPrice, 2);

            return Math.Round(summaryPrice, 2);
        }

        public static double CalculatePositionPrice(double price, double amount, PaymentTypes payment)
        {
            double result = 0;

            if (payment == PaymentTypes.Total)
            {
                result = price;
            }
            else
            {
                result = price * amount;
            }

            return Math.Round(result, 2);
        }
    }
}
