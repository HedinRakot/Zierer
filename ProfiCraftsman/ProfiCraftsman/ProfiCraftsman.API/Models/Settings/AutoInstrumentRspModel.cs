using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="AutoInstrumentRsp"/> entity
    /// </summary>
    [DataContract]
    public partial class AutoInstrumentRspModel : BaseModel
    {
        [Required]
        [DataMember]
        public int autoId { get; set; }

        [Required]
        [DataMember]
        public int instrumentId { get; set; }

        [Required]
        [DataMember]
        public int amount { get; set; }
    }
}
