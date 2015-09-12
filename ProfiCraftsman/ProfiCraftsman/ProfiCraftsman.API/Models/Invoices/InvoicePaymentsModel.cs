using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models.Invoices
{
    /// <summary>
    ///     Model for <see cref="InvoicePayments"/> entity
    /// </summary>
    [DataContract]
    public partial class InvoicePaymentsModel : BaseModel
    {
        [Required]
        [DataMember]
        public int invoiceId { get; set; }

        [Required]
        [DataMember]
        public double amount { get; set; }
    }
}
