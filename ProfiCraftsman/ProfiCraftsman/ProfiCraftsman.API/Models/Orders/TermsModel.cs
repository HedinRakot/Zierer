using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models
{
    /// <summary>
    ///     Model for <see cref="Terms"/> entity
    /// </summary>
    [DataContract]
    public partial class TermsModel : BaseModel
    {
        [Required]
        [DataMember]
        public int orderId { get; set; }

        [Required]
        [DataMember]
        public int employeeId{ get; set; }

        [Required]
        [DataMember]
        public int autoId{ get; set; }

        [Required]
        [DataMember]
        public DateTime date { get; set; }

        [Required]
        [DataMember]
        public int duration { get; set; }

        [DataMember]
        public string comment{ get; set; }
        
        [DataMember]
        public string status { get; set; }
    }
}
