using CoreBase.Controllers;
using CoreBase.Entities;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.API.Models.Warehouse;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfiCraftsman.API.Controllers.Settings
{
    /// <summary>
    ///     Controller for <see cref="WarehouseMaterials"/> entity
    /// </summary>
    public partial class WarehouseMaterialsController : ClientApiController<WarehouseMaterialModel, WarehouseMaterials, int, IWarehouseMaterialsManager>
    {

        public WarehouseMaterialsController(IWarehouseMaterialsManager manager) : base(manager) { }

        protected override void EntityToModel(WarehouseMaterials entity, WarehouseMaterialModel model)
        {
            model.materialId = entity.MaterialId;
            model.materialName = entity.Materials.Name;
            model.materialNumber = entity.Materials.Number;
            model.isAmount = entity.IsAmount;
            model.mustAmount = entity.MustAmount;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }

        protected override void ModelToEntity(WarehouseMaterialModel model, WarehouseMaterials entity, ActionTypes actionType)
        {
            entity.MaterialId = model.materialId;
            entity.IsAmount = model.isAmount;
            entity.MustAmount = model.mustAmount;
        }

        protected override string BuildWhereClause<T>(Filter filter)
        {
            if (filter.Field == "name")
            {
                var clauses = new List<string>();

                clauses.AddRange(new[] {
                        base.BuildWhereClause<T>(new Filter { Field = "Materials.Name", Operator = filter.Operator, Value = filter.Value }),
                        base.BuildWhereClause<T>(new Filter { Field = "Materials.Number", Operator = filter.Operator, Value = filter.Value }),
                    });

                return string.Join(" or ", clauses);
            }
            else if (filter.Field == "isLessAsMustAmountStatus")
            {
                int isLessAsMustAmountStatus;
                if (!String.IsNullOrEmpty(filter.Value))
                {
                    Int32.TryParse(filter.Value, out isLessAsMustAmountStatus);

                    return String.Format("{0}", isLessAsMustAmountStatus == 1 ? " 1 == 1" : " IsAmount < MustAmount");
                }
            }

            return base.BuildWhereClause<T>(filter);
        }

        protected override IQueryable<WarehouseMaterials> Sort(IQueryable<WarehouseMaterials> entities, Sorting sorting)
        {
            if (sorting.Field == "materialName")
            {
                if (sorting.Direction == "desc")
                    return entities.OrderByDescending(o => o.Materials.Name);
                else
                    return entities.OrderBy(o => o.Materials.Name);
            }
            else if (sorting.Field == "materialNumber")
            {
                if (sorting.Direction == "desc")
                    return entities.OrderByDescending(o => o.Materials.Number);
                else
                    return entities.OrderBy(o => o.Materials.Number);
            }

            return base.Sort(entities, sorting);
        }
    }
}
