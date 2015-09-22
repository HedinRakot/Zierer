using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models
{
    /// <summary>
    ///     Model for <see cref="Orders"/> entity
    /// </summary>
    [DataContract]
    public partial class OrdersModel: BaseModel
    {
        [DataMember]
        public string customerName { get; set; }

        [Required]
        [DataMember]
        public int customerId{ get; set; }

        [DataMember]
        public int? communicationPartnerId{ get; set; }

        [DataMember]
        public string communicationPartnerTitle { get; set; }

        [Required]
        [DataMember]
        public string street{ get; set; }

        [Required]
        [DataMember]
        public string zip{ get; set; }

        [Required]
        [DataMember]
        public string city{ get; set; }

        [DataMember]
        public string comment{ get; set; }
        
        [DataMember]
        public string orderNumber{ get; set; }
       
        [DataMember]
        public bool autoBill{ get; set; }

        [DataMember]
        public double? discount{ get; set; }
        
        [Required]
        [DataMember]
        public int customerNumber { get; set; }

        [Required]
        [DataMember]
        public string newCustomerName { get; set; }

        [Required]
        [DataMember]
        public string customerStreet { get; set; }

        [Required]
        [DataMember]
        public string customerZip { get; set; }

        [Required]
        [DataMember]
        public string customerCity { get; set; }

        [DataMember]
        public string customerPhone { get; set; }

        [DataMember]
        public string customerFax { get; set; }

        [Required]
        [DataMember]
        public string customerEmail { get; set; }

        [DataMember]
        public int customerSelectType { get; set; }

        [DataMember]
        public bool isOffer { get; set; }

        [DataMember]
        public int status { get; set; }
    }
}
