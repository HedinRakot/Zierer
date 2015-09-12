using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="ProceedsAccounts"/> entity
    /// </summary>
    [DataContract]
    public partial class ProceedsAccountsModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="ProceedsAccounts.Value"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int value{ get; set; }

    }
}
