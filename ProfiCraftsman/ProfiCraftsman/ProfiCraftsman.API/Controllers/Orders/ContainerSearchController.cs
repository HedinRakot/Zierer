
using System;
using System.Collections.Generic;
using System.Linq;
using ProfiCraftsman.API.Models.Orders;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts.Enums;
using CoreBase.Entities;
using CoreBase.Controllers;

namespace ProfiCraftsman.API.Controllers
{
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public class ProductSearchController : ClientApiController<ProductSmartModel, Products, int, IProductsManager>
    {
        private DateTime fromDate;
        private DateTime toDate;

        public ProductSearchController(IProductsManager manager)
            : base(manager)
        {
        }

        protected override void EntityToModel(Products entity, ProductSmartModel model)
        {
            model.number = entity.Number;
            model.productTypeId = entity.ProductTypeId;
            model.price = entity.Price;
            model.proceedsAccount = entity.ProceedsAccount;
            model.comment = entity.Comment;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;

            //specific
            model.fromDate = fromDate;
            model.toDate = toDate;
        }

        protected override void ModelToEntity(ProductSmartModel model, Products entity, ActionTypes actionType)
        {
            entity.Number = model.number;
            entity.ProductTypeId = model.productTypeId;
            entity.Price = model.price;
            entity.ProceedsAccount = model.proceedsAccount;
            entity.Comment = model.comment;
        }

        //TODO
        //protected override IQueryable<Products> Filter(IQueryable<Products> entities, Filtering filtering)
        //{
        //    //Filter is performed by parameters : 
        //    //1. Product type
        //    //2. available from, 3. available to
        //    //4. name (freetext)
        //    //5. equipments

        //    int? typeId;
        //    string name;
        //    List<int> equpmentIds;

        //    GetFilters(filtering, out typeId, out name, out equpmentIds);

        //    if (fromDate == DateTime.MinValue || toDate == DateTime.MinValue)
        //    {
        //        return Manager.GetFreeProducts(new List<int>(), typeId, name, equpmentIds); //for offers we return Products independs from booking
        //    }

        //    var positions = Manager.GetActualPositions(fromDate, toDate);
        //    var ids = positions.Select(o => o.ProductId.Value).Distinct().ToList();

        //    return Manager.GetFreeProducts(ids, typeId, name, equpmentIds);
        //}
        
        private void GetFilters(Filtering filtering, out int? typeId, out string name, out List<int> equipmentIds)
        {
            fromDate = DateTime.MinValue;
            toDate = DateTime.MinValue;
            var typeIdTemp = -1;
            name = String.Empty;
            equipmentIds = new List<int>();

            foreach (var compositeFilter in filtering.Filters)
            {
                foreach (var filter in compositeFilter.Filters)
                {
                    switch (filter.Field.ToLower())
                    {
                        case "fromdate":
                            DateTime.TryParse(filter.Value, out fromDate);
                            break;
                        case "todate":
                            DateTime.TryParse(filter.Value, out toDate);
                            break;
                        case "producttypeid":
                            int.TryParse(filter.Value, out typeIdTemp);
                            break;
                        case "name":
                            name = filter.Value;
                            break;
                        case "equipments":
                            if (!String.IsNullOrEmpty(filter.Value))
                            {
                                var parts = filter.Value.Split(',');
                                foreach (var part in parts)
                                {
                                    int temp;
                                    if (Int32.TryParse(part, out temp))
                                    {
                                        equipmentIds.Add(temp);
                                    }
                                }
                            }
                            break;
                        default:
                            break;

                    }
                }
            }
            typeId = (typeIdTemp < 1) ? (int?)null : typeIdTemp;
        }        
    }
}
