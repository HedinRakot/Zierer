using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class ProductTypeEquipmentRsp: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.ProductType_Equipment_Rsp";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="ProductTypeEquipmentRsp.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'ProductTypeId' for property <see cref="ProductTypeEquipmentRsp.ProductTypeId"/>
            /// </summary>
            public static readonly string ProductTypeId = "ProductTypeId";
            /// <summary>
            /// Column name 'EquipmentId' for property <see cref="ProductTypeEquipmentRsp.EquipmentId"/>
            /// </summary>
            public static readonly string EquipmentId = "EquipmentId";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="ProductTypeEquipmentRsp.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="ProductTypeEquipmentRsp.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="ProductTypeEquipmentRsp.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'Amount' for property <see cref="ProductTypeEquipmentRsp.Amount"/>
            /// </summary>
            public static readonly string Amount = "Amount";
          
        }
        #endregion
        public int Id{ get; set; }
        public int ProductTypeId{ get; set; }
        public int EquipmentId{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public int Amount{ get; set; }
        public virtual ProductTypes ProductTypes{ get; set; }
        public virtual Equipments Equipments{ get; set; }
        public bool HasProductTypes
        {
            get { return !ReferenceEquals(ProductTypes, null); }
        }
        public bool HasEquipments
        {
            get { return !ReferenceEquals(Equipments, null); }
        }
        DateTime ISystemFields.CreateDate
        {
            get { return CreateDate; }
            set { CreateDate = value; }
        }
        DateTime ISystemFields.ChangeDate
        {
            get { return ChangeDate; }
            set { ChangeDate = value; }
        }
                
        
        /// <summary>
        /// Shallow copy of object. Exclude navigation properties and PK properties
        /// </summary>
        public ProductTypeEquipmentRsp ShallowCopy()
        {
            return new ProductTypeEquipmentRsp {
                       ProductTypeId = ProductTypeId,
                       EquipmentId = EquipmentId,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       Amount = Amount,
        	           };
        }
    }
}
