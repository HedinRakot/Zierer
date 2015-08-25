using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Models.Invoices;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.Contracts.Services;
using CoreBase;
using System;
using System.Web.Http;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Controllers
{
    [DataContract]
    public class GetTermSignatureModel
    {
        [DataMember]
        public int id { get; set; }
    }

    /// <summary>
    ///     Controller for close order
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class GetTermSignatureController : ApiController
    {
        private readonly IDeliveryNoteSignaturesManager deliveryNoteSignaturesManager;

        public GetTermSignatureController(IDeliveryNoteSignaturesManager deliveryNoteSignaturesManager)
        {
            this.deliveryNoteSignaturesManager = deliveryNoteSignaturesManager;
        }

        public IHttpActionResult Put(GetTermSignatureModel model)
        {
            var signatureData = String.Empty;

            var data = deliveryNoteSignaturesManager.GetEntities(o => o.TermId == model.id).FirstOrDefault();
            if(data != null)
            {
                signatureData = data.Signature;
            }

            return Ok(new { SignatureData = signatureData });
        }
    }
}
