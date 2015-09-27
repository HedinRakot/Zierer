using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models
{
    /// <summary>
    ///     Model for Work Hours
    /// </summary>
    [DataContract]
    public partial class WorkHoursModel : BaseModel
    {
        [DataMember]
        public int employeeId { get; set; }

        [DataMember]
        public string employeeName { get; set; }

        [DataMember]
        public double amount { get; set; }

        [DataMember]
        public string amountString { get; set; }

        [DataMember]
        public DateTime date { get; set; }

        [DataMember]
        public string duration { get; set; }
    }
}
