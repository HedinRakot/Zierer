using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="Permission"/> entity
    /// </summary>
    [DataContract]
    public partial class PermissionModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="Permission.Name"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string name{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Permission.Description"/> entity
        /// </summary>
        [DataMember]
        public string description{ get; set; }

    }
}
