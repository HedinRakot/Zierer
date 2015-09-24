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
        public string address { get; set; }
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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Home })]
    public partial class ShowTermsController : ApiController
    {
        private readonly ITermsManager manager;
        private readonly IAbsencesManager absencesManager;
        private readonly IProductTypesManager productTypesManager;
        private readonly IUniqueNumberProvider numberProvider;

        public ShowTermsController(ITermsManager manager, IProductTypesManager productTypesManager, IUniqueNumberProvider numberProvider,
            IAbsencesManager absencesManager)
        {
            this.manager = manager;
            this.productTypesManager = productTypesManager;
            this.numberProvider = numberProvider;
            this.absencesManager = absencesManager;
        }

        public IHttpActionResult Post(TermSearchModel model)
        {
            var result = new List<TermViewModel>();

            if (!String.IsNullOrEmpty(model.StartDateStr) && !String.IsNullOrEmpty(model.EndDateStr))
            {
                var terms = manager.GetActualTerms(model.StartDate, model.EndDate).ToList();
                var columnIndexes = ProccessEmployees(model, result, terms);

                ProccessTerms(result, terms, columnIndexes);

                ProccessAbsences(model, result, columnIndexes);
            }

            return Ok(result);
        }

        private void ProccessTerms(List<TermViewModel> result, List<Contracts.Entities.Terms> terms, Dictionary<int, int> columnIndexes)
        {
            foreach (var term in terms.OrderBy(o => o.Id))
            {
                foreach (var termEmployee in term.TermEmployees.Where(e => !e.DeleteDate.HasValue).ToList())
                {
                    result.Add(new TermViewModel()
                    {
                        id = term.Id,
                        start = term.Date.ToString("yyyy-MM-ddTHH:mm"),
                        end = term.Date.AddMinutes(term.Duration).ToString("yyyy-MM-ddTHH:mm"),
                        url = String.Format("#Orders/{0}", term.OrderId),
                        title = String.Format("{0}\n{1}\n{2} {3}\n{4}",
                             String.Format("{0} {1}", termEmployee.Employees.Name, termEmployee.Employees.FirstName),
                             term.Orders.Street, term.Orders.Zip, term.Orders.City, term.Orders.CustomerName),
                        address = String.Format("{0},{1} {2}",
                             term.Orders.Street, term.Orders.Zip, term.Orders.City),
                        color = termEmployee.Employees.Color,
                        agendaEvent = false,
                        columnIndex = columnIndexes[termEmployee.EmployeeId],
                        employees = new List<int>() { termEmployee.EmployeeId },
                    });
                }
            }
        }

        private void ProccessAbsences(TermSearchModel model, List<TermViewModel> result, Dictionary<int, int> columnIndexes)
        {
            var absences = absencesManager.GetEntities().Where(r =>
                   (r.FromDate >= model.StartDate.Date && r.FromDate <= model.EndDate.Date) || //from date inside period
                   (r.ToDate >= model.StartDate.Date && r.ToDate <= model.EndDate.Date) || // to date inside period
                   (r.FromDate <= model.StartDate.Date && r.ToDate >= model.EndDate.Date)).ToList();//period is a part of an existing one


            var columnIndex = 0;
            if(columnIndexes.Count > 0)
            {
                columnIndex = columnIndexes.Values.Max() + 1;
            }

            foreach (var employee in absences.Select(o => o.Employees).Distinct().ToList())
            {
                columnIndexes[employee.Id] = columnIndex;
                columnIndex++;

                result.Add(new TermViewModel()
                {
                    start = model.StartDate.ToString("yyyy-MM-ddTHH:mm"),
                    end = model.StartDate.ToString("yyyy-MM-ddTHH:mm"),
                    url = String.Empty,
                    title = String.Format("{0} {1}", employee.Name, employee.FirstName),
                    color = employee.Color,
                    agendaEvent = true
                });
            }

            foreach (var absence in absences)
            {
                result.Add(new TermViewModel()
                {
                    id = absence.Id,
                    start = new DateTime(absence.FromDate.Year, absence.FromDate.Month, absence.FromDate.Day, 7, 0, 0).ToString("yyyy-MM-ddTHH:mm"),
                    end = new DateTime(absence.ToDate.Year, absence.ToDate.Month, absence.ToDate.Day, 18, 0, 0).ToString("yyyy-MM-ddTHH:mm"),
                    url = "javascript:void(0)",
                    title = String.Format("{0}\n{1}",
                         String.Format("{0} {1}", absence.Employees.Name, absence.Employees.FirstName),
                         absence.Description),
                    address = String.Empty,
                    color = absence.Employees.Color,
                    agendaEvent = false,
                    columnIndex = columnIndexes[absence.EmployeeId],
                    employees = new List<int>() { absence.EmployeeId },
                });
            }
        }

        private Dictionary<int, int> ProccessEmployees(TermSearchModel model, List<TermViewModel> result, 
            List<Contracts.Entities.Terms> terms)
        {
            int columnIndex = 0;
            var columnIndexes = new Dictionary<int, int>();

            foreach (var employee in terms.SelectMany(o => o.TermEmployees.Where(e => !e.DeleteDate.HasValue)).
                                Select(o => o.Employees).Distinct().ToList())
            {
                columnIndexes[employee.Id] = columnIndex;
                columnIndex++;

                result.Add(new TermViewModel()
                {
                    start = model.StartDate.ToString("yyyy-MM-ddTHH:mm"),
                    end = model.StartDate.ToString("yyyy-MM-ddTHH:mm"),
                    url = String.Empty,
                    title = String.Format("{0} {1}", employee.Name, employee.FirstName),
                    color = employee.Color,
                    agendaEvent = true
                });
            }

            return columnIndexes;
        }
    }
}
