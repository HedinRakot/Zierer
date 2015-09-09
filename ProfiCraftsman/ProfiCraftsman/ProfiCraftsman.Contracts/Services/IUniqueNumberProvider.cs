
namespace ProfiCraftsman.Contracts.Services
{
    public interface IUniqueNumberProvider
    {
        string GetNextOrderNumber();

        string GetNextInvoiceNumber();
    }
}
