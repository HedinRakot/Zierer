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
    public class ClientTermsController : ApiController
	{
	    private readonly IUserManager userManager;
	    private readonly ITermsManager termManager;

        public ClientTermsController(IUserManager userManager, ITermsManager termManager)
	    {
	        this.userManager = userManager;
	        this.termManager = termManager;
        }

	    public IHttpActionResult Post([FromBody]ClientTermSearchModel model)
		{
            var user = userManager.GetByLogin(model.userLogin);
            var result = new List<ClientTermViewModel>();
            var missingMaterials = new List<ClientTermMaterialViewModel>();

            if (user != null && user.EmployeeId.HasValue)
            {
                var date = DateTime.Now.Date;
                if(model.termsForTommorow)
                {
                    date = date.AddDays(1);
                }

                var terms = termManager.GetEntities(o => 
                o.TermEmployees.Any(e => !e.DeleteDate.HasValue && e.EmployeeId == user.EmployeeId.Value) && o.Date.Date == date);
                result = terms.Select(term => TermViewModelHelper.ToModel(term, false, true)).OrderBy(o => o.FromDate).ToList();

                var auto = terms.Select(o => o.Autos).FirstOrDefault(); //todo?
                var materials = result.SelectMany(o => o.Materials.Where(m => !m.Amount.HasValue));
                foreach(var materialGroup in materials.GroupBy(o => o.MaterialId))
                {
                    var neededAmount = materialGroup.Where(o => o.PlannedAmount.HasValue).Sum(o => o.PlannedAmount.Value);
                    var isAmount = (double)auto.AutoMaterialRsps.Where(o => o.MaterialId == materialGroup.Key).Sum(o => o.Amount);

                    if(neededAmount > isAmount)
                    {
                        missingMaterials.Add(new ClientTermMaterialViewModel()
                        {
                            Id = materialGroup.Key,
                            Description = materials.FirstOrDefault(o => o.MaterialId == materialGroup.Key).Description,
                            Number = materials.FirstOrDefault(o => o.MaterialId == materialGroup.Key).Number,
                            Amount = neededAmount - isAmount,
                        });
                    }
                }
            }

            return Ok(new
            {
                terms = result,
                missingMaterials = missingMaterials
            });
		}	
	}
}