using System.Linq;
using System.Web.Http;
using System.Web.Security;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.Contracts.Managers;
using CoreBase;
using CoreBase.Models;
using System;
using System.Collections.Generic;

namespace ProfiCraftsman.API.ClientControllers
{
    public class ClientTermPositionViewModel
    {
        public int Id { get; set; }
        public int TermId { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string PlannedAmount { get; set; }
        public int? ProccessedAmount { get; set; }
    }
}