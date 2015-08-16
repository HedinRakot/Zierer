using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="TransportProducts"/> entity
    /// </summary>
    [DataContract]
    public partial class TransportProductsModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="TransportProducts.Name"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string name{ get; set; }
        /// <summary>
        ///     Model property for <see cref="TransportProducts.Description"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string description{ get; set; }
        /// <summary>
        ///     Model property for <see cref="TransportProducts.Price"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public double price{ get; set; }
        /// <summary>
        ///     Model property for <see cref="TransportProducts.ProceedsAccount"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int proceedsAccount{ get; set; }

    }
}
