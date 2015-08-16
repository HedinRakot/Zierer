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

        /// <summary>
        ///     Model property for <see cref="Orders.CustomerId"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int customerId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Orders.CommunicationPartnerId"/> entity
        /// </summary>
        [DataMember]
        public int? communicationPartnerId{ get; set; }

        [DataMember]
        public string communicationPartnerTitle { get; set; }
              
        /// <summary>
        ///     Model property for <see cref="Orders.DeliveryPlace"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string deliveryPlace{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Orders.Street"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string street{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Orders.Zip"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string zip{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Orders.City"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string city{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Orders.Comment"/> entity
        /// </summary>
        [DataMember]
        public string comment{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Orders.OrderDate"/> entity
        /// </summary>
        [DataMember]
        public DateTime? orderDate{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Orders.OrderedFrom"/> entity
        /// </summary>
        [DataMember]
        public string orderedFrom{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Orders.OrderNumber"/> entity
        /// </summary>
        [DataMember]
        public string customerOrderNumber { get; set; }
        /// <summary>
        ///     Model property for <see cref="Orders.OrderNumber"/> entity
        /// </summary>
        [DataMember]
        public string orderNumber{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Orders.RentOrderNumber"/> entity
        /// </summary>
        
        [DataMember]
        public string rentOrderNumber{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Orders.RentFromDate"/> entity
        /// </summary>
        [DataMember]
        public DateTime? rentFromDate{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Orders.RentToDate"/> entity
        /// </summary>
        [DataMember]
        public DateTime? rentToDate{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Orders.AutoBill"/> entity
        /// </summary>
        [DataMember]
        public bool autoBill{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Orders.AutoBill"/> entity
        /// </summary>
        [DataMember]
        public bool autoProlongation { get; set; }
        /// <summary>
        ///     Model property for <see cref="Orders.Discount"/> entity
        /// </summary>
        [DataMember]
        public double? discount{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Orders.BillTillDate"/> entity
        /// </summary>
        [DataMember]
        public DateTime? billTillDate{ get; set; }


        /// <summary>
        ///     Model property for <see cref="Customers.Number"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int customerNumber { get; set; }
        /// <summary>
        ///     Model property for <see cref="Customers.Name"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string newCustomerName { get; set; }
        /// <summary>
        ///     Model property for <see cref="Customers.Street"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string customerStreet { get; set; }
        /// <summary>
        ///     Model property for <see cref="Customers.Zip"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string customerZip { get; set; }
        /// <summary>
        ///     Model property for <see cref="Customers.City"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string customerCity { get; set; }
        /// <summary>
        ///     Model property for <see cref="Customers.Phone"/> entity
        /// </summary>
        [DataMember]
        public string customerPhone { get; set; }
        /// <summary>
        ///     Model property for <see cref="Customers.Fax"/> entity
        /// </summary>
        [DataMember]
        public string customerFax { get; set; }
        /// <summary>
        ///     Model property for <see cref="Customers.Email"/> entity
        /// </summary>
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
