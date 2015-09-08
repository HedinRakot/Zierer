using ProfiCraftsman.Contracts.Entities;
using System.Collections.Generic;
using System.IO;

namespace ProfiCraftsman.Contracts.Managers
{
    /// <summary>
    /// </summary>
    public partial interface IPrinterManager
    {
        MemoryStream PrepareOrderPrintData(int id, string path, ITaxesManager taxesManager, IOrdersManager ordersManager);

        MemoryStream PrepareOfferPrintData(int id, string path, ITaxesManager taxesManager, IOrdersManager ordersManager);

        MemoryStream PrepareInvoicePrintData(int id, string path, IInvoicesManager invoicesManager, IOrdersManager ordersManager);

        MemoryStream PrepareInvoiceStornoPrintData(int id, string path, IInvoiceStornosManager invoicesManager, IOrdersManager ordersManager);

        MemoryStream PrepareReminderPrintData(IEnumerable<Invoices> invoices, string path, IInvoicesManager invoicesManager, 
            ITaxesManager taxesManager, IOrdersManager ordersManager);

        MemoryStream PrepareMonthInvoicePrintData(IEnumerable<Invoices> invoices, string path, IInvoicesManager invoicesManager, 
            ITaxesManager taxesManager, IOrdersManager ordersManager);

        MemoryStream PrepareDeliveryNotePrintData(int id, string path, ITermsManager termsManager);
    }
}