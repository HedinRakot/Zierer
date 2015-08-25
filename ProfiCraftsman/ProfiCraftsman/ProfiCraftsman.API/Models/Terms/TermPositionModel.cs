using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models
{
    /// <summary>
    ///     Model for <see cref="TermPositionModel"/> entity
    /// </summary>
    [DataContract]
    public partial class TermPositionModel : BaseModel
    {
        [Required]
        [DataMember]
        public int termId{ get; set; }
        
        [DataMember]
        public int positionId { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string number { get; set; }
                
        [DataMember]
        public double price { get; set; }
        
        [DataMember]
        public int amount { get; set; }

        [DataMember]
        public int? proccessedAmount { get; set; }

        [DataMember]
        public int paymentType { get; set; }
        
        [Required]
        [DataMember]
        public bool isAlternative { get; set; }
        
        [DataMember]
        public string amountType { get; set; }

        [DataMember]
        public string totalPrice { get; set; }
    }
}
