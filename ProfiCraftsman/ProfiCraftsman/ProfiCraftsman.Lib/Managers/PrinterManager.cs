﻿using CoreBase.Managers;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace ProfiCraftsman.Lib.Managers
{
    public class PrinterManager : PrinterManagerBase, IPrinterManager
    {
        #region Prepare Print

        public MemoryStream PrepareRentOrderPrintData(int id, string path, ITaxesManager taxesManager, IOrdersManager ordersManager)
        {
            return PrepareCommonOrderPrintData(ordersManager, id, path, PrintTypes.RentOrder, null, taxesManager);
        }

        public MemoryStream PrepareOfferPrintData(int id, string path, ITaxesManager taxesManager, IOrdersManager ordersManager)
        {
            return PrepareCommonOrderPrintData(ordersManager, id, path, PrintTypes.Offer, null, taxesManager);
        }

        public MemoryStream PrepareInvoicePrintData(int id, string path, IInvoicesManager invoicesManager, IOrdersManager ordersManager)
        {
            return PrepareCommonOrderPrintData(ordersManager, id, path, PrintTypes.Invoice, invoicesManager, null);
        }

        public MemoryStream PrepareInvoiceStornoPrintData(int id, string path, IInvoiceStornosManager invoiceStornosManager, IOrdersManager ordersManager)
        {
            return PrepareCommonOrderPrintData(ordersManager, id, path, PrintTypes.InvoiceStorno, null, null, invoiceStornosManager);
        }

        public MemoryStream PrepareTransportInvoicePrintData(int id, string path, ITransportOrdersManager transportOrdersManager, 
            ITaxesManager taxesManager, IOrdersManager ordersManager)
        {
            return PrepareCommonOrderPrintData(ordersManager, id, path, PrintTypes.TransportInvoice, null, taxesManager, null, transportOrdersManager);
        }

        public MemoryStream PrepareDeliveryNotePrintData(int id, string path, ITermsManager termsManager)
        {
            return PrepareCommonOrderPrintData(null, id, path, PrintTypes.DeliveryNote, null, null, null, null, termsManager);
        }

        public MemoryStream PrepareBackDeliveryNotePrintData(int id, string path, IOrdersManager ordersManager)
        {
            return PrepareCommonOrderPrintData(ordersManager, id, path, PrintTypes.BackDeliveryNote, null, null);
        }

        public MemoryStream PrepareMonthInvoicePrintData(IEnumerable<Invoices> invoices, string path, IInvoicesManager invoicesManager, 
            ITaxesManager taxesManager, IOrdersManager ordersManager)
        {
            var result = new MemoryStream();
            try
            {
                Package pkg;
                PackagePart part;
                XmlReader xmlReader;
                XDocument xmlMainXMLDoc;
                GetXmlDoc(path, result, out pkg, out part, out xmlReader, out xmlMainXMLDoc);


                var temp = xmlMainXMLDoc.Descendants().LastOrDefault(o => o.Value.Contains("#CustomerName"));
                var parentElement = GetParentElementByName(temp, "<w:body ");
                var bodyText = String.Join("", parentElement.Elements());

                var templateBody = xmlMainXMLDoc.Root.ToString();
                bool firstElem = true;
                foreach (var invoice in invoices)
                {
                    if (!firstElem)
                    {
                        var index = templateBody.IndexOf("</w:body");
                        var pageBreak = @"<w:p w:rsidRDefault=""00C97ADC"" w:rsidR=""00C97ADC""><w:pPr><w:rPr><w:lang w:val=""en-GB""/></w:rPr></w:pPr><w:r><w:rPr><w:lang w:val=""en-GB""/>
                            </w:rPr><w:br w:type=""page""/></w:r></w:p><w:p w:rsidRDefault=""009A5AB0"" w:rsidRPr=""00905C57"" w:rsidR=""009A5AB0"" w:rsidP=""0030272E"">
                            <w:pPr><w:rPr><w:lang w:val=""en-GB""/></w:rPr></w:pPr><w:bookmarkStart w:name=""_GoBack"" w:id=""0""/><w:bookmarkEnd w:id=""0""/></w:p>";
                        templateBody = templateBody.Substring(0, index) + pageBreak + bodyText + templateBody.Substring(index);
                    }
                    else
                    {
                        firstElem = false;
                    }

                    //replace fields
                    templateBody = ReplaceFields(ordersManager, 0, PrintTypes.Invoice, templateBody, invoicesManager, taxesManager, invoice);
                }

                xmlMainXMLDoc = SaveDoc(result, pkg, part, xmlReader, xmlMainXMLDoc, templateBody);
            }
            catch
            {
            }

            return result;
        }

        public MemoryStream PrepareReminderPrintData(IEnumerable<Invoices> invoices, string path, IInvoicesManager invoicesManager, 
            ITaxesManager taxesManager, IOrdersManager ordersManager)
        {
            var result = new MemoryStream();
            try
            {
                Package pkg;
                PackagePart part;
                XmlReader xmlReader;
                XDocument xmlMainXMLDoc;
                GetXmlDoc(path, result, out pkg, out part, out xmlReader, out xmlMainXMLDoc);


                var temp = xmlMainXMLDoc.Descendants().LastOrDefault(o => o.Value.Contains("#CustomerName"));
                var parentElement = GetParentElementByName(temp, "<w:body ");
                var bodyText = String.Join("", parentElement.Elements());

                var templateBody = xmlMainXMLDoc.Root.ToString();
                bool firstElem = true;
                foreach (var invoiceGroup in invoices.GroupBy(o => o.Orders.Customers))
                {
                    if (!firstElem)
                    {
                        var index = templateBody.IndexOf("</w:body");
                        var pageBreak = @"<w:p w:rsidRDefault=""00C97ADC"" w:rsidR=""00C97ADC""><w:pPr><w:rPr><w:lang w:val=""en-GB""/></w:rPr></w:pPr><w:r><w:rPr><w:lang w:val=""en-GB""/>
                            </w:rPr><w:br w:type=""page""/></w:r></w:p><w:p w:rsidRDefault=""009A5AB0"" w:rsidRPr=""00905C57"" w:rsidR=""009A5AB0"" w:rsidP=""0030272E"">
                            <w:pPr><w:rPr><w:lang w:val=""en-GB""/></w:rPr></w:pPr><w:bookmarkStart w:name=""_GoBack"" w:id=""0""/><w:bookmarkEnd w:id=""0""/></w:p>";
                        templateBody = templateBody.Substring(0, index) + pageBreak + bodyText + templateBody.Substring(index);
                    }
                    else
                    {
                        firstElem = false;
                    }

                    //replace fields
                    templateBody = ReplaceCommonFields(invoiceGroup.Key, templateBody);
                    templateBody = ReplaceTotalReminderPositions(invoiceGroup.ToList(), templateBody);
                }

                //if (firstElem)
                //{
                //    templateBody = XDocument.Parse(templateBody.Substring(0, templateBody.IndexOf("<w:body>")) + "<w:body>" + 
                //        templateBody.Substring(templateBody.IndexOf("</w:body"))).Root.ToString();
                //}

                xmlMainXMLDoc = SaveDoc(result, pkg, part, xmlReader, xmlMainXMLDoc, templateBody);
            }
            catch
            {
            }

            return result;
        }

        private MemoryStream PrepareCommonOrderPrintData(IOrdersManager ordersManager, int id, string path, PrintTypes type,
            IInvoicesManager invoicesManager, ITaxesManager taxesManager, IInvoiceStornosManager invoiceStornosManager = null,
            ITransportOrdersManager transportOrdersManager = null,
            ITermsManager termsManager = null)
        {
            var result = new MemoryStream();
            try
            {
                Package pkg;
                PackagePart part;
                XmlReader xmlReader;
                XDocument xmlMainXMLDoc;
                GetXmlDoc(path, result, out pkg, out part, out xmlReader, out xmlMainXMLDoc);

                //replace fields
                var templateBody = ReplaceFields(ordersManager, id, type, xmlMainXMLDoc.Root.ToString(),
                    invoicesManager, taxesManager, null, invoiceStornosManager, transportOrdersManager, termsManager);

                xmlMainXMLDoc = SaveDoc(result, pkg, part, xmlReader, xmlMainXMLDoc, templateBody);
            }
            catch
            {
            }

            return result;
        }
        

        #endregion

        #region Replace Fields Info

        private string ReplaceFields(IOrdersManager ordersManager, int id, PrintTypes printType, string xmlMainXMLDoc,
            IInvoicesManager invoicesManager, ITaxesManager taxesManager, Invoices invoice = null,
            IInvoiceStornosManager invoiceStornosManager = null,
            ITransportOrdersManager transportOrdersManager = null,
            ITermsManager termsManager = null)
        {
            string result = xmlMainXMLDoc;

            switch (printType)
            {
                case PrintTypes.RentOrder:
                    var order = ordersManager.GetById(id);
                    result = ReplaceCommonFields(order, result);
                    result = ReplaceBaseOrderFields(order, result);

                    result = result.Replace("#SignatureDate", order.CreateDate.AddDays(2).ToShortDateString());

                    result = ReplaceRentPositions(order, result, taxesManager);
                    result = ReplaceTotalPrice(order, result, taxesManager);
                    result = ReplaceRentAdditionalCostPositions(order, result);
                    break;
                case PrintTypes.Offer:
                    order = ordersManager.GetById(id);
                    result = ReplaceCommonFields(order, result);
                    result = ReplaceBaseOfferFields(order, result);
                    result = ReplaceBaseOrderFields(order, result);
                    result = ReplaceRentPositions(order, result, taxesManager);
                    result = ReplaceRentAdditionalCostPositions(order, result);
                    break;
                case PrintTypes.Invoice:

                    if (invoice == null)
                    {
                        invoice = invoicesManager.GetById(id);
                    }

                    order = invoice.Orders;

                    result = ReplaceCommonFields(order, result);
                    result = ReplaceBaseOrderFields(order, result);
                    result = ReplaceBaseInvoiceFields(invoice, result, printType);

                    bool manualPricePrinted = false;
                    result = ReplaceInvoicePositions(invoice, invoice.InvoicePositions.ToList(), result,
                        "#ProductDescription", "#ProductPrice", "Mietgegenstand: ", true, ref manualPricePrinted);
                    result = ReplaceInvoicePositions(invoice, invoice.InvoicePositions.ToList(), result,
                        "#AdditionalCostDescription", "#AdditionalCostPrice", "Nebenkosten: ", false, ref manualPricePrinted);
                    result = ReplaceInvoicePrices(invoice, result);
                    break;
                case PrintTypes.InvoiceStorno:

                    var invoiceStorno = invoiceStornosManager.GetById(id);
                    invoice = invoiceStorno.Invoices;
                    order = invoice.Orders;

                    result = ReplaceCommonFields(order, result);
                    result = ReplaceBaseOrderFields(order, result);
                    result = ReplaceBaseInvoiceFields(invoice, result, printType);
                    result = ReplaceInvoiceStornoPrices(invoiceStorno, result);

                    result = ReplaceFieldValue(result, "#FreeText", invoiceStorno.FreeText);

                    break;
                case PrintTypes.ReminderMail:

                    invoice = invoicesManager.GetById(id);
                    order = invoice.Orders;

                    result = ReplaceCommonFields(order, result);
                    result = ReplaceReminderPositions(invoice.InvoicePositions.ToList(), result);
                    result = ReplaceReminderTotalPrice(invoice, result, taxesManager);

                    break;
                case PrintTypes.TransportInvoice:

                    var transportOrder = transportOrdersManager.GetById(id);

                    result = ReplaceTransportOrderCommonFields(transportOrder, result);
                    result = ReplaceBaseTransportInvoiceFields(transportOrder, result, printType);
                    result = ReplaceTransportPositions(transportOrder.TransportPositions.Where(o => !o.DeleteDate.HasValue).ToList(), result);
                    result = ReplaceTransportInvoicePrices(transportOrder, result, taxesManager);
                    break;
                case PrintTypes.DeliveryNote:

                    var term = termsManager.GetById(id);
                    result = ReplaceCommonFields(term.Orders, result);
                    result = ReplaceBaseOrderFields(term.Orders, result);

                    result = result.Replace("#DeliveryNoteType", "Lieferschein");
                    result = result.Replace("#DateType", "Liefertermin");
                    result = result.Replace("#AdressType", "Lieferanschrift");
                    result = result.Replace("#OrderNumber", term.Orders.OrderNumber);
                    
                    var positions = term.Orders.Positions != null ? term.Orders.Positions.Where(o => !o.DeleteDate.HasValue).ToList() :
                        new List<Positions>();

                    result = ReplacePositionWithDescription(positions, result);
                    break;
                //case PrintTypes.BackDeliveryNote:

                //    order = ordersManager.GetById(id);
                //    result = ReplaceCommonFields(order, result);
                //    result = ReplaceBaseOrderFields(order, result);

                //    result = result.Replace("#DeliveryNoteType", "Rücklieferschein");
                //    result = result.Replace("#DateType", "Abholtermin");
                //    result = result.Replace("#AdressType", "Abholanschrift");
                //    result = result.Replace("#OrderNumber", order.OrderNumber);
                    
                //    positions = order.Positions != null ? order.Positions.Where(o => !o.DeleteDate.HasValue).ToList() :
                //        new List<Positions>();

                //    result = ReplacePositionWithDescription(positions, result);
                //    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        private string ReplaceCommonFields(Orders order, string xmlMainXMLDoc)
        {
            return ReplaceCommonFields(order.Customers, xmlMainXMLDoc);
        }

        private string ReplaceCommonFields(Customers customer, string xmlMainXMLDoc)
        {
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CustomerName", customer.Name);
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CustomerStreet", customer.Street);
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CustomerZip", customer.Zip.ToString());
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CustomerCity", customer.City);
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CustomerNumber", customer.Number.ToString());
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CustomerPhone", customer.Phone.ToString());
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#IBAN", customer.Iban);
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#BIC", customer.Bic);
            xmlMainXMLDoc = xmlMainXMLDoc.Replace("#Today", DateTime.Now.ToShortDateString());

            return xmlMainXMLDoc;
        }

        private string ReplaceBaseOrderFields(Orders order, string xmlMainXMLDoc)
        {
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#Street", order.Street);
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#ZIP", order.Zip.ToString());
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#City", order.City);

            return xmlMainXMLDoc;
        }

        private string ReplaceBaseOfferFields(Orders order, string xmlMainXMLDoc)
        {
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CustomerPhone", order.Customers.Phone);
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CustomerFax", order.Customers.Fax);

            if (order.CommunicationPartners != null)
            {
                xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CommunicationPartnerName",
                    String.Format("{0} {1}", order.CommunicationPartners.FirstName, order.CommunicationPartners.Name));
            }
            else
            {
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#CommunicationPartnerName", String.Empty);
            }

            var positions = order.Positions != null ? order.Positions.Where(o => !o.DeleteDate.HasValue && o.ProductId.HasValue).ToList() :
                new List<Positions>();

            if (positions.Count != 0)
            {
                var minDate = DateTime.Now;
                var maxDate = DateTime.Now;
                var duration = maxDate - minDate;
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#RentDuration", String.Format("{0} Tage", duration.Days));
            }
            else
            {
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#RentDuration", String.Empty);
            }

            return xmlMainXMLDoc;
        }

        #region Offers/Orders

        private string ReplaceRentPositions(Orders order, string xmlMainXMLDoc, ITaxesManager taxesManager)
        {
            var positions = order.Positions != null ? order.Positions.Where(o => !o.DeleteDate.HasValue && o.ProductId.HasValue).ToList() :
                new List<Positions>();

            if (positions.Count != 0)
            {
                var minDate = DateTime.Now;
                var maxDate = DateTime.Now;
                var totalSellPrice = positions.Sum(o => o.Products.Price);

                if (positions.Any(o => o.Payment == PaymentTypes.Total))
                {
                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#RentPositionDescription", "Produkt gemäß Position 1");
                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#PaymentType", "Pauschal");

                    var totalPriceWithoutTax = positions.Sum(o => o.Price);
                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#RentPrice", totalPriceWithoutTax.ToString("N2"));

                    if (order.Customers.WithTaxes)
                    {
                        var taxes = CalculationHelper.CalculateTaxes(taxesManager);

                        var taxValue = (totalPriceWithoutTax / (double)100) * taxes;
                        //with taxes
                        var totalPrice = totalPriceWithoutTax + taxValue;

                        xmlMainXMLDoc = xmlMainXMLDoc.Replace("#BruttoPauschalPreis", totalPrice.ToString("N2"));
                    }
                    else
                    {
                        xmlMainXMLDoc = xmlMainXMLDoc.Replace("#BruttoPauschalPreis", totalPriceWithoutTax.ToString("N2"));
                    }
                }
                else
                {
                    xmlMainXMLDoc = ReplaceShortPositionDescription(positions, xmlMainXMLDoc);
                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#BruttoPauschalPreis", String.Empty);
                }

                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#FromDate", minDate.ToShortDateString());
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#ToDate", maxDate.ToShortDateString());
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#LastPaymentDate", maxDate.AddDays(10).ToShortDateString());
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TotalSellPrice", totalSellPrice.ToString("N2"));

                xmlMainXMLDoc = ReplacePositionWithDescription(positions, xmlMainXMLDoc);
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#ProductDescription", String.Empty);
            }
            else
            {
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#ProductDescription", String.Empty);
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#FromDate", String.Empty);
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#ToDate", String.Empty);
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#LastPaymentDate", String.Empty);
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#BruttoPauschalPreis", String.Empty);
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TotalSellPrice", String.Empty);
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#RentPositionDescription", String.Empty);
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#RentPrice", String.Empty);
            }

            return xmlMainXMLDoc;
        }

        private string ReplaceTotalPrice(Orders order, string xmlMainXMLDoc, ITaxesManager taxesManager)
        {
            if (order.Positions != null && order.Positions.Count != 0)
            {
                double totalPriceWithoutDiscountWithoutTax = 0;
                double totalPriceWithoutTax = 0;
                double totalPrice = 0;
                double summaryPrice = 0;

                CalculationHelper.CalculateOrderPrices(order, taxesManager, out totalPriceWithoutDiscountWithoutTax, out totalPriceWithoutTax,
                out totalPrice, out summaryPrice);

                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TotalPrice", summaryPrice.ToString("N2"));
            }
            else
            {
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TotalPrice", String.Empty);
            }

            return xmlMainXMLDoc;
        }

        private string ReplaceRentAdditionalCostPositions(Orders order, string xmlMainXMLDoc)
        {
            if (order.Positions != null && order.Positions.Count != 0)
            {
                var positions = order.Positions.Where(o => !o.DeleteDate.HasValue && o.MaterialId.HasValue).ToList();
                var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
                var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#AdditionalCostDescription"));
                var parentTableElement = GetParentElementByName(temp, "<w:tr ");
                var prevElement = parentTableElement;

                var hasPauschalPosition = order.Positions.Any(o => !o.DeleteDate.HasValue && o.PaymentType == (int)PaymentTypes.Total);

                if (parentTableElement != null)
                {
                    foreach (var position in positions)
                    {
                        var price = Math.Round(position.Price * position.Amount, 2);

                        if (hasPauschalPosition)
                        {
                            price = 0;
                        }

                        var textElem = XElement.Parse(
                            ReplaceFieldValue(parentTableElement.ToString(), "#AdditionalCostDescription",
                                position.Materials.Name).
                            Replace("#AdditionalCostType",
                                String.Format("{0} x {1}", position.Amount, "Produkt")).
                            Replace("#AdditionalCostPrice", price.ToString("N2")));

                        prevElement.AddAfterSelf(textElem);
                        prevElement = textElem;
                    }

                    parentTableElement.Remove();
                }

                xmlMainXMLDoc = xmlDoc.Root.ToString();
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#AdditionalCostDescription", String.Empty);
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#AdditionalCostPrice", String.Empty);
            }
            else
            {
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#AdditionalCostDescription", String.Empty);
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#AdditionalCostPrice", String.Empty);
            }

            return xmlMainXMLDoc;
        }

        private string ReplaceShortPositionDescription(List<Positions> positions, string xmlMainXMLDoc)
        {
            var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#RentPositionDescription"));
            var parentTableElement = GetParentElementByName(temp, "<w:tr ");
            var prevElement = parentTableElement;

            if (parentTableElement != null)
            {
                foreach (var position in positions)
                {
                    var textElem = XElement.Parse(ReplaceFieldValue(
                        parentTableElement.ToString(), "#RentPositionDescription", position.Products.ProductTypes.Name).
                        Replace("#PaymentType", position.PaymentTypeString).
                        Replace("#RentPrice", Math.Round(position.Price / (double)30, 2).ToString("N2")));
                    prevElement.AddAfterSelf(textElem);
                    prevElement = textElem;
                }

                parentTableElement.Remove();
            }

            return xmlDoc.Root.ToString();
        }

        private string ReplacePositionWithDescription(List<Positions> positions, string xmlMainXMLDoc)
        {
            var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#PositionDescription"));
            var parentTableElement = GetParentElementByName(temp, "<w:tr ");

            if (parentTableElement != null)
            {
                var prevTableElem = parentTableElement;

                foreach (var position in positions)
                {
                    var elem = XElement.Parse(ReplaceFieldValue(parentTableElement.ToString(), "#PositionDescription",
                        position.ProductId.HasValue ? position.Products.Name :
                            position.MaterialId.HasValue ? position.Materials.Name : String.Empty).
                        Replace("#Amount", position.ProductId.HasValue ? position.TermPositions.Sum(o => o.Amount).ToString() :
                            position.MaterialId.HasValue ? position.PositionMaterialRsps.Where(o => o.Amount.HasValue).Sum(o => o.Amount.Value).ToString() : String.Empty).
                        Replace("#PositionNumber", position.ProductId.HasValue ? position.Products.Number :
                            position.MaterialId.HasValue ? position.Materials.Number : String.Empty));

                    prevTableElem.AddAfterSelf(elem);
                    prevTableElem = elem;

                    if (position.PositionMaterialRsps != null && position.PositionMaterialRsps.Count != 0)
                    {
                        foreach (var material in position.PositionMaterialRsps)
                        {
                            elem = XElement.Parse(ReplaceFieldValue(parentTableElement.ToString(), "#PositionDescription", material.Materials.Name).
                            Replace("#Amount", material.Amount.HasValue ? material.Amount.Value.ToString() : String.Empty).
                            Replace("#PositionNumber", material.Materials.Number));

                            prevTableElem.AddAfterSelf(elem);
                            prevTableElem = elem;
                        }
                    }
                }

                parentTableElement.Remove();
            }

            return xmlDoc.Root.ToString();
        }

        #endregion

        #region Invoices

        private string ReplaceBaseInvoiceFields(Invoices invoice, string xmlMainXMLDoc, PrintTypes printType)
        {
            var order = invoice.Orders;

            if (printType == PrintTypes.InvoiceStorno)
            {
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#InvoiceType", "Gutschrift");
            }
            else
            {
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#InvoiceType", "Rechnung");
            }

            xmlMainXMLDoc = xmlMainXMLDoc.Replace("#InvoiceNumber", invoice.InvoiceNumber);
            xmlMainXMLDoc = xmlMainXMLDoc.Replace("#InvoiceDate", invoice.CreateDate.ToShortDateString());

            //xmlMainXMLDoc = ReplaceOrderedFromInfo(xmlMainXMLDoc, order);

            //xmlMainXMLDoc = ReplaceCustomerOrderNumber(xmlMainXMLDoc, order);

            xmlMainXMLDoc = ReplaceRentOrderInfo(xmlMainXMLDoc, order, invoice);

            xmlMainXMLDoc = xmlMainXMLDoc.Replace("#OrderNumber", order.OrderNumber);

            xmlMainXMLDoc = ReplaceUstId(xmlMainXMLDoc, order);

            xmlMainXMLDoc = ReplaceRentInterval(xmlMainXMLDoc, order, invoice);

            xmlMainXMLDoc = ReplaceFooterTexts(xmlMainXMLDoc, order, invoice);

            return xmlMainXMLDoc;
        }
        
        private string ReplaceRentOrderInfo(string xmlMainXMLDoc, Orders order, Invoices invoice)
        {
            var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#RentOrderInfo"));
            var parentElement = GetParentElementByName(temp, "<w:tr ");

            if (parentElement != null)
            {
                //if (!invoice.IsSellInvoice && !String.IsNullOrEmpty(order.RentOrderNumber))
                //{
                //    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#RentOrderInfo", String.Format("{0}{1}{2}",
                //        order.CreateDate.ToShortDateString(),
                //        !String.IsNullOrEmpty(order.RentOrderNumber) ? " Nr. " : String.Empty,
                //        !String.IsNullOrEmpty(order.RentOrderNumber) ? order.RentOrderNumber : String.Empty));
                //}
                //else
                //{
                //    parentElement.Remove();
                //    xmlMainXMLDoc = xmlDoc.Root.ToString();
                //}
            }
            return xmlMainXMLDoc;
        }

        private string ReplaceUstId(string xmlMainXMLDoc, Orders order)
        {
            var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#CustomerUstId"));
            var parentElement = GetParentElementByName(temp, "<w:tr ");

            if (parentElement != null)
            {
                if (!String.IsNullOrEmpty(order.Customers.UstId))
                {
                    xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CustomerUstId", order.Customers.UstId);
                }
                else
                {
                    parentElement.Remove();
                    xmlMainXMLDoc = xmlDoc.Root.ToString();
                }
            }
            return xmlMainXMLDoc;
        }

        private string ReplaceRentInterval(string xmlMainXMLDoc, Orders order, Invoices invoice)
        {
            var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#RentPeriod"));
            var parentElement = GetParentElementByName(temp, "<w:tr ");

            if (parentElement != null)
            {
                var positions = invoice.InvoicePositions != null ? invoice.InvoicePositions.Where(o => !o.DeleteDate.HasValue && o.Positions.ProductId.HasValue).ToList() :
                    new List<InvoicePositions>();

                if (!invoice.IsSellInvoice && positions.Count != 0)
                {
                    var minDate = DateTime.Now;
                    var maxDate = DateTime.Now;

                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#RentPeriod", String.Format("{0} bis {1}",
                        minDate.ToShortDateString(),
                        maxDate.ToShortDateString()));
                }
                else
                {
                    parentElement.Remove();
                    xmlMainXMLDoc = xmlDoc.Root.ToString();
                }
            }
            return xmlMainXMLDoc;
        }

        private string ReplaceInvoicePositions(Invoices invoice, List<InvoicePositions> positions, string xmlMainXMLDoc,
            string parentTag, string priceTag, string titleText, bool isAlternative, ref bool manualPricePrinted)
        {
            var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains(parentTag));
            var parentTableElement = GetParentElementByName(temp, "<w:tr ");

            if (parentTableElement != null)
            {
                var prevTableElem = parentTableElement;

                bool firstElem = true;

                foreach (var position in positions.Where(o => o.Positions.IsAlternative == isAlternative && o.Positions.Products != null))
                {
                    double price = 0;
                    if (!invoice.ManualPrice.HasValue)
                    {
                        price = CalculationHelper.CalculatePositionPrice(position.Price, position.Amount, position.Payment);
                    }
                    else if (!manualPricePrinted)
                    {
                        price = invoice.ManualPrice.Value;
                        manualPricePrinted = true;
                    }

                    var rowElem = XElement.Parse(ReplaceFieldValue(
                        parentTableElement.ToString(), parentTag,
                            String.Format("{0}{1} Nr. {2}", firstElem ? titleText : "",
                                position.Positions.Products.ProductTypes.Name,
                                position.Positions.Products.Number)).
                        Replace(priceTag, price.ToString("N2")));
                    prevTableElem.AddAfterSelf(rowElem);
                    prevTableElem = rowElem;

                    if (firstElem)
                    {
                        firstElem = false;
                    }
                }

                foreach (var position in positions.Where(o => o.Positions.IsAlternative == isAlternative && o.Positions.Materials != null))
                {
                    double price = 0;
                    if (!invoice.ManualPrice.HasValue)
                    {
                        price = CalculationHelper.CalculatePositionPrice(position.Price, position.Amount, position.Payment);
                    }
                    else if (!manualPricePrinted)
                    {
                        price = invoice.ManualPrice.Value;
                        manualPricePrinted = true;
                    }

                    var rowElem = XElement.Parse(ReplaceFieldValue(
                        parentTableElement.ToString(), parentTag,
                            String.Format("{0}{1} {2}", firstElem ? titleText : "",
                                position.Amount,
                                position.Positions.Materials.Name)).
                        Replace(priceTag, price.ToString("N2")));
                    prevTableElem.AddAfterSelf(rowElem);
                    prevTableElem = rowElem;

                    if (firstElem)
                    {
                        firstElem = false;
                    }
                }

                parentTableElement.Remove();
            }

            return xmlDoc.Root.ToString();
        }

        private string ReplaceInvoicePrices(Invoices invoice, string xmlMainXMLDoc)
        {
            if (invoice.InvoicePositions != null && invoice.InvoicePositions.Count != 0)
            {
                double totalPriceForMainPositions = 0;
                double totalPriceWithoutDiscountWithoutTax = 0;
                double totalPriceWithoutTax = 0;
                double totalPrice = 0;
                double summaryPrice = 0;

                if (!invoice.ManualPrice.HasValue)
                {
                    CalculationHelper.CalculateInvoicePrices(invoice, out totalPriceForMainPositions, out totalPriceWithoutDiscountWithoutTax, out totalPriceWithoutTax,
                        out totalPrice, out summaryPrice);
                }
                else
                {
                    totalPriceWithoutTax = invoice.ManualPrice.Value;
                    var taxValue = (totalPriceWithoutTax / (double)100) * invoice.TaxValue;
                    if (invoice.WithTaxes && invoice.TaxValue > 0)
                    {
                        //with taxes
                        totalPrice = totalPriceWithoutTax + taxValue;
                    }
                    else
                    {
                        totalPrice = totalPriceWithoutTax;
                    }
                }

                //Discount
                var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
                var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#DiscountText"));
                var parentTableElement = GetParentElementByName(temp, "<w:tr ");

                if (!invoice.ManualPrice.HasValue && invoice.Discount > 0 && parentTableElement != null)
                {
                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#DiscountText",
                        String.Format("Abzüglich {0}% Rabatt", invoice.Discount));

                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#DiscountValue",
                        String.Format("-{0}", Math.Round(totalPriceWithoutDiscountWithoutTax - totalPriceWithoutTax, 2).
                            ToString("N2")));

                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#PriceWithoutTax", totalPriceWithoutTax.ToString("N2"));
                }
                else
                {
                    parentTableElement.Remove();
                    temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#PriceWithoutTax"));
                    parentTableElement = GetParentElementByName(temp, "<w:tr ");
                    parentTableElement.Remove();
                    xmlMainXMLDoc = xmlDoc.Root.ToString();
                }

                //Taxes
                xmlDoc = XDocument.Parse(xmlMainXMLDoc);
                temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#TaxText"));
                parentTableElement = GetParentElementByName(temp, "<w:tr ");

                if (invoice.WithTaxes && invoice.TaxValue > 0 && parentTableElement != null)
                {
                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TaxText",
                        String.Format("Zuzüglich {0}% MwSt.", invoice.TaxValue));

                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TaxValue",
                        String.Format("{0}", Math.Round(totalPrice - totalPriceWithoutTax, 2).ToString("N2")));
                }
                else
                {
                    parentTableElement.Remove();
                    xmlMainXMLDoc = xmlDoc.Root.ToString();
                }

                if (!invoice.ManualPrice.HasValue)
                {
                    //total price without discount and tax for main positions only                
                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TotalPriceWithoutDiscount", totalPriceForMainPositions.ToString("N2"));
                }
                else
                {
                    xmlDoc = XDocument.Parse(xmlMainXMLDoc);
                    temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#TotalPriceWithoutDiscount"));
                    parentTableElement = GetParentElementByName(temp, "<w:tr ");
                    parentTableElement.Remove();
                    xmlMainXMLDoc = xmlDoc.Root.ToString();
                }


                //total price
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TotalPriceText", "Zu zahlender Betrag");
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TotalPrice", totalPrice.ToString("N2"));
            }

            return xmlMainXMLDoc;
        }

        private string ReplaceFooterTexts(string xmlMainXMLDoc, Orders order, Invoices invoice)
        {
            var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#PlanedPayDate"));
            var parentElement = GetParentElementByName(temp, "<w:tr ");

            var payDate = invoice.CreateDate.AddDays(invoice.PayInDays);

            //pay due information
            if (parentElement != null)
            {
                if (!String.IsNullOrEmpty(order.Customers.Iban) && !String.IsNullOrEmpty(order.Customers.Bic))
                {
                    temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#PayCashInterval"));
                    parentElement = GetParentElementByName(temp, "<w:tr ");
                    parentElement.Remove();
                    xmlMainXMLDoc = xmlDoc.Root.ToString();

                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#PlanedPayDate",
                        invoice.IsSellInvoice ? String.Empty : String.Format("am {0}", payDate.ToShortDateString()));
                }
                else
                {
                    parentElement.Remove();
                    xmlMainXMLDoc = xmlDoc.Root.ToString();

                    if (invoice.IsSellInvoice)
                    {
                        temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#PayCashInterval"));
                        parentElement = GetParentElementByName(temp, "<w:tr ");
                        parentElement.Remove();
                        xmlMainXMLDoc = xmlDoc.Root.ToString();
                    }
                    else
                    {
                        xmlMainXMLDoc = xmlMainXMLDoc.Replace("#PayCashInterval",
                            invoice.PayInDays == 0 ? "einem Tag" : String.Format("{0} Tage", invoice.PayInDays));
                    }
                }
            }


            //for sell Invoices
            xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#PayParts"));
            parentElement = GetParentElementByName(temp, "<w:tr ");

            if (parentElement != null)
            {
                if (invoice.IsSellInvoice)
                {
                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#PayParts",
                        String.Format("{0}% der Gesamtsumme bis {1} rein netto. {2}{3}% der Gesamtsumme nach Lieferung rein netto.",
                            invoice.PayPartOne.HasValue ? invoice.PayPartOne.Value : 75,
                            payDate.ToShortDateString(),
                            invoice.PayPartTwo.HasValue && invoice.PayPartTree.HasValue ?
                                String.Format("{0}% der Gesamtsumme bis {1} rein netto. ", invoice.PayPartTwo.Value,
                                payDate.AddDays(invoice.PayInDays).ToShortDateString()) : String.Empty,
                            invoice.PayPartTwo.HasValue && invoice.PayPartTree.HasValue ? invoice.PayPartTree.Value :
                                invoice.PayPartTwo.HasValue ? invoice.PayPartTwo.Value : 25
                        ));
                }
                else
                {
                    parentElement.Remove();
                    xmlMainXMLDoc = xmlDoc.Root.ToString();
                }
            }


            //Invoice without taxe
            xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#InvoiceWithoutTaxes"));
            parentElement = GetParentElementByName(temp, "<w:tr ");

            if (parentElement != null)
            {
                if (!invoice.WithTaxes)
                {
                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#InvoiceWithoutTaxes", String.Empty);
                }
                else
                {
                    parentElement.Remove();
                    xmlMainXMLDoc = xmlDoc.Root.ToString();
                }
            }

            return xmlMainXMLDoc;
        }

        #endregion

        #region Invoice Storno

        private string ReplaceInvoiceStornoPrices(InvoiceStornos invoiceStorno, string xmlMainXMLDoc)
        {
            double totalPrice = invoiceStorno.Price;

            //Discount
            xmlMainXMLDoc = xmlMainXMLDoc.Replace("#PriceWithoutTax", totalPrice.ToString("N2"));

            //Taxes
            var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#TaxText"));
            var parentTableElement = GetParentElementByName(temp, "<w:tr ");

            var invoice = invoiceStorno.Invoices;
            if (invoice.WithTaxes && invoice.TaxValue > 0 && parentTableElement != null)
            {
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TaxText",
                    String.Format("Zuzüglich {0}% MwSt.", invoice.TaxValue));

                var taxValue = (totalPrice / (double)100) * invoice.TaxValue;

                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TaxValue", taxValue.ToString("N2"));

                totalPrice += taxValue;
            }
            else
            {
                parentTableElement.Remove();
                xmlMainXMLDoc = xmlDoc.Root.ToString();
            }

            //total price
            xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TotalPrice", String.Format("-{0}", totalPrice.ToString("N2")));

            return xmlMainXMLDoc;
        }

        #endregion

        #region Reminder

        private string ReplaceTotalReminderPositions(List<Invoices> invoices, string xmlMainXMLDoc)
        {
            var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#InvoiceNumber"));
            var parentTableElement = GetParentElementByName(temp, "<w:tr ");

            if (parentTableElement != null)
            {
                var prevTableElem = parentTableElement;

                bool firstElem = true;
                double totalPriceForCustomer = 0;

                foreach (var invoice in invoices)
                {
                    double totalPriceForMainPositions = 0;
                    double totalPriceWithoutDiscountWithoutTax = 0;
                    double totalPriceWithoutTax = 0;
                    double totalPrice = 0;
                    double summaryPrice = 0;

                    CalculationHelper.CalculateInvoicePrices(invoice, out totalPriceForMainPositions, out totalPriceWithoutDiscountWithoutTax, out totalPriceWithoutTax,
                        out totalPrice, out summaryPrice);

                    totalPriceForCustomer += summaryPrice;

                    var rowElem = XElement.Parse(parentTableElement.ToString().
                        Replace("#InvoiceNumber", invoice.InvoiceNumber).
                        Replace("#InvoiceDate", invoice.CreateDate.ToShortDateString()).
                        Replace("#ReminderCount", invoice.ReminderCount.ToString()).
                        Replace("#Price", summaryPrice.ToString()));
                    prevTableElem.AddAfterSelf(rowElem);
                    prevTableElem = rowElem;

                    if (firstElem)
                    {
                        firstElem = false;
                    }
                }

                parentTableElement.Remove();

                xmlMainXMLDoc = xmlDoc.Root.ToString();
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TotalPrice", totalPriceForCustomer.ToString("N2"));

                double reminderPrice = 0;
                if (invoices.Any(o => o.ReminderCount == 3))
                {
                    reminderPrice = Contracts.Configuration.ReminderLevelTreePrice;
                }
                else if (invoices.Any(o => o.ReminderCount == 2))
                {
                    reminderPrice = Contracts.Configuration.ReminderLevelTwoPrice;
                }

                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TotalPrice", totalPriceForCustomer.ToString("N2"));
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#ReminderPrice", reminderPrice != 0 ?
                    String.Format("Mahngebühr: {0}", reminderPrice.ToString("N2")) : String.Empty);
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#PriceWithReminder", reminderPrice != 0 ?
                    String.Format("Gesamtbetrag: {0}", (totalPriceForCustomer + reminderPrice).ToString("N2")) : String.Empty);

                var maxDate = invoices.Max(o => o.LastReminderDate.Value);
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#PayDueDate", maxDate.AddDays(8).ToShortDateString());
            }

            return xmlMainXMLDoc;
        }

        private string ReplaceReminderPositions(List<InvoicePositions> positions, string xmlMainXMLDoc)
        {
            var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#InvoiceNumber"));
            var parentTableElement = GetParentElementByName(temp, "<w:tr ");

            if (parentTableElement != null)
            {
                var prevTableElem = parentTableElement;

                bool firstElem = true;
                foreach (var position in positions)
                {
                    var price = CalculationHelper.CalculatePositionPrice(position.Price, position.Amount, position.Payment);

                    var description = String.Empty;
                    if (position.Positions.ProductId.HasValue)
                    {
                        description = ReplaceFieldValue("#", "#", String.Format("{0} {1}", position.Amount,
                            position.Positions.Products.ProductTypes.Name));
                    }
                    else
                    {
                        description = ReplaceFieldValue("#", "#", String.Format("{0} {1}", position.Amount,
                            position.Positions.Materials.Name));
                    }

                    var rowElem = XElement.Parse(parentTableElement.ToString().
                        Replace("#InvoiceNumber", position.Invoices.InvoiceNumber).
                        Replace("#InvoiceDate", position.Invoices.CreateDate.ToShortDateString()).
                        Replace("#ReminderCount", position.Invoices.ReminderCount.ToString()).
                        Replace("#Description", description).
                        Replace("#Price", price.ToString("N2")));
                    prevTableElem.AddAfterSelf(rowElem);
                    prevTableElem = rowElem;

                    if (firstElem)
                    {
                        firstElem = false;
                    }
                }

                parentTableElement.Remove();
            }

            return xmlDoc.Root.ToString();
        }

        private string ReplaceReminderTotalPrice(Invoices invoice, string xmlMainXMLDoc, ITaxesManager taxesManager)
        {
            if (invoice.InvoicePositions != null && invoice.InvoicePositions.Count != 0)
            {
                double totalPriceForMainPositions = 0;
                double totalPriceWithoutDiscountWithoutTax = 0;
                double totalPriceWithoutTax = 0;
                double totalPrice = 0;
                double summaryPrice = 0;

                CalculationHelper.CalculateInvoicePrices(invoice, out totalPriceForMainPositions, out totalPriceWithoutDiscountWithoutTax, out totalPriceWithoutTax,
                    out totalPrice, out summaryPrice);

                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TotalPrice", summaryPrice.ToString("N2"));
            }
            else
            {
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TotalPrice", String.Empty);
            }

            return xmlMainXMLDoc;
        }

        #endregion

        #region Transport Invoice

        private string ReplaceTransportOrderCommonFields(TransportOrders transportOrder, string xmlMainXMLDoc)
        {
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CustomerName", transportOrder.CustomerName);
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CustomerStreet", transportOrder.Customers.Street);
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CustomerZip", transportOrder.Customers.Zip.ToString());
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CustomerCity", transportOrder.Customers.City);
            xmlMainXMLDoc = xmlMainXMLDoc.Replace("#Today", DateTime.Now.ToShortDateString());
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#DeliveryPlace", transportOrder.DeliveryPlace);
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#Street", transportOrder.Street);
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#ZIP", transportOrder.Zip.ToString());
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#City", transportOrder.City);

            return xmlMainXMLDoc;
        }

        private string ReplaceBaseTransportInvoiceFields(TransportOrders transportOrder, string xmlMainXMLDoc, PrintTypes printType)
        {
            if (printType == PrintTypes.InvoiceStorno)
            {
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#InvoiceType", "Gutschrift");
            }
            else
            {
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#InvoiceType", "Rechnung");
            }

            xmlMainXMLDoc = xmlMainXMLDoc.Replace("#InvoiceNumber", transportOrder.OrderNumber);
            xmlMainXMLDoc = xmlMainXMLDoc.Replace("#InvoiceDate", transportOrder.CreateDate.ToShortDateString());
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CustomerNumber", transportOrder.Customers.Number.ToString());

            xmlMainXMLDoc = ReplaceTransportOrderedFromInfo(xmlMainXMLDoc, transportOrder);

            xmlMainXMLDoc = ReplaceTransportCustomerOrderNumber(xmlMainXMLDoc, transportOrder);

            xmlMainXMLDoc = xmlMainXMLDoc.Replace("#OrderNumber", transportOrder.OrderNumber);

            xmlMainXMLDoc = ReplaceTransportUstId(xmlMainXMLDoc, transportOrder);

            xmlMainXMLDoc = ReplaceTransportFooterTexts(xmlMainXMLDoc, transportOrder);

            return xmlMainXMLDoc;
        }

        private string ReplaceTransportOrderedFromInfo(string xmlMainXMLDoc, TransportOrders transportOrder)
        {
            var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#OrderedFromInfo"));
            var parentElement = GetParentElementByName(temp, "<w:tr ");

            if (parentElement != null)
            {
                if (!String.IsNullOrEmpty(transportOrder.OrderedFrom) || transportOrder.OrderDate.HasValue)
                {
                    xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#OrderedFromInfo", String.Format("{0}{1}{2}",
                        transportOrder.OrderDate.HasValue ? transportOrder.OrderDate.Value.ToShortDateString() : String.Empty,
                        !String.IsNullOrEmpty(transportOrder.OrderedFrom) ? " durch " : String.Empty,
                        !String.IsNullOrEmpty(transportOrder.OrderedFrom) ? transportOrder.OrderedFrom : String.Empty));
                }
                else
                {
                    parentElement.Remove();
                    xmlMainXMLDoc = xmlDoc.Root.ToString();
                }
            }
            return xmlMainXMLDoc;
        }

        private string ReplaceTransportCustomerOrderNumber(string xmlMainXMLDoc, TransportOrders transportOrder)
        {
            var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#CustomerOrderNumber"));
            var parentElement = GetParentElementByName(temp, "<w:tr ");

            if (parentElement != null)
            {
                if (!String.IsNullOrEmpty(transportOrder.CustomerOrderNumber))
                {
                    xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CustomerOrderNumber", transportOrder.CustomerOrderNumber);
                }
                else
                {
                    parentElement.Remove();
                    xmlMainXMLDoc = xmlDoc.Root.ToString();
                }
            }
            return xmlMainXMLDoc;
        }

        private string ReplaceTransportUstId(string xmlMainXMLDoc, TransportOrders transportOrder)
        {
            var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#CustomerUstId"));
            var parentElement = GetParentElementByName(temp, "<w:tr ");

            if (parentElement != null)
            {
                if (!String.IsNullOrEmpty(transportOrder.Customers.UstId))
                {
                    xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CustomerUstId", transportOrder.Customers.UstId);
                }
                else
                {
                    parentElement.Remove();
                    xmlMainXMLDoc = xmlDoc.Root.ToString();
                }
            }
            return xmlMainXMLDoc;
        }

        private string ReplaceTransportPositions(List<TransportPositions> positions, string xmlMainXMLDoc)
        {
            var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#Description"));
            var parentTableElement = GetParentElementByName(temp, "<w:tr ");

            if (parentTableElement != null)
            {
                var prevTableElem = parentTableElement;

                bool firstElem = true;
                foreach (var position in positions)
                {
                    var rowElem = XElement.Parse(ReplaceFieldValue(
                        parentTableElement.ToString(), "#Description",
                            String.Format("{0}{1} {2}", firstElem ? "Leistungen: " : "",
                                position.Amount,
                                position.TransportProducts.Name)).
                        Replace("#Price", position.Price.ToString("N2")));
                    prevTableElem.AddAfterSelf(rowElem);
                    prevTableElem = rowElem;

                    if (firstElem)
                    {
                        firstElem = false;
                    }
                }

                parentTableElement.Remove();
            }

            return xmlDoc.Root.ToString();
        }

        private string ReplaceTransportInvoicePrices(TransportOrders transportOrder, string xmlMainXMLDoc, ITaxesManager taxesManager)
        {
            if (transportOrder.TransportPositions != null && transportOrder.TransportPositions.Count != 0)
            {
                double totalPriceWithoutDiscountWithoutTax = 0;
                double totalPriceWithoutTax = 0;
                double totalPrice = 0;
                double summaryPrice = 0;
                var withTaxes = true; //TODO 
                double? manualPrice = null;
                var taxValue = CalculationHelper.CalculateTaxes(taxesManager);

                CalculationHelper.CalculateTransportInvoicePrices(transportOrder, taxValue, withTaxes, manualPrice,
                    out totalPriceWithoutDiscountWithoutTax, out totalPriceWithoutTax, out totalPrice, out summaryPrice);

                //Discount
                var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
                var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#DiscountText"));
                var parentTableElement = GetParentElementByName(temp, "<w:tr ");

                if (transportOrder.Discount > 0 && parentTableElement != null)
                {
                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#DiscountText",
                        String.Format("Abzüglich {0}% Rabatt", transportOrder.Discount));

                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#DiscountValue",
                        String.Format("-{0}", Math.Round(totalPriceWithoutDiscountWithoutTax - totalPriceWithoutTax, 2).
                            ToString("N2")));

                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#PriceWithoutTax", totalPriceWithoutTax.ToString("N2"));
                }
                else
                {
                    parentTableElement.Remove();
                    temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#PriceWithoutTax"));
                    parentTableElement = GetParentElementByName(temp, "<w:tr ");
                    parentTableElement.Remove();
                    xmlMainXMLDoc = xmlDoc.Root.ToString();
                }

                //Taxes
                xmlDoc = XDocument.Parse(xmlMainXMLDoc);
                temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#TaxText"));
                parentTableElement = GetParentElementByName(temp, "<w:tr ");

                if (withTaxes && taxValue > 0 && parentTableElement != null)
                {
                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TaxText",
                        String.Format("Zuzüglich {0}% MwSt.", taxValue));

                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TaxValue",
                        String.Format("{0}", Math.Round(totalPrice - totalPriceWithoutTax, 2).ToString("N2")));
                }
                else
                {
                    parentTableElement.Remove();
                    xmlMainXMLDoc = xmlDoc.Root.ToString();
                }

                //total price
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TotalPriceText", "Zu zahlender Betrag");
                xmlMainXMLDoc = xmlMainXMLDoc.Replace("#TotalPrice", totalPrice.ToString("N2"));
            }

            return xmlMainXMLDoc;
        }

        private string ReplaceTransportFooterTexts(string xmlMainXMLDoc, TransportOrders transportOrder)
        {
            var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#PlanedPayDate"));
            var parentElement = GetParentElementByName(temp, "<w:tr ");

            //pay due information
            if (parentElement != null)
            {
                if (!String.IsNullOrEmpty(transportOrder.Customers.Iban) && !String.IsNullOrEmpty(transportOrder.Customers.Bic))
                {

                    temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#PayCash"));
                    parentElement = GetParentElementByName(temp, "<w:tr ");
                    parentElement.Remove();
                    xmlMainXMLDoc = xmlDoc.Root.ToString();


                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#PlanedPayDate", transportOrder.CreateDate.AddDays(10).ToShortDateString());
                    xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#IBAN", transportOrder.Customers.Iban);
                    xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#BIC", transportOrder.Customers.Bic);
                }
                else
                {
                    parentElement.Remove();
                    xmlMainXMLDoc = xmlDoc.Root.ToString();
                    xmlMainXMLDoc = xmlMainXMLDoc.Replace("#PayCash", String.Empty);
                }
            }

            //Invoice without taxes
            //xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            //temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#InvoiceWithoutTaxes"));
            //parentElement = GetParentElementByName(temp, "<w:tr ");

            //if (parentElement != null)
            //{
            //    if (!invoice.WithTaxes)
            //    {
            //        xmlMainXMLDoc = xmlMainXMLDoc.Replace("#InvoiceWithoutTaxes", String.Empty);
            //    }
            //    else
            //    {
            //        parentElement.Remove();
            //        xmlMainXMLDoc = xmlDoc.Root.ToString();
            //    }
            //}

            return xmlMainXMLDoc;
        }

        #endregion

        #region Common Functions

        #endregion

        #endregion
    }
}
