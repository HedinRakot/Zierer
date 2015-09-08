using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models.Settings
{
    public partial class InstrumentsModel
    {
        [DataMember]
        public string employeeName { get; set; }
	}
}