using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models.Warehouse
{
    /// <summary>
    ///     Model for <see cref="WarehouseMaterialModel"/> entity
    /// </summary>
    [DataContract]
    public partial class WarehouseMaterialModel : BaseModel
    {
        [Required]
        [DataMember]
        public int materialId { get; set; }

        [Required]
        [DataMember]
        public int isAmount { get; set; }
        
        [DataMember]
        public int mustAmount { get; set; }
    }
}
