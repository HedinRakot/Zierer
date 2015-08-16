using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="Taxes"/> entity
    /// </summary>
    [DataContract]
    public partial class TaxesModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="Taxes.Value"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public double value{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Taxes.FromDate"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public DateTime fromDate{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Taxes.ToDate"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public DateTime toDate{ get; set; }

    }
}
