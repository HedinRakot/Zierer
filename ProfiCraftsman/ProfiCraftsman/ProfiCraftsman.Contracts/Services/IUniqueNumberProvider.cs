
namespace ProfiCraftsman.Contracts.Services
{
    public interface IUniqueNumberProvider
    {
        string GetNextOrderNumber();

        string GetNextTransportOrderNumber();
        
        string GetNextRentOrderNumber(string preffix);

        string GetNextInvoiceNumber();
    }
}
