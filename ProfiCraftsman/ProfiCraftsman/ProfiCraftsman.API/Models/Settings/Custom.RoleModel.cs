using System.Collections.Generic;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
	public partial class RoleModel
	{
        [DataMember]
        public IEnumerable<int> permissions { get; set; }
	}
}