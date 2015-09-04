using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.Contracts.Entities;
using System.Web.Http;
using CoreBase;
using System.Collections.Generic;
using ProfiCraftsman.Contracts.Managers;
using CoreBase.Controllers;
using System.Linq;

namespace ProfiCraftsman.API.Controllers.Settings
{
    public partial class ProductMaterialRspsController
    {
        protected void ExtraEntityToModel(ProductMaterialRsp entity, ProductMaterialRspModel model)
        {
            model.materialName = entity.Materials.Name;
        }
    }
}
