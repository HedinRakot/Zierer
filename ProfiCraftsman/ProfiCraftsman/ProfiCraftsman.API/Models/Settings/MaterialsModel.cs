using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="Materials"/> entity
    /// </summary>
    [DataContract]
    public partial class MaterialsModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="Materials.Name"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string name{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Materials.Number"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string number{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Materials.Length"/> entity
        /// </summary>
        [DataMember]
        public int? length{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Materials.Width"/> entity
        /// </summary>
        [DataMember]
        public int? width{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Materials.Height"/> entity
        /// </summary>
        [DataMember]
        public int? height{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Materials.Color"/> entity
        /// </summary>
        [DataMember]
        public string color{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Materials.Price"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public double price{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Materials.IsVirtual"/> entity
        /// </summary>
        [DataMember]
        public bool isVirtual{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Materials.BoughtFrom"/> entity
        /// </summary>
        [DataMember]
        public string boughtFrom{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Materials.BoughtPrice"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public double boughtPrice{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Materials.Comment"/> entity
        /// </summary>
        [DataMember]
        public string comment{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Materials.MaterialAmountType"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int materialAmountType{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Materials.IsForAuto"/> entity
        /// </summary>
        [DataMember]
        public bool isForAuto{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Materials.MustCount"/> entity
        /// </summary>
        [DataMember]
        public int mustCount{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Materials.ProceedsAccountId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int proceedsAccountId{ get; set; }

    }
}
