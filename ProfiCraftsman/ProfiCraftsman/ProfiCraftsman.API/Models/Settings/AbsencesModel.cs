using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="Absences"/> entity
    /// </summary>
    [DataContract]
    public partial class AbsencesModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="Absences.EmployeeId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int employeeId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Absences.Description"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string description{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Absences.FromDate"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public DateTime fromDate{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Absences.ToDate"/> entity
        /// </summary>
        [DataMember]
        public DateTime toDate{ get; set; }

    }
}
