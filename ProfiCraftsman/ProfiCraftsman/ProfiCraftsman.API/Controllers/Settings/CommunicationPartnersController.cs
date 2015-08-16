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
    ///     Controller for <see cref="CommunicationPartners"/> entity
    /// </summary>
    public partial class CommunicationPartnersController: ClientApiController<CommunicationPartnersModel, CommunicationPartners, int, ICommunicationPartnersManager>
    {

        public CommunicationPartnersController(ICommunicationPartnersManager manager): base(manager){}

        protected override void EntityToModel(CommunicationPartners entity, CommunicationPartnersModel model)
        {
            model.name = entity.Name;
            model.firstName = entity.FirstName;
            model.customerId = entity.CustomerId;
            model.phone = entity.Phone;
            model.mobile = entity.Mobile;
            model.fax = entity.Fax;
            model.email = entity.Email;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(CommunicationPartnersModel model, CommunicationPartners entity, ActionTypes actionType)
        {
            entity.Name = model.name;
            entity.FirstName = model.firstName;
            entity.CustomerId = model.customerId;
            entity.Phone = model.phone;
            entity.Mobile = model.mobile;
            entity.Fax = model.fax;
            entity.Email = model.email;
        }
    }
}
