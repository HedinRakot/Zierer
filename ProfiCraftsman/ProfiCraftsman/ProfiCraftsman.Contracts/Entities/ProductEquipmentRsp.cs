using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class ProductEquipmentRsp: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.Product_Equipment_Rsp";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="ProductEquipmentRsp.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'ProductId' for property <see cref="ProductEquipmentRsp.ProductId"/>
            /// </summary>
            public static readonly string ProductId = "ProductId";
            /// <summary>
            /// Column name 'EquipmentId' for property <see cref="ProductEquipmentRsp.EquipmentId"/>
            /// </summary>
            public static readonly string EquipmentId = "EquipmentId";
            /// <summary>
            /// Column name 'Amount' for property <see cref="ProductEquipmentRsp.Amount"/>
            /// </summary>
            public static readonly string Amount = "Amount";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="ProductEquipmentRsp.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="ProductEquipmentRsp.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="ProductEquipmentRsp.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
          
        }
        #endregion
        public int Id{ get; set; }
        public int ProductId{ get; set; }
        public int EquipmentId{ get; set; }
        public int Amount{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public virtual Products Products{ get; set; }
        public virtual Equipments Equipments{ get; set; }
        public bool HasProducts
        {
            get { return !ReferenceEquals(Products, null); }
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
        public ProductEquipmentRsp ShallowCopy()
        {
            return new ProductEquipmentRsp {
                       ProductId = ProductId,
                       EquipmentId = EquipmentId,
                       Amount = Amount,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
        	           };
        }
    }
}
