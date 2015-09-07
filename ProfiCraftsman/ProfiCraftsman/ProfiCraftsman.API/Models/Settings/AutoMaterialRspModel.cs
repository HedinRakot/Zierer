using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="AutoMaterialRsp"/> entity
    /// </summary>
    [DataContract]
    public partial class AutoMaterialRspModel : BaseModel
    {
        [Required]
        [DataMember]
        public int autoId { get; set; }

        [Required]
        [DataMember]
        public int materialId { get; set; }

        [DataMember]
        public string materialName { get; set; }

        [Required]
        [DataMember]
        public int amount { get; set; }
        
        [DataMember]
        public int mustCount { get; set; }

        [DataMember]
        public double? restAmount { get; set; }
    }
}
