﻿using ProfiCraftsman.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfiCraftsman.API.ClientControllers
{
    public static class TermViewModelHelper
    {
        public static ClientTermViewModel ToModel(Terms term, bool withPositions)
        {
            var positions = new List<ClientTermPositionViewModel>();

            if(withPositions)
            {
                positions = PositionModels(term);
            }

            return new ClientTermViewModel()
            {
                Id = term.Id,
                FromDate = String.Format("{0}", term.Date.ToString("HH:mm")),
                ToDate = String.Format("{0}", term.Date.AddMinutes(term.Duration).ToString("HH:mm")),
                Address = String.Format("{0} {1} {2}", term.Orders.Street, term.Orders.Zip, term.Orders.City),
                Status = term.Status,
                Positions = positions,
                //IsFirstTerm 
            };
        }

        public static List<ClientTermPositionViewModel> PositionModels(Terms term)
        {
            var result = new List<ClientTermPositionViewModel>();

            var positions = term.TermPositions.Where(o => o.Positions.ProductId.HasValue).ToList();
            for (int i = 0; i < positions.Count; i++)
            {
                var position = positions[i];
                result.Add(new ClientTermPositionViewModel()
                {
                    Id = position.Id,
                    Number = (i + 1).ToString(),
                    Description = position.Positions.Products.Name,
                    PlannedAmount = position.Amount.ToString(),
                    TermId = position.TermId,
                    ProccessedAmount = position.ProccessedAmount,
                });
            }

            return result;
        }
    }
}
