using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models
{
    /// <summary>
    ///     Model for <see cref="TransportPositionsModel"/> entity
    /// </summary>
    [DataContract]
    public partial class TransportPositionsModel : BaseModel
    {
        [Required]
        [DataMember]
        public int transportOrderId{ get; set; }
        
        [DataMember]
        public int transportProductId { get; set; }

        [DataMember]
        public string description { get; set; }
                
        [Required]
        [DataMember]
        public double price { get; set; }

        [Required]
        [DataMember]
        public int amount { get; set; }
    }
}
