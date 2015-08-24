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
    public class ChangeStateTermModel
    {
        public int termId { get; set; }
        public int status { get; set; }
        public string Login { get; set; }
        public bool BeginTripFromOffice { get; set; }
    }
}