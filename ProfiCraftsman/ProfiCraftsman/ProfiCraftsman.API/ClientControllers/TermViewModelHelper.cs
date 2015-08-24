using ProfiCraftsman.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfiCraftsman.API.ClientControllers
{
    public static class TermViewModelHelper
    {
        public static ClientTermViewModel ToModel(Terms term)
        {
            return new ClientTermViewModel()
            {
                Id = term.Id,
                FromDate = String.Format("{0}", term.Date.ToString("HH:mm")),
                ToDate = String.Format("{0}", term.Date.AddMinutes(term.Duration).ToString("HH:mm")),
                Address = String.Format("{0} {1} {2}", term.Orders.Street, term.Orders.Zip, term.Orders.City),
                Status = term.Status,
                //IsFirstTerm 
            };
        }
    }
}
