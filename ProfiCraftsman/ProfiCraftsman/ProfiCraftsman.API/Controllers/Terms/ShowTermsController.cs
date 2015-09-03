using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.Contracts.Services;
using CoreBase;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace ProfiCraftsman.API.Controllers
{
    public class TermSearchModel
    {
        //TODO public string Name { get; set; }
        //public IEnumerable<int> Equipments { get; set; }

        public string StartDateStr { get; set; }
        public string EndDateStr { get; set; }

        public DateTime StartDate
        {
            get
            {
                var result = DateTime.Now;
                DateTime.TryParse(StartDateStr, out result);
                return result;
            }
        }

        public DateTime EndDate
        {
            get
            {
                var result = DateTime.Now;
                DateTime.TryParse(EndDateStr, out result);
                return result;
            }
        }
    }

    public class TermViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string color { get; set; }
        public bool agendaEvent { get; set; }
        public int columnIndex { get; set; }
        public IEnumerable<int> employees { get; set; }
    }

    /// <summary>
    ///     Controller for Disposition
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class ShowTermsController : ApiController
    {
        private readonly ITermsManager manager;
        private readonly IProductTypesManager productTypesManager;
        private readonly IUniqueNumberProvider numberProvider;

        public ShowTermsController(ITermsManager manager, IProductTypesManager productTypesManager, IUniqueNumberProvider numberProvider)
        {
            this.manager = manager;
            this.productTypesManager = productTypesManager;
            this.numberProvider = numberProvider;
        }

        public IHttpActionResult Post(TermSearchModel model)
        {
            var result = new List<TermViewModel>();

            if (!String.IsNullOrEmpty(model.StartDateStr) && !String.IsNullOrEmpty(model.EndDateStr))
            {
                var termsQuery = manager.GetActualTerms(model.StartDate, model.EndDate);

                var terms = termsQuery.ToList();
                var columnIndex = 0;

                foreach (var termGroup in terms.GroupBy(o => o.Employees).OrderBy(o => o.Key.Id))
                {
                    var date = DateTime.Now;

                    foreach (var term in termGroup)
                    {
                        date = term.Date;

                        result.Add(new TermViewModel()
                        {
                            id = term.Id,
                            start = term.Date.ToString("yyyy-MM-ddTHH:mm"),
                            end = term.Date.AddMinutes(term.Duration).ToString("yyyy-MM-ddTHH:mm"),
                            url = String.Format("#Orders/{0}", term.OrderId),
                            title = String.Format("{0}\n{1}\n{2} {3}\n{4}",
                                 String.Format("{0} {1}", termGroup.Key.Name, termGroup.Key.FirstName),
                                 term.Orders.Street, term.Orders.Zip, term.Orders.City, term.Orders.CustomerName),
                            color = termGroup.Key.Color,
                            agendaEvent = false,
                            columnIndex = columnIndex,
                            employees = new List<int>() { term.EmployeeId },
                        });
                    }

                    result.Add(new TermViewModel()
                    {
                        start = date.ToString("yyyy-MM-ddTHH:mm"),
                        end = date.ToString("yyyy-MM-ddTHH:mm"),
                        url = String.Empty,
                        title = String.Format("{0} {1}", termGroup.Key.Name, termGroup.Key.FirstName),
                        color = termGroup.Key.Color,
                        agendaEvent = true
                    });

                    columnIndex++;
                }
            }

            return Ok(result);
        }
    }
}
