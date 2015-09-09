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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.ReportOrders })]
    public partial class ReportPositionsController: ApiController
    {
        private ITermPositionsManager termPositionsManager { get; set; }
        private IPositionsManager positionsManager { get; set; }
        private ITermCostsManager termCostsManager { get; set; }

        public ReportPositionsController(ITermPositionsManager termPositionsManager, IPositionsManager positionsManager, ITermCostsManager termCostsManager) 
        {
            this.termPositionsManager = termPositionsManager;
            this.positionsManager = positionsManager;
            this.termCostsManager = termCostsManager;
        }


        public virtual IHttpActionResult Get([FromUri] GridArgs args)
        {
            var entities = GetEntities(args.Filtering);

            if (entities == null)
            {
                var empty = new GridResult<ReportPositionsModel, int>
                {
                    total = 0,
                    data = new List<ReportPositionsModel>()
                };

                return Ok(empty);
            }

            var total = entities.Count();

            entities = Page(entities, args.Paging);

            var result = new GridResult<ReportPositionsModel, int>
            {
                total = total,
                data = entities.ToList()
            };

            return Ok(result);
        }

        protected IEnumerable<ReportPositionsModel> GetEntities(Filtering filtering)
        {
            var orderId = GetFilters(filtering);
            var result = new List<ReportPositionsModel>();

            if(orderId != 0)
            {
                //TODO discuss with customer - take positions where proccessed amount not null (but take with 0)
                var termPositions = termPositionsManager.GetEntities(o => !o.DeleteDate.HasValue && o.Terms.OrderId == orderId && o.ProccessedAmount.HasValue).ToList();

                var id = 0;
                foreach(var termPosition in termPositions)
                {
                    //positions
                    if (termPosition.ProccessedAmount.Value > 0)
                    {
                        id++;
                        result.Add(PositionsToModel(id, termPosition.Positions, termPosition.ProccessedAmount.Value, termPosition.Terms.Date));
                    }

                    //materials
                    foreach(var material in termPosition.TermPositionMaterialRsps.Where(o => !o.DeleteDate.HasValue && o.Amount.HasValue))
                    {
                        id++;

                        var amount = material.Amount.Value;
                        if(material.Materials.MaterialAmountTypes == MaterialAmountTypes.Meter)
                        {
                            if (material.Materials.Length != 0)
                            {
                                amount = amount / (double)material.Materials.Length.Value;
                            }
                            else
                            {
                                //todo
                            }
                        }

                        result.Add(new ReportPositionsModel()
                        {
                            Id = id,
                            amount = material.Amount.Value,
                            description = material.Materials.Name,
                            number = material.Materials.Number,
                            createDate = termPosition.Terms.Date,
                            amountType = material.Materials.MaterialAmountTypeString,
                            price = material.Materials.Price,
                            totalPrice = CalculationHelper.CalculatePositionPrice(material.Materials.Price, amount, PaymentTypes.Standard).ToString("N2") + " EUR"
                        });
                    }
                }

                //material positions without terms
                var materialPositionsWithoutTerms = positionsManager.GetEntities(o => o.OrderId == orderId && !o.DeleteDate.HasValue && 
                    !o.TermId.HasValue && o.MaterialId.HasValue && o.IsMaterialPosition).ToList();
                foreach (var position in materialPositionsWithoutTerms)
                {
                    id++;

                    result.Add(PositionsToModel(id, position, position.Amount, position.ChangeDate /*todo check*/));
                }

                //extra costs
                var termCosts = termCostsManager.GetEntities(o => !o.DeleteDate.HasValue && o.Terms.OrderId == orderId).ToList();
                foreach (var termCost in termCosts)
                {
                    id++;

                    result.Add(new ReportPositionsModel()
                    {
                        Id = id,
                        amount = 1,
                        description = termCost.Name,
                        createDate = termCost.ChangeDate/*todo check*/,
                        amountType = "Pauschal",
                        price = termCost.Price,
                        totalPrice = CalculationHelper.CalculatePositionPrice(termCost.Price, 1, PaymentTypes.Standard).ToString("N2") + " EUR"
                    });
                }
            }

            return result.OrderBy(o => o.createDate);
        }
        
        private int GetFilters(Filtering filtering)
        {
            var orderId = 0;

            foreach (var compositeFilter in filtering.Filters)
            {
                foreach (var filter in compositeFilter.Filters)
                {
                    switch (filter.Field.ToLower())
                    {
                        case "orderid":
                            int.TryParse(filter.Value, out orderId);
                            break;
                        default:
                            break;

                    }
                }
            }

            return orderId;
        }

        private IEnumerable<ReportPositionsModel> Page(IEnumerable<ReportPositionsModel> entities, Paging paging)
        {
            if (paging.Take > 0)
            {
                entities = entities.Skip(paging.Skip).Take(paging.Take);
            }

            return entities;
        }

        protected ReportPositionsModel PositionsToModel(int id, Positions entity, int amount, DateTime date)
        {
            var model = new ReportPositionsModel();

            model.Id = id;
            model.orderId = entity.OrderId;
            model.paymentType = entity.PaymentType;
            model.paymentTypeString = entity.PaymentTypeString;
            model.amount = amount;
            model.amountString = amount.ToString();
            model.price = entity.Price;
            model.priceString = entity.Price.ToString();
            model.description = entity.Description;
            model.createDate = date;
            model.changeDate = date;

            if (entity.ProductId.HasValue)
            {
                model.number = entity.Products.Number;
                model.amountType = entity.Products.ProductAmountTypeString;
                model.totalPrice = CalculationHelper.CalculatePositionPrice(entity.Price, amount, entity.Payment).ToString("N2") + " EUR";
            }
            else if (entity.MaterialId.HasValue)
            {
                model.number = entity.Materials.Number;
                model.amountType = entity.Materials.MaterialAmountTypeString;
                model.totalPrice = CalculationHelper.CalculatePositionPrice(entity.Price, amount, entity.Payment).ToString("N2") + " EUR";
            }

            return model;
        }       
    }
}
