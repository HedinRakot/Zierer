using System.Runtime.Serialization;
using ProfiCraftsman.API.Models.Settings;
using System;

namespace ProfiCraftsman.API.Models.Orders
{
    public class ProductSmartModel : ProductsModel
    {
        [DataMember]
        public DateTime fromDate { get; set; }

        [DataMember]
        public DateTime toDate { get; set; }
       
    }
}
