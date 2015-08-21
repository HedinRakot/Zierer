using CoreBase.Controllers;
using CoreBase.Entities;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.API.Controllers.Settings
{
    /// <summary>
    ///     Controller for <see cref="AutoInstrumentRsp"/> entity
    /// </summary>
    public partial class AutoInstrumentRspsController : ClientApiController<AutoInstrumentRspModel, AutoInstrumentRsp, int, IAutoInstrumentRspManager>
    {

        public AutoInstrumentRspsController(IAutoInstrumentRspManager manager) : base(manager) { }

        protected override void EntityToModel(AutoInstrumentRsp entity, AutoInstrumentRspModel model)
        {
            model.autoId = entity.AutoId;
            model.instrumentId = entity.InstrumentId;
            model.amount = entity.Amount;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(AutoInstrumentRspModel model, AutoInstrumentRsp entity, ActionTypes actionType)
        {
            entity.AutoId = model.autoId;
            entity.InstrumentId = model.instrumentId;
            entity.Amount = model.amount;
        }
    }
}
