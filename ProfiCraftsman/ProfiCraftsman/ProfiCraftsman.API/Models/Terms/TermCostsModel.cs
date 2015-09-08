using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models
{
    /// <summary>
    ///     Model for <see cref="TermCostsModel"/> entity
    /// </summary>
    [DataContract]
    public partial class TermCostsModel : BaseModel
    {
        [Required]
        [DataMember]
        public int termId{ get; set; }

        [Required]
        [DataMember]
        public double price { get; set; }
        
        [Required]
        [DataMember]
        public string name { get; set; }
    }
}
