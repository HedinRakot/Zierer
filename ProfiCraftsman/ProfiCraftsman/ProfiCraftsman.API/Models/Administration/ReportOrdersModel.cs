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
    public partial class ReportOrdersModel: BaseModel
    {
        [DataMember]
        public string customerName { get; set; }
        
        [DataMember]
        public string communicationPartnerTitle { get; set; }
        
        [DataMember]
        public string street{ get; set; }
        
        [DataMember]
        public string zip{ get; set; }
        
        [DataMember]
        public string city{ get; set; }        
        
        [DataMember]
        public string orderNumber{ get; set; }      
        
        [DataMember]
        public bool isOffer { get; set; }

        [DataMember]
        public int status { get; set; }
    }
}
