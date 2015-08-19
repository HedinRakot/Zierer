using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models
{
    /// <summary>
    ///     Model for <see cref="PositionsModel"/> entity
    /// </summary>
    [DataContract]
    public partial class PositionsModel : BaseModel
    {
        [Required]
        [DataMember]
        public int orderId{ get; set; }

        [Required]
        [DataMember]
        public bool isMaterialPosition { get; set; }

        [DataMember]
        public int? productId { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string number { get; set; }

        [DataMember]
        public int? materialId { get; set; }
        
        [Required]
        [DataMember]
        public double price { get; set; }

        [Required]
        [DataMember]
        public int amount { get; set; }

        [Required]
        [DataMember]
        public int paymentType { get; set; }

        [Required]
        [DataMember]
        public bool isAlternative { get; set; }
        
        [DataMember]
        public int positionNumber { get; set; }

        [DataMember]
        public string amountType { get; set; }

        [DataMember]
        public string totalPrice { get; set; }
    }
}
