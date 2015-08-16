using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="RolePermissionRsp"/> entity
    /// </summary>
    [DataContract]
    public partial class RolePermissionRspModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="RolePermissionRsp.RoleId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int roleId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="RolePermissionRsp.PermissionId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int permissionId{ get; set; }

    }
}
