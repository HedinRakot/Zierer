using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models
{
    /// <summary>
    ///     Model for Report Material
    /// </summary>
    [DataContract]
    public partial class ReportMaterialModel : BaseModel
    {
        [DataMember]
        public string materialNumber { get; set; }

        [DataMember]
        public string materialName { get; set; }
        
        [DataMember]
        public double amount { get; set; }

        [DataMember]
        public string price { get; set; }

        [DataMember]
        public string date { get; set; }   
    }
}
