using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="AdditionalCosts"/> entity
    /// </summary>
    [DataContract]
    public partial class AdditionalCostsModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="AdditionalCosts.Price"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public double price{ get; set; }
        /// <summary>
        ///     Model property for <see cref="AdditionalCosts.Automatic"/> entity
        /// </summary>
        [DataMember]
        public bool automatic{ get; set; }
        /// <summary>
        ///     Model property for <see cref="AdditionalCosts.FromDate"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public DateTime fromDate{ get; set; }
        /// <summary>
        ///     Model property for <see cref="AdditionalCosts.ToDate"/> entity
        /// </summary>
        [DataMember]
        public DateTime? toDate{ get; set; }
        /// <summary>
        ///     Model property for <see cref="AdditionalCosts.AdditionalCostTypeId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int additionalCostTypeId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="AdditionalCosts.ProceedsAccountId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int proceedsAccountId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="AdditionalCosts.Description"/> entity
        /// </summary>
        [DataMember]
        public string description{ get; set; }

    }
}
