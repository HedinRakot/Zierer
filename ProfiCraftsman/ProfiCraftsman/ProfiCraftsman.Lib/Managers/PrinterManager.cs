using CoreBase.Managers;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public MemoryStream PrepareOrderPrintData(int id, string path, ITaxesManager taxesManager, IOrdersManager ordersManager)
        {
            return PrepareCommonOrderPrintData(ordersManager, id, path, PrintTypes.Order, null, taxesManager);
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

        public MemoryStream PrepareDeliveryNotePrintData(int id, string path, ITermsManager termsManager)
        {
            return PrepareCommonOrderPrintData(null, id, path, PrintTypes.DeliveryNote, null, null, null, null, termsManager);
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


                var images = new List<Image>();

                if (type == PrintTypes.DeliveryNote)
                {
                    var term = termsManager.GetById(id);
                    for (var i = 0; i < term.DeliveryNoteSignatures.Count; i++)
                    {
                        var deliveryNoteSignature = term.DeliveryNoteSignatures.ElementAt(term.DeliveryNoteSignatures.Count - i - 1);
                        //TODO doesnt work ((
                        //pkg.CreateRelationship(uri, TargetMode.Internal,
                        //    "Http://schemas.openxmlformats.org/officeDocument/2006/relationships/image",
                        //    "barcodeImageId");


                        byte[] bytes = Convert.FromBase64String(deliveryNoteSignature.Signature.Replace("data:image/png;base64,", ""));

                        Image image;
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            image = Image.FromStream(ms);
                        }

                        images.Add(image);
                    }
                }

                //replace fields
                var templateBody = ReplaceFields(ordersManager, id, type, xmlMainXMLDoc.Root.ToString(),
                    invoicesManager, taxesManager, null, invoiceStornosManager, transportOrdersManager, termsManager, images);

                xmlMainXMLDoc = SaveDoc(result, pkg, part, xmlReader, xmlMainXMLDoc, templateBody);

                InsertImages(result, images);

                var doc = new Spire.Doc.Document();
                doc.LoadFromStream(result, Spire.Doc.FileFormat.Docx);
                doc.JPEGQuality = 100;

                result = new MemoryStream();
                doc.SaveToStream(result, Spire.Doc.FileFormat.PDF);
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
            ITermsManager termsManager = null, 
            IEnumerable<Image> images = null)
        {
            string result = xmlMainXMLDoc;

            switch (printType)
            {
                case PrintTypes.Order:
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
                case PrintTypes.DeliveryNote:

                    var term = termsManager.GetById(id);
                    result = ReplaceCommonFields(term.Orders, result);
                    result = ReplaceBaseOrderFields(term.Orders, result);

                    result = result.Replace("#DeliveryNoteType", "Lieferschein");
                    result = result.Replace("#DateType", "Liefertermin");
                    result = result.Replace("#AdressType", "Lieferanschrift");
                    result = result.Replace("#OrderNumber", term.Orders.OrderNumber);
                    
                    result = ReplacePositionWithDescription(term, result);


                    if (term.DeliveryNoteSignatures.Count != 0)
                    {
                        var doc = XDocument.Parse(result);
                        var signatureElement = doc.Descendants().FirstOrDefault(o => o.Value.Equals("#Signature",
                            StringComparison.InvariantCultureIgnoreCase));

                        if (signatureElement != null && images != null && images.Count() != 0)
                        {
                            var currentElement = signatureElement;
                            for (var i = 0; i < images.Count(); i++)
                            {
                                var image = images.ElementAt(images.Count() - i - 1);
                                //TODO doesnt work ((
                                //pkg.CreateRelationship(uri, TargetMode.Internal,
                                //    "Http://schemas.openxmlformats.org/officeDocument/2006/relationships/image",
                                //    "barcodeImageId");
                                
                                //insert image
                                XmlElement tagDrawing = GetImageTag(image.Width, image.Height,
                                    term.DeliveryNoteSignatures.Count - i);

                                signatureElement.AddAfterSelf(XDocument.Parse(tagDrawing.InnerXml).Root);
                            }

                            signatureElement.Remove();
                            result = doc.Root.ToString();
                        }
                        else
                        {
                            result = result.Replace("#Signature", String.Empty);
                        }
                    }
                    else
                    {
                        result = result.Replace("#Signature", String.Empty);
                    }

                    break;
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
            xmlMainXMLDoc = ReplaceFieldValue(xmlMainXMLDoc, "#CustomerPhone", customer.Phone ?? String.Empty);
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

                //todo xmlMainXMLDoc = ReplacePositionWithDescription(positions, xmlMainXMLDoc);
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

        private string ReplacePositionWithDescription(Terms term, string xmlMainXMLDoc)
        {
            var xmlDoc = XDocument.Parse(xmlMainXMLDoc);
            var temp = xmlDoc.Descendants().LastOrDefault(o => o.Value.Contains("#PositionDescription"));
            var parentTableElement = GetParentElementByName(temp, "<w:tr ");

            if (parentTableElement != null)
            {
                var prevTableElem = parentTableElement;

                var positions = term.TermPositions != null ? term.TermPositions.Where(o => !o.DeleteDate.HasValue).ToList() :
                    new List<TermPositions>();

                foreach (var position in positions.Where(o => o.ProccessedAmount.HasValue))
                {
                    var elem = XElement.Parse(ReplaceFieldValue(parentTableElement.ToString(), "#PositionDescription", position.Positions.Products.Name).
                        Replace("#Amount", position.ProccessedAmount.Value.ToString()).
                        Replace("#PositionNumber", position.Positions.Products.Number));

                    prevTableElem.AddAfterSelf(elem);
                    prevTableElem = elem;

                    if (position.TermPositionMaterialRsps != null && position.TermPositionMaterialRsps.Count != 0)
                    {
                        foreach (var material in position.TermPositionMaterialRsps)
                        {
                            elem = XElement.Parse(ReplaceFieldValue(parentTableElement.ToString(), "#PositionDescription", material.Materials.Name).
                            Replace("#Amount", material.Amount.HasValue ? material.Amount.Value.ToString() : String.Empty).
                            Replace("#PositionNumber", material.Materials.Number));

                            prevTableElem.AddAfterSelf(elem);
                            prevTableElem = elem;
                        }
                    }
                }

                if (term.Positions != null && term.Positions.Count != 0)
                {
                    foreach (var position in term.Positions.Where(o => !o.DeleteDate.HasValue && o.MaterialId.HasValue))
                    {
                        var elem = XElement.Parse(ReplaceFieldValue(parentTableElement.ToString(), "#PositionDescription", position.Materials.Name).
                            Replace("#Amount", position.Amount.ToString()).
                            Replace("#PositionNumber", position.Materials.Number));

                        prevTableElem.AddAfterSelf(elem);
                        prevTableElem = elem;
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
        
        #region Common Functions

        private Stream InsertImages(Stream sourceStream, IEnumerable<Image> images)
        {
            try
            {
                if (images != null && images.Count() != 0)
                {
                    for (int i = 0; i < images.Count(); i++)
                    {
                        InsertImage(sourceStream, images.ElementAt(i), i + 1);
                    }

                    InsertImageIds(sourceStream, images.Count());
                }
            }
            catch
            {
            }

            return sourceStream;
        }

        private void InsertImage(Stream sourceStream, Image image, int index)
        {
            var pkg = Package.Open(sourceStream, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var uri = new Uri(String.Format("/word/media/image_generated_for_export_to_pdf_{0}.png",
                index), UriKind.Relative);
            PackagePart partImage = pkg.CreatePart(uri, "image/png");
            using (var targetStream = partImage.GetStream())
            {
                image.Save(targetStream, System.Drawing.Imaging.ImageFormat.Png);
            }

            pkg.Flush();
            pkg.Close();

            sourceStream.Position = 0;
        }

        private void InsertImageIds(Stream sourceStream, int count)
        {
            var pkg = Package.Open(sourceStream, FileMode.Open, FileAccess.ReadWrite);

            var uri = new Uri("/word/_rels/document.xml.rels", UriKind.Relative);
            var part = pkg.GetPart(uri);

            var xmlReader = XmlReader.Create(part.GetStream(FileMode.Open, FileAccess.Read));
            var xmlMainXMLDoc = XDocument.Load(xmlReader);

            for (int i = 0; i < count; i++)
            {
                xmlMainXMLDoc.Root.Add(new XElement("Relationship",
                    new XAttribute("Target", String.Format("media/image_generated_for_export_to_pdf_{0}.png",
                        i + 1)),
                    new XAttribute("Type", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/image"),
                    new XAttribute("Id", String.Format("ImageId_{0}", i + 1))));
            }

            xmlMainXMLDoc = XDocument.Parse(xmlMainXMLDoc.Root.ToString().Replace(@"xmlns=""""", ""));

            var partWrt = new StreamWriter(part.GetStream(FileMode.Open, FileAccess.ReadWrite));
            xmlMainXMLDoc.Save(partWrt);

            partWrt.Flush();
            partWrt.Close();
            pkg.Close();

            sourceStream.Position = 0;

            xmlReader.Close();
        }

        private XmlElement GetImageTag(int imageWidth, int imageHeight, int index)
        {
            string WordprocessingML = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
            string RelationShips = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";
            string Drawing = "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing";
            string DrawingML = "http://schemas.openxmlformats.org/drawingml/2006/main";
            string Pic = "http://schemas.openxmlformats.org/drawingml/2006/picture";

            var realWidth = imageWidth * 914400 / 96;
            var realHeight = imageHeight * 914400 / 96;

            // Create WordML
            XmlDocument xmlStartPart = new XmlDocument();
            XmlElement tagDrawing = xmlStartPart.CreateElement("w:drawing", WordprocessingML);
            XmlElement tagInline = xmlStartPart.CreateElement("wp:inline", Drawing);
            tagDrawing.AppendChild(tagInline);
            //Element extent
            XmlElement tagExtent = xmlStartPart.CreateElement("wp:extent", Drawing);
            tagInline.AppendChild(tagExtent);
            //attributes of extent
            XmlAttribute attributcx = xmlStartPart.CreateAttribute("cx");
            attributcx.InnerText = realWidth.ToString();
            tagExtent.SetAttributeNode(attributcx);
            XmlAttribute attributcy = xmlStartPart.CreateAttribute("cy");
            attributcy.InnerText = realHeight.ToString();
            tagExtent.SetAttributeNode(attributcy);
            //Element docPr
            XmlElement tagdocPr = xmlStartPart.CreateElement("wp:docPr", Drawing);
            tagInline.AppendChild(tagdocPr);
            //attributes of docPr
            XmlAttribute attributname = xmlStartPart.CreateAttribute("name");
            attributname.InnerText = String.Format("image_generated_for_export_to_pdf_{0}.png", index);
            tagdocPr.SetAttributeNode(attributname);
            XmlAttribute attributid = xmlStartPart.CreateAttribute("id");
            attributid.InnerText = (index * 2 - 1).ToString();
            tagdocPr.SetAttributeNode(attributid);
            //Element graphic
            XmlElement taggraphic = xmlStartPart.CreateElement("a:graphic", DrawingML);
            tagInline.AppendChild(taggraphic);
            //Element graphicData
            XmlElement taggraphicData = xmlStartPart.CreateElement("a:graphicData", DrawingML);
            taggraphic.AppendChild(taggraphicData);
            //attributes pf graphicData
            XmlAttribute attributuri = xmlStartPart.CreateAttribute("uri");
            attributuri.InnerText = "http://schemas.openxmlformats.org/drawingml/2006/picture";
            taggraphicData.SetAttributeNode(attributuri);
            //Element pic
            XmlElement tagpic = xmlStartPart.CreateElement("pic:pic", Pic);
            taggraphicData.AppendChild(tagpic);
            //Element nvPicPr
            XmlElement tagnvPicPr = xmlStartPart.CreateElement("pic:nvPicPr", Pic);
            tagpic.AppendChild(tagnvPicPr);
            //Element cNvPr
            XmlElement tagcNvPr = xmlStartPart.CreateElement("pic:cNvPr", Pic);
            tagnvPicPr.AppendChild(tagcNvPr);
            //attributes of cNvPr
            XmlAttribute attributnamecNvPr = xmlStartPart.CreateAttribute("name");
            attributnamecNvPr.InnerText = String.Format("image_generated_for_export_to_pdf_{0}.png", index);
            tagcNvPr.SetAttributeNode(attributnamecNvPr);
            XmlAttribute attributidcNvPr = xmlStartPart.CreateAttribute("id");
            attributidcNvPr.InnerText = (index * 2).ToString();
            tagcNvPr.SetAttributeNode(attributidcNvPr);
            //Element cNvPicPr
            XmlElement tagcNvPicPr = xmlStartPart.CreateElement("pic:cNvPicPr", Pic);
            tagnvPicPr.AppendChild(tagcNvPicPr);
            //Element blipFill
            XmlElement tagblipFill = xmlStartPart.CreateElement("pic:blipFill", Pic);
            tagpic.AppendChild(tagblipFill);
            //Element blip
            XmlElement tagblip = xmlStartPart.CreateElement("a:blip", DrawingML);
            tagblipFill.AppendChild(tagblip);
            //attributes of blip
            XmlAttribute attributembed = xmlStartPart.CreateAttribute("r:embed", RelationShips);
            attributembed.InnerText = String.Format("ImageId_{0}", index);
            tagblip.SetAttributeNode(attributembed);
            //Element stretch
            XmlElement tagstretch = xmlStartPart.CreateElement("a:stretch", DrawingML);
            tagblipFill.AppendChild(tagstretch);
            //Element fillRect
            XmlElement tagfillRect = xmlStartPart.CreateElement("a:fillRect", DrawingML);
            tagstretch.AppendChild(tagfillRect);
            //Element spPr
            XmlElement tagspPr = xmlStartPart.CreateElement("pic:spPr", Pic);
            tagpic.AppendChild(tagspPr);
            //Element xfrm
            XmlElement tagxfrm = xmlStartPart.CreateElement("a:xfrm", DrawingML);
            tagspPr.AppendChild(tagxfrm);
            //Element off
            XmlElement tagoff = xmlStartPart.CreateElement("a:off", DrawingML);
            tagxfrm.AppendChild(tagoff);
            //attributes of off
            XmlAttribute attributx = xmlStartPart.CreateAttribute("x");
            attributx.InnerText = "0";
            tagoff.SetAttributeNode(attributx);
            XmlAttribute attributy = xmlStartPart.CreateAttribute("y");
            attributy.InnerText = "0";
            tagoff.SetAttributeNode(attributy);
            //Element ext
            XmlElement tagext = xmlStartPart.CreateElement("a:ext", DrawingML);
            tagxfrm.AppendChild(tagext);
            //attributes of ext
            XmlAttribute attributcxext = xmlStartPart.CreateAttribute("cx");
            attributcxext.InnerText = realWidth.ToString();
            tagext.SetAttributeNode(attributcxext);
            XmlAttribute attributcyext = xmlStartPart.CreateAttribute("cy");
            attributcyext.InnerText = realHeight.ToString();
            tagext.SetAttributeNode(attributcyext);
            //Element prstGeom
            XmlElement tagprstGeom = xmlStartPart.CreateElement("a:prstGeom", DrawingML);
            tagspPr.AppendChild(tagprstGeom);
            //attributs of prstGeom
            XmlAttribute attributprst = xmlStartPart.CreateAttribute("prst");
            attributprst.InnerText = "rect";
            tagprstGeom.SetAttributeNode(attributprst);


            XmlElement tagRun = xmlStartPart.CreateElement("w:p", Drawing);
            XmlElement tagRun2 = xmlStartPart.CreateElement("w:p", Drawing);
            XmlElement tagRun3 = xmlStartPart.CreateElement("w:r", Drawing);
            tagRun.AppendChild(tagRun2);
            tagRun2.AppendChild(tagRun3);
            tagRun3.AppendChild(tagDrawing);

            return tagRun;
        }

        #endregion

        #endregion
    }
}
