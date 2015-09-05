using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models
{
    /// <summary>
    ///     Model for <see cref="TermEmployeeModel"/> entity
    /// </summary>
    [DataContract]
    public partial class TermEmployeeModel : BaseModel
    {
        [Required]
        [DataMember]
        public int termId{ get; set; }
        
        [DataMember]
        public int employeeId { get; set; }
    }
}
