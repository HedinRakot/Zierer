using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models.Settings
{
    public partial class EmployeesModel
    {
        [DataMember]
        public string jobPosition { get; set; }
	}
}