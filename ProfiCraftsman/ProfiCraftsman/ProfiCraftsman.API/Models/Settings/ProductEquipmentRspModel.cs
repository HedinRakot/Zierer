using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="ProductEquipmentRsp"/> entity
    /// </summary>
    [DataContract]
    public partial class ProductEquipmentRspModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="ProductEquipmentRsp.ProductId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int productId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="ProductEquipmentRsp.EquipmentId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int equipmentId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="ProductEquipmentRsp.Amount"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int amount{ get; set; }

    }
}
