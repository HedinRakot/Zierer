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
