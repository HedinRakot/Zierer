using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="ProductTypes"/> entity
    /// </summary>
    [DataContract]
    public partial class ProductTypesModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="ProductTypes.Name"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string name{ get; set; }
        /// <summary>
        ///     Model property for <see cref="ProductTypes.Comment"/> entity
        /// </summary>
        [DataMember]
        public string comment{ get; set; }

    }
}
