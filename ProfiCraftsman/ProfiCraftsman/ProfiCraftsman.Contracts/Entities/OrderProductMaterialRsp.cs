using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class OrderProductMaterialRsp: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.OrderProduct_Material_Rsp";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="OrderProductMaterialRsp.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'OrderId' for property <see cref="OrderProductMaterialRsp.OrderId"/>
            /// </summary>
            public static readonly string OrderId = "OrderId";
            /// <summary>
            /// Column name 'ProductId' for property <see cref="OrderProductMaterialRsp.ProductId"/>
            /// </summary>
            public static readonly string ProductId = "ProductId";
            /// <summary>
            /// Column name 'MaterialId' for property <see cref="OrderProductMaterialRsp.MaterialId"/>
            /// </summary>
            public static readonly string MaterialId = "MaterialId";
            /// <summary>
            /// Column name 'Amount' for property <see cref="OrderProductMaterialRsp.Amount"/>
            /// </summary>
            public static readonly string Amount = "Amount";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="OrderProductMaterialRsp.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="OrderProductMaterialRsp.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="OrderProductMaterialRsp.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
          
        }
        #endregion
        public int Id{ get; set; }
        public int OrderId{ get; set; }
        public int ProductId{ get; set; }
        public int MaterialId{ get; set; }
        public int Amount{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public virtual Materials Materials{ get; set; }
        public virtual Orders Orders{ get; set; }
        public virtual Products Products{ get; set; }
        public bool HasMaterials
        {
            get { return !ReferenceEquals(Materials, null); }
        }
        public bool HasOrders
        {
            get { return !ReferenceEquals(Orders, null); }
        }
        public bool HasProducts
        {
            get { return !ReferenceEquals(Products, null); }
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
        public OrderProductMaterialRsp ShallowCopy()
        {
            return new OrderProductMaterialRsp {
                       OrderId = OrderId,
                       ProductId = ProductId,
                       MaterialId = MaterialId,
                       Amount = Amount,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
        	           };
        }
    }
}
