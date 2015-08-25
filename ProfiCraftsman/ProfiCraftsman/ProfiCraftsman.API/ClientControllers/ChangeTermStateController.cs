using System.Linq;
using System.Web.Http;
using System.Web.Security;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.Contracts.Managers;
using CoreBase;
using CoreBase.Models;
using System;
using System.Collections.Generic;
using ProfiCraftsman.Contracts.Enums;
using System.Linq;

namespace ProfiCraftsman.API.ClientControllers
{
    public class ChangeTermStateController : ApiController
	{
	    private readonly ITermsManager termManager;
        private readonly IUserManager userManager;

        public ChangeTermStateController(ITermsManager termManager, IUserManager userManager)
	    {
	        this.termManager = termManager;
	        this.userManager = userManager;
        }

	    public IHttpActionResult Post([FromBody]ChangeStateTermModel model)
		{
            var term = termManager.GetById(model.termId);
            ClientTermViewModel result = null;

            //TODO security check (user id)
            var user = userManager.GetByLogin(model.Login);
            if (user != null && term != null)
            {
                term.User = user;
                term.Status = model.status;

                switch ((TermStatusTypes)model.status)
                {
                    case TermStatusTypes.BeginTrip:
                        term.BeginTripFromOffice = model.BeginTripFromOffice;
                        term.BeginTrip = DateTime.Now;
                        break;
                    case TermStatusTypes.EndTrip:
                        term.EndTrip = DateTime.Now;
                        break;
                    case TermStatusTypes.BeginWork:
                        term.BeginWork = DateTime.Now;
                        break;
                    case TermStatusTypes.CheckPositions:

                        var termPositions = term.TermPositions.Where(o => !o.DeleteDate.HasValue).ToList();
                        foreach(var position in model.Positions)
                        {
                            var termPosition = termPositions.FirstOrDefault(o => o.Id == position.Id);
                            termPosition.ProccessedAmount = position.ProccessedAmount;
                        }

                        termManager.SaveChanges();
                        break;
                    case TermStatusTypes.EndWork:
                        term.EndWork = DateTime.Now;
                        break;
                    case TermStatusTypes.BeginReturnTrip:
                        term.BeginReturnTrip = DateTime.Now;
                        break;
                    case TermStatusTypes.EndReturnTrip:
                        term.EndReturnTrip = DateTime.Now;
                        break;
                }

                termManager.SaveChanges();

                if (term != null)
                {
                    result = TermViewModelHelper.ToModel(term, model.withPositions, model.withMaterials);
                }

                return Ok(result);
            }

            return BadRequest();
		}	
	}
}