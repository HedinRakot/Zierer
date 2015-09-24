using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="OwnProducts"/> entity
    /// </summary>
    [DataContract]
    public partial class OwnProductsModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="OwnProducts.Description"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string description{ get; set; }
        /// <summary>
        ///     Model property for <see cref="OwnProducts.Price"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public double price{ get; set; }
        /// <summary>
        ///     Model property for <see cref="OwnProducts.FromDate"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public DateTime fromDate{ get; set; }
        /// <summary>
        ///     Model property for <see cref="OwnProducts.ToDate"/> entity
        /// </summary>
        [DataMember]
        public DateTime? toDate{ get; set; }
        /// <summary>
        ///     Model property for <see cref="OwnProducts.ProceedsAccountId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int proceedsAccountId{ get; set; }

    }
}
