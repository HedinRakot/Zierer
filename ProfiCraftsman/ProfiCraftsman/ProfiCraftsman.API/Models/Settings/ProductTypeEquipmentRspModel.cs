using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="ProductTypeEquipmentRsp"/> entity
    /// </summary>
    [DataContract]
    public partial class ProductTypeEquipmentRspModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="ProductTypeEquipmentRsp.ProductTypeId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int productTypeId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="ProductTypeEquipmentRsp.EquipmentId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int equipmentId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="ProductTypeEquipmentRsp.Amount"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int amount{ get; set; }

    }
}
