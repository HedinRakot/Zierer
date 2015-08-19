using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="Autos"/> entity
    /// </summary>
    [DataContract]
    public partial class AutosModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="Autos.Number"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string number{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Autos.Comment"/> entity
        /// </summary>
        [DataMember]
        public string comment{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Autos.LastInspectionDate"/> entity
        /// </summary>
        [DataMember]
        public DateTime? lastInspectionDate{ get; set; }

    }
}
