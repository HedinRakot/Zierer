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
    ///     Controller for <see cref="Positions"/> entity
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class PositionsController: ClientApiController<PositionsModel, Positions, int, IPositionsManager>
    {
        public IPositionMaterialRspManager PositionMaterialRspManager { get; set; }
        public IProductsManager ProductManager { get; set; }
        public IMaterialsManager MaterialManager { get; set; }

        public PositionsController(IPositionsManager manager, IPositionMaterialRspManager posiionMaterialRspManager,
            IProductsManager productsManager, IMaterialsManager materialManager) : 
            base(manager)
        {
            this.PositionMaterialRspManager = posiionMaterialRspManager;
            this.ProductManager = productsManager;
            this.MaterialManager = materialManager;
        }

        private int positionNumber = 0;

        protected override void EntityToModel(Positions entity, PositionsModel model)
        {
            positionNumber++;
            model.positionNumber = positionNumber;
            model.orderId = entity.OrderId;
            model.isMaterialPosition = entity.IsMaterialPosition;
            model.productId = entity.ProductId;
            model.materialId = entity.MaterialId;
            model.isAlternative = entity.IsAlternative;
            model.paymentType = entity.PaymentType;
            model.parentId = entity.ParentId;

            if (entity.ProductId.HasValue)
            {
                model.number = entity.Products.Number;
                model.amountType = entity.Products.ProductAmountTypeString;
                model.totalPrice = CalculationHelper.CalculatePositionPrice(entity.Price, entity.Amount, entity.Payment).ToString("N2") + " EUR";
            }
            else if (entity.MaterialId.HasValue)
            {
                model.number = entity.Materials.Number;
                model.amountType = entity.Materials.MaterialAmountTypeString;
                model.totalPrice = CalculationHelper.CalculatePositionPrice(entity.Price, entity.Amount, entity.Payment).ToString("N2") + " EUR";
            }


            model.description = entity.Description;            

            model.amount = entity.Amount;
            model.price = entity.Price;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }

        protected override void ModelToEntity(PositionsModel model, Positions entity, ActionTypes actionType)
        {
            entity.OrderId = model.orderId;
            entity.IsMaterialPosition = model.isMaterialPosition;
            entity.ProductId = model.productId != 0 ? model.productId : (int?)null;
            entity.MaterialId = model.materialId != 0 ? model.materialId : (int?)null;
            entity.Price = model.price;
            entity.IsAlternative = model.isAlternative;
            entity.PaymentType = model.paymentType;
            entity.Amount = model.amount;
            entity.Description = model.description;
            entity.ParentId = model.parentId != 0 ? model.parentId : (int?)null;

            if(actionType == ActionTypes.Add)
            {
                if (model.productId.HasValue && model.productId != 0)
                {
                    var product = ProductManager.GetById(model.productId.Value);

                    entity.Description = product.Name;

                    foreach (var material in product.ProductMaterialRsps)
                    {
                        PositionMaterialRspManager.AddEntity(new PositionMaterialRsp()
                        {
                            Amount = material.Amount,
                            PositionId = model.Id,
                            MaterialId = material.MaterialId
                        });
                    }
                }
                else if(model.materialId.HasValue && model.materialId != 0)
                {
                    var material = MaterialManager.GetById(model.materialId.Value);
                    entity.Description = material.Name;
                }
                else
                {
                    Manager.AddEntity(entity);
                }
            }            
        }

        protected override string BuildWhereClause<T>(Filter filter)
        {
            if (filter.Field == "hasParent")
            {
                var hasParent = Boolean.Parse(filter.Value);

                return String.Format("ParentId.HasValue == {0}", hasParent);
            }

            return base.BuildWhereClause<T>(filter);
        }

        //public override IHttpActionResult Put([FromBody] PositionsModel model)
        //{
        //    var entity = Manager.GetById(model.Id);
        //    if (entity == null)
        //    {
        //        return NotFound();
        //    }
        //    if (HasConcurrency(entity, model))
        //    {
        //        //TODO: put proper processor for concurrency
        //        return Conflict();
        //    }

        //    Validate(model, entity, ActionTypes.Update);
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    ModelToEntity(model, entity, ActionTypes.Update);
        //    SetChangeDate(entity);

        //    // TODO we should save FROM_DATE as "FROM_DATE 00:00:00"
        //    // TO_DATE as "TO_DATE 23:59:59"
        //    var sysModel = ((object)model) as IModelIntervalFields;
        //    var sysEntity = entity as IIntervalFields;
        //    if (sysEntity != null && sysModel != null)
        //    {
        //        sysEntity.ToDate = sysModel.toDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        //    }

        //    try
        //    {
        //        Manager.SaveChanges();
        //    }
        //    catch (DuplicateEntityException ex)
        //    {
        //        SetDuplicateErrorsToModelState(ModelState, ex);
        //        return BadRequest(ModelState);
        //    }

        //    OnActionSuccess(entity, ActionTypes.Update);

        //    EntityToModel(entity, model);

        //    return Ok(model);
        //}



        //public override IHttpActionResult Post([FromBody] PositionsModel model)
        //{
        //    var entity = Manager.DataContext.CreateObject<Positions>();
        //    Validate(model, entity, ActionTypes.Add);
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    ModelToEntity(model, entity, ActionTypes.Add);
        //    SetChangeDate(entity);
        //    Manager.AddEntity(entity);

        //    try
        //    {
        //        Manager.SaveChanges();
        //    }
        //    catch (DuplicateEntityException ex)
        //    {
        //        SetDuplicateErrorsToModelState(ModelState, ex);
        //        return BadRequest(ModelState);
        //    }

        //    model = new PositionsModel
        //    {
        //        Id = entity.Id
        //    };

        //    OnActionSuccess(entity, ActionTypes.Add);

        //    EntityToModel(entity, model);

        //    return Ok(model);
        //}
    }
}
