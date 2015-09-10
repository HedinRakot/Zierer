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
    public partial class ReportPositionsModel : BaseModel
    {
        [DataMember]
        public int orderId{ get; set; }
        
        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string number { get; set; }
                
        [DataMember]
        public string price { get; set; }
        
        [DataMember]
        public string priceString { get; set; }

        [DataMember]
        public double amount { get; set; }
        
        [DataMember]
        public string amountString { get; set; }

        [DataMember]
        public int paymentType { get; set; }

        [DataMember]
        public string paymentTypeString { get; set; }
                
        [DataMember]
        public string amountType { get; set; }

        [DataMember]
        public string totalPrice { get; set; }        
    }
}
