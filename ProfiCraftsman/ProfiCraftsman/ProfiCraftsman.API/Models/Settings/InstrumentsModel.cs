using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="Instruments"/> entity
    /// </summary>
    [DataContract]
    public partial class InstrumentsModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="Instruments.Name"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string name{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Instruments.Number"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string number{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Instruments.ProceedsAccount"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int proceedsAccount{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Instruments.IsForAuto"/> entity
        /// </summary>
        [DataMember]
        public bool isForAuto{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Instruments.BoughtPrice"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public double boughtPrice{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Instruments.Comment"/> entity
        /// </summary>
        [DataMember]
        public string comment{ get; set; }

    }
}
