using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models.Settings
{
    public partial class ProductMaterialRspModel
    {
        [DataMember]
        public string materialName { get; set; }
	}
}