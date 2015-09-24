using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models
{
    /// <summary>
    ///     Model for Profit Reports
    /// </summary>
    [DataContract]
    public class ProfitReportsModel
    {
        [DataMember]
        public string materialsSum { get; set; }

        [DataMember]
        public string additionalCostsSum { get; set; }

        [DataMember]
        public string foreignProductsSum { get; set; }

        [DataMember]
        public string ownProductsSum { get; set; }

        [DataMember]
        public string salarySum { get; set; }

        [DataMember]
        public string socialTaxesSum { get; set; }
        
        [DataMember]
        public string instrumentsSum { get; set; }

        [DataMember]
        public string totalOrdersSum { get; set; }
        
        [DataMember]
        public string totalInvoicesSum { get; set; }
        
        [DataMember]
        public string totalPayedSum { get; set; }

        [DataMember]
        public string totalProfitSum { get; set; }
    }
}
