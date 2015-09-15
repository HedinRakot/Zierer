using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="SocialTaxes"/> entity
    /// </summary>
    [DataContract]
    public partial class SocialTaxesModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="SocialTaxes.EmployeeId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int employeeId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="SocialTaxes.Description"/> entity
        /// </summary>
        [DataMember]
        public string description{ get; set; }
        /// <summary>
        ///     Model property for <see cref="SocialTaxes.Price"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public double price{ get; set; }
        /// <summary>
        ///     Model property for <see cref="SocialTaxes.ProceedsAccountId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int proceedsAccountId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="SocialTaxes.FromDate"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public DateTime fromDate{ get; set; }
        /// <summary>
        ///     Model property for <see cref="SocialTaxes.ToDate"/> entity
        /// </summary>
        [DataMember]
        public DateTime? toDate{ get; set; }

    }
}
