using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models
{
    /// <summary>
    ///     Model for <see cref="TermPositionMaterialModel"/> entity
    /// </summary>
    [DataContract]
    public partial class TermPositionMaterialModel : BaseModel
    { 
        [Required]
        [DataMember]
        public int termPositionId{ get; set; }

        [Required]
        [DataMember]
        public int materialId { get; set; }

        [DataMember]
        public string materialName { get; set; }

        [DataMember]
        public double? amount { get; set; }
    }
}
