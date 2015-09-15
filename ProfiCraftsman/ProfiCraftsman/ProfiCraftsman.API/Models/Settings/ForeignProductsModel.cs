using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="ForeignProducts"/> entity
    /// </summary>
    [DataContract]
    public partial class ForeignProductsModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="ForeignProducts.Description"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string description{ get; set; }
        /// <summary>
        ///     Model property for <see cref="ForeignProducts.Price"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public double price{ get; set; }
        /// <summary>
        ///     Model property for <see cref="ForeignProducts.FromDate"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public DateTime fromDate{ get; set; }
        /// <summary>
        ///     Model property for <see cref="ForeignProducts.ToDate"/> entity
        /// </summary>
        [DataMember]
        public DateTime? toDate{ get; set; }
        /// <summary>
        ///     Model property for <see cref="ForeignProducts.ProceedsAccountId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int proceedsAccountId{ get; set; }

    }
}
