using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="CustomProducts"/> entity
    /// </summary>
    [DataContract]
    public partial class CustomProductsModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="CustomProducts.Name"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string name{ get; set; }
        /// <summary>
        ///     Model property for <see cref="CustomProducts.Price"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public double price{ get; set; }
        /// <summary>
        ///     Model property for <see cref="CustomProducts.Auto"/> entity
        /// </summary>
        [DataMember]
        public bool auto{ get; set; }

    }
}
