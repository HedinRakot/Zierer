using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models
{
    /// <summary>
    ///     Model for <see cref="PositionMaterialModel"/> entity
    /// </summary>
    [DataContract]
    public partial class PositionMaterialModel : BaseModel
    { 
        [Required]
        [DataMember]
        public int positionId{ get; set; }

        [Required]
        [DataMember]
        public int materialId { get; set; }

        [DataMember]
        public double? amount { get; set; }
    }
}
