using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="NotProductiveWorkHours"/> entity
    /// </summary>
    [DataContract]
    public partial class NotProductiveWorkHoursModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="NotProductiveWorkHours.EmployeeId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int employeeId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="NotProductiveWorkHours.Description"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string description{ get; set; }
        /// <summary>
        ///     Model property for <see cref="NotProductiveWorkHours.FromDate"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public DateTime fromDate{ get; set; }
        /// <summary>
        ///     Model property for <see cref="NotProductiveWorkHours.ToDate"/> entity
        /// </summary>
        [DataMember]
        public DateTime toDate{ get; set; }

    }
}
