using CoreBase.Models;
using CoreBase.Validation;
using System;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Models
{
    /// <summary>
    ///     Model for <see cref="OrderFilesModel"/> entity
    /// </summary>
    [DataContract]
    public partial class OrderFilesModel : BaseModel
    {
        [Required]
        [DataMember]
        public int orderId{ get; set; }

        [Required]
        [DataMember]
        public string fileName { get; set; }

        [DataMember]
        public string filePath { get; set; }

        [DataMember]
        public string comment { get; set; }
    }
}
