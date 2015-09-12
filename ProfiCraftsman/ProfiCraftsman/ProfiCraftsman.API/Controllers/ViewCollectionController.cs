using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ProfiCraftsman.Contracts.Managers;
using System.Web.Http.Dependencies;
using CoreBase.Entities;
using CoreBase.Controllers;

namespace ProfiCraftsman.API.Controllers
{
    public partial class CollectionTypesModel
    {
        public bool CommunicationPartners { get; set; }
        public bool PaymentIntervals { get; set; }
        public bool PaymentTypes { get; set; }
        public bool ProductTypesForDisposition { get; set; }
        public bool ProductAmountTypes { get; set; }
        public bool MaterialAmountTypes { get; set; }
    }
    
    public class ViewCollectionController: ApiController
    {
        public ViewCollectionController()
        {
        }

        [Authorize]
        public IHttpActionResult Get([FromUri] CollectionTypesModel model)
        {
            if (model == null)
                return NotFound();

            var result = new Dictionary<string, IEnumerable<object>>();

            if (model.CommunicationPartners)
            {
                var manager = (ICommunicationPartnersManager)GlobalConfiguration.Configuration.DependencyResolver.
                    GetService(typeof(ICommunicationPartnersManager));

                result.Add("CommunicationPartners", manager.GetEntities().
                    Select(o => new { id = o.Id, name = o.Title, customerId = o.CustomerId }).ToList());
            }

            if (model.PaymentIntervals)
                result.Add("PaymentIntervals", new[]
                {
                    new { id = 0, name = "Sofort"},
                    new { id = 5, name = "5 Tage"},
                    new { id = 10, name = "10 Tage"},
                    new { id = 30, name = "30 Tage"},
                });

            if (model.PaymentTypes)
                result.Add("PaymentTypes", new[]
                {
                    new { id = 0, name = "Standard"},
                    new { id = 1, name = "Pauschal"},
                });

            if (model.ProductAmountTypes)
                result.Add("ProductAmountTypes", new[]
                {
                    new { id = 0, name = "Stunde"},
                    new { id = 1, name = "Stück"},
                });

            if (model.MaterialAmountTypes)
                result.Add("MaterialAmountTypes", new[]
                {
                    new { id = 0, name = "Stück"},
                    new { id = 1, name = "Meter"},
                });

            new MasterDataViewCollectionControllerFactory().GetViewCollections(
                GlobalConfiguration.Configuration.DependencyResolver, model, result);
                       			
			return Ok(result);
        }
    }
}
