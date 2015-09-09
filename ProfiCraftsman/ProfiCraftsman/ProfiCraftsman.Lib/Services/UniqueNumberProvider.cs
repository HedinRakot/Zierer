
using System.Linq;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Services;
using System.Collections.Generic;
using CoreBase.Managers;

namespace ProfiCraftsman.Lib.Services
{
    public class UniqueNumberProvider : Manager, IUniqueNumberProvider
    {
        public UniqueNumberProvider(IProfiCraftsmanEntities context)
            : base(context)
        {

        }

        public string GetNextOrderNumber()
        {
            return GetNextNumber(UniqueNumberType.OrderNumber).ToString();
        }

        public string GetNextInvoiceNumber()
        {
            return GetNextNumber(UniqueNumberType.InvoiceNumber).ToString();

        }
  
        private long GetNextNumber(UniqueNumberType type)
        {
            lock (this)
            {
                var temp = DataContext.GetSet<Numbers>().FirstOrDefault(o => o.NumberType == (short)type);
                if (temp == null)
                {
                    throw new KeyNotFoundException(string.Format("Data is not provided by the DB: {0}", type.ToString()));
                }
                temp.CurrentNumber++;
                SaveChanges();
                return temp.CurrentNumber;
            }
        }
    }
}
