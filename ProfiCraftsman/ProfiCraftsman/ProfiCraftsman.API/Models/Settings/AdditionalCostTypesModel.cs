using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="AdditionalCostTypes"/> entity
    /// </summary>
    [DataContract]
    public partial class AdditionalCostTypesModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="AdditionalCostTypes.Name"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string name{ get; set; }

    }
}
