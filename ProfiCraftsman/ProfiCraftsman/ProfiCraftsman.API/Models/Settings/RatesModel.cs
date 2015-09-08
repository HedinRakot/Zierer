using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="Rates"/> entity
    /// </summary>
    [DataContract]
    public partial class RatesModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="Rates.JobPositionId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int jobPositionId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Rates.Price"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public double price{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Rates.FromDate"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public DateTime fromDate{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Rates.ToDate"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public DateTime toDate{ get; set; }

    }
}
