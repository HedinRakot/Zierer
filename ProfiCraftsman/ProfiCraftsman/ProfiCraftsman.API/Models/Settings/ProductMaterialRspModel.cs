using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="ProductMaterialRsp"/> entity
    /// </summary>
    [DataContract]
    public partial class ProductMaterialRspModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="ProductMaterialRsp.ProductId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int productId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="ProductMaterialRsp.MaterialId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int materialId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="ProductMaterialRsp.Amount"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int amount{ get; set; }

    }
}
