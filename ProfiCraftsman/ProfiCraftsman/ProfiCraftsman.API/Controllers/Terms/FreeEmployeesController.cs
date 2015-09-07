using CoreBase.Controllers;
using CoreBase.Entities;
using CoreBase.Exceptions;
using CoreBase.Models;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.Lib.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Http;

namespace ProfiCraftsman.API.Controllers
{
    /// <summary>
    ///     Controller for <see cref="TermInstruments"/> entity
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class FreeEmployeesController : ReadOnlyClientApiController<EmployeesModel, Employees, int, IEmployeesManager>
    {
        protected ITermsManager termManager { get; set; }

        public FreeEmployeesController(IEmployeesManager manager, ITermsManager termManager) :
            base(manager)
        {
            this.termManager = termManager;
        }

        protected override IQueryable<Employees> Filter(IQueryable<Employees> entities, Filtering filtering)
        {
            var termId = GetFilters(filtering);
            var term = termManager.GetById(termId);

            if (term != null)
            {
                var termEmployeeIds = term.TermEmployees.Where(o => !o.DeleteDate.HasValue).Select(o => o.EmployeeId).ToList();

                var employees = entities.ToList().Where(o => !termEmployeeIds.Contains(o.Id));

                var busyEmployeeIds = GetBusyEmployees(employees, term.Date, term.Date.AddMinutes(term.Duration));

                entities = employees.Where(o => !busyEmployeeIds.Contains(o.Id)).AsQueryable();
            }

            return entities;
        }

        private int GetFilters(Filtering filtering)
        {
            var termId = 0;

            foreach (var compositeFilter in filtering.Filters)
            {
                foreach (var filter in compositeFilter.Filters)
                {
                    switch (filter.Field.ToLower())
                    {
                        case "termid":
                            int.TryParse(filter.Value, out termId);
                            break;
                        default:
                            break;

                    }
                }
            }

            return termId;
        }

        private IEnumerable<int> GetBusyEmployees(IEnumerable<Employees> entities, DateTime dateFrom, DateTime dateTo)
        {
            return entities.SelectMany(o => o.TermEmployees).
                Where(r =>
                    (r.Terms.Date >= dateFrom && r.Terms.Date <= dateTo) || //from date inside period
                    (r.Terms.Date.AddMinutes(r.Terms.Duration) >= dateFrom && r.Terms.Date.AddMinutes(r.Terms.Duration) <= dateTo) || // to date inside period
                    (r.Terms.Date <= dateFrom && r.Terms.Date.AddMinutes(r.Terms.Duration) >= dateTo)).Select(o => o.EmployeeId); //period is a part of an existing one
        }

        protected override void EntityToModel(Employees entity, EmployeesModel model)
        {
            model.number = entity.Number;
            model.name = entity.Name;
            model.firstName = entity.FirstName;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
    }
}
