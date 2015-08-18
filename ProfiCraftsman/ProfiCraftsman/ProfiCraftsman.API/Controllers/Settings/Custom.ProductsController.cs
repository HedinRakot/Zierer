using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.Contracts.Entities;
using System.Web.Http;
using CoreBase;
using System.Collections.Generic;
using ProfiCraftsman.Contracts.Managers;
using CoreBase.Controllers;

namespace ProfiCraftsman.API.Controllers.Settings
{
    public partial class ProductsController
    {
        protected override string BuildWhereClause<T>(Filter filter)
        {
            if (filter.Field == "name")
            {
                var clauses = new List<string>();

                clauses.AddRange(new[] { 
        				base.BuildWhereClause<T>(new Filter { Field = "Name", Operator = filter.Operator, Value = filter.Value }),
        				base.BuildWhereClause<T>(new Filter { Field = "Number", Operator = filter.Operator, Value = filter.Value }),
                        base.BuildWhereClause<T>(new Filter { Field = "ProductTypes.Name", Operator = filter.Operator, 
                            Value = filter.Value }),
        			});

                return string.Join(" or ", clauses);
            }

            return base.BuildWhereClause<T>(filter);
        }

        protected void ExtraModelToEntity(Products entity, ProductsModel model, ActionTypes actionType)
        {
            if (actionType == ActionTypes.Add)
            {
                //TODO delete
                //entity.ProductEquipmentRsps = new List<ProductEquipmentRsp>();
                //var productTypeManager = GlobalConfiguration.Configuration.DependencyResolver.GetService<IProductTypesManager>();
                //var productType = productTypeManager.GetById(model.productTypeId);
                //foreach (var equipment in productType.ProductTypeEquipmentRsps)
                //{
                //    entity.ProductEquipmentRsps.Add(new ProductEquipmentRsp()
                //    {
                //        Amount = equipment.Amount,
                //        Products = entity,
                //        EquipmentId = equipment.EquipmentId
                //    });
                //}
            }
        }
    }
}
