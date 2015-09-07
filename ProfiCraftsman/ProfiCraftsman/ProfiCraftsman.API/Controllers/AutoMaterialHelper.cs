using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfiCraftsman.API.Controllers
{
    public static class AutoMaterialHelper
    {
        public static void CalculateUsedMaterial(double amount, double? previousAmount, TermPositionMaterialRsp entity)
        {
            var usedMaterialAmount = amount;

            if (previousAmount.HasValue)
            {
                usedMaterialAmount -= previousAmount.Value;
            }

            var autoMaterial = entity.TermPositions.Terms.Autos.AutoMaterialRsps.
                Where(o => !o.DeleteDate.HasValue && o.MaterialId == entity.MaterialId).FirstOrDefault();

            if (autoMaterial != null && usedMaterialAmount != 0)
            {
                if (autoMaterial.Materials.MaterialAmountTypes == MaterialAmountTypes.Item)
                {
                    autoMaterial.Amount -= Int32.Parse(usedMaterialAmount.ToString());
                }
                else
                {
                    if (autoMaterial.Materials.Length != 0)
                    {
                        var count = (int)(usedMaterialAmount / autoMaterial.Materials.Length.Value);
                        autoMaterial.Amount -= count;

                        var rest = usedMaterialAmount - count * autoMaterial.Materials.Length.Value;


                        if (!autoMaterial.RestAmount.HasValue)
                        {
                            autoMaterial.Amount--;
                            autoMaterial.RestAmount = autoMaterial.Materials.Length.Value - rest;
                        }
                        else
                        {
                            if (autoMaterial.RestAmount.Value > rest)
                            {
                                autoMaterial.RestAmount -= rest;
                            }
                            else
                            {
                                autoMaterial.Amount--;
                                autoMaterial.RestAmount = autoMaterial.Materials.Length.Value - (rest - autoMaterial.RestAmount.Value);
                            }
                        }
                    }
                    else
                    {
                        autoMaterial.Amount--;
                    }
                }
            }
            else
            {
                //todo
            }
        }
    }
}
