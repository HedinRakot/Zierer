﻿using System.Linq;
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
    public class ClientTermSearchModel
    {
        public string userLogin { get; set; }
        public bool termsForTommorow { get; set; }
    }
}