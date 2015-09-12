using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="Employees"/> entity
    /// </summary>
    [DataContract]
    public partial class EmployeesModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="Employees.Number"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int number{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Employees.AutoId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int autoId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Employees.Name"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string name{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Employees.FirstName"/> entity
        /// </summary>
        [DataMember]
        public string firstName{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Employees.Street"/> entity
        /// </summary>
        [DataMember]
        public string street{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Employees.Zip"/> entity
        /// </summary>
        [DataMember]
        public string zip{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Employees.City"/> entity
        /// </summary>
        [DataMember]
        public string city{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Employees.Country"/> entity
        /// </summary>
        [DataMember]
        public string country{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Employees.Phone"/> entity
        /// </summary>
        [DataMember]
        public string phone{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Employees.Mobile"/> entity
        /// </summary>
        [DataMember]
        public string mobile{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Employees.Fax"/> entity
        /// </summary>
        [DataMember]
        public string fax{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Employees.Email"/> entity
        /// </summary>
        [DataMember]
        public string email{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Employees.Comment"/> entity
        /// </summary>
        [DataMember]
        public string comment{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Employees.Color"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string color{ get; set; }

    }
}
