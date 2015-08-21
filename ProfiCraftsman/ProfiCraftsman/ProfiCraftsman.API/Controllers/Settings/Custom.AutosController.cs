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
    public partial class AutosController
    {
        protected void ExtraModelToEntity(Autos entity, AutosModel model, ActionTypes actionType)
        {
            if (actionType == ActionTypes.Add)
            {
                entity.AutoMaterialRsps = new List<AutoMaterialRsp>();
                var materialManager = GlobalConfiguration.Configuration.DependencyResolver.GetService<IMaterialsManager>();

                foreach (var material in materialManager.GetEntities().Where(o => o.IsForAuto).ToList())
                {
                    entity.AutoMaterialRsps.Add(new AutoMaterialRsp()
                    {
                        Amount = 0,
                        Autos = entity,
                        MaterialId = material.Id
                    });
                }

                entity.AutoInstrumentRsps = new List<AutoInstrumentRsp>();
                var instrumentManager = GlobalConfiguration.Configuration.DependencyResolver.GetService<IInstrumentsManager>();

                foreach (var instrument in instrumentManager.GetEntities().Where(o => o.IsForAuto).ToList())
                {
                    entity.AutoInstrumentRsps.Add(new AutoInstrumentRsp()
                    {
                        Amount = 0,
                        Autos = entity,
                        InstrumentId = instrument.Id
                    });
                }
            }
        }
    }
}
