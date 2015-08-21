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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Instruments })]
    /// <summary>
    ///     Controller for <see cref="Instruments"/> entity
    /// </summary>
    public partial class InstrumentsController: ClientApiController<InstrumentsModel, Instruments, int, IInstrumentsManager>
    {

        public InstrumentsController(IInstrumentsManager manager): base(manager){}

        protected override void EntityToModel(Instruments entity, InstrumentsModel model)
        {
            model.name = entity.Name;
            model.number = entity.Number;
            model.proceedsAccount = entity.ProceedsAccount;
            model.isForAuto = entity.IsForAuto;
            model.boughtPrice = entity.BoughtPrice;
            model.comment = entity.Comment;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(InstrumentsModel model, Instruments entity, ActionTypes actionType)
        {
            entity.Name = model.name;
            entity.Number = model.number;
            entity.ProceedsAccount = model.proceedsAccount;
            entity.IsForAuto = model.isForAuto;
            entity.BoughtPrice = model.boughtPrice;
            entity.Comment = model.comment;
        }
    }
}
