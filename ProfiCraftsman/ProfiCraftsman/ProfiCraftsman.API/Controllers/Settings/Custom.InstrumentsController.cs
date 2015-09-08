using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.Contracts.Entities;
using System.Web.Http;
using CoreBase;
using System.Collections.Generic;
using ProfiCraftsman.Contracts.Managers;
using CoreBase.Controllers;
using System.Linq;

namespace ProfiCraftsman.API.Controllers.Settings
{
    public partial class InstrumentsController
    {
        protected void ExtraEntityToModel(Instruments entity, InstrumentsModel model)
        {
            var termInstrument = entity.TermInstruments.Where(o => !o.DeleteDate.HasValue).LastOrDefault();
            model.employeeName = termInstrument != null ? termInstrument.Employees.Name : string.Empty;
        }
    }
}
