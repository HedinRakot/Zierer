using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models.Settings
{
    public partial class MasterDataMonitorableInfoMasterDataNotificationsRspModel
	{
        [DataMember]
        public string monitorableInfoObject { get; set; }
        
        [DataMember]
        public string monitorableInfoTypeText { get; set; }
	}
}