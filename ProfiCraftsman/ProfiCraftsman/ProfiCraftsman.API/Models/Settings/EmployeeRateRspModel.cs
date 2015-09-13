using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="EmployeeRateRsp"/> entity
    /// </summary>
    [DataContract]
    public partial class EmployeeRateRspModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="EmployeeRateRsp.EmployeeId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int employeeId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="EmployeeRateRsp.JobPositionId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int jobPositionId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="EmployeeRateRsp.FromDate"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public DateTime fromDate{ get; set; }
        /// <summary>
        ///     Model property for <see cref="EmployeeRateRsp.ToDate"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public DateTime toDate{ get; set; }
        /// <summary>
        ///     Model property for <see cref="EmployeeRateRsp.SalaryType"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int salaryType{ get; set; }
        /// <summary>
        ///     Model property for <see cref="EmployeeRateRsp.Salary"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public double salary{ get; set; }

    }
}
