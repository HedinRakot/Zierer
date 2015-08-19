using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="JobPositions"/> entity
    /// </summary>
    [DataContract]
    public partial class JobPositionsModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="JobPositions.Name"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string name{ get; set; }
        /// <summary>
        ///     Model property for <see cref="JobPositions.Comment"/> entity
        /// </summary>
        [DataMember]
        public string comment{ get; set; }

    }
}
