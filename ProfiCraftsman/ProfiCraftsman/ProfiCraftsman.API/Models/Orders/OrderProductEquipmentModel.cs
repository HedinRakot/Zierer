using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models
{
    /// <summary>
    ///     Model for <see cref="OrderProductEquipment"/> entity
    /// </summary>
    [DataContract]
    public partial class OrderProductMaterialModel : BaseModel
    { 
        [Required]
        [DataMember]
        public int positionId{ get; set; }

        [Required]
        [DataMember]
        public int productId { get; set; }

        [Required]
        [DataMember]
        public int materialId { get; set; }

        [Required]
        [DataMember]
        public int amount { get; set; }
    }
}
