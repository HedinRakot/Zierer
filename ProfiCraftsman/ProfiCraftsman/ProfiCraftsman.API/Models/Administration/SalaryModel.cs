using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models
{
    /// <summary>
    ///     Model for Salary
    /// </summary>
    [DataContract]
    public partial class SalaryModel : BaseModel
    {
        [DataMember]
        public string employeeName { get; set; }
        
        [DataMember]
        public string amount { get; set; }

        [DataMember]
        public string date { get; set; }   
    }
}
