using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models.Invoices
{
    /// <summary>
    ///     Model for <see cref="InvoicePositions"/> entity
    /// </summary>
    [DataContract]
    public partial class InvoicePositionsModel: BaseModel
    {
        [DataMember]
        public double price{ get; set; }

        [DataMember]
        public string priceString { get; set; }

        [DataMember]
        public string totalPrice { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public double amount { get; set; }

        [DataMember]
        public string number { get; set; }
        
        [DataMember]
        public int paymentType { get; set; }
    }
}
