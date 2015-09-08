using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models
{
    /// <summary>
    ///     Model for <see cref="TermInstrumentModel"/> entity
    /// </summary>
    [DataContract]
    public partial class TermInstrumentModel : BaseModel
    {
        [Required]
        [DataMember]
        public int termId{ get; set; }

        [Required]
        [DataMember]
        public int instrumentId { get; set; }

        [Required]
        [DataMember]
        public int employeeId { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string number { get; set; }
    }
}
