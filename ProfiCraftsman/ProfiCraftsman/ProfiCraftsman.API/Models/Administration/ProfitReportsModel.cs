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
        public string salary { get; set; }

        [DataMember]
        public string totalOrdersSum { get; set; }
    }
}
