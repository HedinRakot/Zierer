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
    public class ClientTermViewModel
    {
        public int Id { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public bool IsFirstTerm { get; set; }

        public List<ClientTermPositionViewModel> Positions { get; set; }
        public List<ClientTermMaterialViewModel> Materials { get; set; }
    }
}