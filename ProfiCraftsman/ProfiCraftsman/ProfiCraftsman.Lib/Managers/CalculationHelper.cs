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
            out double totalPriceForMainPositions, 
            out double totalPriceWithoutDiscountWithoutTax,
            out double totalPriceWithoutTax,
            out double totalPrice,
            out double summaryPrice)
        {
            totalPriceForMainPositions = 0;
            totalPriceWithoutDiscountWithoutTax = 0;
            totalPriceWithoutTax = 0;
            totalPrice = 0;

            var allPositions = entity.InvoicePositions.Where(o => !o.DeleteDate.HasValue).ToList();

            //todo
            ////total price for main positions
            //foreach (var position in allPositions.Where(o => !o.Positions.IsAlternative))
            //{
            //    if (position.Positions.HasProducts)
            //    {
            //        totalPriceForMainPositions += CalculatePositionPrice(position.Price, position.Amount, position.Payment);
            //    }
            //    else
            //    {
            //        totalPriceForMainPositions += position.Price * (double)position.Amount;
            //    }
            //}

            ////Product prices
            //foreach (var position in allPositions.Where(o => o.Positions.ProductId.HasValue))
            //{
            //    totalPriceWithoutDiscountWithoutTax += CalculatePositionPrice(position.Price, position.Amount, position.Payment);
            //}

            double additionalCostPrices = 0;
            ////additional cost prices
            //foreach (var position in allPositions.Where(o => o.Positions.MaterialId.HasValue))
            //{
            //    additionalCostPrices += position.Price * (double)position.Amount;
            //}


            //total price for positions
            foreach (var position in allPositions)//TODO.Where(o => !o.Positions.IsAlternative))
            {
                totalPriceForMainPositions += CalculatePositionPrice(position.Price, position.Amount, position.Payment);
            }


            totalPriceWithoutDiscountWithoutTax = totalPriceForMainPositions;

            summaryPrice = CalculateTaxesAndDiscount(entity.Discount, entity.TaxValue, entity.WithTaxes, entity.ManualPrice, additionalCostPrices,
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
            foreach (var position in allPositions.Where(o => o.ProductId.HasValue))
            {
                totalPriceWithoutDiscountWithoutTax += CalculatePositionPrice(position.Price, position.Amount, position.Payment);
            }

            double additionalCostPrices = 0;
            //additional cost prices
            foreach (var position in allPositions.Where(o => o.MaterialId.HasValue))
            {
                additionalCostPrices += position.Price * (double)position.Amount;
            }

            var taxValue = CalculateTaxes(taxesManager);

            summaryPrice = CalculateTaxesAndDiscount(entity.Discount ?? 0, taxValue, entity.Customers.WithTaxes, null, additionalCostPrices,
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
        
        public static void CalculateTransportInvoicePrices(TransportOrders entity,
            double taxValue,
            bool withTaxes,
            double? manualPrice,
            out double totalPriceWithoutDiscountWithoutTax,
            out double totalPriceWithoutTax,
            out double totalPrice,
            out double summaryPrice)
        {
            totalPriceWithoutDiscountWithoutTax = 0;
            totalPriceWithoutTax = 0;
            totalPrice = 0;

            var allPositions = entity.TransportPositions.Where(o => !o.DeleteDate.HasValue).ToList();
            //Product prices
            foreach (var position in allPositions)
            {
                totalPriceWithoutDiscountWithoutTax += CalculatePositionPrice(position.Price, position.Amount, PaymentTypes.Total);
            }

            summaryPrice = CalculateTaxesAndDiscount(entity.Discount ?? 0, taxValue, withTaxes, manualPrice, 0,
                ref totalPriceWithoutDiscountWithoutTax, ref totalPriceWithoutTax, ref totalPrice);
        }

        private static double CalculateTaxesAndDiscount(double discount,
            double taxes,
            bool withTaxes,
            double? manualPrice,
            double additionalCostPrices,
            ref double totalPriceWithoutDiscountWithoutTax, 
            ref double totalPriceWithoutTax, 
            ref double totalPrice)
        {
            double summaryPrice = 0;
            //discount only for products
            var discountValue = (totalPriceWithoutDiscountWithoutTax / (double)100) * discount;

            totalPriceWithoutDiscountWithoutTax += additionalCostPrices;

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
