using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models
{
    /// <summary>
    ///     Model for Trips
    /// </summary>
    [DataContract]
    public partial class TripsModel : BaseModel
    {
        [DataMember]
        public string employees { get; set; }

        [DataMember]
        public int autoId{ get; set; }

        [DataMember]
        public DateTime date { get; set; }

        [DataMember]
        public TimeSpan duration { get; set; }

        [DataMember]
        public TimeSpan returnWayDuration { get; set; }
    }
}
