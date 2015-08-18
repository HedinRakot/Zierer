using CoreBase.Models;
using CoreBase.Validation;
using ProfiCraftsman.Contracts.Entities;
using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace ProfiCraftsman.API.Models.Settings
{
    /// <summary>
    ///     Model for <see cref="Products"/> entity
    /// </summary>
    [DataContract]
    public partial class ProductsModel: BaseModel
    {

        /// <summary>
        ///     Model property for <see cref="Products.Number"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string number{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Products.ProductTypeId"/> entity
        /// </summary>
        [DataMember]
        public int? productTypeId{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Products.Length"/> entity
        /// </summary>
        [DataMember]
        public int? length{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Products.Width"/> entity
        /// </summary>
        [DataMember]
        public int? width{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Products.Height"/> entity
        /// </summary>
        [DataMember]
        public int? height{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Products.Color"/> entity
        /// </summary>
        [DataMember]
        public string color{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Products.Price"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public double price{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Products.ProceedsAccount"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int proceedsAccount{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Products.BoughtFrom"/> entity
        /// </summary>
        [DataMember]
        public string boughtFrom{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Products.BoughtPrice"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public double boughtPrice{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Products.Comment"/> entity
        /// </summary>
        [DataMember]
        public string comment{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Products.Name"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public string name{ get; set; }
        /// <summary>
        ///     Model property for <see cref="Products.ProductAmountType"/> entity
        /// </summary>
        [Required]
        [DataMember]
        public int productAmountType{ get; set; }

    }
}
